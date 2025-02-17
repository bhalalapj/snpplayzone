using System.Windows.Controls;

using SnpPlayzone.ViewModels;

namespace SnpPlayzone.Views;

public partial class SettingsPage : Page
{
    public SettingsPage(SettingsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
