using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject SettingPage;
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
        }
        else
        {
            SettingPage.SetActive(true);
        }
    }
}
