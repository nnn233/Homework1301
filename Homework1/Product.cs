namespace Homework1
{
    public class Product
    {
        public Product() { }
        public Product(string name, int vendorCode, byte[] image, int price)
        {
            Name = name;
            VendorCode = vendorCode;
            Image = image;
            Price = price;
        }

        public string Name { get; set; }
        public int VendorCode { get; set; }
        public byte[] Image { get; set; }
        public int Price { get; set; }
    }
}
