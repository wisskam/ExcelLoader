using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ExcelLoader
{

    class Connection
    {
        public string Server;
        public string Name;
        public string Username;
        public string Password;
        public string Type;
        private static string[] _availableTypes = { "sql-server" };
        //private static string[] _availableTypes = { "sql-server", "oracle" };
        public static string[] AvailableTypes => _availableTypes;
        private bool IsFinal = false;

        public Connection(string server)
        {
            this.Server = server;
        }

        [JsonConstructor]
        public Connection(string server, string name, string username, string password, string type)
        {
            this.Server = server;
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.Type = type;
            this.IsFinal = true;
        }

        public void SetFinal()
        {
            this.IsFinal = true;
        }

        public string getConnectionString()
        {
            switch (this.Type)
            {
                case "sql-server":
                    return $"Server={this.Server};Database={this.Name};User Id={this.Username};Password={this.Password};Integrated Security=false;";
             
                case "oracle":
                    return "";
                
                default:
                    return "";
            }

        }

        public void TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(this.getConnectionString()))
            {

                connection.Open();
                connection.Close();

            }
        }

        public void RunQuery(string query)
        {

            using (SqlConnection connection = new SqlConnection(this.getConnectionString()))
            {

                SqlCommand command = new SqlCommand(query, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

            }

        }










    }
}
