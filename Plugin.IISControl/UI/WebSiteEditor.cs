using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Plugin.IISControl.Bll;

namespace Plugin.IISControl.UI
{
	internal class WebSiteEditor : UITypeEditor
	{
		private WebSiteEditorControl _control;

		public override Object EditValue(ITypeDescriptorContext context, IServiceProvider provider, Object value)
		{
			if(this._control == null)
				this._control = new WebSiteEditorControl(((PluginSettings)context.Instance).Plugin);
			this._control.SetStatus((String)value);
			((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService))).DropDownControl(this._control);
			return this._control.Result;//base.EditValue(context, provider, value);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
			=> UITypeEditorEditStyle.DropDown; //base.GetEditStyle(context);

		#region StatusEditorControl
		private class WebSiteEditorControl : UserControl
		{
			#region Fields
			private String _webSiteName;
			private ListBox lbWebSite = new ListBox();
			#endregion Fields
			#region Properties
			public String Result
			{
				get
				{
					if(this.lbWebSite.Enabled && this.lbWebSite.SelectedItem != null)
						return this.lbWebSite.SelectedItem.ToString();
					else
						return _webSiteName;
				}
			}
			protected PluginWindows Plugin { get; private set; }
			#endregion Properties
			#region Constructors
			public WebSiteEditorControl(PluginWindows plugin)
			{
				this.Plugin = plugin;
				base.SuspendLayout();
				base.Size = new Size(160, 80);
				base.BackColor = SystemColors.Control;
				this.lbWebSite.FormattingEnabled = true;
				this.lbWebSite.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
				this.lbWebSite.Size = new Size(base.Size.Width, base.Size.Height);
				this.lbWebSite.BorderStyle = BorderStyle.None;
				base.Controls.AddRange(new Control[] { this.lbWebSite, });
				base.ResumeLayout();

				foreach(IisSiteControl item in this.Plugin.GetIisControl())
					this.lbWebSite.Items.Add(item.Name);
			}
			#endregion Constructors
			#region Methods
			public void SetStatus(String webSiteName)
			{
				this._webSiteName = webSiteName;
				if(this.lbWebSite.Enabled)
					this.lbWebSite.SelectedItem = webSiteName;
			}
			#endregion Methods
		}
		#endregion StatusEditorControl
	}
}