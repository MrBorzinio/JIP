using System.Data.SqlClient;

namespace JIP
{
    class DataBaseConnection
    {
        //"Data Source=ServerName;" +
        //"Initial Catalog=DataBaseName;" +
        //"User id=UserName;" +
        //"Password=Secret;";

        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=JAN\SQLEXPRESS;Initial Catalog=BidsCalc;Integrated Security=True");
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=BB01-WS542983\STP;Initial Catalog=BidsCalc;User id=sa;Password=486");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
