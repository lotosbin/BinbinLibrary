using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSourceManagementTool.WpfApplication2
{
    public class OpenSourceProject
    {
        public string Name { get; set; }
        public Uri Url { get; set; }
    }
    public class OpenSourceSite
    {
        public List<OpenSourceProject> Projects { get; set; }
        public OpenSourceSite(string name, Uri home, Uri url)
        {
            Name = name;
            Home = home;
            Url = url;
            this.Projects = new List<OpenSourceProject>();
        }

        public OpenSourceSite()
        {

        }
        public string Name { get; set; }
        public Uri Home { get; set; }
        public Uri Url { get; set; }
    }
    public class OpenSourceSiteRepository
    {
        public OpenSourceSiteRepository()
        {
            this.Sites = new List<OpenSourceSite>
                             {
                                 new OpenSourceSite("codeplex", new Uri("http://www.codeplex.com"),
                                                    new Uri("http://www.codeplex.com"))
                                     {
                                         Projects = new List<OpenSourceProject>(){new OpenSourceProject()
                                                                                      {
                                                                                          Name = "Galaxy Library",
                                                                                          Url = new Uri("http://lotosgalaxy.codeplex.com/"),
                                                                                      }}
                                     },
                                                    new OpenSourceSite("google code",new Uri("http://code.google.com"),new Uri("http://code.google.com") ),
                             };

        }
        public List<OpenSourceSite> Sites { get; private set; }
    }
}
