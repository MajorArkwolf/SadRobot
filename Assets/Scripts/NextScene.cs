using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(LoadNextScene(scene.name));
        }
    }
    private string LoadNextScene(string name)
    {
        string newName;

        if (name == "Level1")
        {
            newName = "Level2";
        } else if (name == "Level2")
        {
            newName = "Level3";
        } else if (name == "Level3")
        {
            newName = "Level4";
        } else if (name == "Level4")
        {
            newName = "Level5";
        } else if (name == "Level5")
        {
            newName = "Level1";
        } else
        {
            newName = "Level1";
        }

        return newName;
    }
}


