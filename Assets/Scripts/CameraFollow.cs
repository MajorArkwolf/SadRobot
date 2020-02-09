using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;

    public Vector3 offset = new Vector3();

    public int zLock = -10;

    public float smoothFactor = 10f;

    public float smallCutoff = 0.05f;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
        transform.position = target.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        Vector3 newPos = target.transform.position + offset;
        newPos.z = zLock;



        if (Vector3.Distance(transform.position, newPos) < smallCutoff)
        {
            // do nothin
            //transform.position = newPos;
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, newPos,
                ref velocity, smoothFactor * Time.deltaTime);
        }
    }

    void FindPlayer()
    {
        if (target == null)
        {
            target = GameObject.FindWithTag("Player");
        }
    }
}
