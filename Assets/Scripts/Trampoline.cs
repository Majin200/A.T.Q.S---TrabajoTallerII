using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float force;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        Vector2 rbVelocity = rb.velocity;
        rb.AddForce(transform.up * (rbVelocity.y * -force));
    }
}
