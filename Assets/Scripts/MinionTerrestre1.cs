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
    float vida = 0;
    [SerializeField] float maxvida = 3f;
    private Vector3 puntoInicio;
    private Vector3 puntoFinal;
    private bool siguiendo = false;
    float tiempo = 0;

    [SerializeField] float cantidadDanio = 0.25f;

    void Start()
    {

        vida = maxvida;

        puntoInicio = transform.position;
        puntoFinal = new Vector3(transform.position.x + distanciaPatrulla, transform.position.y, transform.position.z);
        StartCoroutine(Patrulla());
    }

    public void RecibirDanio(float cantidad)
    {
        vida -= cantidad;

        Debug.Log(vida);

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
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
