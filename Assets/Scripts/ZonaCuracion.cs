using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZonaCuracion : MonoBehaviour
{
    [SerializeField] float cantidadCuracion = 0.25f;
    float tiempo = 0;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tiempo >= 0.4f)
            {
                tiempo = 0;
                other.GetComponent<Player>().CurarDanio(cantidadCuracion);
            }
        }
    }

    private void FixedUpdate()
    {
        if (tiempo < 0.4f)
        {
            tiempo += Time.fixedDeltaTime;
        }
    }
}
