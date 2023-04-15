using System;
using System.ComponentModel;
using System.Linq;
using Diary.App.Models;
using Diary.App.Singletons;
using Diary.App.Views;

namespace Diary.App.ViewModels;

public class LoginViewmodel
{
    private readonly DatabaseContext _databaseContext;
    private readonly User _user;

    public LoginViewmodel()
    {
        _user = new User();
        LoginButtonClicked += Login;
        _databaseContext = DatabaseSingleton.Instance;
    }

    public string Username
    {
        get => _user.Username;

        set
        {
            if (_user.Username == value) return;
            _user.Username = value;
            OnPropertyChanged("Username");
        }
    }

    public string Password
    {
        get => _user.Password;

        set
        {
            if (_user.Password == value) return;
            _user.Password = value;
            OnPropertyChanged("Password");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public event EventHandler? LoginButtonClicked;

    public void InvokeLoginButtonClicked(object sender, EventArgs eventArgs)
    {
        LoginButtonClicked?.Invoke(sender, eventArgs);
    }

    private void Login(object? sender, EventArgs eventArgs)
    {
        if (Username == "" || Password == "" || Username == null || Password == null) return;

        var user = _databaseContext.Users.FirstOrDefault(x => x.Username == Username);

        if (user == null)
        {
            var viewModel = sender as Login;
            viewModel?.Register();
            return;
        }

        if (user.Password != Password) return;

        //Todo create a new main window with the user's data
    }
}