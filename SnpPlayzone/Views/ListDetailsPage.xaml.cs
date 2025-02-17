using System.Windows.Controls;

using SnpPlayzone.ViewModels;

namespace SnpPlayzone.Views;

public partial class ListDetailsPage : Page
{
    public ListDetailsPage(ListDetailsViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
