using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using Plugin.IISControl.UI;
using Plugin.IISControl.UI.Bll;

namespace Plugin.IISControl
{
	public class PluginSettings : ICustomTypeDescriptor, INotifyPropertyChanged
	{
		#region Fields
		private String _serverName;
		private String _sourcePath;
		private String _destinationPath;
		private String _webSiteName;
		#endregion Fields

		internal PluginWindows Plugin { get; private set; }

		[Category("Security")]
		[DefaultValue("")]
		[RefreshProperties(RefreshProperties.All)]
		[DisplayName("IIS Server")]
		[Description("Remote server name")]
		public String ServerName
		{
			get => this._serverName;
			set => this.SetField(ref this._serverName, value, nameof(this.ServerName));
		}

		[Category("Folder Copy")]
		[DefaultValue("")]
		[DisplayName("Source Folder")]
		[Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
		public String SourcePath
		{
			get => this._sourcePath;
			set => this.SetField(ref this._sourcePath, value, nameof(this.SourcePath));
		}

		[Category("Folder Copy")]
		[DefaultValue("")]
		[DisplayName("Destination Folder")]
		[Editor(typeof(FolderNameEditor),typeof(UITypeEditor))]
		public String DestinationPath
		{
			get => this._destinationPath;
			set => this.SetField(ref this._destinationPath, value, nameof(this.DestinationPath));
		}

		[Category("Security")]
		[DefaultValue("")]
		[Editor(typeof(WebSiteEditor), typeof(UITypeEditor))]
		[DynamicReadonly("ServerName")]
		[DisplayName("Web Site")]
		[Description("Name of the web site in IIS Server")]
		public String WebSiteName
		{
			get => this._webSiteName;
			set => this.SetField(ref this._webSiteName, value, nameof(this.WebSiteName));
		}

		internal PluginSettings(PluginWindows plugin)
			=> this.Plugin = plugin;
		#region ICustomTypeDescriptor Members
		public TypeConverter GetConverter()
		{
			// TODO:  Add PropertyClassDescriptor.GetConverter implementation
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			// TODO:  Add PropertyClassDescriptor.GetEvents implementation
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents()
		{
			// TODO:  Add PropertyClassDescriptor.System.ComponentModel.ICustomTypeDescriptor.GetEvents implementation
			return TypeDescriptor.GetEvents(this, true);
		}

		public String GetComponentName()
		{
			// TODO:  Add PropertyClassDescriptor.GetComponentName implementation
			return TypeDescriptor.GetComponentName(this, true);
		}

		public Object GetPropertyOwner(PropertyDescriptor pd)
		{
			// TODO:  Add PropertyClassDescriptor.GetPropertyOwner implementation
			return this;
		}

		public AttributeCollection GetAttributes()
		{
			// TODO:  Add PropertyClassDescriptor.GetAttributes implementation
			return TypeDescriptor.GetAttributes(this, true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			// TODO:  Add PropertyClassDescriptor.GetProperties implementation
			return this.GetProperties();
		}

		public PropertyDescriptorCollection GetProperties()
		{
			// use new implemented class to get properties
			return DynamicTypeDescriptor.GetProperties(this);
		}

		public Object GetEditor(Type editorBaseType)
		{
			// TODO:  Add PropertyClassDescriptor.GetEditor implementation
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			// TODO:  Add PropertyClassDescriptor.GetDefaultProperty implementation
			return TypeDescriptor.GetDefaultProperty(this, true);
		}

		public EventDescriptor GetDefaultEvent()
		{
			// TODO:  Add PropertyClassDescriptor.GetDefaultEvent implementation
			return TypeDescriptor.GetDefaultEvent(this, true);
		}

		public String GetClassName()
		{
			// TODO:  Add PropertyClassDescriptor.GetClassName implementation
			return TypeDescriptor.GetClassName(this, true);
		}
		#endregion

		#region INotifyPropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		private Boolean SetField<T>(ref T field, T value, String propertyName)
		{
			if(EqualityComparer<T>.Default.Equals(field, value))
				return false;

			field = value;
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			return true;
		}
		#endregion INotifyPropertyChanged
	}
}