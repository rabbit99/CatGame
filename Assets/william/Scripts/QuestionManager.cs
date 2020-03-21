using Fungus;
using Live2D.Cubism.Framework.Expression;
using System.Collections;
using System.Linq;
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
    private AnalysisResults _analysisResults;
    private AnalysisResultsData[] _analysisResultsDatas;
    private int _questionIndex = 0;
    private int _dollStateIndex = -1;
    private Color _highlight;
    private Color _normal;
    private Dictionary<string, int> summaryDic = new Dictionary<string, int>();

    private string[] Mbtis = new string[8] { "E", "I" ,"S","N","T","F","J","P"};
    // Start is called before the first frame update
    void Start()
    {
        initExcelData();
        initDic();
        _highlight = OptionBtns[0].GetComponentInChildren<Button>().colors.highlightedColor;
        _normal = OptionBtns[0].GetComponentInChildren<Button>().colors.normalColor;
    }

    private void initExcelData()
    {
        _questionList = Resources.Load<QuestionList>("Data/QuestionList");
        _questionListDatas = _questionList.dataArray;
        //Debug.Log(_questionListDatas[0].Question);
        _analysisResults = Resources.Load<AnalysisResults>("Data/AnalysisResults");
        _analysisResultsDatas = _analysisResults.dataArray;
    }

    private void initDic()
    {
        summaryDic.Clear();
        foreach (var go in Mbtis)
        {
            summaryDic.Add(go, 0);
        }
    }

    public void SetQuestion()
    {
        Flowchart.SetStringVariable("_question", _questionListDatas[_questionIndex].Question);
        string zero = null;
        if(_questionIndex + 1 < 10)
        {
            zero = "0";
        }
        PageNum.text = zero + (_questionIndex + 1) + "/" + _questionListDatas.Length;
        
        setDollStateIndex();
    }

    public void SetOption()
    {
        OptionBtns[0].GetComponentInChildren<Text>().text = _questionListDatas[_questionIndex].Option1;
        OptionBtns[1].GetComponentInChildren<Text>().text = _questionListDatas[_questionIndex].Option2;
        OptionBtns[2].GetComponentInChildren<Text>().text = _questionListDatas[_questionIndex].Option3;
        foreach (var btn in OptionBtns)
        {
            btn.GetComponentInChildren<Button>().interactable = true;
            btn.GetComponentInChildren<Button>().targetGraphic.color = _normal;
        }
    }

    public void Reset()
    {
        _questionIndex = 0;
        _dollStateIndex = -1;
        initDic();
        SummaryWindow.ReSet();
        Flowchart.SetBooleanVariable("testFinish", false);
        Flowchart.ExecuteBlock("Reset");
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
        Debug.Log("_questionIndex = " + _questionIndex);
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

        if (_questionIndex == _questionListDatas.Length - 1)
        {
            Flowchart.SetBooleanVariable("testFinish", true);
            SummaryWindow.Show(checkAnalysisResultsData());
        }
        else
        {
            _questionIndex++;
           
        }
        Flowchart.ExecuteBlock("check");
        setDollStateIndex();
    }

    private void setDollStateIndex()
    {
        //if (_dollStateIndex >= 4)
        //{
        //    _dollStateIndex = 0;
        //}
        //else
        //{
        //    _dollStateIndex++;
        //}
        int _dollStateIndex = Random.Range(0, Live2dDollController.ExpressionsList.CubismExpressionObjects.Length);
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

    private AnalysisResultsData checkAnalysisResultsData()
    {
        AnalysisResultsData data = new AnalysisResultsData();

        List<string> result = new List<string>();

        string key = null;
        foreach (KeyValuePair<string, int> kvp in summaryDic) {
            Debug.Log(string.Format("key = {0}, value = {1}", kvp.Key, kvp.Value));
            switch (kvp.Key)
            {
                case "E":
                    pickKey(ref key, "E","I");
                    result.Add(key);
                    break;
                case "S":
                    pickKey(ref key, "S", "N");
                    result.Add(key);
                    break;
                case "T":
                    pickKey(ref key, "T", "F");
                    result.Add(key);
                    break;
                case "J":
                    pickKey(ref key, "J", "P");
                    result.Add(key);
                    break;
            }
        }
        
        string strTemp1 = string.Join("", result.ToArray());
        Debug.Log("result Count = " + result.Count + " result = " + strTemp1);

        List<AnalysisResultsData> lst = _analysisResultsDatas.ToList();
        data = lst.Find(type => type.Type == strTemp1);

        return data;
    }

    private void pickKey(ref string _key,string key1, string key2)
    {
        if(summaryDic[key1] > summaryDic[key2])
        {
            _key = key1;
        }
        else if (summaryDic[key1] < summaryDic[key2])
        {
            _key = key2;
        }
        else if(summaryDic[key1] == summaryDic[key2])
        {
            if(Random.Range(0, 2) == 0)
            {
                _key = key1;
            }
            else
            {
                _key = key2;
            }
        }
    }

    public void PlayCursorSound()
    {
        AudioController.Play("Cursor");
    }

    public void PlayBackSound()
    {
        AudioController.Play("Back");
    }

    public void RandomMusic()
    {
        AudioController.PlayMusic("InGameBgm");
    }
}
