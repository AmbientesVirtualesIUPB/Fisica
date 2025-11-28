using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlPerros : MonoBehaviour
{
    public static ControlPerros singleton;


    public List<Perro> perros;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            DestroyImmediate(this);
        }
        perros = new List<Perro>();
    }

    public void RegistrarPerro(Perro p)
    {
        if (!perros.Contains(p))
        {
            perros.Add(p);
        }
    }
    public void DesregistrarPerro(Perro p)
    {
        if (perros.Contains(p))
        {
            perros.Remove(p);
        }
    }

    public float CalcularFuerza()
    {
        float f = 0;
        for (int i = 0; i < perros.Count; i++)
        {
            f += perros[i].fuerza;
        }
        return f;
    }
}
