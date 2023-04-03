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
    //[SerializeField] GameObject corazones;
    //[SerializeField] Sprite corazoEntero;
    //[SerializeField] GameObject prefabCorazon;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;

        /*for (int i = 0; i<vidaMaxima; i++) {
            GameObject newCorazon = Instantiate(prefabCorazon, corazones.transform);
        }*/
        //SpawnSprite();
    }

    // Update is called once per frame
    void Update()
    {
        textoVida.text = "Vida: " + vidaActual.ToString();
        textoDinero.text = "Dinero: " + tickets.ToString();
    }

    public void RecibirDanio(float cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log(vidaActual);

        if (vidaActual <= 0)
        {
            textoVida.text = "Vida: " + vidaActual.ToString();
            Morir();
        }
    }

    public void RecibirDinero(float cantidad)
    {
        tickets += cantidad;

        if (vidaActual <= 0)
        {
            textoVida.text = "Vida: " + vidaActual.ToString();
            Morir();
        }
    }

    void Morir()
    {
        Destroy(gameObject);
    }

    /*void SpawnSprite()
    {
        GameObject obj = new GameObject("SpriteRenderer");
        SpriteRenderer sr = obj.AddComponent<SpriteRenderer>();
        sr.sprite = corazoEntero;
        obj.transform.parent = corazones.transform;
    }*/
}
