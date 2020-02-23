using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPage : MonoBehaviour
{
    public Image LoadingImage;
    public TextMeshProUGUI LoadingText;
    public RectTransform LoadingImageGo;
    public float WaitSec = 2f;
    public List<Sprite> LoadingCGs = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Show()
    {
        LoadingImage.raycastTarget = true;
        int index = Random.Range(0, 5);
        LoadingImage.sprite = LoadingCGs[index];
        
        //gameObject.SetActive(true);
        DOTween.ToAlpha(() => LoadingImage.color, x => LoadingImage.color = x, 1, 0.5f);
        DOTween.ToAlpha(() => LoadingText.color, x => LoadingText.color = x, 1, 0.5f);
        //auto close
        StartCoroutine(Close());
    }

    IEnumerator Close()
    {
        yield return new WaitForSeconds(WaitSec);
        //gameObject.SetActive(false);
        DOTween.ToAlpha(() => LoadingImage.color, x => LoadingImage.color = x, 0, 0.5f);
        DOTween.ToAlpha(() => LoadingText.color, x => LoadingText.color = x, 0, 0.5f);
        LoadingImage.raycastTarget = false;
    }
}
