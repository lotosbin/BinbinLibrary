using System;
using System.Collections.Generic;
using System.Text;

namespace Lotos.SVOPattern
{
	public class SubjectObject
	{
		public SubjectProperty GetProperty(string propertyName)
		{
			return new SubjectProperty(this,propertyName);
		}
		public override string ToString()
		{
			return this.GetType().Name;
		}
	}
}
