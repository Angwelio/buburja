using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVatrapapibes : MonoBehaviour
{
    public atrapapibes guardia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            limpiadordepibes PibeScript = col.gameObject.GetComponent<limpiadordepibes>();
            if (PibeScript.ilegal){
                guardia.alert = true;
                guardia.tempo = 900;
            }
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "Player"){
            limpiadordepibes PibeScript = col.gameObject.GetComponent<limpiadordepibes>();
            if (PibeScript.ilegal){
                guardia.alert = false;
                guardia.per = true;
            }
        }
    }
}
