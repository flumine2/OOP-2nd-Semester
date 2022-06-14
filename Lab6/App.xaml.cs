using Lab6.ViewModels;
using Lab6.Views;
using Lab6.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var orderEditView = new OrderEditView();
            var serviceDeskView = new ServiceDeskView();

            var mainVM = new MainWindowViewModel(serviceDeskView);
            var serviceDeskViewModel = new ServiceDeskViewModel(mainVM);

            serviceDeskView.DataContext = serviceDeskViewModel;

            var mainWindow = new MainWindow() { DataContext = mainVM };
            mainWindow.Show();
        }
    }
}
