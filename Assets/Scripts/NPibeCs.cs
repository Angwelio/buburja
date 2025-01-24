using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPibeCs : MonoBehaviour
{
    private Animator anim;
    public bool inbubble;
    public GameObject texto;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void trapped(){
    }
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            texto.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            texto.SetActive(false);
        }
    }
}
