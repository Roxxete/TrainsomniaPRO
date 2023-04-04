using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    [SerializeField] float cantidadDanio = 0.25f;
    float tiempo = 0;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && tiempo >= 1f)
        {
            tiempo = 0;
            other.GetComponent<Player>().RecibirDanio(cantidadDanio);
        }
    }
    private void FixedUpdate()
    {
        if (tiempo < 1f)
        {
            tiempo += Time.fixedDeltaTime;
        }
    }
}
