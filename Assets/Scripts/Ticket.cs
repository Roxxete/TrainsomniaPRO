using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour
{
    private bool yaColisiono = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!yaColisiono && other.CompareTag("Player"))
        {
            yaColisiono = true;
            Destroy(gameObject);
            other.GetComponent<Player>().RecibirDinero(1);
        }
    }
}
