using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionTerrestre1 : MonoBehaviour
{
    public Transform Objetivo;
    public float velocidad;
    public NavMeshAgent IA;
    public float distanciaDeseada = 5f;
    public float distanciaPatrulla = 10f;
    private Vector3 puntoInicio;
    private Vector3 puntoFinal;
    private bool siguiendo = false;

    [SerializeField] float cantidadDanio = 0.25f;

    void Start()
    {
        puntoInicio = transform.position;
        puntoFinal = new Vector3(transform.position.x + distanciaPatrulla, transform.position.y, transform.position.z);
        StartCoroutine(Patrulla());
    }

    IEnumerator Patrulla()
    {
        while (true)
        {
            yield return StartCoroutine(MoverHacia(puntoFinal));
            yield return StartCoroutine(MoverHacia(puntoInicio));
        }
    }

    IEnumerator MoverHacia(Vector3 destino)
    {
        IA.enabled = true;

        IA.SetDestination(destino);

        while (Vector3.Distance(transform.position, destino) > 0.1f)
        {
            IA.speed = velocidad;
            yield return null;
        }

        IA.speed = 0f;
        yield return new WaitForSeconds(1f);
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, Objetivo.position);

        if (distancia <= distanciaDeseada && !siguiendo)
        {
            IA.enabled = true;
            siguiendo = true;
        }

        if (siguiendo)
        {
            IA.SetDestination(Objetivo.position);
            IA.speed = velocidad;
        }

        if (distancia > distanciaDeseada && siguiendo)
        {
            IA.enabled = false;
            siguiendo = false;
            StartCoroutine(Patrulla());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().RecibirDanio(cantidadDanio);
        }
    }
}
