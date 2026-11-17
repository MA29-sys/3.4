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
        if (!TryReadItem(out var item) || item is null)
        {
            return;
        }

        if (SaveItem(item))
        {
            _showList();
        }
    }

    private bool TryReadItem(out CatalogItem? item)
    {
        item = null;
        if (!int.TryParse(YearInput.Text, out var year))
        {
            StatusText.Text = "Wpisz poprawny rok.";
            return false;
        }

        if (!int.TryParse(RatingInput.Text, out var rating))
        {
            StatusText.Text = "Wpisz ocenę od 1 do 10.";
            return false;
        }

        item = new CatalogItem(TitleInput.Text ?? "", year, rating);
        return true;
    }

    private bool SaveItem(CatalogItem item)
    {
        try
        {
            _repository.Add(item);
            return true;
        }
        catch (ArgumentException error)
        {
            StatusText.Text = error.Message;
            return false;
        }
        catch (IOException error)
        {
            StatusText.Text = $"Nie udało się zapisać pliku: {error.Message}";
            return false;
        }
        catch (UnauthorizedAccessException error)
        {
            StatusText.Text = $"Brak uprawnień do zapisu pliku: {error.Message}";
            return false;
        }
    }

    private void OnCancelClick(object? sender, RoutedEventArgs e)
    {
        _showList();
    }
}
