using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float vidaMaxima = 10;
    [SerializeField] float tickets = 0;
    float vidaActual;
    [SerializeField] TextMeshProUGUI textoVida;
    [SerializeField] TextMeshProUGUI textoDinero;
    [SerializeField] GameObject spawnPoint;

    //[SerializeField] GameObject corazones;
    //[SerializeField] Sprite corazoEntero;
    //[SerializeField] GameObject prefabCorazon;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
        textoVida.text = "Vida: " + vidaActual.ToString();
        textoDinero.text = "Dinero: " + tickets.ToString();

        /*for (int i = 0; i<vidaMaxima; i++) {
            GameObject newCorazon = Instantiate(prefabCorazon, corazones.transform);
        }*/
        //SpawnSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;
        textoVida.text = "Vida: " + vidaActual.ToString();

        if (vidaActual <= 0)
        {
            textoVida.text = "Vida: " + vidaActual.ToString();
            Morir();
        }
    }

    public void CurarDanio(float cantidad)
    {
        if (vidaActual < vidaMaxima)
        {
            vidaActual += cantidad;
            textoVida.text = "Vida: " + vidaActual.ToString();
        }
    }

    public void RecibirDinero(float cantidad)
    {
        tickets += cantidad;
        textoDinero.text = "Dinero: " + tickets.ToString();

        if (vidaActual <= 0)
        {
            textoVida.text = "Vida: " + vidaActual.ToString();
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("ha muerto");

        Vector3 spawnPos = spawnPoint.transform.position;
        GetComponent<CharacterController>().enabled = false; // Deshabilitar temporalmente el controlador
        transform.position = spawnPos; // Teleportar al jugador
        GetComponent<CharacterController>().enabled = true; // Volver a habilitar el controlador        
        //Destroy(gameObject);
        //gameObject.transform.position = spawnPoint.position;
        vidaActual = vidaMaxima;
        textoVida.text = "Vida: " + vidaActual.ToString();
    }

    /*void SpawnSprite()
    {
        GameObject obj = new GameObject("SpriteRenderer");
        SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = corazoEntero;
        obj.transform.parent = corazones.transform;
    }*/
}
