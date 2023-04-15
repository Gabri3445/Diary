using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Diary.App.Databases;
using Diary.App.Models;
using Diary.App.Singletons;
using Diary.App.Views;
using Microsoft.EntityFrameworkCore;

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
            if (value != null) _user.Username = value;
            OnPropertyChanged("Username");
        }
    }

    public string? Password
    {
        get => _user.Password;

        set
        {
            if (_user.Password == value) return;
            if (value != null) _user.Password = value;
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
        await RegisterAsync(sender, eventArgs);
    }

    private async Task RegisterAsync(object? sender, EventArgs eventArgs)
    {
        if (Username == "" || Password == "" || Username == null || Password == null) return;

        var user = await _databaseContext.Users.FirstOrDefaultAsync(x => x.Username == Username).ConfigureAwait(false);

        if (user != null) return; // User already exists

        await _databaseContext.Users.AddAsync(new User {Username = Username, Password = Password})
            .ConfigureAwait(false);

        await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

        var view = sender as Register;

        view?.Close();
    }
}