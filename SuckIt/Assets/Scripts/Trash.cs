using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    [Tooltip("0 for no speed, 1 for max speed")][SerializeField] float movingSpeedPercentage = 1f;
    Vector3 movingDir;
    void Start()
    {
        movingDir = new Vector3(transform.position.x, 0f, 0f);
    }
    void Update()
    {
        transform.position += movingDir * movingSpeedPercentage * Time.deltaTime;
    }
}
