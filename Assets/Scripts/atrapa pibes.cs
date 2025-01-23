using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atrapapibes : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mov, direction;
    public float speed, angle, tolerance = 0.01f;
    public Transform pibe, patrol1, patrol2, patrol3, patrol4, patrol5;
    public bool alert, per, debug;
    //public GameObject FOV;
    public int tempo, patrolnum, ptempo; //se calcula en frames, osea multiplicar el numero de segundos por 60
    //public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        //anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (alert /*&& tempo > 0*/){
            transform.position = Vector2.MoveTowards(transform.position, pibe.position, speed * Time.deltaTime);
            direction = pibe.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle);
            if (tempo + 30 >= 900){
                tempo = 900;
            } else {
                tempo += 30;
            }
        }
        if (!alert && per){
            transform.position = Vector2.MoveTowards(transform.position, pibe.position, speed * Time.deltaTime);
            direction = pibe.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.MoveRotation(angle);
            if (tempo - 1 <= 0){
                tempo = 0;
                per = false;
                switch (patrolnum){
                    case 1:
                        direction = patrol1.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        rb.MoveRotation(angle);
                        break;
                    case 2:
                        direction = patrol2.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        rb.MoveRotation(angle);
                        break;
                    case 3:
                        direction = patrol3.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        rb.MoveRotation(angle);
                        break;
                    case 4:
                        direction = patrol4.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        rb.MoveRotation(angle);
                        break;
                    case 5:
                        direction = patrol5.position - transform.position;
                        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        rb.MoveRotation(angle);
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
                        rb.MoveRotation(angle);
                    }
                    break;

                case 2:
                    transform.position = Vector2.MoveTowards(transform.position, patrol2.position, speed * Time.deltaTime);
                    if (ptempo == 0){
                        patrolnum = 3;
                        ptempo = 300;
                        direction = patrol3.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.MoveRotation(angle);
                    }
                    break;

                case 3:
                    transform.position = Vector2.MoveTowards(transform.position, patrol3.position, speed * Time.deltaTime);
                    if (ptempo == 0){
                        patrolnum = 4;
                        ptempo = 300;
                        direction = patrol4.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.MoveRotation(angle);
                    }
                    break;

                case 4:
                    transform.position = Vector2.MoveTowards(transform.position, patrol4.position, speed * Time.deltaTime);
                    if (ptempo == 0){
                        patrolnum = 5;
                        ptempo = 300;
                        direction = patrol5.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.MoveRotation(angle);
                    }
                    break;

                case 5:
                    transform.position = Vector2.MoveTowards(transform.position, patrol5.position, speed * Time.deltaTime);
                    if (ptempo == 0){
                        patrolnum = 1;
                        ptempo = 300;
                        direction = patrol1.position - transform.position;
                    angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    rb.MoveRotation(angle);
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

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            alert = true;
            tempo = 300;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            alert = false;
            per = true;
        }
    }
}
