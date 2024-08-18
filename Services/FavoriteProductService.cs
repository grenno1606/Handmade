using MySqlConnector;
using System.Collections.Generic;

public class FavoriteProductsService
{
    public List<FavoriteProductModel> GetAll()
    {
        List<FavoriteProductModel> favoriteProducts = new List<FavoriteProductModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM favoriteproducts");
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            favoriteProducts.Add(FavoriteProductModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return favoriteProducts;
    }

    public FavoriteProductModel? GetById(int id)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM favoriteproducts WHERE favoriteid = @id");
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return FavoriteProductModel.FromDatabase(reader);
        }
        database.CloseConnection();
        return null;
    }

    public FavoriteProductModel? GetByUsername(String username)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM favoriteproducts WHERE username = @username");
        command.Parameters.AddWithValue("@username", username);
        var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return FavoriteProductModel.FromDatabase(reader);
        }
        database.CloseConnection();
        return null;
    }

    public void Add(FavoriteProductModel favoriteProduct)
    {
        Database database = new Database();
        var command = database.CreateCommand("INSERT INTO favoriteproducts(username, productid) VALUES (@username, @productId)");
        command.Parameters.AddWithValue("@username", favoriteProduct.Username);
        command.Parameters.AddWithValue("@productId", favoriteProduct.ProductId);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Delete(int id)
    {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM favoriteproducts WHERE favoriteid = @id");
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
}
