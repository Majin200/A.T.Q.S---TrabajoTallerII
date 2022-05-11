using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woods : MonoBehaviour
{
    public GameObject woods;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Box"))
        {
            Destroy(woods);
        }
    }
}
