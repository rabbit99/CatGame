using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Rabbit")]
    public static void CreateRabbitAssetFile()
    {
        Rabbit asset = CustomAssetUtility.CreateAsset<Rabbit>();
        asset.SheetName = "TextContent";
        asset.WorksheetName = "Rabbit";
        EditorUtility.SetDirty(asset);        
    }
    
}