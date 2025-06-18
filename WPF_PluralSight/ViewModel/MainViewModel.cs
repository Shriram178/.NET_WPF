using WPF_PluralSight.Command;

namespace WPF_PluralSight.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private ViewModelBase _selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel,
            ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            _selectedViewModel = CustomersViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public DelegateCommand SelectViewModelCommand { get; }
        public CustomersViewModel CustomersViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        public override async Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
