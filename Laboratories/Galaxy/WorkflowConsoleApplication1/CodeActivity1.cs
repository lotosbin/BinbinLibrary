using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WorkflowConsoleApplication1
{

    public sealed class CodeActivity1 : CodeActivity
    {
        // Define an activity input argument of type string
        public InArgument<string> Text { get; set; }

        // If your activity returns a value, derive from CodeActivity<TResult>
        // and return the value from the Execute method.
        protected override void Execute(CodeActivityContext context)
        {
            System.Console.Write("请输入内容:");
            string inputString = System.Console.ReadLine();

            string outputString = string.Format("你输入的是:{0}", inputString);
            System.Console.WriteLine(outputString);
        }
    }
}
