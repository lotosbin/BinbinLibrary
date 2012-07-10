using System;
using System.Collections.Generic;

namespace GalaxyAutoEntity.WpfApplication.Core
{
    public class AutoEntity
    {
        public AutoEntity(Guid typeGuid)
        {
            TypeGuid = typeGuid;
            this.Properties = new Dictionary<string, AutoEntityProperty>();
        }

        public AutoEntity(string typeGuidText)
            : this(new Guid(typeGuidText))
        {

        }
        public Guid TypeGuid { get; set; }
        public Dictionary<string, AutoEntityProperty> Properties { get; private set; }
        public void AddProperty(AutoEntityProperty property)
        {
            if (property == null) throw new ArgumentNullException("property");
            this.Properties.Add(property.PropertyName,property);
        }
    }
}
