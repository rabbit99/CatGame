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
[CustomEditor(typeof(Rabbit))]
public class RabbitEditor : BaseGoogleEditor<Rabbit>
{	    
    public override bool Load()
    {        
        Rabbit targetData = target as Rabbit;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<RabbitData>(targetData.WorksheetName) ?? db.CreateTable<RabbitData>(targetData.WorksheetName);
        
        List<RabbitData> myDataList = new List<RabbitData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            RabbitData data = new RabbitData();
            
            data = Cloner.DeepCopy<RabbitData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
