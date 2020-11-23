using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

[DisallowMultipleComponent] 
public class Vacuum : MonoBehaviour
{
    [SerializeField] Core core = null;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Killable")
        {
            Destroy(collider.gameObject);
            if(core.isAlive)
            {
                core.AddScore(core.GetScoreMultiplier());
            } 
        }
    }
}
