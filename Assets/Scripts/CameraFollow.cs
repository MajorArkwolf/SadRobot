using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    GameObject target;

    [SerializeField]
    Vector3 offset;

    [SerializeField]
    int zLock;

    [SerializeField]
    float smoothFactor;

    [SerializeField]
    float smallCutoff;

    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
}
