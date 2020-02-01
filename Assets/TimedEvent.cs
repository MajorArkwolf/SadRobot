using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedEvent : MonoBehaviour
{

    [SerializeField]
    private float delaySeconds;

    [SerializeField]
    GameObject toInstantiate;

    [SerializeField]
    Vector3 position;

    [SerializeField]
    bool repeat = false;

    private bool executed = false;
    private float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!executed && Time.time - startTime > delaySeconds)
        {
            if (!repeat) { 
                executed = true;
            } else
            {
                startTime = Time.time;
            }
               
            GameObject newObj = Instantiate(toInstantiate);
            newObj.transform.position = position;
        }
    }
}
