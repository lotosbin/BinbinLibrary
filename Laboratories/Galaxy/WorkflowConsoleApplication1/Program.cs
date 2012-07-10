using System;
using System.Linq;
using System.Activities;
using System.Activities.Statements;

namespace WorkflowConsoleApplication1
{

    class Program
    {
        static void Main(string[] args)
        {
            //WorkflowInvoker.Invoke(new Workflow1());
            var workflowApplication = new WorkflowApplication(new Workflow1());
            workflowApplication.Completed = new Action<WorkflowApplicationCompletedEventArgs>(workflowCompleted);
            workflowApplication.OnUnhandledException = unhandledException;

            //启动实例
            workflowApplication.Run();
        }

        static void workflowCompleted(WorkflowApplicationCompletedEventArgs e)
        {
            System.Console.WriteLine("状态:{0}", e.CompletionState.ToString());
            System.Console.WriteLine("实例编号:{0}", e.InstanceId);
        }
        static UnhandledExceptionAction unhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            System.Console.WriteLine("unhandledException:{0}", e.UnhandledException.Message);
            return UnhandledExceptionAction.Abort;
        }
    }

}
