using Diary.App.Databases;

namespace Diary.App.Singletons;

public static class DatabaseSingleton
{
    private static DatabaseContext? _instance;
    private static readonly object Padlock = new();

    public static DatabaseContext Instance
    {
        get
        {
            lock (Padlock)
            {
                _instance ??= new DatabaseContext();
                _instance.Database.EnsureCreated();
                return _instance;
            }
        }
    }
}