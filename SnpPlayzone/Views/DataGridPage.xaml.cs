using System.Windows.Controls;

using SnpPlayzone.ViewModels;

namespace SnpPlayzone.Views;

public partial class DataGridPage : Page
{
    public DataGridPage(DataGridViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
