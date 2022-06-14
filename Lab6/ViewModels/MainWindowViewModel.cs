using Lab6.Data;
using Lab6.Data.Repositories;
using Lab6.Infrastructure.Commands;
using Lab6.ViewModels.Base;
using Lab6.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Lab6.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        /*-----------------------------------------------------------------------------------------*/

        public RepositoryControler RepositoryControler { get; private set; }

        private Page _frame;

        public Page FrameContent
        {
            get => _frame;
            set => Set(ref _frame, value);
        }

        #region Title : string

        private string _title = "Service Desk Page";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        } 

        #endregion

        /*-----------------------------------------------------------------------------------------*/
        #region Commands

        #endregion

        /*-----------------------------------------------------------------------------------------*/

        public MainWindowViewModel(ServiceDeskView serviceDeskView)
        {
             RepositoryControler = new RepositoryControler();
            _frame = serviceDeskView;

        }

        /*-----------------------------------------------------------------------------------------*/
    }
}
