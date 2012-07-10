using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WorkflowConsoleApplication1
{

    public sealed class InsertDataToSQLServerActivity : NativeActivity
    {
        public InArgument<string> UserID { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            insertUserTable(UserID.Get(context));
        }

        void insertUserTable(string UserID)
        {
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Binbin@Codeplex\Galaxy\WorkflowConsoleApplication1\Databases\Database1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
            con.Open();
            System.Data.SqlClient.SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = string.Format("insert into UserTable (UserID) values ('{0}')", UserID);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
