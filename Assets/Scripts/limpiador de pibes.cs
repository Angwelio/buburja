using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limpiadordepibes : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mov;
    public float speed;
    private Animator anim;
    public Transform pointer;
    public GameObject burbuja;
    public bool ilegal,playable;
    public int tempo;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if(!playable){
            return;
        }
        if (ilegal){
            if (tempo-- <= 0){
                tempo = 0;
                ilegal = false;
            }else{
                tempo--;
            }
        }
        mov = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Horizontal") == 1){
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            pointer.position = (transform.position + new Vector3(2, 0, 0));
        }
        if (Input.GetAxisRaw("Horizontal") == -1){
            //transform.rotation = Quaternion.Euler(0, 0, 270);
            pointer.position = (transform.position + new Vector3(-2, 0, 0));
        }
        if (Input.GetAxisRaw("Vertical") == 1){
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            pointer.position = (transform.position + new Vector3(0, 2, 0));
        }
        if (Input.GetAxisRaw("Vertical") == -1){
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            pointer.position = (transform.position + new Vector3(0, -2, 0));
        }
        if (mov != Vector2.zero)
        {
        anim.SetFloat("X",mov.x);
        anim.SetFloat("Y",mov.y);
        anim.SetBool("PibeCorre",true);
        }else
        {
        anim.SetBool("PibeCorre",false);
        }
        if (Input.GetKey(KeyCode.E))
        {
        anim.SetBool("LimpiaPibe",true);
        }else
        {
        anim.SetBool("LimpiaPibe",false);
        }
       

        if (Input.GetKeyUp(KeyCode.Z))
        {
            generaburbuja();
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + mov * speed * Time.fixedDeltaTime);
    }
    void generaburbuja()
    {
        Instantiate(burbuja, pointer.position, pointer.rotation);
    }
}
