using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace WorkflowSample.DataAccess
{
    [DataContract()]
    public class TableB
    {
        [DataMember()]
        public string RowID
        { set; get; }

        [DataMember()]
        public string ID
        { set; get; }

        [DataMember()]
        public string Value
        { set; get; }
    }
}
