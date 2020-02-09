using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteTwinkling : MonoBehaviour
{
    private Button _imgBtn;
    // Start is called before the first frame update
    void Start()
    {
        _imgBtn = GetComponent<Button>();
        StartCoroutine(twinking());
    }

    IEnumerator twinking()
    {
        float a = 255f;
        while (true)
        {
            Debug.Log("twinking a "+ a);
            if(a >= 0)
            {
                a -= Time.deltaTime * 10;
                _imgBtn.image.color = new Color(255, 255, 225, a);
                
            }
            else
            {
                a += Time.deltaTime * 10;
                _imgBtn.image.color = new Color(255, 255, 225, a);
                
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
