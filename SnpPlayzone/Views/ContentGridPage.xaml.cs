using System.Windows.Controls;

using SnpPlayzone.ViewModels;

namespace SnpPlayzone.Views;

public partial class ContentGridPage : Page
{
    public ContentGridPage(ContentGridViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
