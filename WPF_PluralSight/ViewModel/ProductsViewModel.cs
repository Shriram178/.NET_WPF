using System.Collections.ObjectModel;
using WPF_PluralSight.Data;
using WPF_PluralSight.Models;

namespace WPF_PluralSight.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        private readonly IProductDataProvider _productDataProvider;

        public ProductsViewModel(IProductDataProvider productDataProvider)
        {
            _productDataProvider = productDataProvider;
        }

        public ObservableCollection<Product> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            var products = await _productDataProvider.GetAllAsync();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
    }
}
