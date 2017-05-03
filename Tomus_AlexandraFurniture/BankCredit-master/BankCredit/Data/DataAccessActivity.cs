using BankCredit.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace BankCredit.DAL
{
    public class DataAccessActivity
    {

        private const String Path = @"D:\Facultate\Anul 3\SemII\PS\Assigment\Assigment2\Send2\Tomus_AlexandraFurniture\BankCredit-master\XML\file.xml";
        private List<Activity> activityList;
       


        public string connString;

        public DataAccessActivity()
        {
            connString = "Server=127.0.1;Port=3306;Database=manager;Uid=root;Pwd=1234;";
            activityList = new List<Activity>(); 

        }


        public void Raport()
        {
            try
            {

                activityList = RetrieveActivity();

                string path = @"D:\Facultate\Anul 3\SemII\PS\Assigment\Assigment2\Send\Tomus_AlexandraFurniture\BankCredit-master\XML\Activity.xml";

                var stoc = activityList.ToList();
                //    var stoc = activityList.Where(book => book.ID == 1).ToList();


                if (!File.Exists(path))
                {
                    // Create a file to write to. 
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("<?xml version=" + "\"" + "1.0" + "\"" + " encoding=" + "\"" + "UTF-8" + "\"" + "?>");
                        sw.WriteLine("<Activities>");

                        foreach (Activity b in stoc)
                        {
                            sw.WriteLine(" <Activity>");
                            sw.WriteLine("  <ID>" + b.ID + "</ID>");
                            sw.WriteLine("  <AddOp>" + b.AddOp + "</AddOp>");
                            sw.WriteLine("  <UpdateOp>" + b.UpdateOp + "</UpdateOp>");
                            sw.WriteLine("  <ViewProduct>" + b.Viewproduct + "</ViewProduct>");
                            sw.WriteLine("  <Date>" + b.DeliveryDate + "</Date>");
                            sw.WriteLine(" </Activity>");

                        }
                        sw.WriteLine("</Activities>");
                    }
                }
                else
                {
                    File.Delete(path);
                    Raport();
                }
            }
            catch (Exception e) {

                MessageBox.Show("Eroare generare raport");

            }

            MessageBox.Show("Raport generat cu succes!");
        }



        


        public List<Activity> RetrieveActivity(int idemployee, string data1, string data2)
        {
            List<Activity> activityList = new List<Activity>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // string statement = "SELECT * FROM activity WHERE"+idemployee+"; ";
                //string statement = "SELECT * FROM activity WHERE'" + idemployee + "';";

                string statement = "SELECT * FROM activity WHERE IdEmployee='" + idemployee + "'and deliverydate > '"+data1+"' and deliverydate < '"+data2+"';";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity();
                        activity.ID = reader.GetInt32("ID");
                        activity.IdEmployee = reader.GetInt32("IdEmployee");
                        activity.AddOp = reader.GetInt32("AddOp");
                        activity.UpdateOp = reader.GetInt32("UpdateOp");
                        activity.Viewproduct = reader.GetInt32("Viewproduct");
                        activity.DeliveryDate = reader.GetDateTime("DeliveryDate").ToString();
                        activityList.Add(activity);
                        Console.WriteLine("asa:", activity.ID);
                    }
                }
            }

            return activityList;
        }


        public List<Activity> RetrieveActivity(int idemployee)
        {
            List<Activity> activityList = new List<Activity>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                // string statement = "SELECT * FROM activity WHERE"+idemployee+"; ";
                //string statement = "SELECT * FROM activity WHERE'" + idemployee + "';";

                string statement = "SELECT * FROM activity WHERE IdEmployee='" + idemployee + "';";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity();
                        activity.ID = reader.GetInt32("ID");
                        activity.IdEmployee = reader.GetInt32("IdEmployee");
                        activity.AddOp = reader.GetInt32("AddOp");
                        activity.UpdateOp = reader.GetInt32("UpdateOp");
                        activity.Viewproduct = reader.GetInt32("Viewproduct");
                        activity.DeliveryDate = reader.GetDateTime("DeliveryDate").ToString();
                        activityList.Add(activity);
                        Console.WriteLine("asa:", activity.ID);
                    }
                }
            }

            return activityList;
        }


        public List<Activity> RetrieveActivity()
        {
            List<Activity> activityList = new List<Activity>();

            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();

                string statement = "SELECT * FROM activity ";
                MySqlCommand cmd = new MySqlCommand(statement, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Activity activity = new Activity();
                        activity.ID = reader.GetInt32("ID");
                        activity.IdEmployee = reader.GetInt32("IdEmployee");
                        activity.AddOp = reader.GetInt32("AddOp");
                        activity.UpdateOp = reader.GetInt32("UpdateOp");
                        activity.Viewproduct = reader.GetInt32("Viewproduct");
                        activity.DeliveryDate = reader.GetDateTime("DeliveryDate").ToString();
                        activityList.Add(activity);
                        Console.WriteLine("asa:", activity.ID);
                    }
                }
            }

            return activityList;
        }


        public void AddActivity(Activity activity)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO activity(ID, idemployee, addop, updateop, viewproduct, deliverydate) VALUES(@ID, @idemployee, @addop, @updateop, @viewproduct, @deliverydate)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@ID", activity.ID);
                cmd.Parameters.AddWithValue("@idEmployee", activity.IdEmployee);
                cmd.Parameters.AddWithValue("@addop", activity.AddOp);
                cmd.Parameters.AddWithValue("@updateop", activity.UpdateOp);
                cmd.Parameters.AddWithValue("@viewproduct", activity.Viewproduct);
                cmd.Parameters.AddWithValue("@deliverydate", activity.DeliveryDate);

                cmd.ExecuteNonQuery();
            }
        }

          public void CreateXml()
        {
            if (!File.Exists(Path))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.NewLineOnAttributes = true;
                xmlWriterSettings.Indent = true;

                using (XmlWriter xmlWriter = XmlWriter.Create(Path, xmlWriterSettings))
                {

                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Users");
          

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }


            }


        }


    }
}
