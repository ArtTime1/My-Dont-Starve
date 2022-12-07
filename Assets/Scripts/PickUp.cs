using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform _destination;
 
    void Update()
    {
        DropThings();
    }        

    private void PickUpThings()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            this.transform.position = _destination.position;
            this.transform.parent = GameObject.Find("Destination").transform;                            
        }       
    }

    private void DropThings()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.transform.parent = null;           
        }       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickUpThings();
        }
    }               
}
