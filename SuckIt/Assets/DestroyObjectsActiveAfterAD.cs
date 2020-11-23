using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core;

public class DestroyObjectsActiveAfterAD : MonoBehaviour
{
    [SerializeField] Core core = null;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Killable")
        {
            Destroy(other.gameObject);
        }
    }
    private void Update()
    {
        if(!core.isAlive)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
    }
    public void Deactivate()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
    public void Activate()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
}
