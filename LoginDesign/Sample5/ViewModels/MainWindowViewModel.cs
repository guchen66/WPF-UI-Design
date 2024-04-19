using Prism.Mvvm;

namespace Sample5.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }

        private string _selected;

        public string IsSelected
        {
            get { return _selected; }
            set { SetProperty<string>(ref _selected, value); }
        }
    }
}
