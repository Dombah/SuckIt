using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] 
public class Vacumm : MonoBehaviour
{
    [SerializeField] Scoreboard scoreboard;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Killable")
        {
            Destroy(collider.gameObject);
            scoreboard.AddScore(2);
        }
    }
}
