using System.Windows.Controls;

using SnpPlayzone.ViewModels;

namespace SnpPlayzone.Views;

public partial class MainPage : Page
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
