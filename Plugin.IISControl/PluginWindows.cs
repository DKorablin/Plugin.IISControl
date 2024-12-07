using System;
using SAL.Flatbed;
using SAL.Windows;
using System.Collections.Generic;
using Plugin.IISControl.Bll;
using System.Diagnostics;

namespace Plugin.IISControl
{
	public class PluginWindows : IPlugin, IPluginSettings<PluginSettings>
	{
		private TraceSource _trace;
		private PluginSettings _settings;
		private Dictionary<String, DockState> _documentTypes;

		internal TraceSource Trace
		{
			get { return this._trace ?? (this._trace = PluginWindows.CreateTraceSource<PluginWindows>()); }
		}

		internal IHostWindows HostWindows { get; }

		/// <summary>Настройки для взаимодействия из хоста</summary>
		Object IPluginSettings.Settings { get { return this.Settings; } }

		/// <summary>Настройки для взаимодействия из плагина</summary>
		public PluginSettings Settings
		{
			get
			{
				if(this._settings == null)
				{
					this._settings = new PluginSettings(this);
					this.HostWindows.Plugins.Settings(this).LoadAssemblyParameters(this._settings);
				}
				return this._settings;
			}
		}

		private IMenuItem IIsMenu { get; set; }
		private IMenuItem IisSiteCtrlMenu { get; set; }
		private IMenuItem IisCtrlMenu { get; set; }
		private Dictionary<String, DockState> DocumentTypes
		{
			get
			{
				if(this._documentTypes == null)
					this._documentTypes = new Dictionary<String, DockState>()
					{
						{ typeof(PanelIISSiteCtrl).ToString(), DockState.DockTopAutoHide },
						{ typeof(PanelIISControl).ToString(), DockState.DockTopAutoHide },
					};
				return this._documentTypes;
			}
		}

		public PluginWindows(IHostWindows hostWindows)
		{
			this.HostWindows = hostWindows ?? throw new ArgumentNullException(nameof(hostWindows));
		}

		public IWindow GetPluginControl(String typeName, Object args)
			=> this.CreateWindow(typeName, false, args);

		Boolean IPlugin.OnConnection(ConnectMode mode)
		{
			IMenuItem menuTools = this.HostWindows.MainMenu.FindMenuItem("Tools");
			if(menuTools == null)
			{
				this.Trace.TraceEvent(TraceEventType.Error, 10, "Menu item 'Tools' not found");
				return false;
			}

			this.IIsMenu = menuTools.FindMenuItem("IIS");
			if(this.IIsMenu == null)
			{
				this.IIsMenu = menuTools.Create("IIS");
				this.IIsMenu.Name = "Tools.IIS";
			}

			this.IisSiteCtrlMenu = this.IIsMenu.Create("&Site Control");
			this.IisSiteCtrlMenu.Name = "Tools.IIS.SiteCtrl";
			this.IisSiteCtrlMenu.Click += (sender, e) => { this.CreateWindow(typeof(PanelIISSiteCtrl).ToString(), true); };

			this.IisCtrlMenu = this.IIsMenu.Create("&IIS Control");
			this.IisCtrlMenu.Name = "Tools.IIS.IISCtrl";
			this.IisCtrlMenu.Click += (sender, e) => { this.CreateWindow(typeof(PanelIISControl).ToString(), true); };

			this.IIsMenu.Items.Add(this.IisCtrlMenu);
			this.IIsMenu.Items.Add(this.IisSiteCtrlMenu);

			menuTools.Items.Add(this.IIsMenu);
			return true;
		}

		Boolean IPlugin.OnDisconnection(DisconnectMode mode)
		{
			if(this.IisSiteCtrlMenu != null)
				this.HostWindows.MainMenu.Items.Remove(this.IisSiteCtrlMenu);
			if(this.IisCtrlMenu != null)
				this.HostWindows.MainMenu.Items.Remove(this.IisCtrlMenu);
			if(this.IIsMenu != null)
				this.HostWindows.MainMenu.Items.Remove(this.IIsMenu);
			return true;
		}

		internal IisControl GetIisControl()
		{
			return this.Settings.ServerName == null
				? null
				: new IisControl(this.Settings.ServerName);
		}

		private IWindow CreateWindow(String typeName, Boolean searchForOpened, Object args = null)
		{
			DockState state;
			return this.DocumentTypes.TryGetValue(typeName, out state)
				? this.HostWindows.Windows.CreateWindow(this, typeName, searchForOpened, state, args)
				: null;
		}

		private static TraceSource CreateTraceSource<T>(String name = null) where T : IPlugin
		{
			TraceSource result = new TraceSource(typeof(T).Assembly.GetName().Name + name);
			result.Switch.Level = SourceLevels.All;
			result.Listeners.Remove("Default");
			result.Listeners.AddRange(System.Diagnostics.Trace.Listeners);
			return result;
		}
	}
}