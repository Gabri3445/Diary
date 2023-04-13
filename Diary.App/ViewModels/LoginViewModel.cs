using System;
using System.ComponentModel;
using System.Windows.Input;
using Diary.App.Models;

namespace Diary.App.ViewModels;

public class LoginViewmodel
{
    private User _user;

    public LoginViewmodel()
    {
        _user = new User();
        LoginCommand = new RelayCommand(Login);
    }

    private void Login(object o)
    {
        Username = "Giglo";
    }

    public string Username
    {
        get => _user.Username;

        set
        {
            if (_user.Username == value) return;
            _user.Username = value;
            Console.WriteLine(value);
            OnPropertyChanged("Username");
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand LoginCommand { get; set; }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}