using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Perro : MonoBehaviour
{
    LineRenderer linea;
    public Transform[] posiciones;
    private void Awake()
    {
        linea = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        linea.SetPosition(0, posiciones[0].position);
        linea.SetPosition(1, posiciones[1].position);
    }
}
