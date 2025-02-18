using System.Windows.Controls;

using SnpPlayzone.ViewModels;

namespace SnpPlayzone.Views;

public partial class ChildEntryPage : Page
{
    public ChildEntryPage(ChildEntryViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
