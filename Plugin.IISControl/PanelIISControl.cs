using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Plugin.IISControl.Bll;
using Plugin.IISControl.Properties;
using SAL.Windows;
using System.Diagnostics;
using System.Threading;

namespace Plugin.IISControl
{
	internal partial class PanelIISControl : UserControl
	{
		private const String Caption = "IIS Control";
		#region Properties
		private PluginWindows Plugin { get { return (PluginWindows)this.Window.Plugin; } }
		private IWindow Window { get { return (IWindow)base.Parent; } }
		private IisControl Utils { get { return this.Plugin.GetIisControl(); } }

		#endregion Properties
		public PanelIISControl()
		{
			lvColumnSorter = new UI.ListViewSorter();
			InitializeComponent();
			lvSites.ListViewItemSorter = lvColumnSorter;
			splitMain.Panel2Collapsed = true;
		}

		protected override void OnCreateControl()
		{
			this.Plugin.Settings.PropertyChanged += SettingsInternal_PropertyChanged;

			this.Window.Caption = PanelIISControl.Caption;
			this.Window.SetTabPicture(Resources.iis);
			this.Window.Shown += new EventHandler(Window_Shown);
			this.Window.Closed += new EventHandler(Window_Closed);

			base.OnCreateControl();
		}

		private void Window_Shown(Object sender, EventArgs e)
		{
			this.UpdateServerList();
		}

		private void Window_Closed(Object sender, EventArgs e)
		{
			this.Plugin.Settings.PropertyChanged -= SettingsInternal_PropertyChanged;
		}

		private void SettingsInternal_PropertyChanged(Object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			this.UpdateServerList();
		}

		private void tsbnRefresh_Click(Object sender, EventArgs e)
		{
			this.UpdateServerList();
		}

		private void lvSites_KeyDown(Object sender, KeyEventArgs e)
		{
			switch(e.KeyData)
			{
			case Keys.F5:
				e.Handled = true;
				this.UpdateServerList();
				break;
			}
		}

		private void lvSites_SelectedIndexChanged(Object sender, EventArgs e)
		{
			Int32 count = lvSites.SelectedItems.Count;
			if(count == 0)
				pgSettings.SelectedObject = null;
			else
				this.UpdateSiteInfo();
		}

		private void bwSiteList_DoWork(Object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			List<IisSiteControl> entryItems = new List<IisSiteControl>();

			foreach(IisSiteControl entry in this.Utils)
			{
				bwSiteList.ReportProgress(10, entry);
				entryItems.Add(entry);
			}

			e.Result = entryItems.ToArray();
		}

		private void bwSiteList_ProgressChanged(Object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			if(e.ProgressPercentage == 10)
			{
				IisSiteControl entry = (IisSiteControl)e.UserState;
				ListViewItem listItem = this.FindSiteNode(entry.Id);
				if(listItem == null)
				{
					listItem = new ListViewItem();
					String[] subItems = Array.ConvertAll<String, String>(new String[lvSites.Columns.Count], delegate(String a) { return String.Empty; });
					listItem.SubItems.AddRange(subItems);
					listItem.Tag = entry;
					lvSites.Items.Add(listItem);
				}

				this.UpdateListItemData(listItem);
			}
		}

		private void bwSiteList_RunWorkerCompleted(Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			if(e.Error != null)
				this.Plugin.Trace.TraceData(TraceEventType.Error, 10, e.Error);
			else
			{
				lvSites.SuspendLayout();
				Int32 itemsCount = lvSites.Items.Count;

				IisSiteControl[] entries = (IisSiteControl[])e.Result;
				for(Int32 loop = lvSites.Items.Count - 1; loop >= 0; loop--)
				{
					ListViewItem item = lvSites.Items[loop];
					IisSiteControl entry = (IisSiteControl)item.Tag;
					if(!Array.Exists(entries, delegate(IisSiteControl t) { return t.Id == entry.Id; }))
						item.Remove();
				}

				if(itemsCount == 0)
					this.lvSites_ColumnClick(sender, new ColumnClickEventArgs(colPath.Index));
				lvSites.ResumeLayout();
			}

			base.Cursor = Cursors.Default;
			lvSites.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			this.Window.Caption = String.Join(" - ", new String[] { this.Plugin.Settings.ServerName, PanelIISControl.Caption, });
		}

		private void bwSiteInfo_DoWork(Object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			Int32 count = lvSites.SelectedItems.Count;
			if(count == 0)
				return;//Т.к. при снятии выделения с массива элементов, сначала приходит событие снятия одного элемента, а потом всех остальных элементов

			IisSiteControl[] ctrl = new IisSiteControl[count];

			for(Int32 loop = 0; loop < count; loop++)
				ctrl[loop] = (IisSiteControl)lvSites.SelectedItems[loop].Tag;

			IisSiteCtrlUI ui = new IisSiteCtrlUI(ctrl);
			if(pgSettings.InvokeRequired)
				pgSettings.Invoke((MethodInvoker)delegate { pgSettings.SelectedObject = ui; });
			else
				pgSettings.SelectedObject = ui;
		}

		private void bwSiteInfo_RunWorkerCompleted(Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			base.Cursor = Cursors.Default;

			if(e.Error != null)
				this.Plugin.Trace.TraceData(TraceEventType.Error, 10, e.Error);
		}

		private void pgSettings_PropertyValueChanged(Object sender, PropertyValueChangedEventArgs e)
		{
			for(Int32 loop = 0; loop < lvSites.SelectedItems.Count; loop++)
				this.UpdateListItemData(lvSites.SelectedItems[loop]);
		}

		/// <summary>Обновить данные элемента в списке</summary>
		/// <param name="item">Элемент списка для обновления</param>
		private void UpdateListItemData(ListViewItem item)
		{
			item.SubItems[colPath.Index].Text = "<Loading>";
			ThreadPool.QueueUserWorkItem(UpdateWebSitePath, item);

			IisSiteControl ctrl = (IisSiteControl)item.Tag;
			item.SubItems[colId.Index].Text = ctrl.Id.ToString();
			item.SubItems[colName.Index].Text = ctrl.Name;
			//item.SubItems[colPath.Index].Text = ctrl.Path;
		}

		private void UpdateWebSitePath(Object state)
		{
			ListViewItem item = (ListViewItem)state;
			IisSiteControl ctrl=(IisSiteControl)item.Tag;
			item.SubItems[colPath.Index].Text = ctrl.Path;
		}

		private ListViewItem FindSiteNode(Int32 webSiteId)
		{
			foreach(ListViewItem item in lvSites.Items)
			{
				IisSiteControl ctrl = (IisSiteControl)item.Tag;
				if(ctrl.Id == webSiteId)
					return item;
			}
			return null;
		}

		/// <summary>Обновить список сайтов в IIS сервера</summary>
		private void UpdateServerList()
		{
			if(String.IsNullOrEmpty(this.Plugin.Settings.ServerName))
			{
				this.Window.Caption = PanelIISControl.Caption;
				lvSites.Items.Clear();
				return;
			}

			this.Window.Caption = String.Format("{0} - Loading...", PanelIISControl.Caption, this.Plugin.Settings.ServerName);

			if(!bwSiteList.IsBusy)
			{
				base.Cursor = Cursors.WaitCursor;
				splitMain.Panel2Collapsed = true;
				pgSettings.SelectedObject = null;
				bwSiteList.RunWorkerAsync();
			}
		}

		/// <summary>Обновить информацию по специфичному сайту</summary>
		private void UpdateSiteInfo()
		{
			if(!bwSiteInfo.IsBusy)
			{
				base.Cursor = Cursors.WaitCursor;
				splitMain.Panel2Collapsed = false;

				bwSiteInfo.RunWorkerAsync();
			}
		}

		private void lvSites_ColumnClick(Object sender, ColumnClickEventArgs e)
		{
			if(e.Column == lvColumnSorter.SortColumn)
			{
				if(lvColumnSorter.Order == SortOrder.Ascending)
					lvColumnSorter.Order = SortOrder.Descending;
				else
					lvColumnSorter.Order = SortOrder.Ascending;
			} else
			{
				lvColumnSorter.SortColumn = e.Column;
				lvColumnSorter.Order = SortOrder.Ascending;
			}

			lvSites.Sort();
		}
	}
}