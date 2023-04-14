using System.Windows;
using Diary.App.ViewModels;

namespace Diary.App.Views;

public partial class Login : Window
{
    private readonly LoginViewmodel? _dataContext;

    public Login()
    {
        InitializeComponent();
        _dataContext = DataContext as LoginViewmodel;
    }

    private void LoginButton_OnClick(object sender, RoutedEventArgs e)
    {
        _dataContext?.InvokeLoginButtonClicked(sender, e);
    }
}