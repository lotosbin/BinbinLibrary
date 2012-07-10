using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WorkflowConsoleApplication1
{
    public class MyTextWriter : TextWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
        public override void WriteLine(string value)
        {
            System.Console.WriteLine("MyTextWriter:" + value);

        }
    }
}
