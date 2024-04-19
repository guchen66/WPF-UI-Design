using Prism.Ioc;
using Sample4.Helper;
using Sample4.IService;
using Sample4.Views;
using System.Windows;
using System.Windows.Controls;

namespace Sample4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册保存CheckBox和RadioButton的信息
            containerRegistry.RegisterSingleton<ISettingsService, SettingsService>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //程序启动加载上一次关闭时SetData的数据状态
            StateHelper.ApplySavedState();

        }

        
    }
}
