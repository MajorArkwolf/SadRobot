using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{

    [SerializeField]
    GameObject follow;

    [SerializeField]
    float parallaxStrength;

    [SerializeField]
    bool x, y;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - follow.transform.position; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 target = follow.transform.position;

        transform.position = new Vector3(x ? parallaxStrength * target.x + offset.x : transform.position.x,
            y ? parallaxStrength * target.y + offset.y : transform.position.y, transform.position.z);

    }
}
