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
[CustomEditor(typeof(AnalysisResults))]
public class AnalysisResultsEditor : BaseGoogleEditor<AnalysisResults>
{	    
    public override bool Load()
    {        
        AnalysisResults targetData = target as AnalysisResults;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<AnalysisResultsData>(targetData.WorksheetName) ?? db.CreateTable<AnalysisResultsData>(targetData.WorksheetName);
        
        List<AnalysisResultsData> myDataList = new List<AnalysisResultsData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            AnalysisResultsData data = new AnalysisResultsData();
            
            data = Cloner.DeepCopy<AnalysisResultsData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
