using System;
using System.ComponentModel;
using System.Reflection;

namespace Plugin.IISControl.UI.Bll
{
	internal class PropertyInfoDescriptor : PropertyDescriptor
	{
		private PropertyInfo propInfo;

		public PropertyInfoDescriptor(PropertyInfo prop, Attribute[] attribs)
			: base(prop.Name, attribs)
			=> propInfo = prop;

		private Object DefaultValue
		{
			get => propInfo.IsDefined(typeof(DefaultValueAttribute), false)
					? ((DefaultValueAttribute)propInfo.GetCustomAttributes(typeof(DefaultValueAttribute), false)[0]).Value
					: null;
		}

		public override Boolean IsReadOnly
		{
			get => this.Attributes.Contains(new System.ComponentModel.ReadOnlyAttribute(true));
		}

		public override Object GetValue(Object component)
			=> propInfo.GetValue(component, null);

		public override Boolean CanResetValue(Object component)
			=> (!this.IsReadOnly & (this.DefaultValue != null && !this.DefaultValue.Equals(this.GetValue(component))));

		public override void ResetValue(Object component)
			=> this.SetValue(component, this.DefaultValue);

		public override void SetValue(Object component, Object value)
			=> propInfo.SetValue(component, value, null);

		public override Boolean ShouldSerializeValue(Object component)
			=> (!this.IsReadOnly & (this.DefaultValue != null && !this.DefaultValue.Equals(this.GetValue(component))));

		public override Type ComponentType { get => propInfo.DeclaringType; }

		public override Type PropertyType { get => propInfo.PropertyType; }
	}
}
