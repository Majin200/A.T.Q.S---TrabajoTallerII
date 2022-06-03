using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Move : MonoBehaviour
{
    public int speed, jump;
    private float X, tiempoAire;
    public Rigidbody2D player;
    public LayerMask Floor;
    public GameObject origin, origin1, origin2, originUP1, originUP2, Hand, handCheck;
    public Animator animator;
    float inputHorizontal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            animator.ResetTrigger("isNotJumping");
            animator.SetTrigger("isJumping");
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            animator.ResetTrigger("isJumping");
            animator.SetTrigger("isNotJumping");
        }
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("isMoving", 3);
        }

        if(Input.GetKeyUp(KeyCode.A))
        {
            animator.SetFloat("isMoving", 0);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("isMoving", 3);
        }

        if(Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("isMoving", 1);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetFloat("isMoving", 3);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetFloat("isMoving", 0);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetFloat("isMoving", 3);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("isMoving", 1);
        }

        player.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * speed, player.velocity.y, 0);

        RaycastHit2D raycastForFloor = Physics2D.Raycast(origin.transform.position, Vector2.down, 0.52f, Floor);
        RaycastHit2D raycastForFloor1 = Physics2D.Raycast(origin1.transform.position, Vector2.down, 0.52f, Floor);
        RaycastHit2D raycastForFloor2 = Physics2D.Raycast(origin2.transform.position, Vector2.down, 0.52f, Floor);

        Debug.DrawRay(origin.transform.position, Vector2.down, Color.blue);
        Debug.DrawRay(origin1.transform.position, Vector2.down, Color.blue);
        Debug.DrawRay(origin2.transform.position, Vector2.down, Color.blue);

        if (raycastForFloor == true || raycastForFloor1 == true || raycastForFloor2 == true)
        {
            tiempoAire = 0;
           
        }

        else
        {
            tiempoAire += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(raycastForFloor == true || raycastForFloor1 == true || raycastForFloor2 == true)
            {
                player.velocity = new Vector2(player.velocity.x, jump);
                Debug.DrawRay(origin.transform.position, Vector2.down, Color.red, Floor);
                Debug.DrawRay(origin1.transform.position, Vector2.down, Color.red, Floor);
                Debug.DrawRay(origin2.transform.position, Vector2.down, Color.red, Floor);
            }

            else
            {
                if(tiempoAire < 0.25f)
                {
                    player.velocity = new Vector2(player.velocity.x, jump);
                }
            }

        }

        RaycastHit2D raycastD = Physics2D.Raycast(originUP1.transform.position, Vector2.up, 0.52f, Floor);
        RaycastHit2D raycastI = Physics2D.Raycast(originUP2.transform.position, Vector2.up, 0.52f, Floor);

        Debug.DrawRay(originUP1.transform.position, Vector2.up, Color.blue);
        Debug.DrawRay(originUP2.transform.position, Vector2.up, Color.blue);


        if (raycastI && !raycastD)
        {
            transform.position += new Vector3(0.3f, 0);
            Debug.DrawRay(originUP1.transform.position, Vector2.up, Color.red);
            Debug.DrawRay(originUP2.transform.position, Vector2.up, Color.blue);

        }

        else if(!raycastI && raycastD)
        {
            transform.position -= new Vector3(0.3f, 0);
            Debug.DrawRay(originUP1.transform.position, Vector2.up, Color.blue);
            Debug.DrawRay(originUP2.transform.position, Vector2.up, Color.red);

        }

        RaycastHit2D raycastForHandle = Physics2D.Raycast(handCheck.transform.position, Vector2.right, 0.10f);
        Debug.DrawRay(handCheck.transform.position, Vector2.right, Color.cyan);

        if (raycastForHandle.collider && raycastForHandle.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.L))
            {
                raycastForHandle.collider.gameObject.transform.parent = handCheck.transform;
                raycastForHandle.collider.gameObject.transform.position = handCheck.transform.position;
                raycastForHandle.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }

            else
            {
                raycastForHandle.collider.gameObject.transform.parent = null;
                raycastForHandle.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }
        }


    }

    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");


        if(inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(7, 7, 7);
        }

        if(inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-7, 7, 7);
        }

    }

}
