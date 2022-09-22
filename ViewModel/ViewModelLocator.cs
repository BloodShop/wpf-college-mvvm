using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using WpfDesignerAss.Services;

namespace WpfDesignerAss.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            // IOC = Inversion of Control 
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register</*ISchoolService,*/ DataService>(true); // DataService Implements the interface ISchoolService -- Gives an error
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<TeachersViewModel>();
            SimpleIoc.Default.Register<StudentsViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public TeachersViewModel Teachers => ServiceLocator.Current.GetInstance<TeachersViewModel>();
        public StudentsViewModel Students => ServiceLocator.Current.GetInstance<StudentsViewModel>();

        public static void Cleanup() { /* TODO Clear the ViewModels */ }
    }
}