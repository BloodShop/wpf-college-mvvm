using GalaSoft.MvvmLight;
using System.Collections.Specialized;
using WpfDesignerAss.Services;

namespace WpfDesignerAss.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyCollectionChanged
    {
        protected readonly DataService _service;

        // DI = Dependency Injection
        public MainViewModel(DataService service) => _service = service;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public virtual void RaiseCollectionChanged(NotifyCollectionChangedEventArgs e) => CollectionChanged?.Invoke(this, e);

        //event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        //{
        //    add { this.PropertyChanged += value; }
        //    remove { this.PropertyChanged -= value; }
        //}
        //protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //public virtual void RaisePropertyChanged(PropertyChangedEventArgs e) => this.PropertyChanged?.Invoke(this, e);
    }
}