using Avalonia.Controls;

namespace katalog;

public partial class MainWindow : Window
{
    private readonly CatalogRepository _repository;

    public MainWindow()
    {
        InitializeComponent();
        _repository = new CatalogRepository();
        ShowList();
    }

    private void ShowList()
    {
        var screen = new ListScreen();
        screen.Configure(
            _repository,
            ShowDetails,
            ShowAddForm);
        ScreenContent.Content = screen;
    }

    private void ShowDetails(CatalogItem item)
    {
        var screen = new DetailsScreen();
        screen.Configure(item, ShowList);
        ScreenContent.Content = screen;
    }

    private void ShowAddForm()
    {
        var screen = new AddScreen();
        screen.Configure(_repository, ShowList);
        ScreenContent.Content = screen;
    }
}
