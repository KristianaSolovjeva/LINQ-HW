using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQhw
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 15, StandardID = 1 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21, StandardID = 1 },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18, StandardID =  2 },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20, StandardID = 2 },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 },
                new Student() { StudentID = 6, StudentName = "Bill", Age = 13 },
                new Student() { StudentID = 7, StudentName = "John", Age = 17 }};

            IList<Standard> standardList = new List<Standard>()
            {
                new Standard() { StandardID = 1, StandardName = "Standard 1"},
                new Standard() { StandardID = 2, StandardName = "Standard 2"},
                new Standard() { StandardID = 3, StandardName = "Standard 3"},
            };

            Console.WriteLine("Join:");
            var innerJoin = from s in studentList //outer sequence
                            join st in standardList //inner sequence
                            on s.StandardID equals st.StandardID //key selector
                            select new
                            {
                                StudentName = s.StudentName,
                                StandardName = st.StandardName
                            };

            var innerJoin1 = studentList.Join(standardList,
                standard => standard.StandardID,
                student => student.StandardID,

                (student, standard) => new
                {
                    student = student.StudentName,
                    standard = standard.StandardName
                }
                    );

            foreach (var listed in innerJoin)
            {
                Console.WriteLine(listed.StandardName + " " + listed.StudentName);
            }
            Console.WriteLine();

            foreach (var listed in innerJoin1)
            {
                Console.WriteLine(listed.standard + " " + listed.student);
            }
            ;
            Console.ReadLine();

            Console.WriteLine("Comparer:");

            Student std = new Student() { StudentID = 5, StudentName = "Ron", Age = 15 };
            StudentComparer comparer = new StudentComparer();
            bool result;
            foreach (var stud in studentList)
            {
                result = comparer.Equals(std, stud);
                Console.WriteLine("Is line " + stud.StudentID + " equal to std?: " + result);
            }

            Console.ReadLine();
            Console.WriteLine("First/FirstOrDefault that I didn't finish: ");
            try
            {
                Console.WriteLine("1st Element using First (age 13): {0}", studentList.First(s => s.Age == 13).StudentName);
                Console.WriteLine("1st Element using FirstOrDefault (age 15): {0}", studentList.FirstOrDefault(s => s.Age == 15).StudentName);
                Console.WriteLine("1st Element using FirstOrDefault: {0}", studentList.FirstOrDefault(s => s.Age == 100)?.StudentName);
                Console.WriteLine("1st Element using First: {0}", studentList.First(s => s.Age == 100).StudentName);

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadLine();
            Console.WriteLine("Output in LINQ without loops: ");

            studentList.Select(s => {
                Console.WriteLine(s.StudentID + " " + s.StudentName + " " + s.Age);
                return false; }).ToList();
            Console.ReadLine();
            // I don't have the 2nd task about making another Contains() method. 
            //Seymur showed some examples that I couldn't write down and I couldn't come up with one myself. 
        }
    }
}
