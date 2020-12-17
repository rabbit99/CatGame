using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/RabbitShop")]
    public static void CreateRabbitShopAssetFile()
    {
        RabbitShop asset = CustomAssetUtility.CreateAsset<RabbitShop>();
        asset.SheetName = "TextContent";
        asset.WorksheetName = "RabbitShop";
        EditorUtility.SetDirty(asset);        
    }
    
}