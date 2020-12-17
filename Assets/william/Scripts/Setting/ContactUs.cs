using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactUs : MonoBehaviour
{
    private UrlLinkTool _urlLinkTool = new UrlLinkTool();

    public void TryLink(string url)
    {
        _urlLinkTool.TryLink("請問是否確認要前往連結？", url);
    }
}
