using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollided : MonoBehaviour
{
    [SerializeField] Scoreboard scoreboard;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killable")
        {
            Destroy(other.gameObject);
            if(scoreboard.isAlive && scoreboard.GetHealthPoints() != 0)
            {
                scoreboard.LoseHealth(scoreboard.GetLoseHealthMultiplier());
                if(scoreboard.GetHealthPoints() == 0)
                {
                    scoreboard.Die();
                }
            }
        }
    }
}
