using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

[DisallowMultipleComponent]
public class Trash : MonoBehaviour
{
    #region Variables
    [SerializeField] float movingSpeedFactor = 1f;
    Vector3 movingDir;

    [SerializeField] float timeAtNextSpawn = 15f; //   TODO
    [SerializeField] float timeIncrement = 15f;         //  Make Spawner.cs be the script this is in
    #endregion

    Core core;
    private void Awake()
    {
        core = FindObjectOfType<Core>();
    }
    void Start()
    {
        movingDir = new Vector3(transform.position.x, 0f, 0f);
    }

    void Update()
    {
        if(!core.isAlive) { return; }
        ProcessTrashMovement();
    }

    private void ProcessTrashMovement()
    {
        if (Time.time >= timeAtNextSpawn) { timeAtNextSpawn += timeIncrement; movingSpeedFactor += .015f; }
        transform.position += movingDir * movingSpeedFactor * Time.deltaTime;
    }
}
