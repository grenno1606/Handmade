using MySqlConnector;

public class FavoriteTutorialModel{
    public int FavoriteId;
    public String Username;
    public String TutorialId;
    public DateTime CreatedAt;
    public FavoriteTutorialModel(String Username,String TutorialId) {
        this.Username = Username;
        this.TutorialId = TutorialId;
    }
     public static FavoriteTutorialModel FromDatabase(MySqlDataReader reader)
    {
        return new FavoriteTutorialModel(reader.GetString("username"),reader.GetString("tutorialid"));
    }
}