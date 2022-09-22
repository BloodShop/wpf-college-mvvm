using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WpfDesignerAss.Services
{
    public class DataService : ISchoolService
    {
        public readonly SchoolContainer School = new SchoolContainer();

        public event Action<Teacher> StudentsByLecture;

        // Not needed because of the locator - SimpleIoc.Default.Register<IDataService, DataService>(); 
        // Registering the singleton approach
        // public static DataService Instance { get; } = new DataService(); // Singleton design pattern
        // DataService() { }

        public IEnumerable<Student> GetStudents() => School.People.OfType<Student>();
        public Task<IEnumerable<Student>> GetStudentsAsync() => Task.Run(GetStudents);

        public IEnumerable<Teacher> GetTeachers() => School.People.OfType<Teacher>();
        public Task<IEnumerable<Teacher>> GetTeachersAsync() => Task.Run(GetTeachers);

        public IEnumerable<CourseType> GetCourseTypes() => Enum.GetValues(typeof(CourseType)).Cast<CourseType>();
        public Task<IEnumerable<CourseType>> GetCourseTypesAsync() => Task.Run(GetCourseTypes);

        public void GetStudentsByLecture(Teacher teacher) => StudentsByLecture?.Invoke(teacher);
        public async void GetStudentsByLectureAsync(Teacher teacher) => await Task.Run(() => GetStudentsByLecture(teacher));

        public void AddCourseToTeacher(Teacher selectedTeacher, CourseType selectedCourse)
        {
            selectedTeacher.CourseTeach |= selectedCourse;
            School.SaveChanges();
        }
        public void RemoveCourseFromTeacher(Teacher selectedTeacher, CourseType selectedCourse)
        {
            selectedTeacher.CourseTeach -= selectedCourse;
            School.SaveChanges();
        }
    }
}