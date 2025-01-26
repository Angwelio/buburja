using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class atrapapibes : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 direction;
    public float speed, angle, tolerance = 0.01f;
    public Transform pibe, patrol1, patrol2, patrol3, patrol4, patrol5;
    public GameObject FOV;
    public bool alert, per, debug, inbubble;
    public int tempo, patrolnum, ptempo, slowtempo; //se calcula en frames, osea multiplicar el numero de segundos por 60
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();
        pibe = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        if (inbubble){
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            if (tempo-- <= 0){
                tempo = 0;
                inbubble = false;
                rb.constraints = RigidbodyConstraints2D.None;
                alert = true;
            }else{
                tempo--;
            }
            return;
        }
        if (alert /*&& tempo > 0*/){
            transform.position = Vector2.MoveTowards(transform.position, pibe.position, speed * Time.deltaTime);
            direction = pibe.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            PibeAngular(angle); 
            if (tempo + 30 >= 1500){
                tempo = 1500;
            } else {
                tempo += 30;
            }
        }
        if (!alert && per){
            transform.position = Vector2.MoveTowards(transform.position, pibe.position, speed * Time.deltaTime);
            direction = pibe.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            PibeAngular(angle);
            if (tempo - 1 <= 0){
                tempo = 0;
                per = false;
                switch (patrolnum){
                    case 1:
                        direction = patrol1.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        PibeAngular(angle);
                        break;
                    case 2:
                        direction = patrol2.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        PibeAngular(angle);
                        break;
                    case 3:
                        direction = patrol3.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        PibeAngular(angle);
                        break;
                    case 4:
                        direction = patrol4.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        PibeAngular(angle);
                        break;
                    case 5:
                        direction = patrol5.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        PibeAngular(angle);
                        break;
                }
            } else {
                tempo --;
            }
        }
        if (!alert && !per){
            switch (patrolnum){
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
                        patrolnum = 3;
                        ptempo = 300;
                        direction = patrol3.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    PibeAngular(angle);
                    }
                    break;

                case 3:
                    transform.position = Vector2.MoveTowards(transform.position, patrol3.position, speed * Time.deltaTime);
                    if (ptempo == 0){
                        patrolnum = 4;
                        ptempo = 300;
                        direction = patrol4.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    PibeAngular(angle);
                    }
                    break;

                case 4:
                    transform.position = Vector2.MoveTowards(transform.position, patrol4.position, speed * Time.deltaTime);
                    if (ptempo == 0){
                        patrolnum = 5;
                        ptempo = 300;
                        direction = patrol5.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    PibeAngular(angle);
                    }
                    break;

                case 5:
                    transform.position = Vector2.MoveTowards(transform.position, patrol5.position, speed * Time.deltaTime);
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
        }
        if (Vector3.Distance(rb.position, patrol1.position) < tolerance && patrolnum == 1 || Vector3.Distance(rb.position, patrol2.position) < tolerance && patrolnum == 2 || Vector3.Distance(rb.position, patrol3.position) < tolerance && patrolnum == 3 || Vector3.Distance(rb.position, patrol4.position) < tolerance && patrolnum == 4 || Vector3.Distance(rb.position, patrol5.position) < tolerance && patrolnum == 5){
            ptempo--;
        }
    }
    public void trapped(){
        inbubble = true;
        tempo = 1500;
    }
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
        FOV.transform.position = (transform.position + new Vector3(0, 2, 0));
                anim.SetFloat("Y",direction.y);

        //animacion de arriba
    }
    else if (PibeChecador(angle, 225, 315))  // Down
    {
        FOV.transform.position = (transform.position + new Vector3(0, -2, 0));
                anim.SetFloat("Y",direction.y);

        //animacion de abajo
    }
    else if (PibeChecador(angle, 135, 225))  // Left
    {
        FOV.transform.position = (transform.position + new Vector3(-2, 0, 0));
        anim.SetFloat("X",direction.x);

        //animacion de izquierda
        //spriteRenderer.flipX = true;  // Flip to face left
    }
    else  // Right (0 to 45 and 315 to 360)
    {
        FOV.transform.position = (transform.position + new Vector3(2, 0, 0));
        anim.SetFloat("X",direction.x);

        //animacion de derecha
        //spriteRenderer.flipX = false;
    }
    }
    bool PibeChecador(float angle, float min, float max){
        return angle >= min && angle < max;
    }
}
