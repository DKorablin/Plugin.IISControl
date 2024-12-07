using System;
using System.ComponentModel;

namespace Plugin.IISControl.UI.Bll
{
	internal class DynamicBrowsableAttribute : DependsOnPropertyAttribute
	{
		public DynamicBrowsableAttribute(String property)
			: base(property) { }

		public DynamicBrowsableAttribute(String property, Int32 index)
			: base(property, index) { }

		protected override Attribute OnEvaluateCoplete(Object value)
		{
			Attribute output;
			try
			{
				// check if value is provided
				if(value == null)
					value = true; // asume default
				// create attribute
				output = new BrowsableAttribute((Boolean)value);
			} catch
			{
				output = new ReadOnlyAttribute(true);
			}
			return output;
		}
	}
}
