using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicaNpc : MonoBehaviour
{

    public GameObject simboloMision;
    //public LogicaPersonaje1 jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject objetivos;
    public int numeroObjetivos;
    public GameObject botonMision;


    // Start is called before the first frame update
    void Start()
    {


        panelNPC.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && aceptarMision == false)
        {

            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }

    private void onTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            jugadorCerca = true;
            if (aceptarMision == false)
            {

                panelNPC.SetActive(true);
            }
        }
    }

    private void onTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            jugadorCerca = false;

            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);

        }
    }

    public void NO()
    {
        panelNPC.SetActive(true);
        panelNPC2.SetActive(false);
    }

    public void SI(){
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }

}
