using System;
using System.ComponentModel;

namespace Plugin.IISControl.Bll
{
	internal class IisSiteCtrlUI
	{
		private const String Multiple = "Multiple values";
		private readonly IisSiteControl[] _ctrls;

		[DefaultValue(IisSiteCtrlUI.Multiple)]
		[Category("Data")]
		[Description("Наименование сайта")]
		public String Name
		{
			get
			{
				String name = this._ctrls[0].Name;
				if(this._ctrls.Length > 1)
					foreach(IisSiteControl ctrl in this._ctrls)
						if(ctrl.Name != name)
							return Multiple;
				return name;
			}
		}

		[DefaultValue(IisSiteCtrlUI.Multiple)]
		[Category("Data")]
		[Description("Локальный путь к проекту")]
		public String Path
		{
			get
			{
				String path = this._ctrls[0].Path;
				if(this._ctrls.Length > 1)
					foreach(IisSiteControl ctrl in this._ctrls)
						if(ctrl.Path != path)
							return Multiple;
				return path;
			}
			set
			{
				foreach(IisSiteControl ctrl in this._ctrls)
					ctrl.Path = value;
			}
		}

		public IisSiteCtrlUI(IisSiteControl[] ctrls)
		{
			if(ctrls == null || ctrls.Length == 0)
				throw new ArgumentException("Слишком мало элементов в массиве!!!111");

			this._ctrls = ctrls;
		}
	}
}