
using BankCredit.DAL;
using Furniture.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Furniture.DAL
{
   public class DataAccessProduct
    {
        public string connString;
        public List<Product> productList;


      

        public DataAccessProduct()
        {
           
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
            productList = new List<Product>();

        }



        public void Raport()
        {
            try
            {
                productList = RetrieveProduct();
                string path = @"D:\Facultate\Anul 3\SemII\PS\Assigment\Assigment2\Send2\Tomus_AlexandraFurniture\BankCredit-master\XML\Product.xml";
                var stoc = productList.Where(book => book.Stock == 0).ToList();

              //  var stoc = productList.ToList();
                // var stoc = productList.Where(book => book.ID == 2 || book.Stock==8).ToList();


                if (!File.Exists(path))
                {

                    {

                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine("<?xml version=" + "\"" + "1.0" + "\"" + " encoding=" + "\"" + "UTF-8" + "\"" + "?>");
                            sw.WriteLine("<Products>");

                            foreach (Product b in stoc)
                            {
                                sw.WriteLine(" <Product>");
                                sw.WriteLine("  <ID>" + b.ID + "</ID>");
                                sw.WriteLine("  <Title>" + b.Title + "</Title>");
                                sw.WriteLine("  <Stock>" + b.Stock + "</Stock>");
                                sw.WriteLine(" </Product>");

                            }
                            sw.WriteLine("</Products>");
                        }
                    }



                }
                else
                {
                    File.Delete(path);
                    Raport();
                }
            }
            catch (Exception e) {

                MessageBox.Show("Eoare generare raport!");

            }

            MessageBox.Show("Raport generat cu succes!");
        }




        public List<Product> RetrieveProduct()
        {
            List<Product> productList = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string statement = "SELECT * FROM Product";

                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ID = reader.GetInt32("Id");
                        product.Title = reader.GetString("Title");
                        product.Description = reader.GetString("Description");
                        product.Color = reader.GetString("Color");
                        product.Size = reader.GetInt32("Size");
                        product.Price = reader.GetInt32("Price");
                        product.Stock = reader.GetInt32("Stock");
                      
                        productList.Add(product);
                    }
                }
            }

            return productList;
        }


   



        public void AddProduct(Product product)

        {

                using (MySqlConnection conn = new MySqlConnection(connString))
                {

                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Product(id, title, description, color, size, price,stock) VALUES( @id,@title, @description, @color, @size, @price, @stock)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@id", product.ID);
                    cmd.Parameters.AddWithValue("@title", product.Title);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@color", product.Color);
                    cmd.Parameters.AddWithValue("@size", product.Size);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@stock", product.Stock);

                    cmd.ExecuteNonQuery();
                }
          
        }

        public void UpdateProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Product SET  stock=@stock WHERE id = @id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", product.ID);
                cmd.Parameters.AddWithValue("@title", product.Title);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@color", product.Color);
                cmd.Parameters.AddWithValue("@size", product.Size);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE FROM Product WHERE id = @id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", product.ID);
                cmd.Parameters.AddWithValue("@title", product.Title);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@color", product.Color);
                cmd.Parameters.AddWithValue("@size", product.Size);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);

                cmd.ExecuteNonQuery();
            }
        }

        public IList<Product> RetrieveProductOrder(int idProduct)
        {
            IList<Product> productList = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                 string statement = "SELECT * FROM Product WHERE Id='" + idProduct+ "';" ;
               // string statement = "SELECT * FROM Product ";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ID = reader.GetInt32("Id");
                        product.Title = reader.GetString("Title");
                        product.Description = reader.GetString("Description");
                        product.Color = reader.GetString("Color");
                        product.Size = reader.GetInt32("Size");
                        product.Price = reader.GetInt32("Price");
                        product.Stock = reader.GetInt32("Stock");

                        productList.Add(product);
                    }
                }
            }

            return productList;
        }

        public void UpdateProduct(int idProduct, int stock)
        {
            Product product = new Product();
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

               // string statement = "SELECT * FROM activity WHERE IdEmployee='" + idemployee + "'and deliverydate > '" + data1 + "' and deliverydate < '" + data2 + "';";
            


                cmd.CommandText = "UPDATE Product SET  stock='" + stock + "'WHERE id ='" + idProduct+"';";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@id", product.ID);
                cmd.Parameters.AddWithValue("@title", product.Title);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@color", product.Color);
                cmd.Parameters.AddWithValue("@size", product.Size);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@stock", product.Stock);

                cmd.ExecuteNonQuery();
            }
        }

        public bool AddProductTest(Product product)
        {

            try
            {
                AddProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool DeleteProductTest(Product product)
        {

            try
            {
                DeleteProduct(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

       


        
    }
}
