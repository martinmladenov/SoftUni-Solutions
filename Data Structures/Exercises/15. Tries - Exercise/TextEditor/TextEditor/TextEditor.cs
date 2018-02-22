using System.Collections.Generic;
using System.Text;

public class TextEditor : ITextEditor
{

    Trie<StringBuilder> userTexts;
    Trie<Stack<string>> userHistory;


    public TextEditor()
    {
        userTexts = new Trie<StringBuilder>();
        userHistory = new Trie<Stack<string>>();
    }

    public void Login(string username)
    {
        userTexts.Insert(username, new StringBuilder());
        if (!userHistory.Contains(username))
            userHistory.Insert(username, new Stack<string>());
    }

    public void Logout(string username)
    {
        userTexts.Delete(username);
        userHistory.Delete(username);
    }

    public void Prepend(string username, string str)
    {
        this.Insert(username, 0, str);
    }

    public void Insert(string username, int index, string str)
    {
        if (!userTexts.Contains(username))
        {
            return;
        }

        this.PushToHistory(username);

        userTexts.GetValue(username).Insert(index, str);
    }

    public void Substring(string username, int startIndex, int length)
    {
        if (!userTexts.Contains(username))
        {
            return;
        }

        this.PushToHistory(username);

        var sb = userTexts.GetValue(username);
        sb.Remove(0, startIndex);
        sb.Remove(length, sb.Length - length);
    }

    public void Delete(string username, int startIndex, int length)
    {
        if (!userTexts.Contains(username))
        {
            return;
        }

        this.PushToHistory(username);

        var sb = userTexts.GetValue(username);
        sb.Remove(startIndex, length);
    }

    public void Clear(string username)
    {
        if (!userTexts.Contains(username))
        {
            return;
        }

        this.PushToHistory(username);

        userTexts.Insert(username, new StringBuilder());
    }

    public int Length(string username)
    {
        if (!userTexts.Contains(username))
        {
            return 0;
        }

        return userTexts.GetValue(username).Length;
    }

    public string Print(string username)
    {
        if (!userTexts.Contains(username))
        {
            return string.Empty;
        }

        return userTexts.GetValue(username).ToString();
    }

    public void Undo(string username)
    {
        //Environment.Exit(0);
        if (!userTexts.Contains(username))
        {
            return;
        }

        var history = userHistory.GetValue(username);

        if (history.Count == 0)
        {
            return;
        }

        userTexts.Insert(username, new StringBuilder(history.Pop()));
    }

    public IEnumerable<string> Users(string prefix = "")
    {
        return userTexts.GetByPrefix(prefix);
    }

    private void PushToHistory(string user)
    {
        userHistory.GetValue(user).Push(userTexts.GetValue(user).ToString());
    }
}

