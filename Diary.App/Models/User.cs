using System.Collections.Generic;

namespace Diary.App.Models;

public class User
{
    public int UserId { get; set; }
    public string Username { get; set; }

    public string Password { get; set; }

    public List<DiaryPage> DiaryPages { get; set; }
}