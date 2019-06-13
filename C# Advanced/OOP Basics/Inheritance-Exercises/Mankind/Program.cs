using System;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] studentArgs = Console.ReadLine().Split();
            string studentFirstName = studentArgs[0];
            string studentLastName = studentArgs[1];
            string facultyNumber = studentArgs[2];

            string[] workerArgs = Console.ReadLine().Split();
            string workerFirstName = workerArgs[0];
            string workerLastName = workerArgs[1];
            double salary = double.Parse(workerArgs[2]);
            double workingHours = double.Parse(workerArgs[3]);

            try
            {
                Student student = new Student(studentFirstName, studentLastName, facultyNumber);
                Worker worker = new Worker(workerFirstName, workerLastName, salary, workingHours);

                Console.WriteLine(student.ToString());
                Console.WriteLine(worker.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                Environment.Exit(0);
            }
        }
    }
}
