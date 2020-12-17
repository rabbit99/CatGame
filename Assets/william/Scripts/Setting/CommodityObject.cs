using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommodityObject : MonoBehaviour
{
    public Text itemNameText;
    public Text rabbitpointText;
    public string itemName;
    public int rabbitpoint;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetStatus(bool isPurchased)
    {
        if(isPurchased)
            animator.SetTrigger("DoPurchase");
    }

    public void SetData(int index, string _itemName, int _rabbitpoint)
    {
        string zero = null;
        if (index + 1 < 10)
        {
            zero = "0";
        }
        index += 1;
       itemName = zero + index.ToString() + ". " + _itemName;
        itemNameText.text = itemName;
        rabbitpoint = _rabbitpoint;
        zero = null;
        if (_rabbitpoint + 1 < 10)
        {
            zero = "0";
        }
        rabbitpointText.text = zero + _rabbitpoint.ToString();
        if ((DataManager.Instance.CheckHasPurchased(itemName))){
            GetComponent<Button>().interactable = false;
            SetStatus(true);
        }
    }

    public void PurchaseByRabbit()
    {
        if (DataManager.Instance.PurchaseByRabbit(itemName, rabbitpoint))
            animator.SetTrigger("DoPurchase");
    }
}
