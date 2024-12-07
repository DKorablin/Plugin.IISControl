using System;
using System.DirectoryServices;
using System.Collections.Generic;

namespace Plugin.IISControl.Bll
{
	internal class IisSiteControl
	{
		private readonly IisControl _iis;

		private String _name;
		private String _path;

		/// <summary>Получить идентификатор сайта</summary>
		public Int32 Id { get; }

		/// <summary>Получить наименование сайта</summary>
		public String Name
		{
			get
			{
				if(this._name == null)
					using(DirectoryEntry entry = this.GetSiteEntry())
						this._name = entry.Properties["ServerComment"].Value.ToString();
				return this._name;
			}
		}

		/// <summary>Локальный путь к папке сайта</summary>
		public String Path
		{
			get
			{
				if(this._path == null)
					using(DirectoryEntry root = this.GetSiteRootEntry())
						this._path = root.Properties["Path"].Value.ToString();

				return this._path;
			}
			set
			{
				if(String.IsNullOrEmpty(value))
					throw new ArgumentNullException(nameof(value));

				using(DirectoryEntry root = this.GetSiteRootEntry())
				{
					root.Properties["Path"].Value = value;
					//root.InvokeSet("Path", value);
					root.CommitChanges();
				}

				this._path = value;
			}
		}

		public Dictionary<String, Object> Properties
		{
			get
			{
				using(DirectoryEntry entry = this.GetSiteEntry())
					return IisControl.GetEntryProperties(entry);
			}
		}

		public IisSiteControl(IisControl iis, DirectoryEntry entry)
			: this(iis)
		{
			_ = entry ?? throw new ArgumentNullException(nameof(entry));

			this.Id = Convert.ToInt32(entry.Name);

			this._name = entry.Properties["ServerComment"].Value.ToString();
		}

		public IisSiteControl(IisControl iis, Int32 webSiteId)
			: this(iis)
			=> this.Id = webSiteId;

		private IisSiteControl(IisControl iis)
			=> this._iis = iis ?? throw new ArgumentNullException(nameof(iis));

		/*public IEnumerator<IisSiteControl> GetEnumerator()
		{
			using(DirectoryEntry entry = this.GetSiteEntry())
			{
				foreach(DirectoryEntry webSite in entry.Children)
					if(webSite.SchemaClassName == "IIsWebVirtualDir")
						foreach(DirectoryEntry virtualDir in webSite.Children)
							if(virtualDir.SchemaClassName == "IIsWebDirectory" && virtualDir.Properties["Path"].Value != null)
								throw new NotImplementedException();
								//yield return new IisSiteControl(this.Iis, virtualDir);
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}*/

		/// <summary>Получить список заголовков хоста</summary>
		/// <returns>Массив добавленных заголовков</returns>
		public String[] GetHostHeaders()
		{
			using(DirectoryEntry entry = this.GetSiteEntry())
			{
				PropertyValueCollection properties = entry.Properties["ServerBindings"];
				String[] result = new String[properties.Count];
				for(Int32 loop = 0; loop < properties.Count; loop++)
					result[loop] = properties[loop].ToString();
				return result;
			}
		}

		/// <summary>Добавить заголовок хоста</summary>
		/// <param name="host">Домен</param>
		/// <param name="port">Порт</param>
		public void AddHostHeader(String ip, Int32 port, String host)
		{
			if(String.IsNullOrEmpty(ip))
				throw new ArgumentNullException(nameof(ip));

			this.AddHostHeader($"{ip}:{port}:{host}");
		}

		/// <summary>Добавить заголовок хоста</summary>
		/// <param name="hostHeader">Заголовок</param>
		/// <example>127.0.0.1:80:test.com</example>
		public void AddHostHeader(String hostHeader)
		{
			if(String.IsNullOrEmpty(hostHeader))
				throw new ArgumentNullException(nameof(hostHeader));

			using(DirectoryEntry entry = this.GetSiteEntry())
			{
				PropertyValueCollection properties = entry.Properties["ServerBindings"];

				properties.Add(hostHeader);

				Object[] newArray = new Object[properties.Count];
				properties.CopyTo(newArray, 0);

				entry.Properties["ServerBindings"].Value = newArray;

				entry.CommitChanges();
			}
		}

		/// <summary>Удалить заголовок хоста</summary>
		/// <param name="hostHeader">Заголовок для кдаления</param>
		public void RemoveHostHeader(String hostHeader)
		{
			if(String.IsNullOrEmpty(hostHeader))
				throw new ArgumentNullException(nameof(hostHeader));

			using(DirectoryEntry entry = this.GetSiteEntry())
			{
				PropertyValueCollection properties = entry.Properties["ServerBindings"];

				properties.Remove(hostHeader);

				Object[] newArray = new Object[properties.Count];
				properties.CopyTo(newArray, 0);

				entry.Properties["ServerBindings"].Value = newArray;

				entry.CommitChanges();
			}
		}

		/// <summary>Создание виртуальной папки на сайте</summary>
		/// <param name="virtualDirectoryName">Наименование виртуальной папки</param>
		/// <param name="physicalPath">Физический путь к папке</param>
		public void CreateVirtualDirectory(String virtualDirectoryName, String physicalPath)
		{
			using(DirectoryEntry entry = this.GetSiteEntry())
			using(DirectoryEntry virtualDirectory = entry.Children.Add(virtualDirectoryName, entry.SchemaClassName))
			{
				virtualDirectory.CommitChanges();
				if(!String.IsNullOrEmpty(physicalPath))
				{
					virtualDirectory.Properties["Path"].Value = physicalPath;
					virtualDirectory.Properties["AccessRead"][0] = true;
				}
				virtualDirectory.Invoke("AppCreate", true);
				virtualDirectory.Properties["AppFriendlyName"][0] = virtualDirectoryName;
				virtualDirectory.CommitChanges();
			}
		}

		private DirectoryEntry GetSiteEntry()
			=> IisSiteControl.GetSiteEntry(this._iis.ServerName, this.Id);

		private static DirectoryEntry GetSiteEntry(String serverName, Int32 webSiteId)
			=> new DirectoryEntry(String.Format(Constant.Adsi.SiteArgs2, serverName, webSiteId));

		private DirectoryEntry GetSiteRootEntry()
			=> IisSiteControl.GetSiteRootEntry(this._iis.ServerName, this.Id);

		private static DirectoryEntry GetSiteRootEntry(String serverName, Int32 webSiteId)
			=> new DirectoryEntry(String.Format(Constant.Adsi.SiteRootArgs2, serverName, webSiteId));
	}
}