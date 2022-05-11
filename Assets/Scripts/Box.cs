using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Rigidbody2D box;
    public GameObject boxes;
    public bool isMetal = false;

    public Move Move;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKey("D"))
        {
            box.velocity = new Vector2(Move.speed, box.velocity.y);
        }
        else if(collision.CompareTag("Player") && Input.GetKey("A"))
        {
            box.velocity = new Vector2(Move.speed, box.velocity.y);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Wood") && !isMetal)
        {
            Destroy(boxes);           
        }
    }
}
