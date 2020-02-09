using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/AnalysisResults")]
    public static void CreateAnalysisResultsAssetFile()
    {
        AnalysisResults asset = CustomAssetUtility.CreateAsset<AnalysisResults>();
        asset.SheetName = "TextContent";
        asset.WorksheetName = "AnalysisResults";
        EditorUtility.SetDirty(asset);        
    }
    
}