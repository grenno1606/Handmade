public class ProductService {
    public List<ProductModel> GetAll() {
        List<ProductModel> products = new List<ProductModel>();
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM products");
        var reader = command.ExecuteReader();
        while (reader.Read()) {
            products.Add(ProductModel.FromDatabase(reader));
        }
        database.CloseConnection();
        return products;
    }

    public ProductModel? GetById(string id) {
        Database database = new Database();
        var command = database.CreateCommand("SELECT * FROM products WHERE productid = @id");
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();
        if (reader.Read()) {
            return ProductModel.FromDatabase(reader);
        }
        database.CloseConnection();
        return null;
    }

    public void Add(ProductModel product) {
        Database database = new Database();
        var command = database.CreateCommand("INSERT INTO products (productid, image, productname, original_price, discount_percentage, discounted_price) VALUES (@productId, @image, @productName, @originalPrice, @discountPercentage, @discountedPrice)");
        command.Parameters.AddWithValue("@productId", product.ProductId);
        command.Parameters.AddWithValue("@image", product.Image);
        command.Parameters.AddWithValue("@productName", product.ProductName);
        command.Parameters.AddWithValue("@originalPrice", product.OriginalPrice);
        command.Parameters.AddWithValue("@discountPercentage", product.DiscountPercentage);
        command.Parameters.AddWithValue("@discountedPrice", product.DiscountedPrice);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Update(ProductModel product) {
        Database database = new Database();
        var command = database.CreateCommand("UPDATE products SET image = @image, productname = @productName, original_price = @originalPrice, discount_percentage = @discountPercentage, discounted_price = @discountedPrice WHERE productid = @productId");
        command.Parameters.AddWithValue("@image", product.Image);
        command.Parameters.AddWithValue("@productName", product.ProductName);
        command.Parameters.AddWithValue("@originalPrice", product.OriginalPrice);
        command.Parameters.AddWithValue("@discountPercentage", product.DiscountPercentage);
        command.Parameters.AddWithValue("@discountedPrice", product.DiscountedPrice);
        command.Parameters.AddWithValue("@productId", product.ProductId);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }

    public void Delete(string id) {
        Database database = new Database();
        var command = database.CreateCommand("DELETE FROM products WHERE productid = @id");
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        database.CloseConnection();
    }
}
