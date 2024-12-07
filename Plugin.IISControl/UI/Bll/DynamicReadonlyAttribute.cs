using System;
using System.ComponentModel;

namespace Plugin.IISControl.UI.Bll
{
	internal class DynamicReadonlyAttribute : DependsOnPropertyAttribute
	{
		public DynamicReadonlyAttribute(String property)
			: base(property) { }

		public DynamicReadonlyAttribute(String property, Int32 index)
			: base(property, index) { }

		protected override Attribute OnEvaluateCoplete(Object value)
		{
			Attribute output;
			try
			{
				// check if value is provided
				if(value == null)
					value = false; // asume default
				else if(value is String)
					value = String.IsNullOrEmpty(value.ToString());
				// create attribute
				output = new ReadOnlyAttribute((Boolean)value);
			} catch
			{
				output = new ReadOnlyAttribute(false);
			}
			return output;
		}
	}
}