using Microsoft.Data.SqlClient;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DotNetLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Update students");
                Console.WriteLine("2. Delete students");
                Console.WriteLine("3. All students");
                

                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
             
                        case 1:
                            Update();
                            break;
                        case 2:
                            Delete();
                            break;
                        case 3:
                            StuDataRetrival();
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }
        static void Update()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = SBjune23; Integrated Security = True; Connect Timeout = 30";
            cn.Open();
            try
            {
                Student student = new Student();

                Console.Write("Enter rollno where you have to update : ");
                student.rollno = int.Parse(Console.ReadLine());

                Console.Write("Enter Student Name: ");
                student.name = Console.ReadLine();

                Console.Write("Enter students marks: ");
                student.marks = int.Parse(Console.ReadLine());


                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Student Set name = @name ,marks = @marks Where rollno = @rollno";

                cmd.Parameters.AddWithValue("@rollno", student.rollno);
                cmd.Parameters.AddWithValue("@name", student.name);
                cmd.Parameters.AddWithValue("@marks", student.marks);
                
                cmd.ExecuteNonQuery();
                Console.WriteLine("Updation Done ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
        static void Delete()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = SBjune23; Integrated Security = True; Connect Timeout = 30";
            cn.Open();
            try
            {
                Student student = new Student();

                Console.Write("Enter student rollno whose data to be deleted  : ");
                student.rollno = int.Parse(Console.ReadLine());



                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Student where rollno = @rollno ";
                cmd.Parameters.AddWithValue("@rollno", student.rollno);


                cmd.ExecuteNonQuery();
                Console.WriteLine("Deletion Done");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }
        }
        public static void StuDataRetrival()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\ProjectModels; Initial Catalog = SBjune23; Integrated Security = True; Connect Timeout = 30";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Student";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.Write(dr["name"]+" ;");
                    Console.Write(dr["marks"]);
                    Console.WriteLine();
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { cn.Close(); }

        }

    }
        public class Student
        {
            public int rollno
            {
                get; set;
            }
            public string? name
            {
                get; set;
            }
            public int marks
            {
                get; set;
            }

        }
    }
