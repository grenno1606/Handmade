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

    public List<ProductModel> GetByUsername(String username)
    {
        List<ProductModel> products = new List<ProductModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT p.* FROM products p JOIN favoriteproducts fp ON p.productid = fp.productid WHERE fp.username=@username;");
        // var command = database.CreateCommand("SELECT * FROM products");
        command.Parameters.AddWithValue("@username", username);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(ProductModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return products;
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
