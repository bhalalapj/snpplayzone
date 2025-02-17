using System.Windows.Controls;

namespace SnpPlayzone.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}
