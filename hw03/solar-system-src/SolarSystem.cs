﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour {

    void Start () {
        
    }

    void Rotation () {
        GameObject.Find("Mercury").transform.Rotate(Vector3.up * Time.deltaTime * 365);
        GameObject.Find("Venus").transform.Rotate(Vector3.up * Time.deltaTime * 400);
        GameObject.Find("Earth").transform.Rotate(Vector3.up * Time.deltaTime * 300);
        GameObject.Find("Mars").transform.Rotate(Vector3.up * Time.deltaTime * 250);
        GameObject.Find("Jupiter").transform.Rotate(Vector3.up * Time.deltaTime * 200);
        GameObject.Find("Saturn").transform.Rotate(Vector3.up * Time.deltaTime * 190);
        GameObject.Find("Uranus").transform.Rotate(Vector3.up * Time.deltaTime * 180);
        GameObject.Find("Neptune").transform.Rotate(Vector3.up * Time.deltaTime * 160);
    }
    
    void Orbital () {
        GameObject.Find("Mercury").transform.RotateAround(Vector3.zero, new Vector3(1, 1, 0), 25 * Time.deltaTime);
        GameObject.Find("Venus").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 1), 20 * Time.deltaTime);
        GameObject.Find("Earth").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 0), 30 * Time.deltaTime);
        GameObject.Find("Mars").transform.RotateAround(Vector3.zero, new Vector3(2, 1, 0), 45 * Time.deltaTime);
        GameObject.Find("Jupiter").transform.RotateAround(Vector3.zero, new Vector3(1, 2, 0), 35 * Time.deltaTime);
        GameObject.Find("Saturn").transform.RotateAround(Vector3.zero, new Vector3(0, 1, 2), 40 * Time.deltaTime);
        GameObject.Find("Uranus").transform.RotateAround(Vector3.zero, new Vector3(0, 2, 1), 45 * Time.deltaTime);
        GameObject.Find("Neptune").transform.RotateAround(Vector3.zero, new Vector3(1, 1, 1), 50 * Time.deltaTime);
    }

    void Update () {
        Rotation();
        Orbital();
    }
}
