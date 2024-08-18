using MySqlConnector;
class Database{
    public MySqlConnection connection= new MySqlConnection("Server=localhost;Port=3306;User ID=root;Database=handmade");
    public void OpenConnection()
    {
        connection.Open();
    }

    public void CloseConnection()
    {
        connection.Close();
    }

    public MySqlCommand CreateCommand(string query){
        OpenConnection();
        var command=connection.CreateCommand();
        command.CommandText=query;
        return command;
    }
}
