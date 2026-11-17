using System;
using System.Collections.Generic;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace katalog;

public partial class ListScreen : UserControl
{
    private CatalogRepository _repository = new();
    private Action<CatalogItem> _showDetails = _ => throw new InvalidOperationException(
        "Ekran listy nie został skonfigurowany.");
    private Action _showAddForm = () => throw new InvalidOperationException(
        "Ekran listy nie został skonfigurowany.");
    private List<CatalogItem> _items = [];

    public ListScreen()
    {
        InitializeComponent();
    }

    public void Configure(
        CatalogRepository repository,
        Action<CatalogItem> showDetails,
        Action showAddForm)
    {
        _repository = repository;
        _showDetails = showDetails;
        _showAddForm = showAddForm;
        RefreshItems();
    }

    private void RefreshItems()
    {
        try
        {
            _items = _repository.LoadAll();
            ItemsList.Items.Clear();

            foreach (var item in _items)
            {
                ItemsList.Items.Add($"{item.Title} ({item.Year}) — ocena {item.Rating}/10");
            }
        }
        catch (FormatException error)
        {
            StatusText.Text = error.Message;
        }
        catch (IOException error)
        {
            StatusText.Text = $"Nie udało się odczytać pliku: {error.Message}";
        }
        catch (UnauthorizedAccessException error)
        {
            StatusText.Text = $"Brak uprawnień do odczytu pliku: {error.Message}";
        }
    }

    private void OnDetailsClick(object? sender, RoutedEventArgs e)
    {
        if (ItemsList.SelectedIndex < 0)
        {
            StatusText.Text = "Najpierw wybierz pozycję z listy.";
            return;
        }

        _showDetails(_items[ItemsList.SelectedIndex]);
    }

    private void OnAddClick(object? sender, RoutedEventArgs e)
    {
        _showAddForm();
    }

    private void OnCountClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            var count = _repository.CountLines();
            StatusText.Text = $"Pozycji w pliku: {count}";
        }
        catch (IOException error)
        {
            StatusText.Text = $"Nie udało się odczytać pliku: {error.Message}";
        }
        catch (UnauthorizedAccessException error)
        {
            StatusText.Text = $"Brak uprawnień do odczytu pliku: {error.Message}";
        }
    }
}
