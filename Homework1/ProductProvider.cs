using Npgsql;
using System.Data;

namespace Homework1
{
    public class ProductProvider
    {
        private const string CONNECTION_STRING = "Host=localhost:5432;" +
            "Username=postgres;" +
            "Password=25481;" +
            "Database=ProductDatabase";
        private NpgsqlConnection connection;

        private const string TABLE_NAME = "product";

        public ProductProvider()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        public void AddList(List<Product> list)
        {
            string sqlcommand = $"INSERT INTO {TABLE_NAME} (image, vendor_code, name, price) VALUES (@image, @vendor_code, @name, @price)";
            foreach (Product product in list)
            {
                using (NpgsqlCommand command = new NpgsqlCommand(sqlcommand, connection))
                {

                    command.Parameters.AddWithValue("image", product.Image);
                    command.Parameters.AddWithValue("name", product.Name);
                    command.Parameters.AddWithValue("vendor_code", product.VendorCode);
                    command.Parameters.AddWithValue("price", product.Price);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Product> GetProducts()
        {
            string commandText = $"SELECT * FROM {TABLE_NAME}";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(dataReader);
            return ConvertDataTableToList(dt);
        }

        public List<Product> GetProductsWithText(string text)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE lower(name) LIKE '%{text}%'";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(dataReader);
            return ConvertDataTableToList(dt);
        }

        private List<Product> ConvertDataTableToList(DataTable dt)
        {
            return dt.Rows.OfType<DataRow>()
               .Select(m => new Product()
               {
                   VendorCode = m.Field<int>("vendor_code"),
                   Name = m.Field<string>("name"),
                   Price = m.Field<int>("price"),
                   Image = m.Field<byte[]>("image")
               }).ToList();
        }

        public List<Product> GetProductsAsc(string text)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE lower(name) LIKE '%{text}%' ORDER BY name";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(dataReader);
            return ConvertDataTableToList(dt);
        }

        public List<Product> GetProductsDesc(string text)
        {
            string commandText = $"SELECT * FROM {TABLE_NAME} WHERE lower(name) LIKE '%{text}%' ORDER BY name DESC";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            var dataReader = cmd.ExecuteReader();
            DataTable dt = new();
            dt.Load(dataReader);
            return ConvertDataTableToList(dt);
        }

        public void Clear()
        {
            string commandText = $"DELETE FROM {TABLE_NAME}";
            NpgsqlCommand cmd = new NpgsqlCommand(commandText, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
