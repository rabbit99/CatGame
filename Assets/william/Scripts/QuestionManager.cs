using Fungus;
using Live2D.Cubism.Framework.Expression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject[] OptionBtns;
    public GameObject PageIndex;
    public Flowchart Flowchart;
    public Text PageNum;
    public CubismExpressionController Live2dDollController;
    public SummaryWindow SummaryWindow;

    private QuestionList _questionList;
    private QuestionListData[] _questionListDatas;
    private int _questionIndex = 0;
    private int _dollStateIndex = -1;
    private int _answernum = 0;
    private Color _highlight;
    private Color _normal;
    private Dictionary<string, int> summaryDic = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        _questionList = Resources.Load<QuestionList>("Data/QuestionList");
        _questionListDatas = _questionList.dataArray;
        //Debug.Log(_questionListDatas[0].Question);

        _highlight = OptionBtns[0].GetComponentInChildren<Button>().colors.highlightedColor;
        _normal = OptionBtns[0].GetComponentInChildren<Button>().colors.normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuestion()
    {
       
        Flowchart.SetStringVariable("_question", _questionListDatas[_questionIndex].Question);
        OptionBtns[0].GetComponentInChildren<Text>().text = _questionListDatas[_questionIndex].Option1;
        OptionBtns[1].GetComponentInChildren<Text>().text = _questionListDatas[_questionIndex].Option2;
        OptionBtns[2].GetComponentInChildren<Text>().text = _questionListDatas[_questionIndex].Option3;
        //_answernum = _questionListDatas[_questionIndex].Answernum;
        PageNum.text = (_questionIndex + 1) + "/" + _questionListDatas.Length;
        foreach (var btn in OptionBtns)
        {
            btn.GetComponentInChildren<Button>().interactable = true;
            btn.GetComponentInChildren<Button>().targetGraphic.color = _normal;
        }
        _questionIndex++;
        setDollStateIndex();
    }

    public void Reset()
    {
        _questionIndex = 0;
        Flowchart.SetBooleanVariable("testFinish", false);
        Flowchart.ExecuteBlock("QuestionStateStart");
    }

    public void Reply(int check)
    {
        foreach(var btn in OptionBtns)
        {
            btn.GetComponentInChildren<Button>().interactable = false;
            
        }
        OptionBtns[check-1].GetComponentInChildren<Button>().targetGraphic.color = _highlight;
        //if (check == _answernum)
        //{
        //    Flowchart.ExecuteBlock("rightAnswer");
        //}
        //else
        //{
        //    Flowchart.ExecuteBlock("wrongAnswer");
        //}
        string ans = null;
        switch (check)
        {
            case 1:
                ans = _questionListDatas[_questionIndex].Mbti1;
                break;
            case 2:
                ans = _questionListDatas[_questionIndex].Mbti2;
                break;
            case 3:
                ans = _questionListDatas[_questionIndex].Mbti3;
                break;
        }
        if (!string.IsNullOrEmpty(ans))
        {
            addToSummaryDic(ans);
        }

        if (_questionIndex == _questionListDatas.Length)
        {
            Flowchart.SetBooleanVariable("testFinish", true);
            SummaryWindow.Show();
        }

        setDollStateIndex();
        Flowchart.ExecuteBlock("check");
    }

    private void setDollStateIndex()
    {
        if (_dollStateIndex >= 4)
        {
            _dollStateIndex = 0;
        }
        else
        {
            _dollStateIndex++;
        }
        Live2dDollController.CurrentExpressionIndex = _dollStateIndex;
    }

    private void addToSummaryDic(string ans)
    {
        if (!summaryDic.ContainsKey(ans))
        {
            summaryDic.Add(ans, 1);
        }
        else
        {
            summaryDic[ans] = summaryDic[ans] + 1;
        }
    }
}
