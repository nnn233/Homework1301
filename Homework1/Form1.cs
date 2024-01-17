using Microsoft.VisualBasic.ApplicationServices;

namespace Homework1
{
    public partial class Form1 : Form
    {
        readonly ProductProvider productProvider;

        readonly byte[] lamp = File.ReadAllBytes("C:\\Users\\nasty\\Downloads\\desklamp.png");
        readonly byte[] bottle = File.ReadAllBytes("C:\\Users\\nasty\\Downloads\\bottle.png");
        readonly byte[] book = File.ReadAllBytes("C:\\Users\\nasty\\Downloads\\book.png");
        readonly byte[] glass = File.ReadAllBytes("C:\\Users\\nasty\\Downloads\\glass.png");
        readonly byte[] laptop = File.ReadAllBytes("C:\\Users\\nasty\\Downloads\\laptop.png");

        public Form1()
        {
            List<Product> products = new()
            {
                new Product("Настольная лампа", 5442454, lamp, 800),
                new Product("Бутылка", 4154545, bottle, 55),
                new Product("Книга", 87421555, book, 550),
                new Product("Стакан", 7412585, glass, 200),
                new Product("Ноутбук", 9632145, laptop, 35000)
            };

            InitializeComponent();
            productProvider = new ProductProvider();
            productProvider.Clear();
            productProvider.AddList(products);
            LoadProducts(productProvider.GetProducts());
            textBox1.TextChanged += ConstraintsChanged;
            textBox1.Enter += textBox1_Enter;
            textBox1.Leave += textBox1_Leave;
            comboBox1.SelectedIndexChanged += ConstraintsChanged;
            comboBox2.SelectedIndexChanged += ConstraintsChanged;
        }


        private void ConstraintsChanged(object? sender, EventArgs e)
        {
            var filter = comboBox2.SelectedIndex;
            var sort = comboBox1.SelectedIndex;
            var text = textBox1.Text == "Введите для поиска" ? "" : textBox1.Text;
            
            List<Product> list = new();

            if (sort == 1)
                list = productProvider.GetProductsAsc(text);
            else if (sort == 2) list = productProvider.GetProductsDesc(text);
            else list = productProvider.GetProductsWithText(text);

            Product? item = null;
            if (filter == 1)
                item = list.MinBy(x => x.Price);
            if (filter == 2) item = list.MaxBy(x => x.Price);
            if (item != null)
                list.RemoveAll(x => x.Price != item.Price);

            LoadProducts(list);
        }

        private void LoadProducts(List<Product> list)
        {
            dataGridView1.Rows.Clear();
            if (list.Count > 0)
            {
                dataGridView1.Visible = true;
                foreach (Product item in list)
                {
                    var image = ConvertByteArrayToBitmap(item.Image);
                    dataGridView1.Rows.Add(image, item.VendorCode, item.Name, item.Price);
                }

            }
            else dataGridView1.Visible = false;
        }

        private void textBox1_Enter(object? sender, EventArgs e)
        {
            if (textBox1.Text == "Введите для поиска")
                textBox1.Clear();
        }

        private void textBox1_Leave(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                textBox1.Text = "Введите для поиска";
        }

        private static Bitmap ConvertByteArrayToBitmap(byte[] bytes)
        {
            Bitmap bmp;
            using (var ms = new MemoryStream(bytes))
            {
                bmp = new Bitmap(ms);
            }
            return bmp;
        }
    }
}