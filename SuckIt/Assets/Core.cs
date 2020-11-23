using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class Core : MonoBehaviour
    {
        #region Variables
        // Scoreboard dependand variables
        [SerializeField] public int health_Points = 100;
        [SerializeField] public int score_Points = 0;

        // Vacumm and DestroyCollided dependand variables
        [SerializeField] int score_Multiplier = 50;
        [SerializeField] int loseHealth_Multiplier = 10;

        public bool isAlive = true;
        public bool isInDebug = false;
        #endregion

        public int GetScoreMultiplier()
        {
            return score_Multiplier;
        }
        public int GetLoseHealthMultiplier()
        {
            return loseHealth_Multiplier;
        }

        public void AddScore(int score)
        {
            score_Points += score;
        }
        public void LoseHealth(int health)
        {
            health_Points -= health;           
        }

        public void Die()
        {
            if(!isInDebug)
            {
                print("yo??");
                isAlive = false;
            }
        }
    }
}
