using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpfdemo.Commands;

namespace Wpfdemo.ViewModels;

public class MenuViewModel : ViewModelBase
{
    public ICommand OpenProductsCommand { get; }

    public ICommand OpenPageTwoCommand { get; }

    public ICommand OpenPageThreeCommand { get; }

    public MenuViewModel(
        Func<Task> openProducts,
        Action openPageTwo,
        Action openPageThree)
    {
        OpenProductsCommand = new AsyncRelayCommand(_ => openProducts());
        OpenPageTwoCommand = new RelayCommand(_ => openPageTwo());
        OpenPageThreeCommand = new RelayCommand(_ => openPageThree());
    }
}