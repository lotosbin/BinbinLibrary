using System;

namespace GalaxyAutoEntity.WpfApplication.Core
{
    public class AutoEntityProperty
    {
        public AutoEntityProperty(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName { get; set; }

        public object Value { get; set; }
        public string ValueAsString
        {
            get
            {
                return Convert.ToString(this.Value);
            }
        }
    }
}