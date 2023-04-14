using System;
using System.ComponentModel;
using System.Linq;
using Diary.App.Models;
using Diary.App.Singletons;

namespace Diary.App.ViewModels;

public class LoginViewmodel
{
    private User _user;

    public LoginViewmodel()
    {
        _user = new User();
        LoginButtonClicked += Login;
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
        if (Username == "" && Password == "") return;

        var userCollection = DatabaseSingleton.Instance.Users.ToList();
        var user = userCollection.FirstOrDefault(x => x.Username == Username);
        if (user == null) return; //Consider adding a dialogue to register a new user

        if (user.Password != Password) return;

        //Todo create a new main window with the user's data
    }
}