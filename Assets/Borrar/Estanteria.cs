using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estanteria : MonoBehaviour
{
    public GameObject[] pisos;
    [Range(0,4)]
    public int altura;
    void Update()
    {
        for (int i = 0; i < pisos.Length; i++)
        {
            pisos[i].SetActive(i < altura);
        }
    }
}
