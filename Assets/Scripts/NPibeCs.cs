using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPibeCs : MonoBehaviour
{
    private Animator anim;
    private Collider2D col;
    private Vector2 direction;
    private Rigidbody2D rb;
    public float speed, angle, tolerance = 0.01f;
    public bool inbubble,debug;
    public int tempo, patrolnum, ptempo;
    public Transform patrol1, patrol2;
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inbubble){
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            if (tempo-- <= 0){
                tempo = 0;
                inbubble = false;
                rb.constraints = RigidbodyConstraints2D.None;
            }else{
                tempo--;
            }
            return;
        }
        switch(patrolnum){
            case 1:
                    transform.position = Vector2.MoveTowards(transform.position, patrol1.position, speed * Time.deltaTime);                    
                    if (ptempo == 0){
                        patrolnum = 2;
                        ptempo = 300;
                        direction = patrol2.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        PibeAngular(angle);
                    }
                    break;

                case 2:
                    transform.position = Vector2.MoveTowards(transform.position, patrol2.position, speed * Time.deltaTime);
                    if (ptempo == 0){
                        patrolnum = 1;
                        ptempo = 300;
                        direction = patrol1.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    PibeAngular(angle);
                    }
                    break;
                default:
                    patrolnum = 1;
                    break;
        }
        if (Vector3.Distance(rb.position, patrol1.position) < tolerance && patrolnum == 1 || Vector3.Distance(rb.position, patrol2.position) < tolerance && patrolnum == 2){
            ptempo--;
        }
        
    }
    public void trapped(){
        col.enabled=false;
        tempo = 900;
        //animacion de atrapado
    }
    /*void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            texto.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            texto.SetActive(false);
        }
    }*/
    void PibeAngular(float angle){
        angle = (angle + 360) % 360;
        if(direction != Vector2.zero){
        anim.SetBool("Move",true);
        }else
        {
        anim.SetBool("Move",false);
        }

        if (PibeChecador(angle, 45, 135))  // Up
    {
                anim.SetFloat("Y",direction.y);

        //animacion de arriba
    }
    else if (PibeChecador(angle, 225, 315))  // Down
    {
                anim.SetFloat("Y",direction.y);

        //animacion de abajo
    }
    else if (PibeChecador(angle, 135, 225))  // Left
    {
                anim.SetFloat("X",direction.x);

        //animacion de izquierda
        //spriteRenderer.flipX = true;  // Flip to face left
    }
    else  // Right (0 to 45 and 315 to 360)
    {
                anim.SetFloat("X",direction.x);

        //animacion de derecha
        //spriteRenderer.flipX = false;
    }
    }
    bool PibeChecador(float angle, float min, float max){
        return angle >= min && angle < max;
    }
}
