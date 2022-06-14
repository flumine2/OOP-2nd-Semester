using Lab6.Data.Repositories;
using Lab6.Infrastructure.Commands;
using Lab6.Services;
using Lab6.Services.Providers;
using Lab6.ViewModels.Base;
using LibraryFor2ndLab.Models;
using LibraryFor2ndLab.Models.Person;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab6.ViewModels
{
    class OrderEditViewModel : ViewModel
    {
        private MainWindowViewModel MainWindowViewModel;
        private long _serviceDeskId;
        public IEnumerable<Service> ComboBoxSource { get; private set; } = Enum.GetValues(typeof(Service)).Cast<Service>();

        /*-----------------------------------------------------------------------------------------*/

        private RepositoryControler RepositoryControler { get; set; }

        public ObservableCollection<Order> Orders { get; private set; }

        #region Order Creating Name

        private string _serviceDeskCreatingName;

        public string ServiceDeskCreatingName
        {
            get => _serviceDeskCreatingName;
            set => Set(ref _serviceDeskCreatingName, value);
        }

        #endregion

        #region SelectedOrder : Order

        private Order _selectedOrder;

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => Set(ref _selectedOrder, value);
        }

        #endregion

        #region SelectedService : Service

        private Service _selectedService;

        public Service SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService, value);
        }

        #endregion

        #region Creating customer adress : string

        private string _customerAdress;

        public string CreatingCustomerAdress
        {
            get => _customerAdress;
            set => Set(ref _customerAdress, value);
        }

        #endregion

        #region Creating performer name : string

        private string _performerName;

        public string CreatingPerformerName
        {
            get => _performerName;
            set => Set(ref _performerName, value);
        }

        #endregion

        #region Creating performer surname : string

        private string _performerSurname;

        public string CreatingPerformerSurname
        {
            get => _performerSurname;
            set => Set(ref _performerSurname, value);
        }

        #endregion

        #region Creating performer birth date : DateTime

        private DateTime _performerBirthDate = DateTime.Today;

        public DateTime CreatingPerformerBirthDate
        {
            get => _performerBirthDate;
            set => Set(ref _performerBirthDate, value);
        }

        #endregion

        #region Creating order date : DateTime

        private DateTime _orderDate = DateTime.Today;

        public DateTime CreatingOrderDate
        {
            get => _orderDate;
            set => Set(ref _orderDate, value);
        }

        #endregion

        #region Creating order time : DateTime

        private DateTime _orderTime = DateTime.Now;

        public DateTime CreatingOrderTime
        {
            get => _orderTime;
            set => Set(ref _orderTime, value);
        }

        #endregion

        #region Creating order price : string

        private string _orderPrice;

        public string CreatingOrderPrice
        {
            get => _orderPrice;
            set => Set(ref _orderPrice, value);
        }

        #endregion


        /*-----------------------------------------------------------------------------------------*/
        #region Commands

        #region Creating new Order Command

        public ICommand CreateNewOrderCommand { get; set; }

        private bool CanCreateOrderCommandExecute(object p)
        {
            if (string.IsNullOrEmpty(CreatingCustomerAdress) ||
                string.IsNullOrEmpty(CreatingPerformerName) ||
                string.IsNullOrEmpty(CreatingPerformerSurname) ||
                string.IsNullOrEmpty(CreatingOrderPrice))
            {
                return false;
            }
            return true;
        }

        private void OnCreateOrderCommandExecuted(object p)
        {
            Performer performer = new Performer(
                CreatingPerformerName,
                CreatingPerformerSurname,
                CreatingPerformerBirthDate);

            Customer customer = new Customer(
                SelectedService,
                CreatingCustomerAdress);

            //DateTime time = DateTime ;

            DateTime creationOrderDateTime = new DateTime(CreatingOrderDate.Ticks + CreatingOrderTime.TimeOfDay.Ticks);

            Order order = new Order(
                performer,
                customer,
                creationOrderDateTime,
                int.Parse(CreatingOrderPrice));

            List<ValidationResult> validations = new List<ValidationResult>();
            if (!Validator.TryValidateObject(order, new ValidationContext(order), validations, true))
            {
                Exception e = new Exception(string.Join(", ", validations));
                MessageBox.Show("Something went wrong:" + e.Message);
            }
            else
            {
                Orders.Add(order);
            }
        }

        #endregion

        #region Deleting selected Order

        public ICommand DeleteOrderCommand { get; set; }

        private bool CanDeleteOrderCommandExecute(object p)
        {
            return p is Order order && Orders.Contains(order);
        }

        private void OnDeleteOrderCommandExecuted(object p)
        {
            if (!(p is Order order)) return;

            Orders.Remove(order);
        }

        #endregion

        #endregion

        /*-----------------------------------------------------------------------------------------*/
        public OrderEditViewModel(MainWindowViewModel mainWindowViewModel, long serviceDeskId)
        {
            RepositoryControler = RepositoryProvider.GetRepositoryReference();
            _serviceDeskId = serviceDeskId;
            Orders = RepositoryControler.ServiceDeskRepository.GetById(_serviceDeskId).OrdersList;

            CreateNewOrderCommand = new LambdaCommand(OnCreateOrderCommandExecuted, CanCreateOrderCommandExecute);
            DeleteOrderCommand = new LambdaCommand(OnDeleteOrderCommandExecuted, CanDeleteOrderCommandExecute);
        }
    }
}
