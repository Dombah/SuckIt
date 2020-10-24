using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] 
public class Vacuum : MonoBehaviour
{
    [SerializeField] Scoreboard scoreboard;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Killable")
        {
            Destroy(collider.gameObject);
            if(scoreboard.isAlive)
            {
                scoreboard.AddScore(scoreboard.GetScoreMultiplier());
            } 
        }
    }
}
