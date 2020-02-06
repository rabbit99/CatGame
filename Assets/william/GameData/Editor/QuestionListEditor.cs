using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(QuestionList))]
public class QuestionListEditor : BaseGoogleEditor<QuestionList>
{	    
    public override bool Load()
    {        
        QuestionList targetData = target as QuestionList;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<QuestionListData>(targetData.WorksheetName) ?? db.CreateTable<QuestionListData>(targetData.WorksheetName);
        
        List<QuestionListData> myDataList = new List<QuestionListData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            QuestionListData data = new QuestionListData();
            
            data = Cloner.DeepCopy<QuestionListData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
