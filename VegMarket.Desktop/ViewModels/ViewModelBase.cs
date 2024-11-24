using ReactiveUI;

namespace VegMarket.Desktop.ViewModels;

public class ViewModelBase : ReactiveObject
{
    public string Title { get; protected init; } = null!;
}