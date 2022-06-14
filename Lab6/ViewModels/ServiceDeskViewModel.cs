using Lab6.Data.Repositories;
using Lab6.Infrastructure.Commands;
using Lab6.Services;
using Lab6.Services.Providers;
using Lab6.ViewModels.Base;
using Lab6.Views;
using LibraryFor2ndLab.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab6.ViewModels
{
    class ServiceDeskViewModel : ViewModel
    {
        private MainWindowViewModel _MainWindowViewModel;
        private OrderEditView _OrderEditView;

        /*-----------------------------------------------------------------------------------------*/
        public RepositoryControler RepositoryControler { get; set; }
        

        #region Service Desk Creating Name

        private string _serviceDeskCreatingName;

        public string ServiceDeskCreatingName
        {
            get => _serviceDeskCreatingName;
            set => Set(ref _serviceDeskCreatingName, value);
        }

        #endregion

        #region SelectedServiceDesk : ServiceDesk

        private ServiceDesk _selectedServiceDesk;

        public ServiceDesk SelectedServiceDesk
        {
            get => _selectedServiceDesk;
            set => Set(ref _selectedServiceDesk, value);
        }

        #endregion

        /*-----------------------------------------------------------------------------------------*/
        #region Commands

        #region Open Service`s Desk order change window

        public ICommand OpenOrderPageCommand { get; set; }

        private bool CanOpenOrderPageCommandExecute(object p) => true;

        private void OnOpenOrderPageCommandExecuted(object p)
        {
            OrderEditViewModel orderEditViewModel = new OrderEditViewModel(_MainWindowViewModel, (long)p);
            _OrderEditView.DataContext = orderEditViewModel;

            _MainWindowViewModel.FrameContent = _OrderEditView;
        }

        #endregion

        #region Creating new Service Desk Command

        public ICommand CreateNewServiceDeskCommand { get; set; }

        private bool CanCreateServiceDeskCommandExecute(object p)
        {
            if (string.IsNullOrEmpty(ServiceDeskCreatingName))
            {
                return false;
            }
            return !RepositoryControler.DataBase.ServiceDesks.Select(x => x.DeskName).Contains(ServiceDeskCreatingName);
        }

        private void OnCreateServiceDeskCommandExecuted(object p)
        {
            ServiceDesk sd = new ServiceDesk(ServiceDeskCreatingName);

            List<ValidationResult> validations = new List<ValidationResult>();
            if (!Validator.TryValidateObject(sd, new ValidationContext(sd), validations, true))
            {
                Exception e = new Exception(string.Join(", ", validations));
                MessageBox.Show("Something went wrong:" + e.Message);
            }
            else
            {
                RepositoryControler.ServiceDeskRepository.Add(sd);
            }
        }

        #endregion

        #region Deleting selected Service Desk

        public ICommand DeleteServiceDeskCommand { get; set; }

        private bool CanDeleteServiceDeskCommandExecute(object p)
        {
            return p is ServiceDesk serviceDesk && RepositoryControler.DataBase.ServiceDesks.Contains(serviceDesk);
        }

        private void OnDeleteServiceDeskCommandExecuted(object p)
        {
            if (!(p is ServiceDesk serviceDesk)) return;

            RepositoryControler.ServiceDeskRepository.Remove(serviceDesk);
        } 

        #endregion

        #endregion

        /*-----------------------------------------------------------------------------------------*/
        public ServiceDeskViewModel(MainWindowViewModel mainWindowViewModel, OrderEditView orderEditView)
        {
            _MainWindowViewModel = mainWindowViewModel;
            _OrderEditView = orderEditView;

            RepositoryControler = RepositoryProvider.GetRepositoryReference();

            CreateNewServiceDeskCommand = new LambdaCommand(OnCreateServiceDeskCommandExecuted, CanCreateServiceDeskCommandExecute);
            DeleteServiceDeskCommand = new LambdaCommand(OnDeleteServiceDeskCommandExecuted, CanDeleteServiceDeskCommandExecute);
            OpenOrderPageCommand = new LambdaCommand(OnOpenOrderPageCommandExecuted, CanOpenOrderPageCommandExecute);
        }
    }
}
