using MusicShop.entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShop.service
{
    class ProductDBService
    {
        private static string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=resource\database\productDB\ProductDB.mdb";

        public static void executeQuery(string CommandText)
        {
            OleDbConnection connection = new OleDbConnection(ConnectionString);

            connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.CommandText = CommandText;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void addProduct(Product product)
        {
            string query;

            query = string.Format("INSERT INTO Product([name], description, type, price) VALUES ('{0}', '{1}','{2}', {3})", product.Name, product.Description, product.Type, product.Price.ToString().Replace(',', '.'));
            executeQuery(query);
        }

        public static void removeProduct(int id)
        {
            string query;

            query = string.Format("DELETE * FROM Product WHERE Product.id = {0}", id);
            executeQuery(query);
        }

        public static DataSet getProducts()
        {
            string query;

            query = string.Format("SELECT * FROM Product");
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            return ds;
        }

        public static DataSet findProducts(string name, string type, string maxPrice)
        {
            DataSet data = new DataSet();
            string query;
            string namePattern = "";
            string typePattern = "";
            string pricePattern = "";
            bool fl = false;

            query = string.Format("SELECT * FROM Product");
            if (name.Length > 0 || type.Length > 0 || maxPrice.Length > 0)
            {
                query = string.Format("{0} WHERE ", query);
            }
            if (name.Length > 0)
            {
                namePattern = string.Format("Product.[name] = '{0}'", name);
                fl = true;
            }
            if (type.Length > 0)
            {
                if (fl)
                {
                    typePattern = string.Format(" and Product.type  = '{0}'", type);
                }
                else
                {
                    typePattern = string.Format("Product.type  = '{0}'", type);
                }
                fl = true;
            }
            if (maxPrice.Length > 0)
            {
                if (fl)
                {
                    pricePattern = string.Format(" and Product.price < {0}", maxPrice.Replace(',', '.'));
                }
                else
                {
                    pricePattern = string.Format("Product.price < {0}", maxPrice.Replace(',', '.'));
                }
            }
            query = string.Format("{0}{1}{2}{3}", query, namePattern, typePattern, pricePattern);
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, ConnectionString);
            dataAdapter.Fill(data);
            return data;
        }
    }
}
