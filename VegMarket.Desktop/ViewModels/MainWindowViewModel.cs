using System;
using System.Collections.ObjectModel;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace VegMarket.Desktop.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    [Reactive] public bool IsPaneOpen { get; set; }
    
    [Reactive] public string? TitlePage { get; set; }
    [Reactive] public ViewModelBase? CurrentPage { get; set; }

    public ReadOnlyObservableCollection<TogglePaneItemTemplate> TogglePaneItems { get; } = new([
        new TogglePaneItemTemplate(new MarketPageViewModel(), "HomeRegular"),
        new TogglePaneItemTemplate(new CartPageViewModel(), "CartRegular"),
        new TogglePaneItemTemplate(new UserPageViewModel(), "PersonRegular")
    ]);
    [Reactive] public TogglePaneItemTemplate? SelectedTogglePaneItem { get; set; }

    public MainWindowViewModel()
    {
        this.WhenAnyValue(p1 => p1.SelectedTogglePaneItem)
            .Subscribe(OnSelectedTogglePaneItemChanged);
        
        SelectedTogglePaneItem = TogglePaneItems[0];
    }
    
    public void TogglePane()
    {
        IsPaneOpen = !IsPaneOpen;
    }

    private void OnSelectedTogglePaneItemChanged(TogglePaneItemTemplate? item)
    {
        if (item == null) return;
        CurrentPage = item.ViewModel;

        TitlePage = item.Title;
    }
}

public class TogglePaneItemTemplate(ViewModelBase viewModel, string iconKey)
{
    public string Title { get; set; } = viewModel.Title;
    public ViewModelBase ViewModel { get; set; } = viewModel;
    public StreamGeometry Icon { get; set; } = (StreamGeometry)Application.Current!.FindResource(iconKey)!;
}