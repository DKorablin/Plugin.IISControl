using System;
using System.Collections;
using System.Windows.Forms;

namespace Plugin.IISControl.UI
{
	internal class ListViewSorter : IComparer
	{
		public Int32 SortColumn { get; set; }

		public SortOrder Order { get; set; }

		public ListViewSorter()
		{
			this.SortColumn = 0;
			this.Order = SortOrder.None;
		}

		public Int32 Compare(Object x, Object y)
		{
			ListViewItem listviewX = (ListViewItem)x;
			ListViewItem listviewY = (ListViewItem)y;

			// Compare the two items
			Int32 compareResult;

			String strX=listviewX.SubItems[this.SortColumn].Text;
			String strY=listviewY.SubItems[this.SortColumn].Text;
			if(Int64.TryParse(strX, out Int64 iX) && Int64.TryParse(strY, out Int64 iY))
			{
				if(iX == iY)
					compareResult = 0;
				else if(iX < iY)
					compareResult = -1;
				else
					compareResult = 1;
			} else
				compareResult = String.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);

			// Calculate correct return value based on object comparison
			if(this.Order == SortOrder.Ascending)// Ascending sort is selected, return normal result of compare operation
				return compareResult;
			else if(this.Order == SortOrder.Descending)// Descending sort is selected, return negative result of compare operation
				return (-compareResult);
			else// Return '0' to indicate they are equal
				return 0;
		}
	}
}