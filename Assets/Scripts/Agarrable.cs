using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Agarrable : MonoBehaviour
{
    Rigidbody2D rb;
    public bool Lanzable,Inrange;
    public Transform ManoPibe;
    public limpiadordepibes Limpiapibe;
    public GameObject WeaEstante;
    public GameObject OBJECTIVE;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Agarra();
    }    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" )
        {
            Inrange = true;
        }
    }
     public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Inrange = false;
        }
     }
    void Agarra()
    {
        if (Input.GetKey(KeyCode.E) && Inrange)
            {
            Lanzable = true;
            }
        if (Lanzable)
        {
                WeaEstante.transform.position = Limpiapibe.transform.position;
        if (Input.GetKeyUp(KeyCode.E))
        {
            Lanzable =false;
            Clonespible();
        }
    }
    }
    void Clonespible()
    
    {
        Instantiate(WeaEstante,Vector2.MoveTowards(transform.position, Limpiapibe.transform.position, Limpiapibe.speed * Time.deltaTime),Quaternion.identity,WeaEstante.transform);
    }
}


