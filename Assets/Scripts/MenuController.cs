using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    GameObject UIObject;

    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    GameObject pauseMenu;

    public bool paused = false;
    public bool main = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!main && !paused && Input.GetKeyDown(KeyCode.Escape))
        {
            UIObject.SetActive(true);
            mainMenu.SetActive(false);
            pauseMenu.SetActive(true);

            paused = true;
            Time.timeScale = 0.0f;
        } else if (!main && paused && Input.GetKeyDown(KeyCode.Escape))
        {
            UIObject.SetActive(false);
            mainMenu.SetActive(false);
            pauseMenu.SetActive(false);

            paused = false;
            Time.timeScale = 1.0f;
        }
    }

    public void setMain(bool main)
    {
        Debug.Log("main " + main);
        this.main = main;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
