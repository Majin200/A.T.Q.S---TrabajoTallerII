using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Move : MonoBehaviour
{
    public int speed, jump;
    private float X, tiempoAire;
    public bool isPlayerOne;
    public Rigidbody2D player, player2;
    public LayerMask Floor;
    public GameObject origin, origin1, Hand, handCheck;
    public Animator animator;
    float inputHorizontal;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        player2 = GetComponent<Rigidbody2D>();

    }

    public void Update()
    {
        if(isPlayerOne)
        {
            catOne();
        }

        else
        {
            catTwo();
        }
    }

    public void catOne()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animator.ResetTrigger("isNotJumping");
            animator.SetTrigger("isJumping");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animator.ResetTrigger("isJumping");
            animator.SetTrigger("isNotJumping");
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetFloat("isMoving", 3);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetFloat("isMoving", 0);
          
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetFloat("isMoving", 3);
            transform.position += Vector3.right * speed * Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetFloat("isMoving", 1);
            
        }


        RaycastHit2D raycastForFloor = Physics2D.Raycast(origin.transform.position, Vector2.down, 0.52f, Floor);
        RaycastHit2D raycastForFloor1 = Physics2D.Raycast(origin1.transform.position, Vector2.down, 0.52f, Floor);
        

        Debug.DrawRay(origin.transform.position, Vector2.down, Color.blue);
        Debug.DrawRay(origin1.transform.position, Vector2.down, Color.blue);
        

        if (raycastForFloor == true || raycastForFloor1 == true)
        {
            tiempoAire = 0;

        }

        else
        {
            tiempoAire += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (raycastForFloor == true || raycastForFloor1 == true)
            {
                player.velocity = new Vector2(player.velocity.x, jump);
                Debug.DrawRay(origin.transform.position, Vector2.down, Color.red, Floor);
                Debug.DrawRay(origin1.transform.position, Vector2.down, Color.red, Floor);
                
            }

            else
            {
                if (tiempoAire < 0.25f)
                {
                    player.velocity = new Vector2(player.velocity.x, jump);
                }
            }

        }

        RaycastHit2D raycastForHandle = Physics2D.Raycast(handCheck.transform.position, Vector2.right, 0.10f);
        Debug.DrawRay(handCheck.transform.position, Vector2.right, Color.cyan);

        if (raycastForHandle.collider && raycastForHandle.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.F))
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

    public void catTwo()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.ResetTrigger("isNotJumping");
            animator.SetTrigger("isJumping");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            animator.ResetTrigger("isJumping");
            animator.SetTrigger("isNotJumping");
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("isMoving", 3);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetFloat("isMoving", 0);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("isMoving", 3);
            transform.position += Vector3.right * speed * Time.deltaTime;

        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetFloat("isMoving", 1);

        }


        RaycastHit2D raycastForFloor = Physics2D.Raycast(origin.transform.position, Vector2.down, 0.52f, Floor);
        RaycastHit2D raycastForFloor1 = Physics2D.Raycast(origin1.transform.position, Vector2.down, 0.52f, Floor);
        

        Debug.DrawRay(origin.transform.position, Vector2.down, Color.blue);
        Debug.DrawRay(origin1.transform.position, Vector2.down, Color.blue);
        

        if (raycastForFloor == true || raycastForFloor1 == true)
        {
            tiempoAire = 0;

        }

        else
        {
            tiempoAire += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (raycastForFloor == true || raycastForFloor1 == true)
            {
                player.velocity = new Vector2(player.velocity.x, jump);
                Debug.DrawRay(origin.transform.position, Vector2.down, Color.red, Floor);
                Debug.DrawRay(origin1.transform.position, Vector2.down, Color.red, Floor);
             
            }

            else
            {
                if (tiempoAire < 0.25f)
                {
                    player.velocity = new Vector2(player.velocity.x, jump);
                }
            }

        }

       

        RaycastHit2D raycastForHandle = Physics2D.Raycast(handCheck.transform.position, Vector2.right, 0.10f);
        Debug.DrawRay(handCheck.transform.position, Vector2.right, Color.cyan);

        if (raycastForHandle.collider && raycastForHandle.collider.tag == "Box")
        {
            if (Input.GetKey(KeyCode.M))
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


       if(isPlayerOne)
        {
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.localScale = new Vector3(7, 7, 7);
            }

            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.localScale = new Vector3(-7, 7, 7);
            }
        }

        if (!isPlayerOne)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.localScale = new Vector3(7, 7, 7);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.localScale = new Vector3(-7, 7, 7);
            }
        }

    }

}
