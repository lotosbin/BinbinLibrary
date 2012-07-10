namespace WorkflowSample.DataAccess
{
    public static class dbManage
    {
        static string connectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Binbin@Codeplex\Galaxy\WorkflowConsoleApplication1\Databases\Database1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

        //表[TabA]中是否存在[ID]的记?
        public static bool checkIDinTabA(string ID)
        {
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                con.Open();
                var command = con.CreateCommand();
                command.CommandText = string.Format("select ID from TableA where ID='{0}'", ID);
                object obj = command.ExecuteScalar();
                con.Close();
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


        }
        //表[TabB]中是否存在指定[RowID]的记录

        public static bool checkRowIDinTabB(string RowID)
        {
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                con.Open();
                var command = con.CreateCommand();
                command.CommandText = string.Format("select RowID from TableB where RowID='{0}'", RowID);
                object obj = command.ExecuteScalar();
                con.Close();
                if (obj == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        //向表[TabB]中添加记录
        public static void insertTabB(TableB row)
        {

            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                con.Open();
                var command = con.CreateCommand();
                command.CommandText = string.Format("insert into TableB (RowID,ID,Value) values ('{0}','{1}','{2}')", row.RowID, row.ID, row.Value);
                command.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}