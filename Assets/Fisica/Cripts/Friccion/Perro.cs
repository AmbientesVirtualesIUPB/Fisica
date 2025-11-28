using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Perro : MonoBehaviour
{
    LineRenderer linea;
    public Transform posicionInicial;
    public float fuerza = 20;
    private void Awake()
    {
        linea = GetComponent<LineRenderer>();
        if (posicionInicial == null)
        {
            posicionInicial = transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        ControlPerros.singleton.RegistrarPerro(this);
    }

    // Update is called once per frame
    void Update()
    {
        linea.SetPosition(0, posicionInicial.position);
        linea.SetPosition(1, CreadorPerros.singleton.transform.position);
    }

    private void OnDestroy()
    {
        ControlPerros.singleton.DesregistrarPerro(this);
    }
}
