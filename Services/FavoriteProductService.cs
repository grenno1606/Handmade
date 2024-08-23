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

     public FavoriteProductModel? GetById(String id)
    {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM favoriteproducts WHERE productid = @id");
        command.Parameters.AddWithValue("@id", id);
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
        FavoriteProductModel? p = GetById(favoriteProduct.ProductId);
        if (p != null) {}
        else{
        Database database = new Database();
        var command = database.CreateCommand("INSERT INTO favoriteproducts(username, productid) VALUES (@username, @productId)");
        command.Parameters.AddWithValue("@username", favoriteProduct.Username);
        command.Parameters.AddWithValue("@productId", favoriteProduct.ProductId);
        command.ExecuteNonQuery();
        database.CloseConnection();
        }
    }

    public void Delete(String id,String username)
    {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM favoriteproducts WHERE productid = @id AND username = @username");
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@username",username);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
}
