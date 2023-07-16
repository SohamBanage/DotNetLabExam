using Microsoft.Data.SqlClient;
using ModleBindingLab.Models;
using System.Data;

namespace ModleBindingLab.Models
{
    public class Car
    {
        public int CarId
        {
            get; set;
        }
        public string Name
        {
            get;set;
        }
        public int Bhp
        {
            get;set;
        }
        public int CC
        {
            get;set;
        }
        public int Fueltank
        {
            get;set;
        }
        public string FuelEconomy
        {
            get;set;
        }
        public static List<Car> GetAllCars()
        {
            List<Car> carlst = new List<Car>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = SBjune23; Integrated Security = True; Connect Timeout = 30";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Car";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Car cr = new Car();
                    {
                        cr.CarId = Convert.ToInt32(dr["CarId"]);
                        cr.Name = dr["Name"].ToString();
                        cr.Bhp = Convert.ToInt32(dr["Bhp"]);
                        cr.CC = Convert.ToInt32(dr["CC"]);
                        cr.Fueltank = Convert.ToInt32(dr["Bhp"]);
                        cr.FuelEconomy = dr["Name"].ToString();


                    };

                    carlst.Add(cr);

                }

                foreach (Car c in carlst)
                {
                    Console.WriteLine($"CarId: {c.CarId}");
                    Console.WriteLine($"Name: {c.Name}");
                    Console.WriteLine($"Bhp: {c.Bhp}");
                    Console.WriteLine($"CC: {c.CC}");
                    Console.WriteLine($"Fueltank: {c.Fueltank}");
                    Console.WriteLine($"FuelEconomy: {c.FuelEconomy}");

                    Console.WriteLine();
                }


                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return carlst;
        }
        public static Car GetSingleCar(int CarId)
        {
            Car cr = null;
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = SBjune23; Integrated Security = True; Connect Timeout = 30";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "Select * from Car Where CarId = @CarId";
                cmd.Parameters.AddWithValue("@CarId", CarId);

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cr = new Car();
                    {

                        Console.WriteLine(cr.CarId = Convert.ToInt32(dr["CarId"]));
                        Console.WriteLine(cr.Name = dr["Name"].ToString());
                        Console.WriteLine(cr.Bhp = Convert.ToInt32(dr["Bhp"]));
                        Console.WriteLine(cr.CC = Convert.ToInt32(dr["CC"]));
                        Console.WriteLine(cr.Fueltank = Convert.ToInt32(dr["Fueltank"]));
                        Console.WriteLine(cr.FuelEconomy = Convert.ToString(dr["FuelEconomy"]));


                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
            return cr;
        }
        public static void Update(Car obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = SBjune23; Integrated Security = True; Connect Timeout = 30";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Car Set Name = @Name,Bhp = @Bhp,CC = @CC,Fueltank =@Fueltank,FuelEconomy = @FuelEconomy Where EmpNo = @EmpNo";
                cmd.Parameters.AddWithValue("@CarId", obj.CarId);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Bhp", obj.Bhp);
                cmd.Parameters.AddWithValue("@CC", obj.CC);
                cmd.Parameters.AddWithValue("@Fueltank", obj.Fueltank);
                cmd.Parameters.AddWithValue("@FuelEconomy", obj.FuelEconomy);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            finally { cn.Close(); }
        }
        public static void DeleteCar(int CarId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = SBjune23; Integrated Security = True; Connect Timeout = 30";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Car where CarId = @CarId ";
                cmd.Parameters.AddWithValue("@CarId", CarId);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }

    }

}
