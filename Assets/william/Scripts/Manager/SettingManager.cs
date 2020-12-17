using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    static protected SettingManager s_SettingManager;
    static public SettingManager SettingManagerInstance { get { return s_SettingManager; } }

    public List<GameObject> pageObjs = new List<GameObject>();
    public GameObject currentPage = null;
    public GameObject rabbitNum;
    public Setting _setting;

    public CommonSelect commonSelect;

    private GameObject lastPage = null;
    // Start is called before the first frame update
    void Awake()
    {
        s_SettingManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPage(string pageName)
    {
        if (currentPage)
            currentPage.SetActive(false);
        else
            pageName = "SettingBody";
        GameObject _page = pageObjs.Find((x) => x.name == pageName);
        if(_page)
        {
            _page.SetActive(true);
            if (_page.name == "RabbitShopBody" || _page.name == "SettingBody")
                rabbitNum.SetActive(true);
            else
                rabbitNum.SetActive(false);
            lastPage = currentPage;
            currentPage = _page;
        }
    }

    public void Back()
    {
        if (lastPage && currentPage.name != "SettingBody")
        {
            lastPage.SetActive(true);
            currentPage.SetActive(false);
            currentPage = lastPage;
        }
        else
        {
            _setting.ShowSettingPage();
        }
    }
}
