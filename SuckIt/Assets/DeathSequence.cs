using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSequence : MonoBehaviour
{
    [SerializeField] Animator deathSequenceAnimation;
    [SerializeField] GameObject[] imagesToSet;
    [SerializeField] Spawner spawner;

    Scoreboard scoreboard;
    private void Awake()
    {
        scoreboard = GetComponent<Scoreboard>();
    }
    void Update()
    {
        if(!CheckAnimatorValidity()) { return; }
        ProcessDeathSequence();
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
        if (!scoreboard.isAlive)
        {
            SetImageVisibility(true);
            deathSequenceAnimation.SetBool("isAlive", false);          
        }
    }

    public void SetImageVisibility(bool state)
    {
        foreach (GameObject objects in imagesToSet)
        {
            objects.SetActive(state);
        }
    }

    public void RevertDeathSequence()
    {
        deathSequenceAnimation.SetTrigger("RevertDeathSequence");
        scoreboard.isAlive = true;
        deathSequenceAnimation.SetBool("isAlive", true);
        scoreboard.health_Points = 100;
        StartCoroutine(SetFalseAfterTime(1f));
        StartCoroutine(spawner.SpawnTrash());
    }

    IEnumerator SetFalseAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        SetImageVisibility(false);
    }
 
}
