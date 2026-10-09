using AcademyApp.data;
using AcademyApp.model;
using System;
using System.Data.SqlClient;

namespace AcademyApp
{
    internal class Program
    {
        static string connection_string = "Data Source=COMP7A2\\SQLEXPRESS;" +
                "Initial Catalog=academyCollegh;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True";

        static Studentrepos student_repo = new Studentrepos(connection_string);

        static Grouprepos group_repo= new Grouprepos(connection_string);
        static void Main(string[] args)
        {

            bool is_running = true;
            


            while (is_running)
            {
                Console.WriteLine("1. Просмотр всех студентов");
                Console.WriteLine("2. Просмотр всех студентов по iD");
                Console.WriteLine("3. Просмотр все группы");
                Console.WriteLine("4. добавить студента");

                Console.WriteLine("0. Выход");
                Console.Write("Введите номер действия: ");
                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        ShowAllStudent();
                        break;
                    case "2":
                        ShowAllStudentsById();
                        break;

                    case "3":
                        ShowAllGroup();
                        break;

                    case "4":
                        CreateStudent();
                        break;

                    case "0":
                        is_running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод. Введите 1 или 0.");
                        break;
                }

                if (is_running)
                {
                    Console.WriteLine("\nНажмите любую кнопку для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        static void ShowAllStudent()
        {
            var students = student_repo.FindAllStudents();
            foreach (var student in students) {
                Console.WriteLine(student);
            
            }
        }

        static void ShowAllGroup()
        {
            var groups = group_repo.FindAllGroup();
            foreach (var group in groups)
            {
                Console.WriteLine(group);

            }
        }
        static void CreateStudent()
        {
            Console.WriteLine("ввкдите имя студента, фамилию и возраст, группа");
            string first_name = Console.ReadLine();
            string last_name = Console.ReadLine();
            string age = Console.ReadLine();
            string group_id = Console.ReadLine();
            student_repo.AddStudent(first_name, last_name, age, group_id);


        }
         
        static void ShowAllStudentsById() 
        {
            Console.WriteLine("введите номер студениа");
            string choice = Console.ReadLine();
            var student = student_repo.FindStudentBeId(choice);
            Console.WriteLine(student);
        }

       
    }
}
