using MySqlConnector;
using System.Collections.Generic;

public class TutorialService
{
    public List<TutorialModel> GetAll()
    {
        List<TutorialModel> tutorials = new List<TutorialModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM tutorials");
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            tutorials.Add(TutorialModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return tutorials;
    }

    public TutorialModel? GetById(string id)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM tutorials WHERE tutorialid = @id");
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return TutorialModel.FromDatabase(reader);
        }
        database.CloseConnection();
        return null;
    }

    public void Add(TutorialModel tutorial)
    {
        Database database = new Database();
        var command = database.CreateCommand("INSERT INTO tutorials(tutorialid, tutorialname, video) VALUES (@tutorialId, @tutorialName, @video)");
        command.Parameters.AddWithValue("@tutorialId", tutorial.TutorialId);
        command.Parameters.AddWithValue("@tutorialName", tutorial.TutorialName);
        command.Parameters.AddWithValue("@video", tutorial.Video);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Update(TutorialModel tutorial)
    {
        Database database = new Database();
        var command = database.CreateCommand("UPDATE tutorials SET tutorialname = @tutorialName, video = @video WHERE tutorialid = @tutorialId");
        command.Parameters.AddWithValue("@tutorialId", tutorial.TutorialId);
        command.Parameters.AddWithValue("@tutorialName", tutorial.TutorialName);
        command.Parameters.AddWithValue("@video", tutorial.Video);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Delete(string id)
    {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM tutorials WHERE tutorialid = @id");
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
}
