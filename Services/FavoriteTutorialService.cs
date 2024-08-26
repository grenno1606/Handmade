using MySqlConnector;
using System.Collections.Generic;

public class FavoriteTutorialsService
{
    public List<FavoriteTutorialModel> GetAll()
    {
        List<FavoriteTutorialModel> favoriteTutorials = new List<FavoriteTutorialModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM favoritetutorials");
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            favoriteTutorials.Add(FavoriteTutorialModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return favoriteTutorials;
    }
     public List<TutorialModel> GetByUsername(String username)
    {
        List<TutorialModel> tutorials = new List<TutorialModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT t.* FROM tutorials t JOIN favoritetutorials ft ON t.tutorialid = ft.tutorialid  WHERE ft.username=@username;");
        command.Parameters.AddWithValue("@username", username);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            tutorials.Add(TutorialModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return tutorials;
    }

    public FavoriteTutorialModel? GetById(String id,string username)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM favoritetutorials WHERE tutorialid = @id AND username=@username");
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@username",username);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return FavoriteTutorialModel.FromDatabase(reader);
        }
        database.CloseConnection();
        return null;
    }

    public void Add(FavoriteTutorialModel favoriteTutorial)
    {
        FavoriteTutorialModel? t = GetById(favoriteTutorial.TutorialId,favoriteTutorial.Username);
        if (t != null) {}
        else{
        Database database = new Database();
        var command = database.CreateCommand("INSERT INTO favoritetutorials(username, tutorialid) VALUES (@username, @tutorialId)");
        command.Parameters.AddWithValue("@username", favoriteTutorial.Username);
        command.Parameters.AddWithValue("@tutorialId", favoriteTutorial.TutorialId);
        command.ExecuteNonQuery();
        database.CloseConnection();
        }
    }

    public void Delete(String id,String username)
    {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM favoritetutorials WHERE tutorialid = @id AND username = @username");
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("username", username);
        command.ExecuteNonQuery();  
        database.CloseConnection();
    }
}
