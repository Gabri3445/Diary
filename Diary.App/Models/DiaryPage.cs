using System;

namespace Diary.App.Models;

public class DiaryPage
{
    public int DiaryPageId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime TimeOfCreation { get; set; }
}