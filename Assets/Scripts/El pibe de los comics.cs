using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elpibedeloscomics : MonoBehaviour
{
    public GameObject panel1, panel2, panel3, panel4,inst,pauseMenuUI;
    public limpiadordepibes player;
    private bool isPaused = false;
    int panelActual = 1;
    void Start()
    {
        player = GameObject.Find("LimpiaPibe").GetComponent<limpiadordepibes>();
        player.playable = false;
    }

    // Update is called once per frame
    void Update()
    {
        switch (panelActual)
        {
            case 0:
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
                break;
            case 1:
            panel1.SetActive(true);
            inst.SetActive(true);
                break;
            case 2:
            panel2.SetActive(true);
                break;
            case 3:
            panel3.SetActive(true);
                break;
            case 4:
            panel4.SetActive(true);
                break;
            case 5:
            panel1.SetActive(false);
            panel2.SetActive(false);
            panel3.SetActive(false);
            panel4.SetActive(false);
            inst.SetActive(false);
            player.playable = true;
                break;
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            panelActual++;
            /*if (panelActual == 5)
            {
                player.playable = true;
                //Destroy(gameObject);
            }*/
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            panelActual = 5;
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseMenuUI.SetActive(true);
            //Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
            //Cursor.visible = false;
        }
    }
    public void ResumeGame()
    {
        TogglePause();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
