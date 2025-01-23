using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atrapapibes : MonoBehaviour
{
    Rigidbody2D rb,piberb;
    Vector2 mov;
    public float speed;
    public Transform pibe;
    public bool alert;
    //public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //piberb = 
        //anim = GetComponent<Rigidboy2D>();
    }
    void Update()
    {
        if (alert){
            transform.position = Vector2.MoveTowards(transform.position, pibe.position, speed * Time.deltaTime);
        }
    }
}
