using System;

namespace Models.Classes;

public class Message
{

    private string? content;
    public string? Content
    {
        get { return content; }
        set
        {
            content = value;
        }
    }
    

}