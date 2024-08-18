class UserService{
    public List<UserModel> GetAll(){
        List<UserModel> List=new List<UserModel>();
        Database database= new Database();
        var command= database.CreateCommand("SELECT * FROM users");
        var reader=command.ExecuteReader();
        while(reader.Read())
        {
            List.Add(UserModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return List;
    }
}