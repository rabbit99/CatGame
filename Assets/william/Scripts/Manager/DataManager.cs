using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    static protected DataManager s_DataManager;
    static public DataManager Instance { get { return s_DataManager; } }

    public PlayerData playerData;
    void Awake()
    {
        s_DataManager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!Load())
        {
            CreateNewPlayerData();
        }
    }

    public bool Load()
    {
        object playerDataObj;
        try
        {
            playerDataObj = ES3.Load("myPlayerData");
        }
        catch
        {
            Debug.Log("Load catch failed");
            return false;
        }

        if (playerDataObj == null)
        {
            Debug.Log("Load failed");
            return false;
        }
        else
        {
            Debug.Log("Load success");
            playerData = playerDataObj as PlayerData;
            return true;
        }
    }
    public void CreateNewPlayerData()
    {
        playerData = new PlayerData();
        save();
    }


    public void Save()
    {
        save();
    }

    private void save()
    {
        ES3.Save("myPlayerData", playerData);
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (Input.GetKeyDown(KeyCode.M))
        {
            playerData.rabbitPoint += 10;
            Debug.Log("playerData rabbitPoint = "+ playerData.rabbitPoint);
            ES3.Save("myPlayerData", playerData);
        }
    }

    public bool PurchaseByRabbit(string itemName,int rabbitPoint)
    {
        if (!string.IsNullOrEmpty(playerData.bagItems.Find((x) => x == itemName)))
        {
            Debug.LogError("You already have");
            return false;
        }
         
            
        if (playerData.rabbitPoint - rabbitPoint >= 0)
        {
            playerData.rabbitPoint -= rabbitPoint;
            playerData.bagItems.Add(itemName);
            ES3.Save("myPlayerData", playerData);
            return true;
        }
        else
        {
            Debug.LogError("Insufficient funds");
            return false;
        }
    }

    public bool CheckHasPurchased(string itemName)
    {
        if (!string.IsNullOrEmpty(playerData.bagItems.Find((x) => x == itemName)))
        {
            Debug.LogError("You already have");
            return true;
        }
        else
        {
            return false;
        }
    }
}
