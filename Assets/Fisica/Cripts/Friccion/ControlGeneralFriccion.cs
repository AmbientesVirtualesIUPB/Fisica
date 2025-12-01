using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ControlGeneralFriccion : MonoBehaviour
{
    public Bloque bloque;
    public AnimationCurve curvaBien;
    public AnimationCurve curvaMal;

    public float puntoInflexion;

    public void CalcularResultado()
    {

        CreadorPerros.singleton.Generar();
        StartCoroutine(CalculandoResultado());  

    }

    IEnumerator CalculandoResultado()
    {
        yield return new WaitForNextFrameUnit(); /// Obligatoria


        yield return new WaitForSeconds(5);
        float fuerzaPerros = ControlPerros.singleton.CalcularFuerza();

        //////////////////// revisar los cálculos ///////////////

        float resultado = fuerzaPerros - bloque.coeficienteDeFriccion;

        /////////////////// Acá ya empieza lo que revizaría

        if (resultado >= puntoInflexion)
        {
            Victoria();
        }
        else
        {
            Fallo();
        }
    }
    void Victoria()
    {
        StartCoroutine(Victoriando());
    }

    void Fallo()
    {
        StartCoroutine(Fallando());
    }

    public void Reiniciar()
    {

        float t = 0;
        DeslizadorControl.singleton.t = curvaMal.Evaluate(t);
    }

    IEnumerator Fallando()
    {
        float t = 0;
        float pausas = 0.04f;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(pausas);
            t += 0.01f;
            DeslizadorControl.singleton.t = curvaMal.Evaluate(t);
        }
    }

    IEnumerator Victoriando()
    {
        float t = 0;
        float pausas = 0.04f;
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(pausas);
            t += 0.01f;
            DeslizadorControl.singleton.t = curvaBien.Evaluate(t);

        }
    }
}
