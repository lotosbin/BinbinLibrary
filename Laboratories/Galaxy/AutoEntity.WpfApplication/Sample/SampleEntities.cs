using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaxyAutoEntity.WpfApplication.Core;

namespace GalaxyAutoEntity.WpfApplication.Sample
{
    public static class SmapleMemoryDatabaseServer
    {
        
    }
    public class SampleEntities
    {
        public AutoEntity User { get; set; }
        public AutoEntity AutoEntityEditProfile { get; set; }
        public SampleEntities()
        {
            this.User = new AutoEntity(new Guid("FE238880-E5F8-4B67-8E5B-695EA4002AF8"));
            this.User.AddProperty(new AutoEntityProperty("Password"));
            this.User.AddProperty(new AutoEntityProperty("Name"));

            this.AutoEntityEditProfile = new AutoEntity("AF74CB2E-06E2-41C2-93B0-128DEA324288");
            this.AutoEntityEditProfile.AddProperty(new AutoEntityProperty("TypeGuid"));
            this.AutoEntityEditProfile.AddProperty(new AutoEntityProperty("DisplayName"));
            this.AutoEntityEditProfile.AddProperty(new AutoEntityProperty("Description"));
        }
    }
}
