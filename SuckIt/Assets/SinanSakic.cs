using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SinanSakic : MonoBehaviour
{

   [SerializeField] AudioClip trezan;
   [SerializeField] AudioSource audioSource;
   [SerializeField] int sinanBuildIndex = 1;
   [SerializeField] float timeToLoadScene = 2f;

    public void Trezan()
    {
        audioSource.PlayOneShot(trezan);
        Invoke("LoadScene", timeToLoadScene);
    }
    
    private void LoadScene()
    {
        DontDestroyOnLoad(audioSource);
        SceneManager.LoadScene(sinanBuildIndex);
    }  
}

