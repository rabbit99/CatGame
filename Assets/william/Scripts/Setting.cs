using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject SettingPage;
    public GameObject MenuBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowSettingPage()
    {
        if (SettingPage.activeSelf)
        {
            SettingPage.SetActive(false);
            MenuBtn.SetActive(true);
        }
        else
        {
            SettingPage.SetActive(true);
            MenuBtn.SetActive(false);
        }
    }
}
