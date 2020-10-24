using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Trash : MonoBehaviour
{
    [SerializeField] float movingSpeedFactor = 1f;
    Vector3 movingDir;

    [SerializeField] float timeAtNextSpawn = 15f; //   TODO
    [SerializeField] float timeIncrement = 15f;         //  Make Spawner.cs be the script this is in
    Scoreboard scoreboard;
    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>(); // TODO: Make event system and replace all scoreboard instances in every script with events
        movingDir = new Vector3(transform.position.x, 0f, 0f);
    }
    void Update()
    {
        if (!scoreboard.isAlive) { return; }
        ProcessTrashMovement();
    }

    private void ProcessTrashMovement()
    {
        if (Time.time >= timeAtNextSpawn) { timeAtNextSpawn += timeIncrement; movingSpeedFactor += .015f; }
        transform.position += movingDir * movingSpeedFactor * Time.deltaTime;
    }
}
