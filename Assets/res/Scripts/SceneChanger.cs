using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] AudioClip buttonSE;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        audioSource.PlayOneShot(buttonSE);
        Invoke("SceneChane", 0.4f);
    }

    void SceneChane()
    {
        SceneManager.LoadScene(sceneName);
    }
}
