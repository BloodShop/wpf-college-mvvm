using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WpfDesignerAss.Services
{
    public interface ISchoolService
    {
        event Action<Teacher> StudentsByLecture;
        /*async*/ Task<IEnumerable<Teacher>> GetTeachersAsync();
        /*async*/ Task<IEnumerable<Student>> GetStudentsAsync();
        /*async*/ Task<IEnumerable<CourseType>> GetCourseTypesAsync();
        /*async*/ void GetStudentsByLectureAsync(Teacher teacher);
        void AddCourseToTeacher(Teacher selectedTeacher, CourseType selectedCourse);
        void RemoveCourseFromTeacher(Teacher selectedTeacher, CourseType selectedCourse);
    }
}