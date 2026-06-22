using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpfdemo.Commands;
using Wpfdemo.Models;
using Wpfdemo.Services;

namespace Wpfdemo.ViewModels;

public class ProductsViewModel : ViewModelBase
{
    private readonly ProductService _productService;

    private string _name = string.Empty;
    private string _priceText = string.Empty;
    private string _errorMessage = string.Empty;

    public ObservableCollection<Product> Products { get; } = new();

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string PriceText
    {
        get => _priceText;
        set
        {
            _priceText = value;
            OnPropertyChanged();
        }
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddProductCommand { get; }

    public ICommand BackCommand { get; }

    public ProductsViewModel(ProductService productService, Action goHome)
    {
        _productService = productService;

        AddProductCommand = new AsyncRelayCommand(_ => AddProductAsync());
        BackCommand = new RelayCommand(_ => goHome());
    }

    public async Task LoadProductsAsync()
    {
        Products.Clear();

        var products = await _productService.GetAllAsync();

        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    private async Task AddProductAsync()
    {
        ErrorMessage = string.Empty;

        var name = Name.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            ErrorMessage = "Enter product name.";
            return;
        }

        if (!decimal.TryParse(PriceText, out var price))
        {
            ErrorMessage = "Enter valid price.";
            return;
        }

        await _productService.AddAsync(name, price);

        Name = string.Empty;
        PriceText = string.Empty;

        await LoadProductsAsync();
    }
}