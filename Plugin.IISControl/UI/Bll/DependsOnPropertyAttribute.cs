using System;
using System.Reflection;

namespace Plugin.IISControl.UI.Bll
{
	/// <summary>Base class for all dynamic attributes.</summary>
	[AttributeUsage(AttributeTargets.Property)]
	internal abstract class DependsOnPropertyAttribute : Attribute
	{
		private String _property;

		private Object[] _index;

		/// <summary>Create new instance of class</summary>
		/// <param name="expression">Property name</param>
		protected DependsOnPropertyAttribute(String property)
			: base()
		{
			this._property = property;
			this._index = null;
		}
		/// <summary>Create new instance of class</summary>
		/// <param name="property">Property name</param>
		/// <param name="index">Property element index</param>
		protected DependsOnPropertyAttribute(String property, Int32 index)
		{
			this._property = property;
			this._index = new Object[] { index };
		}

		/// <summary>Evaluate attribute using property container supplied</summary>
		/// <param name="container">Object that contains property to evaluate</param>
		/// <returns>Dynamically evaluated attribute</returns>
		public Attribute Evaluate(Object container)
			=> this.OnEvaluateCoplete(RuntimeEvaluator.Eval(container, _property, _index));

		/// <summary>Specific dynamic attribute check implementation</summary>
		/// <param name="value">Evaluated value</param>
		/// <returns>Dynamically evaluated attribute</returns>
		protected abstract Attribute OnEvaluateCoplete(Object value);

		private class RuntimeEvaluator
		{
			public static Object Eval(Object container, String property, Object[] index)
			{
				PropertyInfo pInfo = container.GetType().GetProperty(property);

				return pInfo?.GetValue(container, index);
			}
		}
	}
}