using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class SkillsPlayer : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject Lanzar;
    public int Wrap;
    public float Burbuja;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         animator = GetComponent<Animator>();
    }
        // Update is called once per frame
    
    void Update(){
        // Obtener la entrada del usuario (WASD o flechas)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("X",movement.x);
        animator.SetFloat("Y",movement.y);
    }
    void FixedUpdate()
    {
        // Mover al personaje usando la física
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void EnvuelvePibes()
    {
        Input.GetKey("Z");

    }
    void AtontaPibes()
    {
        Input.GetKey("X");
        


    }

    void AvientaPibes()
    {
        Input.GetKey("C");
        GameObject.Instantiate(Lanzar);
        
    }


    
}
