using System;
using System.Windows.Input;
using Wpfdemo.Commands;

namespace Wpfdemo.ViewModels;

public class CartViewModel : ViewModelBase
{
    public string Title { get; }

    public ICommand BackCommand { get; }

    public CartViewModel(string title, Action goHome)
    {
        Title = title;
        BackCommand = new RelayCommand(_ => goHome());
    }
}