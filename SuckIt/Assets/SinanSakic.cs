using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinanSakic : MonoBehaviour
{

   [SerializeField] AudioClip trezan;
   [SerializeField] AudioSource audioSource;

    private void Trezan()
    {
        audioSource.PlayOneShot(trezan);
        Invoke("LoadScene", 2f);
    }
    
    private void LoadScene()
    {
        DontDestroyOnLoad(audioSource);
        SceneManager.LoadScene(1);
    }  
}
