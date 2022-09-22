using System.Collections.ObjectModel;
using System.Linq;
using WpfDesignerAss.Services;

namespace WpfDesignerAss.ViewModel
{
    public class StudentsViewModel : MainViewModel
    {
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; } = new Student();

        public StudentsViewModel(DataService service) : base(service)
        {
            service.StudentsByLecture += UpdateStudents;

            if (!IsInDesignMode)
                Students = new ObservableCollection<Student>(_service.GetStudents());
        }

        async void GetStudentsAsync() // => Students = new ObservableCollection<Student>(await _service.GetStudentsAsync());
        {
            var std = await _service.GetStudentsAsync();
            Students = new ObservableCollection<Student>(std);
        }
        void UpdateStudents(Teacher teacher)
        {
            Students?.Clear();
            teacher.Students.ToList().ForEach(s => Students.Add(s));
        }
    }
}