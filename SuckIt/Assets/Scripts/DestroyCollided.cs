using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;
public class DestroyCollided : MonoBehaviour
{
    [SerializeField] Core core = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killable")
        {
            Destroy(other.gameObject);
            if(core.isAlive && core.health_Points != 0)
            {
                core.LoseHealth(core.GetLoseHealthMultiplier());
                if(core.health_Points == 0 && !core.isInDebug)
                {
                    core.Die();
                }
            }
            else if(core.health_Points == 0)
            {
                core.Die();
            }
        }
    }
}
