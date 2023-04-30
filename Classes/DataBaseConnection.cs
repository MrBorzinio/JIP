using System.Data;
using System.Data.SqlClient;

namespace JIP
{
    class DataBaseConnection
    {
        //"Data Source=ServerName;" +
        //"Initial Catalog=DataBaseName;" +
        //"User id=UserName;" +
        //"Password=Secret;";

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=JAN\SQLEXPRESS;Initial Catalog=BidsCalc;Integrated Security=True");
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=BB01-WS542983\STP;Initial Catalog=BidsCalc;User id=sa;Password=486");

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public static DataTable GetTable(string queryString)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataBaseConnection dataBase = new DataBaseConnection();
            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            //if (table.Rows.Count == 1) ;
            return table;

            //dataBase.OpenConnection();
            //string queryString = $"SELECT nf_BidStuses FROM t_CalcStatues";
            ////SqlDataAdapter da = new SqlDataAdapter(queryString, dataBase.GetConnection());
            //SqlDataAdapter adapter;
            //adapter = new SqlDataAdapter(queryString, dataBase.GetConnection());
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //cbx_Statuses.DataSource = dt; // setting the datasource property of combobox
        }

        ////private static DataTable DataTableFill(string commandTextOrProcedureName, CommandType cmdType, params SqlParameter[] parameters)
        //public static DataTable GetTable(string queryString, CommandType cmdType, params SqlParameter[] parameters)
        //{
        //    //int rowCount = 0;
        //    //SqlConnection  connection = null;
        //    //SqlCommand command = null;
        //    //DataTable dataTable = null;
        //    //SqlDataAdapter dataAdapter = null;
        //    try
        //    {
        //        //connection = new SqlConnection(conString);
        //        //command = new SqlCommand(commandTextOrProcedureName, connection); //
        //        command = new SqlCommand(queryString, GetConnection());
        //        command.CommandType = cmdType;//SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());
        //        if (parameters != null)
        //        {
        //            command.Parameters.AddRange(parameters);
        //        }
        //        connection.Open();
        //        dataTable = new DataTable();
        //        dataAdapter = new SqlDataAdapter();
        //        dataAdapter.SelectCommand = command;
        //        rowCount = dataAdapter.Fill(dataTable);
        //        IsExecuted = true;
        //    }
        //    catch (Exception e)
        //    {
        //        ShowError(e.ToString());
        //    }
        //    finally
        //    {
        //        if (connection != null)
        //        {
        //            connection.Close(); connection.Dispose();
        //        }
        //        if (command != null)
        //        {
        //            command.Dispose();
        //        }
        //        if (dataAdapter != null)
        //        {
        //            dataAdapter.Dispose();
        //        }
        //    }
        //    return dataTable;
        //}

    }
}
