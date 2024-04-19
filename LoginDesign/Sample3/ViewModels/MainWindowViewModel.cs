using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace Sample3.ViewModels
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

        private DelegateCommand<string> _dragMoveCommand;
        public DelegateCommand<string> DragMoveCommand =>
            _dragMoveCommand ?? (_dragMoveCommand = new DelegateCommand<string>(ExecuteDragMoveCommand, CanExecuteDragMoveCommand));

        private void ExecuteDragMoveCommand(string parameter)
        {
            Application.Current.MainWindow.DragMove();

        }

        private bool CanExecuteDragMoveCommand(string parameter)
        {
            return true;
        }
    }
}
