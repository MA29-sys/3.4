using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class AddScreen : UserControl
{
    private CatalogRepository _repository = new();
    private Action _showList = () => throw new InvalidOperationException(
        "Ekran dodawania nie został skonfigurowany.");

    public AddScreen()
    {
        InitializeComponent();
    }

    public void Configure(CatalogRepository repository, Action showList)
    {
        _repository = repository;
        _showList = showList;
    }

    private void OnSaveClick(object? sender, RoutedEventArgs e)
    {
        if (!int.TryParse(YearInput.Text, out var year))
        {
            StatusText.Text = "Wpisz poprawny rok.";
            return;
        }

        if (!int.TryParse(RatingInput.Text, out var rating))
        {
            StatusText.Text = "Wpisz ocenę od 1 do 10.";
            return;
        }

        try
        {
            _repository.Add(new CatalogItem(TitleInput.Text ?? "", year, rating));
            _showList();
        }
        catch (ArgumentException error)
        {
            StatusText.Text = error.Message;
        }
        catch (IOException error)
        {
            StatusText.Text = $"Nie udało się zapisać pliku: {error.Message}";
        }
        catch (UnauthorizedAccessException error)
        {
            StatusText.Text = $"Brak uprawnień do zapisu pliku: {error.Message}";
        }
    }

    private void OnCancelClick(object? sender, RoutedEventArgs e)
    {
        _showList();
    }
}
