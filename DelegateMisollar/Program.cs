using static DelegatgaMisollar.Program;

namespace DelegatgaMisollar
{
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int EnrollNumber { get; set; }

    }
    public class Program
    {
        public delegate int Oshiruvchi(int n);
        public delegate TResult GenericOshiruvchi<T, TResult>(T value);
        public delegate TResult GenericDelegate<T, TResult>(T value);
        public delegate void GenericDelegateForAction<T>(T value);
        public delegate bool GenericDelegateForPredicate<T>(T value);

        public static void Main(string[] args)
        {
            Oshiruvchi oshir = Increment;
            var m = oshir(5);
            Console.WriteLine(m);

            Console.WriteLine();

            GenericOshiruvchi<int, int> genericOshir = new GenericOshiruvchi<int>(Increment);
            Console.WriteLine(genericOshir(8));


            List<Student> students = new List<Student>()
            {
                new Student { Age = 25, Name = "Abdulla", EnrollNumber = 20134 },
                new Student { Age = 24, Name = "Abubakr", EnrollNumber = 20334 },
                new Student { Age = 18, Name = "Bilol", EnrollNumber = 20164 },
                new Student { Age = 21, Name = "Bahrom", EnrollNumber = 70134 },
                new Student { Age = 22, Name = "Umar", EnrollNumber = 22134 },
                new Student { Age = 27, Name = "Zulfiya", EnrollNumber = 80134 },
                new Student { Age = 19, Name = "Zarina", EnrollNumber = 20131 },
            };

            Func<Student, string> stdNam1 = StudentName1;
            Func<Student, string> stdNam = student => student.Name;
            var studentNames = students.Select(student => student.Name);
            foreach( var name in studentNames)
            {
                Console.WriteLine(name);
            }

            //GenericDelegateForAction<Student> stdNameForAct = StudentName;

            //foreach(var student int students)
            //{
            //    stdNameForAct(student);
            //}

            Action<Student> studentAction = StudentName;
            Action<Student> studentAction = student => Console.WriteLine(student.Name);
            students.ForEach(s => Console.WriteLine(s.Name));

            GenericDelegateForPredicate<Student> studentPredicate = StudentAdultAge;
            var adultStudents = new List<Student>();
            foreach( var student in students)
            {
                if (studentPredicate(student))
                {
                    adultStudents.Add(student);
                }
            }
            foreach( var student in adultStudents)
            {
                Console.WriteLine(studentX.Age);
            }
        }
        private static bool StudentAdultAge(Student student)
        {
            return student.Age > 18;
        }
        // private static bool StudentAdultAge(Student student) => student.Age > 18;

        private static void StudentName(Student student)
        {
            Console.WriteLine(student.Name);
        }
        private static void StudentName1(Student student) => Console.WriteLine(student.Name);

        //private static string StudentName(Student student)
        //{
        //    return student.Name;
        //}

        //private static string StudentName1(Student student) => student.Name;

        private static int Increment(int x)
        {
            return ++x;
        }
        // GenericDelegate<Student, string> genericDelegate = StudentName();


        List<string> studentNames = new List<string>();

        //foreach(var studentX in students)
        //{
        //    string studentName = genericDelegat(studentX);

        //    studentsNames.Add(studentName);
        //}
        
        //foreach (var name in studentsName);
        //{
        //    Console.WriteLine(name);
        //}

    }
}