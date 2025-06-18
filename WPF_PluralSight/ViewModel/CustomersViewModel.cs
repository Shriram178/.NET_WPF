using System.Collections.ObjectModel;
using WPF_PluralSight.Command;
using WPF_PluralSight.Data;
using WPF_PluralSight.Models;

namespace WPF_PluralSight.ViewModel
{

    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }

        private CustomerItemViewModel? _selectedCustomer;
        private int _navigationColumn;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
        }

        private bool CanDelete(object? parameter) => SelectedCustomer is not null;

        private void Delete(object? parameter)
        {
            Customers.Remove(SelectedCustomer);
            SelectedCustomer = null;
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand?.RaiseCanExecuteChanged();
            }
        }

        public bool IsCustomerSelected => SelectedCustomer is not null;

        public int NavigationColumn
        {
            get => _navigationColumn;
            private set
            {
                _navigationColumn = value;
                RaisePropertyChanged();
            }
        }

        public override async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }

        private void Add(Object? parameter)
        {
            var customer = new Customer { FirstName = "Bolo" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationColumn = NavigationColumn == 0 ? 2 : 0;
        }
    }
}
