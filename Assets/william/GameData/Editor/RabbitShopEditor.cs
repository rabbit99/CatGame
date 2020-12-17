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
[CustomEditor(typeof(RabbitShop))]
public class RabbitShopEditor : BaseGoogleEditor<RabbitShop>
{	    
    public override bool Load()
    {        
        RabbitShop targetData = target as RabbitShop;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<RabbitShopData>(targetData.WorksheetName) ?? db.CreateTable<RabbitShopData>(targetData.WorksheetName);
        
        List<RabbitShopData> myDataList = new List<RabbitShopData>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            RabbitShopData data = new RabbitShopData();
            
            data = Cloner.DeepCopy<RabbitShopData>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
