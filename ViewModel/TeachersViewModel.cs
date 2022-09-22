using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfDesignerAss.Services;

namespace WpfDesignerAss.ViewModel
{
    public class TeachersViewModel : MainViewModel
    {
        public ObservableCollection<Teacher> Teachers { get; }
        public Teacher SelectedTeacher { get; set; } = new Teacher() { CourseTeach = CourseType.CSharp | CourseType.WPF | CourseType.OOP | CourseType.ADO | CourseType.MAUI | CourseType.JS | CourseType.SQL };
        public CourseType SelectedCourse { get; set; }
        public List<CourseType> CourseTypes => _service.GetCourseTypes().ToList();

        CourseType _teachersCourses;
        public CourseType TeachersCourses
        {
            get => SelectedTeacher.CourseTeach;
            set => Set(ref _teachersCourses, value, propertyName: nameof(TeachersCourses));
        }

        public ICommand TeacherCoursesCommand { get; private set; }
        public ICommand TeacherStudentsCommand { get; private set; }
        public ICommand AddCourseCommand { get; private set; }
        public ICommand RemoveCourseCommand { get; private set; }

        public TeachersViewModel(DataService service) : base(service)
        {
            TeacherCoursesCommand = new RelayCommand(GetTeacherCourses);
            TeacherStudentsCommand = new RelayCommand(ShowStudentsLecturer);
            AddCourseCommand = new RelayCommand(AddCourseClick, CanAddExecute);
            RemoveCourseCommand = new RelayCommand(RemoveCourseClick, CanRemoveExecute);

            if (!IsInDesignMode)
                Teachers = new ObservableCollection<Teacher>(service.GetTeachers());
        }

        private void GetTeacherCourses() => TeachersCourses = SelectedTeacher.CourseTeach;
        async void ShowStudentsLecturerAsync() => await Task.Run(ShowStudentsLecturer);
        void ShowStudentsLecturer() => _service.GetStudentsByLecture(SelectedTeacher);

        void AddCourseClick()
        {
            if (SelectedTeacher != null && !SelectedTeacher.CourseTeach.HasFlag(SelectedCourse))
            {
                _service.AddCourseToTeacher(SelectedTeacher, SelectedCourse);
                TeachersCourses = SelectedTeacher.CourseTeach;
            }
        }
        void RemoveCourseClick()
        {
            if (SelectedTeacher.CourseTeach.HasFlag(SelectedCourse))
            {
                _service.RemoveCourseFromTeacher(SelectedTeacher, SelectedCourse);
                TeachersCourses = SelectedTeacher.CourseTeach;
            }
        }
        bool CanAddExecute() =>
            //if (SelectedCourse == default || SelectedTeacher.CourseTeach.HasFlag(SelectedCourse)) return false;
            true;
        bool CanRemoveExecute() =>
            //if (SelectedCourse == default || !SelectedTeacher.CourseTeach.HasFlag(SelectedCourse)) return false;
            true;

        //public static class FlagExtensions
        //{
        //    public static CourseType Add(this CourseType me, MyFlags toAdd)
        //    {
        //        return me | toAdd;
        //    }
        //}
    }
}
