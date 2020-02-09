﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletBoi : MonoBehaviour
{
    public uint Direction = 1;
    public float speed = 1;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        } else if(collision.gameObject.name.Contains("cannon"))
        {
            return;
        } else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Direction == 1)
        {
            //Shoot Up
            this.gameObject.transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        } else if (Direction ==2)
        {
            //Shot Right
            this.gameObject.transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
        } else if (Direction == 3)
        {
            //Shot Down
            this.gameObject.transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);
        } else
        {
            //Shoot Left
            this.gameObject.transform.position += new Vector3(-1 * speed * Time.deltaTime, 0, 0);
        }
    }
}
