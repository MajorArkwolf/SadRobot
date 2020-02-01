using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float speed = 1.0f;
    public Boolean isCircular = false;

    public Vector3[] userPath;
    private float startTime;
    private float endTime;
    private float distance;

    private List<Vector3> path = new List<Vector3>();
    private int pathIndex = 0;
    private bool isReturning = false;

    private void SetupNextJourney() {
        Debug.Log(pathIndex + "\t" + nextPath() + "");
        startTime = Time.time;
        endTime = Time.time + Math.Abs(Vector3.Distance(path[pathIndex],
            path[nextPath()]) / speed);
    }

    private void Start() {
        path.Add(transform.position);
        path.AddRange(userPath);
        SetupNextJourney();
    }

    private int nextPath() {
        if (isCircular) {
            if (pathIndex != (path.Count - 1)) {
                return pathIndex + 1;
            } else {
                return 0;
            }
        } else {
            return pathIndex + (isReturning ? -1 : 1);
        }
    }

    private void Update() {
        if (Time.time >= endTime) {
            pathIndex = nextPath();

            if (!isCircular) {
                if (!isReturning && pathIndex == (path.Count - 1)) {
                    isReturning = true;
                } else if (isReturning && pathIndex == 0) {
                    isReturning = false;
                }
            }

            SetupNextJourney();
        }

        float distance = (Time.time - startTime) * speed;
        float frac = distance /
            Vector3.Distance(path[pathIndex], path[nextPath()]);

        transform.position = Vector3.Lerp(path[pathIndex], path[nextPath()], frac);
    }
}
