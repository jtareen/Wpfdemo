using System.Windows.Input;

namespace Wpfdemo.ViewModels;

public class HomeViewModel : ViewModelBase
{
    public ICommand OpenMenuCommand { get; }

    public HomeViewModel(ICommand openMenuCommand)
    {
        OpenMenuCommand = openMenuCommand;
    }
}