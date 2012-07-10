using System;
using System.Collections.Generic;

namespace Galaxy.GoogleReader.WpfApplication.Engine
{
    public class ClientEngineEventArgs:EventArgs
    {
        public List<Feed> UpdateItems { get; set; }
    }
}