using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummaryWindow : MonoBehaviour
{
    public Text typeText;
    public Text titleText;
    public Text rankText;
    public Text descriptionText;
    public Text stroyLineText;
    public Text rewardText;

    public GameObject[] Pages;
    public GameObject[] Dots;
    public Button NextBtn;
    public Button BackBtn;

    private AnalysisResultsData _data;
    private int _pageIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (NextBtn && NextBtn)
        {
            NextBtn.onClick.AddListener(OnClickNextBtn);
            BackBtn.onClick.AddListener(OnClickBackBtn);
        }
    }

    public void Show(AnalysisResultsData data)
    {
        _data = data;
        SetData();
    }

    public void SetData()
    {
        closeAllPage();
        typeText.text = _data.Type;
        titleText.text = _data.Title;
        rankText.text = _data.Rank;

        descriptionText.text = _data.Description;

        stroyLineText.text = _data.Storyline;
        rewardText.text = _data.Reward;

        _pageIndex = 0;
        Pages[_pageIndex].SetActive(true);
        Dots[_pageIndex].SetActive(true);
        setBtnState();
    }

    public void ReSet()
    {
        _data = null;
        typeText.text = null;
        titleText.text = null;
        rankText.text = null;

        descriptionText.text = null;

        stroyLineText.text = null;
        rewardText.text = null;
        closeAllPage();
    }

    public void OnClickNextBtn()
    {
        if (_pageIndex < Pages.Length)
        {
            Debug.Log("_pageIndex = " + _pageIndex+ "Pages.Length = " + Pages.Length);
            closeAllPage();
            _pageIndex++;
            Pages[_pageIndex].SetActive(true);
            Dots[_pageIndex].SetActive(true);
        }
        setBtnState();
    }

    public void OnClickBackBtn()
    {
        if (_pageIndex > 0)
        {
            closeAllPage();
            _pageIndex--;
            Pages[_pageIndex].SetActive(true);
            Dots[_pageIndex].SetActive(true);
        }
        setBtnState();
    }

    private void setBtnState()
    {
        if(_pageIndex == 0)
        {
            BackBtn.gameObject.SetActive(false);
            NextBtn.gameObject.SetActive(true);
        }
        else if (_pageIndex == Pages.Length - 1)
        {
            BackBtn.gameObject.SetActive(true);
            NextBtn.gameObject.SetActive(false);
        }
        else
        {
            BackBtn.gameObject.SetActive(true);
            NextBtn.gameObject.SetActive(true);
        }
    }

    private void closeAllPage()
    {
        foreach(var go in Pages)
        {
            go.SetActive(false);
        }
        foreach (var go in Dots)
        {
            go.SetActive(false);
        }
    }

    public void CloseWindow()
    {
        gameObject.SetActive(false);
    }
}
