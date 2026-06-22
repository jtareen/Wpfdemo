using System;
using System.Windows.Input;
using Wpfdemo.Commands;

namespace Wpfdemo.ViewModels;

public class EmptyPageViewModel : ViewModelBase
{
    public string Title { get; }

    public ICommand BackCommand { get; }

    public EmptyPageViewModel(string title, Action goHome)
    {
        Title = title;
        BackCommand = new RelayCommand(_ => goHome());
    }
}