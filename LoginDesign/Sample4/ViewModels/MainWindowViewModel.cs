using Prism.Commands;
using Prism.Mvvm;
using Sample4.Helper;
using Sample4.IService;
using Sample4.Models;
using System.Windows;
using System.Windows.Controls;

namespace Sample4.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public AppData AppData { get; set; } = AppData.Instance;
        private readonly ISettingsService _settingsService;
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        /*public MainWindowViewModel(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }*/
        public MainWindowViewModel()
        {

        }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty<bool>(ref _isSelected, value); }
        }

        private DelegateCommand _saveStateCmd;
        public DelegateCommand SaveStateCmd =>
            _saveStateCmd ?? (_saveStateCmd = new DelegateCommand(ExecuteSave));

        private void ExecuteSave()
        {
            //_settingsService.SaveDataStateInfos(AppData.Instance.SaveDetailDatas);
            StateHelper.SaveState(AppData.Instance.SaveDetailDatas);
        }

        /// <summary>
        /// 取消
        /// </summary>
        private DelegateCommand _cancelCommand;
        public DelegateCommand CancelCommand =>
            _cancelCommand ?? (_cancelCommand = new DelegateCommand(DoCancel));

        private void DoCancel()
        {
            //App.Current.Shutdown();
            Application.Current.Shutdown();
        }
    }
}
