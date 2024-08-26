using MySqlConnector;

public class TutorialModel{
    public String TutorialId;
    public String TutorialName;
    public String Video;
    public DateTime CreatedAt;
    public DateTime UpdatedAt;
    public TutorialModel(String TutorialId, String TutorialName,String Video) {
        this.TutorialId=TutorialId;
        this.TutorialName=TutorialName;
        this.Video=Video;
    }
    public static TutorialModel FromDatabase(MySqlDataReader reader)
    {
        return new TutorialModel(reader.GetString("tutorialid"),reader.GetString("tutorialname"),reader.GetString("video"));
    }
}