using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommonSelect : MonoBehaviour
{
    public Text message;
    public delegate void RequetstAction(bool result);
    public RequetstAction requetstAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show(string _message, RequetstAction _requetstAction)
    {
        message.text = _message;
        if (_requetstAction != null)
            requetstAction = _requetstAction;
        this.gameObject.SetActive(true);
    }

    public void Close(bool result)
    {
        if (requetstAction != null)
        {
            requetstAction(result);
            requetstAction = null;
        }
        this.gameObject.SetActive(false);
    }
}
