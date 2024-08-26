using MySqlConnector;

public class UserModel{
    public String UserId;
    public String UserName;
    public String Password;
    public String Email;
    public String? Role;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public UserModel(String UserId, String UserName,String Password,String Email) {
        this.UserId = UserId;
        this.UserName = UserName;
        this.Password = Password;
        this.Email = Email;
    }
    public static UserModel FromDatabase(MySqlDataReader reader){
        return new UserModel(reader.GetString("userid"),reader.GetString("username"),reader.GetString("password"),reader.GetString("email"));
    }
}