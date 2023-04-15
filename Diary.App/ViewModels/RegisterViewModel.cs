using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Diary.App.Databases;
using Diary.App.Models;
using Diary.App.Singletons;

namespace Diary.App.ViewModels;

public class RegisterViewModel
{
    private readonly DatabaseContext _databaseContext;
    private readonly User _user;

    public RegisterViewModel()
    {
        _user = new User();
        RegisterButtonClicked += Register;
        _databaseContext = DatabaseSingleton.Instance;
    }

    public string? Username
    {
        get => _user.Username;

        set
        {
            if (_user.Username == value) return;
            _user.Username = value;
            OnPropertyChanged("Username");
        }
    }

    public string? Password
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

    public event EventHandler? RegisterButtonClicked;

    public void InvokeRegisterButtonClicked(object sender, EventArgs eventArgs)
    {
        RegisterButtonClicked?.Invoke(sender, eventArgs);
    }

    private async void Register(object? sender, EventArgs eventArgs)
    {
        await RegisterAsync(sender, eventArgs)
    }

    private async Task RegisterAsync(object? sender, EventArgs eventArgs)
    {
        if (Username == "" || Password == "" || Username == null || Password == null) return;

        var user = _databaseContext.Users.FirstOrDefault(x => x.Username == Username);

        if (user != null) return; // User already exists

        _databaseContext.Users.Add(new User { Username = Username, Password = Password });
    }
}