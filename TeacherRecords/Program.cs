using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace TeacherRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            //Store the path in a variable
            string myPath = @"records.txt";

            //Store the text file data in a List
            List<string> rows = File.ReadAllLines(myPath).ToList();


            //Save the retrieved data as teacher type
            List<Teacher> teachers = new List<Teacher>();

            //Go through the list
            foreach (string row in rows)
            {

                //Split it by comma
                string[] split = row.Split(',');
                
                //Define the teacher class
                Teacher newTeachers = new Teacher();

                //Go through every word and split it by "," and store it in the object
                if (split.Length == 3) {
                    newTeachers.Id = split[0];
                    newTeachers.Name = split[1];
                    newTeachers.Class = split[2];
                }
                else
                {
                    Console.WriteLine("Something wrong, please try again.");
                }

                //Store it in teacher List
                teachers.Add(newTeachers);
            }

            Console.WriteLine("Press the needed option\n 1- Add teacher\n 2- List teachers\n 3- Search for teacher\n 4- Edit teacher");
            var c = Console.ReadLine();


            switch (c) {
                case "1":

                    AddTeacher(teachers);
                   

                    break;
                case "2":

                    listTeachers(teachers);
                    

                    break;
                case "3":

                    findTeacher(teachers);

                    break;

                    case "4":
                    Console.WriteLine("Choose what you want to edit\n 1- Name\n 2- Section");
                    var removeId = Console.ReadLine();

                    Console.WriteLine("Enter the new value:");
                    var name = Console.ReadLine();

                    //StreamReader reading = File.OpenText(@"records.txt");
                    List<string> edited = new List<string>();


                    foreach (var teacherRemoved in teachers)
                    {
                        if (removeId == teacherRemoved.Id)
                        {
                            

                            teacherRemoved.Name = name;
                            
                        }


                    }

                    //var objToString = teachers.OfType<string>();
                    

                    foreach (var teacher in teachers)
                    {

                        //Printing the output in a specific form seperated by |
                        Console.WriteLine($"{teacher.Id} | {teacher.Name} | {teacher.Class}");

                    }
                    //List<object> objects = new List<object>();

                    //List<string> objToString = teachers.Se    lect(s => (string)s).ToList();

                    List<string> objToString = teachers.ConvertAll(f => f.ToString());
                    //Console.WriteLine(teachers.Id);
                    //var objToString = teachers.OfType<string>();
                    File.WriteAllLines(myPath, objToString);

                    break;
                default:
                    break;

        }

        }
        //Let user enter something or press enter to finish the program 
        //Console.ReadLine();

        private static void AddTeacher(List<Teacher> teachers)
        {
            // public void Inserted(int id, string Name, string Class) {
            //User insert data
            Console.WriteLine("Insert ID, Name and Class of the new teacher:");

            Console.WriteLine("ID: ");
            string insertedId = Console.ReadLine();
            Console.WriteLine("Name: ");
            string insertedName = Console.ReadLine();
            Console.WriteLine("Class: ");
            string insertedClass = Console.ReadLine();


            //Store inserted data into teacher List
            if (insertedId != "" && insertedClass != "" && insertedName != "")
            {
                Teacher teacherAssign = new Teacher
                {
                    Id = insertedId,
                    Name = insertedName,
                    Class = insertedClass
                };


                teachers.Add(teacherAssign);


                //Define data List
                List<string> data = new List<string>();

                //Go through teacher List and store the inserted data into "data" List
                foreach (var teacher in teachers)
                {
                    data.Add($"{teacher.Id},{teacher.Name},{teacher.Class}");
                }

                //Write only the inserted data which is store in "data" List into the text file

                File.WriteAllLines(@"records.txt", data);


                Console.WriteLine("Data has been inserted");



            }
            else
            {
                Console.WriteLine("Please enter proper input");
            }
        }

        private static void listTeachers(List<Teacher> teachers)
        {

            //Print the list from txt file to check if the data i` s inserted
            Console.WriteLine("----- Print the data: ");
            foreach (var teacher in teachers)
            {
                //Printing the output in a specific form seperated by |
                Console.WriteLine($"{teacher.Id} | {teacher.Name} | {teacher.Class}");
            }
        }

        private static void findTeacher(List<Teacher> teachers)
        {

            Console.WriteLine("Choose the way to find the teacher\n 1- By ID\n 2- By Name");
            var optionId = Console.ReadLine();

            switch (optionId)
            {

                case "1":
                    Console.WriteLine("Please enter teacher ID:");
                    var gotId = Console.ReadLine();

                    foreach (var teacherId in teachers)
                    {
                        if (gotId == teacherId.Id)
                        {
                            Console.WriteLine($"{teacherId.Id} | {teacherId.Name} | {teacherId.Class}");
                        }
                    }

                    break;
                case "2":
                    Console.WriteLine("Please enter teacher name:");
                    var gotName = Console.ReadLine();

                    foreach (var teacherName in teachers)
                    {
                        if (gotName == teacherName.Name)
                        {
                            Console.WriteLine($"{teacherName.Id} | {teacherName.Name} | {teacherName.Class}");
                        }
                    }
                    break;
                default:
                    break;

            }
        }
        }
    }
