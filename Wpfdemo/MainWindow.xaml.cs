using System.Windows;
using Wpfdemo.ViewModels;

namespace Wpfdemo;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel mainViewModel)
    {
        InitializeComponent();

        DataContext = mainViewModel;
    }
}