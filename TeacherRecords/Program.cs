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

            
            //User insert data
            Console.WriteLine("Insert ID, Name and Class of the new student:");
            
            Console.WriteLine("ID: ");
            string insertedId = Console.ReadLine();
            Console.WriteLine("Name: ");
            string insertedName = Console.ReadLine();
            Console.WriteLine("Class: ");
            string insertedClass = Console.ReadLine();

            //Store inserted data into student List
            if (insertedId != "" && insertedClass != "" && insertedName != "" ) {
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
            foreach(var student in students)
            {
                data.Add($"{student.Id},{student.Name},{student.Class}");
            }

            //Right only the inserted data which is store in "data" List into the text file
            
            File.WriteAllLines(myPath, data);


            Console.WriteLine("Data has been inserted");

            //Print the list from txt file to check if the data is inserted
            Console.WriteLine("----- Print the data: ");
            foreach (var student in students)
            {
                //Printing the output in a specific form seperated by |
                Console.WriteLine($"{student.Id} | {student.Name} | {student.Class}");
            }
                //Let user enter something or press enter to finish the program 
            }
            else
            {
                Console.WriteLine("Please enter proper input");
            }

            Console.ReadLine();
                 }
    }
}
