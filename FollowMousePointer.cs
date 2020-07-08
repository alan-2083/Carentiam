using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FollowMousePointer : MonoBehaviour
{
    public Vector3 worldPosition;
    public Plane plane = new Plane(Vector3.up, 0);
    public float distance;
    private Vector3 direction;


    public GameObject Gun;
    public Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            direction = worldPosition - Gun.transform.position;
           Quaternion rotation = Quaternion.LookRotation(direction);
           Gun.transform.rotation = rotation;
        }
    }
}
