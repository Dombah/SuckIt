using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    #region Variables
    float currentTime = 0f;
    float startingTime = 4.49f;
    [SerializeField] Text timeText = null;
    #endregion

    public event EventHandler<OnCountdownFinishedEventArgs> OnCountdownFinished;
    public class OnCountdownFinishedEventArgs : EventArgs 
    {
        public bool startSpawning;
    }

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        if (this.enabled) { timeText.enabled = true; } // Enable text object when the script is active
        if(currentTime <= 0f) // Disable component when countdown reaches 0
        {
           OnCountdownFinished?.Invoke(this, new OnCountdownFinishedEventArgs { startSpawning = true }); // Send message to spawner to start spawning
           currentTime = startingTime;
           timeText.enabled = false;
           this.enabled = false;
        }
        else if(currentTime >= .5f) 
        {
            DecreaseTime();
            timeText.text = currentTime.ToString("0");
        }
        else // When near 0 print GO 
        {
            DecreaseTime();
            timeText.text = "GO";
        }
    }
    private void DecreaseTime()
    {
        currentTime -= 1f * Time.deltaTime;
    }
}
