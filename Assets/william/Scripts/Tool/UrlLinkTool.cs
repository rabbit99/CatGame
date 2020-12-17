using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlLinkTool
{
    private string _url;
    public void TryLink(string _message, string url)
    {
        _url = url;
        SettingManager.SettingManagerInstance.commonSelect.Show(_message, GotoLink);
    }

    public void GotoLink(bool result)
    {
        if (result && !string.IsNullOrEmpty(_url))
            Application.OpenURL(_url);

    }
}
