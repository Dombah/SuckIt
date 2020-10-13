using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCollided : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killable")
        {
            Destroy(other.gameObject);
        }
    }
}
