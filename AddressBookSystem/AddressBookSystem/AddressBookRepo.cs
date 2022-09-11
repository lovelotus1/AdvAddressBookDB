using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookSystem
{
    class AddressBookRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookService;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllEntries()
        {
            try
            {
                AddressBookModel model = new AddressBookModel();
                using (this.connection)
                {
                    string query = @"select FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,Email
                                     FROM AddressBook";
                    SqlCommand command = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    //check if there are record
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            model.FirstName = sqlDataReader.GetString(0);
                            model.LastName = sqlDataReader.GetString(1);
                            model.Address = sqlDataReader.GetString(2);
                            model.City = sqlDataReader.GetString(3);
                            model.State = sqlDataReader.GetString(4); ;

                            //display retrieved record
                            Console.WriteLine("FirstName:{0}\nLastName:{1}\nAddress:{2}\nCity:{3}\nState:{4}",
                                 model.FirstName, model.LastName, model.Address, model.City, model.State); 

                            Console.WriteLine("\n");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }

    }
}
