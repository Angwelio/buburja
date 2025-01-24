using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buburjapibechiste : MonoBehaviour
{
    public limpiadordepibes PibeScript;
    public bool debug;
    void Start()
    {
    }
    public void Awake()
    {
        PibeScript = GameObject.Find("LimpiaPibe").GetComponent<limpiadordepibes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Sucieda")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Guardia")
        {
            other.transform.position = transform.position;
            atrapapibes guardiaScript = other.gameObject.GetComponent<atrapapibes>();
        if (guardiaScript != null)
        {
            guardiaScript.trapped();
        }
        PibeScript.ilegal = true;
        PibeScript.tempo=1500;
        Destroy(gameObject);
        }
        if (other.gameObject.tag == "NPC")
        {
            other.transform.position = transform.position;
            NPibeCs NPCScript = other.gameObject.GetComponent<NPibeCs>();
            if (NPCScript != null)
            {
                NPCScript.trapped();
            }
            PibeScript.ilegal = true;
            PibeScript.tempo=600;
            Destroy(gameObject);
        }
    }
}
