using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Game.Core;

public class Scoreboard : MonoBehaviour
{
    #region Variables
    [SerializeField ]Text scorePoints = null;
    [SerializeField] Text healthPoints = null;

    [SerializeField] Core core = null;
    #endregion

    private void Update()
    {
        scorePoints.text = core.score_Points.ToString();
        healthPoints.text = core.health_Points.ToString();
    }
}

