using System;
using System.Collections.Generic;
using System.Text;

namespace Lotos.SVOPattern
{
	public class SubjectProperty
	{
		private SubjectObject so;
		private string PropertyName;
		private object PropertyValue;
		public SubjectProperty(SubjectObject o, string name)
		{
			so = o;
			PropertyName = name;
		}
		public SVO IsEqualsTo(object value)
		{
			this.PropertyValue = value;
			return new SVO(so,this);
		}
		public override string ToString()
		{
			return PropertyName+"="+PropertyValue;
		}
	}
}
