using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caminadordepibes : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mov;
    public float speed;
    //public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }
    void Update()
    {
        mov = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity = mov * speed;
        //the animations, ALVARO, usas la madre esa para animaciones que te puso drolejan en tu proyecto
    }
}
