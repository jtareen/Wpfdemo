using System.Windows.Input;
using Wpfdemo.Commands;
using Wpfdemo.Services;

namespace Wpfdemo.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly ProductService _productService;

    private ViewModelBase? _currentViewModel;
    private bool _isMenuOpen;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set
        {
            _currentViewModel = value;
            OnPropertyChanged();
        }
    }

    public bool IsMenuOpen
    {
        get => _isMenuOpen;
        set
        {
            _isMenuOpen = value;
            OnPropertyChanged();
        }
    }

    public ICommand OpenMenuCommand { get; }
    public ICommand CloseMenuCommand { get; }
    public ICommand OpenProductsCommand { get; }
    public ICommand OpenCartCommand { get; }
    public ICommand OpenCustomersCommand { get; }

    public MainViewModel(ProductService productService)
    {
        _productService = productService;

        OpenMenuCommand = new RelayCommand(_ => IsMenuOpen = true);
        CloseMenuCommand = new RelayCommand(_ => IsMenuOpen = false);

        OpenProductsCommand = new AsyncRelayCommand(_ => ShowProductsAsync());
        OpenCartCommand = new RelayCommand(_ => ShowCart());
        OpenCustomersCommand = new RelayCommand(_ => ShowCustomers());

        ShowHome();
    }

    private void ShowHome()
    {
        IsMenuOpen = false;
        CurrentViewModel = new HomeViewModel(OpenMenuCommand);
    }

    private async Task ShowProductsAsync()
    {
        IsMenuOpen = false;

        var productsViewModel = new ProductsViewModel(_productService, ShowHome);

        await productsViewModel.LoadProductsAsync();

        CurrentViewModel = productsViewModel;
    }

    private void ShowCart()
    {
        IsMenuOpen = false;
        CurrentViewModel = new CartViewModel("Cart", ShowHome);
    }

    private void ShowCustomers()
    {
        IsMenuOpen = false;
        CurrentViewModel = new CustomersViewModel("Customers", ShowHome);
    }
}