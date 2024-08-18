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

    public FavoriteTutorialModel? GetById(int id)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM favoritetutorials WHERE favoriteid = @id");
        command.Parameters.AddWithValue("@id", id);
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
        Database database = new Database();
        var command = database.CreateCommand("INSERT INTO favoritetutorials(username, tutorialid) VALUES (@username, @tutorialId)");
        command.Parameters.AddWithValue("@username", favoriteTutorial.Username);
        command.Parameters.AddWithValue("@tutorialId", favoriteTutorial.TutorialId);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Delete(int id)
    {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM favoritetutorials WHERE favoriteid = @id");
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
}
