using System.Windows.Controls;

using MahApps.Metro.Controls;

using SnpPlayzone.Behaviors;

namespace SnpPlayzone.Contracts.Views;

public interface IShellWindow
{
    Frame GetNavigationFrame();

    void ShowWindow();

    void CloseWindow();

    Frame GetRightPaneFrame();

    SplitView GetSplitView();

    RibbonTabsBehavior GetRibbonTabsBehavior();
}
