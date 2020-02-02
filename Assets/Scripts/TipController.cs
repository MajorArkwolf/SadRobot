using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipController : MonoBehaviour
{

    [SerializeField]
    float speed;

    [SerializeField]
    float jumpPower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hor = Input.GetAxis("Horizontal");

        Vector2 move = Vector2.zero;

        if (hor != 0)
        {
            move.x += speed * hor;
            Debug.Log("move");
        }

        if (Input.GetButtonDown("Jump"))
        {
            move.y += jumpPower;
            Debug.Log("jump");
        }

        GetComponent<Rigidbody2D>().velocity += (move);
    }
}
