using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Threading.Tasks;
using System.Windows;
using System;
using Sample2.Models;
using Sample2.Common;

namespace Sample2.ViewModels
{
   
   public class MainWindowViewModel : BindableBase
    {


        IEventAggregator _iea;//事件聚合器
        /*private string _closeWindow;

        public string CloseWindos
        {
            get { return _closeWindow; }
            set { SetProperty<string>(ref _closeWindow,value); }
        }*/

        public LoginModel LoginModel { get; set; }

        public MainWindowViewModel()
        {
            LoginModel = new LoginModel();
            this.LoginModel.UserName = "admin";

        }

        private string _passWord = "admin";

        public string PassWord
        {
            get { return _passWord; }
            set { SetProperty<string>(ref _passWord, value); }
        }

        private string _vertifyCode;

        public string VertifyCode
        {
            get { return _vertifyCode; }
            set { SetProperty<string>(ref _vertifyCode, value); }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty<string>(ref _errorMessage, value); }
        }

        //是否显示ProgressBar控件
        private Visibility _showProgress = Visibility.Collapsed;

        public Visibility ShowProgress
        {
            get { return _showProgress; }
            set
            {
                SetProperty<Visibility>(ref _showProgress, value);

            }
        }

        //cmd快捷键 关闭按钮
        private DelegateCommand<object> _closeWinCommand;
        public DelegateCommand<object> CloseWinCommand =>
            _closeWinCommand ?? (_closeWinCommand = new DelegateCommand<object>(DoExitCommand));

        public void DoExitCommand(object obj)
        {
            (obj as Window).Close();
        }

        //登录
        private DelegateCommand<object> _loginCommand;
        public DelegateCommand<object> LoginCommand =>
            _loginCommand ?? (_loginCommand = new DelegateCommand<object>(ExecuteLoginCommand));


        private void ExecuteLoginCommand(object o)
        {
            this.ErrorMessage = "";
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名";
                //  this.ShowProgress = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(this.PassWord))
            {
                this.ErrorMessage = "请输入密码";
                return;
            }
            if (string.IsNullOrEmpty(this.VertifyCode))
            {
                this.ErrorMessage = "请输入验证码";
                return;
            }
            if (this.VertifyCode.ToLower().ToInt() != 1234)
            {
                this.ErrorMessage = "验证码错误";
                return;
            }

            /*(o as Window).DialogResult = true;
            (o as Window).Close();*/
            Task.Run(new Action(async () =>
            {
                await Task.Delay(2000);
                try
                {
                   /* var user = LocalDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, this.PassWord);
                    if (user == null)
                    {
                        throw new Exception("登录异常，用户名或密码错误！");
                    }
                    GlobalValue.userInfo = user;*/

                    //调用线程无法访问，因为另一个线程拥有该对象
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        (o as Window).DialogResult = true;
                    }));
                }
                catch (Exception ex)
                {

                    this.ErrorMessage = ex.Message;
                }
                finally
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        this.ShowProgress = Visibility.Collapsed;
                    }));
                }
            }));


        }

    }
}
