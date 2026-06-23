using System;
using System.Windows.Input;
using Wpfdemo.Commands;

namespace Wpfdemo.ViewModels;

public class CustomersViewModel : ViewModelBase
{
    public string Title { get; }

    public ICommand BackCommand { get; }

    public CustomersViewModel(string title, Action goHome)
    {
        Title = title;
        BackCommand = new RelayCommand(_ => goHome());
    }
}