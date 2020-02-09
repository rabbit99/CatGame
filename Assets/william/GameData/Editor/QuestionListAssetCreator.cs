using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/QuestionList")]
    public static void CreateQuestionListAssetFile()
    {
        QuestionList asset = CustomAssetUtility.CreateAsset<QuestionList>();
        asset.SheetName = "TextContent";
        asset.WorksheetName = "QuestionList";
        EditorUtility.SetDirty(asset);        
    }
    
}