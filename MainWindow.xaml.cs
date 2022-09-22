using System.Windows;

namespace WpfDesignerAss
{
    public partial class MainWindow : Window
    {
        readonly SchoolContainer data = new SchoolContainer();
        public MainWindow()
        {
            InitializeComponent();
            // set if to true as inializer than set to false and run the program again in order to see the results
#if init
            var t1 = new Teacher { Name = "T1", CourseTeach = CourseType.WPF | CourseType.OOP };
            var t2 = new Teacher { Name = "T2", CourseTeach = CourseType.MAUI | CourseType.SQL };
            var t3 = new Teacher { Name = "T3", CourseTeach = CourseType.ADO | CourseType.JS };
            var t4 = new Teacher { Name = "T4", CourseTeach = CourseType.ADO | CourseType.JS | CourseType.CSharp };

            var s1 = new Student { Name = "S1", Grade = 90.4 };
            var s2 = new Student { Name = "S2", Grade = 87 };
            var s3 = new Student { Name = "S3", Grade = 50 };
            var s4 = new Student { Name = "S4", Grade = 65.3 };
            var s5 = new Student { Name = "S5", Grade = 67.9 };

            t1.Students.Add(s1);
            t1.Students.Add(s2);

            t2.Students.Add(s2);
            t2.Students.Add(s3);

            t3.Students.Add(s3);
            t3.Students.Add(s1);
            t3.Students.Add(s2);

            t4.Students.Add(s4);
            t4.Students.Add(s5);

            data.People.Add(t1);
            data.People.Add(t2);
            data.People.Add(t3);
            data.People.Add(s1);
            data.People.Add(s2);
            data.People.Add(s3);
            data.People.Add(s4);
            data.People.Add(t4);
            data.People.Add(s5);

            data.SaveChanges();
#endif
        }
    }
}
