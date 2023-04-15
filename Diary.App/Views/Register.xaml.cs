using System.Windows;
using Diary.App.ViewModels;

namespace Diary.App.Views;

public partial class Register : Window
{
    private readonly RegisterViewModel? _dataContext;

    public Register()
    {
        InitializeComponent();
        _dataContext = DataContext as RegisterViewModel;
    }

    private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
    {
        _dataContext?.InvokeRegisterButtonClicked(this, e);
    }
}