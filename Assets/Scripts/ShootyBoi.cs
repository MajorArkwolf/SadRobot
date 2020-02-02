using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyBoi : MonoBehaviour
{

    [SerializeField]
    private float delaySeconds = 3;

    [SerializeField]
    GameObject toInstantiate;

    [SerializeField]
    bool repeat = true;

    public uint direction = 1;
    public float padding = 1f;

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
            if (!repeat)
            {
                executed = true;
            }
            else
            {
                startTime = Time.time;
            }


            GameObject newObj = Instantiate(toInstantiate);
            newObj.transform.position = CalcDirection(direction);
            newObj.GetComponent<BulletBoi>().Direction = direction;
            //newObj.transform.position = position;
        }
    }


    Vector3 CalcDirection(uint Direction)
    {
        Vector3 pos = new Vector3();
        pos = this.gameObject.transform.position;
        if (Direction == 1)
        {
            //Shoot Up
            pos.y += padding;
        }
        else if (Direction == 2)
        {
            //Shot Right
            pos.x += padding;
        }
        else if (Direction == 3)
        {
            //Shot Down
            pos.y -= padding;
        }
        else
        {
            //Shoot Left
            pos.x -= padding;
        }
        return pos;
    }
}
