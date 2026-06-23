using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpfdemo.Commands;

namespace Wpfdemo.ViewModels;

public class MenuViewModel : ViewModelBase
{
    public ICommand OpenProductsCommand { get; }

    public ICommand OpenCartCommand { get; }

    public ICommand OpenCustomersCommand { get; }

    public MenuViewModel(
        Func<Task> openProducts,
        Action openPageTwo,
        Action openPageThree)
    {
        OpenProductsCommand = new AsyncRelayCommand(_ => openProducts());
        OpenCartCommand = new RelayCommand(_ => openPageTwo());
        OpenCustomersCommand = new RelayCommand(_ => openPageThree());
    }
}