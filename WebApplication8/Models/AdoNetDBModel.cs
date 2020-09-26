using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class AdoNetDBModel
    {
        private string ConnetionString { get; set; }
        public AdoNetDBModel()
        {
            ConnetionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AspCoreIThelp2020;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public List<Product> Get() {

            List<Product> result = new List<Product>();

            using (DbConnection connection = new SqlConnection(this.ConnetionString))
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select Id, Name, Price From Product";
                    connection.Open();
                    DbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"])
                        });
                    }
                    connection.Close();
                }

            }
            return result;
        }

    }
}
