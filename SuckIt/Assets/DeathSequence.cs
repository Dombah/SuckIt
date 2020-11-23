using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;
using System;

public class DeathSequence : MonoBehaviour
{
    #region Variables
    [SerializeField] Animator deathSequenceAnimation = null;
    [SerializeField] GameObject[] imagesToSet = null;
    [SerializeField] Spawner spawner = null;
    [SerializeField] Core core = null;
    #endregion

    void Update()
    {
        if(Debug.isDebugBuild) { ProcessDebugKeys(); } // Not active in final release
        if(!CheckAnimatorValidity()) { return; }
        ProcessDeathSequence();
    }

    private void ProcessDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            core.isInDebug = !core.isInDebug;
        }
    }

    bool CheckAnimatorValidity()
    {
        if (deathSequenceAnimation == null)
        {
            Debug.LogError("Error! The animator is not selected in the inspector field");
            return false;
        }
        if (!deathSequenceAnimation.enabled)
        {
            Debug.LogError("Error! The animator is not enabled on referenced object");
            return false;
        }
        return true;
    }
    private void ProcessDeathSequence()
    {
        if (!core.isAlive)
        {
            SetImageVisibility(true);
            deathSequenceAnimation.SetBool("isAlive", false);          
        }
    }

    public void SetImageVisibility(bool state)
    {
        foreach (GameObject objects in imagesToSet) // Find each object in the array and set state
        {
            objects.SetActive(state);
        }
    }

    public void RevertDeathSequence()
    {
        deathSequenceAnimation.SetTrigger("RevertDeathSequence"); // Trigger animation 
        core.isAlive = true;                           
        deathSequenceAnimation.SetBool("isAlive", true);          // Set animator isAlive variable 
        core.health_Points = 100;                                   
        StartCoroutine(SetFalseAfterTime(deathSequenceAnimation.GetCurrentAnimatorClipInfo(0).Length));  // Disable Image when the animation stops playing      
    }

    IEnumerator SetFalseAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        SetImageVisibility(false);
    }
 
}
