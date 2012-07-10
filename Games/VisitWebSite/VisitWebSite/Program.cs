using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace VisitWebSite
{

    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(new WorkflowMain());
            Console.ReadLine();
        }
    }
}
