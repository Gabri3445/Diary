using System.ComponentModel;
using Diary.App.Models;

namespace Diary.App.ViewModels;

public class LoginViewmodel
{
    private User _user;

    public LoginViewmodel()
    {
        _user = new User();
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
}