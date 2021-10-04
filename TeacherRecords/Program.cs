using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;


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

            //Save the retrieved data as Student type
            List<Student> students = new List<Student>();

            //Go through the list
            foreach (string row in rows)
            {

                //Split it by comma
                string[] split = row.Split(',');
                
                //Define the Student class
                Student newStudents = new Student();

                //Go through every word and split it by "," and store it in the object
                if (split.Length == 3) {
                    newStudents.Id = split[0];
                    newStudents.Name = split[1];
                    newStudents.Class = split[2];
                }
                else
                {
                    Console.WriteLine("Something wrong, please try again.");
                }

                //Store it in student List
                students.Add(newStudents);
            }

            Console.WriteLine("Press the needed option\n 1- Add student\n 2- List students\n 3- Search for student\n 4- Remove student");
            var c = Console.ReadLine();


            switch (c) {
                case "1":
                    // public void Inserted(int id, string Name, string Class) {
                    //User insert data
                    Console.WriteLine("Insert ID, Name and Class of the new student:");

                    Console.WriteLine("ID: ");
                    string insertedId = Console.ReadLine();
                    Console.WriteLine("Name: ");
                    string insertedName = Console.ReadLine();
                    Console.WriteLine("Class: ");
                    string insertedClass = Console.ReadLine();


                    //Store inserted data into student List
                    if (insertedId != "" && insertedClass != "" && insertedName != "") {
                        Student studentAssign = new Student
                        {
                            Id = insertedId,
                            Name = insertedName,
                            Class = insertedClass
                        };


                        students.Add(studentAssign);


                        //Define data List
                        List<string> data = new List<string>();

                        //Go through student List and store the inserted data into "data" List
                        foreach (var student in students)
                        {
                            data.Add($"{student.Id},{student.Name},{student.Class}");
                        }

                        //Write only the inserted data which is store in "data" List into the text file

                        File.WriteAllLines(@"records.txt", data);


                        Console.WriteLine("Data has been inserted");



                    }
                    else
                    {
                        Console.WriteLine("Please enter proper input");
                    }

                    break;
                case "2":


                    //Print the list from txt file to check if the data i` s inserted
                    Console.WriteLine("----- Print the data: ");
                    foreach (var student in students)
                    {
                        //Printing the output in a specific form seperated by |
                        Console.WriteLine($"{student.Id} | {student.Name} | {student.Class}");
                    }

                    break;
                case "3":
                    Console.WriteLine("Choose the way to find the student\n 1- By ID\n 2- By Name");
                    var optionId = Console.ReadLine();

                    switch (optionId) {

                    case "1":
                    Console.WriteLine("Please enter student ID:");
                    var gotId = Console.ReadLine();

                    foreach (var studentId in students)
                    {
                        if (gotId == studentId.Id)
                        {
                            Console.WriteLine($"{studentId.Id} | {studentId.Name} | {studentId.Class}");
                        }
                    }

                    break;
                    case "2":
                    Console.WriteLine("Please enter student name:");
                    var gotName = Console.ReadLine();

                    foreach (var studentName in students)
                    {
                        if (gotName == studentName.Name)
                        {
                            Console.WriteLine($"{studentName.Id} | {studentName.Name} | {studentName.Class}");
                        }
                    }
                    break;
                        default:
                            break;

            }
                    break;

                    case "4":
                    Console.WriteLine("Choose the way to remove student\n 1- By ID\n 2- By Name");
                    var removeId = Console.ReadLine();

                    Console.WriteLine("Enter the new value:");
                    var name = Console.ReadLine();

                    //StreamReader reading = File.OpenText(@"records.txt");

                    foreach (var studentRemoved in students)
                    {
                        if (removeId == studentRemoved.Id)
                        {
                            //Student studentRemove = new Student
                            //{
                            //    Id = studentRemoved.Id,
                            //    Name = studentRemoved.Name,
                            //    Class = studentRemoved.Class
                            //};

                            studentRemoved.Name = name;


                            // Console.WriteLine(studentRemove);

                            //=students.Remove(studentRemove);
                            //File.WriteAllLines(myPath, students);
                            break;

                            //Console.WriteLine("Removed");
                        }

                      


                    }

                    foreach (var student in students)
                    {
                        //Printing the output in a specific form seperated by |
                        Console.WriteLine($"{student.Id} | {student.Name} | {student.Class}");
                    }

                    break;
                default:
                    break;

        }

        }
        //Let user enter something or press enter to finish the program 
        //Console.ReadLine();
                 }
    }
