using System;
using System.Collections.Generic;
using Galaxy.GoogleReader.WpfApplication.Models;

namespace Galaxy.GoogleReader.WpfApplication.Engine
{
    public class GoogleReaderEngineEventArgs:EventArgs
    {
        public List<ListAllJsonItem> UpdateItems { get; set; }
    }
}