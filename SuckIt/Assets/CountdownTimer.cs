using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 4.49f;
    [SerializeField] Text timeText;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.enabled) { timeText.enabled = true; }
        if(currentTime <= 0f)
        {
           currentTime = startingTime;
           timeText.enabled = false;
           this.enabled = false;        
        }
        else if(currentTime >= .5f)
        {
            DecreaseTime();
            timeText.text = currentTime.ToString("0");
            print(currentTime);
        }
        else
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
