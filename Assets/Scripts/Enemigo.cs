using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TomarDamage()
    {
        vida = vida - 3f;
        if( vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }
}
