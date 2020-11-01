using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSequence : MonoBehaviour
{

    [SerializeField] Scoreboard scoreboard;
    [SerializeField] Animator animator;

    void Update()
    {
        if(!scoreboard.isAlive)
        {
            animator.SetBool("isAlive", false);
        }
    }
}
