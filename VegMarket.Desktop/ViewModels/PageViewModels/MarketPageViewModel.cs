using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using ReactiveUI.Fody.Helpers;
using VegMarket.Desktop.Models;

namespace VegMarket.Desktop.ViewModels;

public class MarketPageViewModel : ViewModelBase
{
    public ReadOnlyObservableCollection<Product> Products { get; set; }
    [Reactive] public Product? SelectedProduct { get; set; }
    
    public MarketPageViewModel()
    {
        Title = "Магазин";
        
        LoadProducts();
    }
    
    public void AddProductToCart(Product product)
    {
        
    }

    private async void LoadProducts()
    {
        var products = await App.HttpClient.GetFromJsonAsync<IEnumerable<Product>>("https://localhost:7201/products");
        Products = new ReadOnlyObservableCollection<Product>(new ObservableCollection<Product>(products));
    }
}