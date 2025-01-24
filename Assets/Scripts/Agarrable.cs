using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Agarrable : MonoBehaviour
{
    public bool Lanzable;
    public Transform ManoPibe;
    public limpiadordepibes Limpiapibe;
    public GameObject WeaEstante;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.E)){
                    Lanzable = true;
            if (Lanzable ==true)
        {
            transform.position = ManoPibe.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = Limpiapibe.pointer.position;
        }        }
    }    
        if(Input.GetKeyUp(KeyCode.E))
        {
        Lanzable = false;
        }
    }

}
