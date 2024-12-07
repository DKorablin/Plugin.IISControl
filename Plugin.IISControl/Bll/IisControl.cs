using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;

namespace Plugin.IISControl.Bll
{
	internal class IisControl : IEnumerable<IisSiteControl>
	{
		public String ServerName { get; }

		public IisSiteControl this[Int32 webSiteId] { get => new IisSiteControl(this, webSiteId); }

		public IisControl(String serverName)
		{
			if(String.IsNullOrEmpty(serverName))
				throw new ArgumentNullException(nameof(serverName));

			this.ServerName = serverName;
		}

		/// <summary>Получить класс управления сайтом по наименованию</summary>
		/// <param name="webSiteName">Наименование сайта</param>
		/// <exception cref="ArgumentNullException">webSiteName != null</exception>
		/// <returns>Интерфейс управления сайтом</returns>
		public IisSiteControl GetSiteByName(String webSiteName)
		{
			if(String.IsNullOrEmpty(webSiteName))
				throw new ArgumentNullException(nameof(webSiteName));

			foreach(IisSiteControl item in this)
				if(item.Name == webSiteName)
					return item;
			return null;
		}

		/// <summary>Get www properties</summary>
		/// <param name="webSiteId">Website identifier</param>
		/// <returns>Key/Value site properties</returns>
		public Dictionary<String,Object> GetWebSiteProperties(Int32 webSiteId)
		{
			using(DirectoryEntry entry = this.GetSiteEntry(webSiteId))
				return IisControl.GetEntryProperties(entry);
		}

		/// <summary>Создание сайта на сервере</summary>
		/// <param name="webSiteName">String containing the ServerCommentServerComment for the new Web site. In IIS Manager, this would be the Description field under Web Site Identification in a Web Site property sheet.</param>
		/// <param name="serverBindings">Each server binding includes at least one of the host name, port, or IP address.</param>
		/// <param name="PathOfRootVirtualDir">String containing a fully qualified path to a physical directory to which you want the Web site mapped.</param>
		/// <returns>Идентификатор сайта</returns>
		public Int32 CreateWebSite(String webSiteName, String serverBindings, String PathOfRootVirtualDir)
		{
			if(String.IsNullOrEmpty(webSiteName))
				throw new ArgumentNullException(nameof(webSiteName));

			using(DirectoryEntry entry = this.GetServerEntry())
			{
				Object[] newSite = new Object[] { webSiteName, new Object[] { serverBindings }, PathOfRootVirtualDir };

				Object webSiteId = entry.Invoke("CreateNewSite", newSite);
				return (Int32)webSiteId;
			}
		}

		#region IisSiteItem Code
		/*/// <summary>Добавить заголовок хоста</summary>
		/// <param name="webSiteId">Идентификатор сайта</param>
		/// <param name="host">Домен</param>
		/// <param name="port">Порт</param>
		public void AddHostHeader(Int32 webSiteId,String ip,Int32 port, String host)
		{
			this.AddHostHeader(webSiteId, String.Format("{0}:{1}:{2}", ip, port, host));
		}*/

		/*/// <summary>Добавить заголовок хоста</summary>
		/// <param name="webSiteId">Идентификатор сайта</param>
		/// <param name="hostHeader">Заголовок</param>
		/// <example>127.0.0.1:80:test.com</example>
		public void AddHostHeader(Int32 webSiteId, String hostHeader)
		{
			if(String.IsNullOrEmpty(hostHeader))
				throw new ArgumentNullException("hostHeader");

			using(DirectoryEntry entry = this.GetDirectoryEntry(webSiteId))
			{
				PropertyValueCollection properties = entry.Properties["ServerBindings"];

				properties.Add(hostHeader);

				Object[] newArray = new Object[properties.Count];
				properties.CopyTo(newArray, 0);

				entry.Properties["ServerBindings"].Value = newArray;

				entry.CommitChanges();
			}
		}*/

		/*/// <summary>Удалить заголовок хоста</summary>
		/// <param name="webSiteId">Идентификатор сайта</param>
		/// <param name="hostHeader">Заголовок для кдаления</param>
		public void RemoveHostHeader(Int32 webSiteId, String hostHeader)
		{
			if(String.IsNullOrEmpty(hostHeader))
				throw new ArgumentNullException("hostHeader");

			using(DirectoryEntry entry = this.GetDirectoryEntry(webSiteId))
			{
				PropertyValueCollection properties = entry.Properties["ServerBindings"];

				properties.Remove(hostHeader);

				Object[] newArray = new Object[properties.Count];
				properties.CopyTo(newArray, 0);

				entry.Properties["ServerBindings"].Value = newArray;

				entry.CommitChanges();
			}
		}*/

		/*/// <summary>Получить список заголовков хоста</summary>
		/// <param name="webSiteId">Идентификатор сайта для которого получить список заголовков</param>
		/// <returns>Массив добавленных заголовков</returns>
		public String[] GetHostHeaders(Int32 webSiteId)
		{
			using(DirectoryEntry entry = this.GetDirectoryEntry(webSiteId))
			{
				PropertyValueCollection properties = entry.Properties["ServerBindings"];
				String[] result = new String[properties.Count];
				for(Int32 loop = 0; loop < properties.Count; loop++)
					result[loop] = properties[loop].ToString();
				return result;
			}
		}*/

		/*/// <summary>Создание виртуальной папки на сайте</summary>
		/// <param name="webSiteId">Идентификатор сайта</param>
		/// <param name="virtualDirectoryName">Наименование виртуальной папки</param>
		/// <param name="physicalPath">Физический путь к папке</param>
		public void CreateVirtualDirectory(Int32 webSiteId, String virtualDirectoryName, String physicalPath)
		{
			using(DirectoryEntry entry = this.GetDirectoryEntry(webSiteId))
			{
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
		}*/

		/*/// <summary>Установить локальный путь на папку</summary>
		/// <param name="webSiteId">Идентификаор сайта</param>
		/// <param name="homeDirectory">Локальная папка для установке на сайт</param>
		public void SetHomeDirectory(Int32 webSiteId, String homeDirectory)
		{
			using(DirectoryEntry entry = this.GetRootDirectoryEntry(webSiteId))
			{
				entry.Properties["Path"].Value = homeDirectory;
				entry.CommitChanges();
			}
		}*/

		/*/// <summary>Получить локальный путь к папке в которой находится сайт</summary>
		/// <param name="webSiteId">Идентификатор сайта</param>
		/// <returns>Локальная папка на сервере</returns>
		public String GetHomeDirectory(Int32 webSiteId)
		{
			using(DirectoryEntry entry = this.GetRootDirectoryEntry(webSiteId))
				return entry.Properties["Path"].Value.ToString();
		}*/
		#endregion IisSiteItem Code

		public IEnumerator<IisSiteControl> GetEnumerator()
		{
			using(DirectoryEntry entry = this.GetServerEntry())
			{
				foreach(DirectoryEntry webSite in entry.Children)
					if(webSite.SchemaClassName == "IIsWebServer")
						yield return new IisSiteControl(this, webSite);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
			=> this.GetEnumerator();

		private DirectoryEntry GetServerEntry()
			=> IisControl.GetServerEntry(this.ServerName);

		internal static Dictionary<String, Object> GetEntryProperties(DirectoryEntry entry)
		{
			Dictionary<String, Object> result = new Dictionary<String, Object>();
			foreach(String name in entry.Properties.PropertyNames)
				result.Add(name, entry.Properties[name].Value);

			return result;
		}

		private static DirectoryEntry GetServerEntry(String serverName)
		{
			DirectoryEntry result = new DirectoryEntry(String.Format(Constant.Adsi.ServerArgs1, serverName));
			result.RefreshCache();
			return result;
		}

		private DirectoryEntry GetSiteEntry(Int32 webSiteId)
			=> IisControl.GetSiteEntry(this.ServerName, webSiteId);

		private static DirectoryEntry GetSiteEntry(String serverName, Int32 webSiteId)
			=> new DirectoryEntry(String.Format(Constant.Adsi.SiteArgs2, serverName, webSiteId));
	}
}