using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class RabbitShopController : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform itemParent;
    public RabbitShop rabbitShop;
    private RabbitShopData[] _rabbitShopDatas;
    // Start is called before the first frame update
    void Start()
    {
        _rabbitShopDatas = rabbitShop.dataArray;
        int index = 0;
        foreach (var go in _rabbitShopDatas)
        {
            GameObject com = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            com.transform.parent = itemParent;
            com.transform.localScale = Vector3.one;
            com.GetComponent<CommodityObject>().SetData(index, _rabbitShopDatas[index].Itemname, _rabbitShopDatas[index].Rabbitpoint);
            index++;
        }
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //test
        if (Input.GetKeyDown(KeyCode.B))
        {
            DataManager.Instance.PurchaseByRabbit("test1", 5);
        }
    }

    public void Show()
    {

    }

}
