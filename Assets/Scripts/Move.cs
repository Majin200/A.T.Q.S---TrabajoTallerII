using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int speed, jump;
    private float X, tiempoAire;
    public Rigidbody2D player;
    public LayerMask Floor;
    public GameObject origin, originUP1, originUP2;

    public void FixedUpdate()
    {
        player.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, player.velocity.y, 0);

        RaycastHit2D raycastForFloor = Physics2D.Raycast(origin.transform.position, Vector2.down, 0.52f, Floor);
        
        if(raycastForFloor == true)
        {
            tiempoAire = 0;
        }

        else
        {
            tiempoAire += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(raycastForFloor == true)
            {
                player.velocity = new Vector2(player.velocity.x, jump);

            }

            else
            {
                if(tiempoAire < 0.30f)
                {
                    player.velocity = new Vector2(player.velocity.x, jump);
                }
            }
        }

        RaycastHit2D raycastD = Physics2D.Raycast(originUP1.transform.position, Vector2.up, 0.52f, Floor);
        RaycastHit2D raycastI = Physics2D.Raycast(originUP2.transform.position, Vector2.up, 0.52f, Floor);

        if(raycastI && !raycastD)
        {
            transform.position += new Vector3(0.3f, 0);
        }

        else if(!raycastI && raycastD)
        {
            transform.position -= new Vector3(0.3f, 0);

        }

    }

}
