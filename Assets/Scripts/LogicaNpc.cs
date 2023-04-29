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
    public Transform bob;
    public Transform mercader;
    public GameObject player;
    private bool seMostroPanel2 = false;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        panelNPC.SetActive(false);
    }

    // Update is called once per frame


    void Update()
    {
        float distance = Vector3.Distance(bob.position, mercader.position);

        if (distance <= 3 && seMostroPanel2 == false)
        {
            panelNPC.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && aceptarMision == false && seMostroPanel2 == false)
            {
                seMostroPanel2 = true;
                panelNPC.SetActive(false);
                panelNPC2.SetActive(true);
            }
        }
        else
        {
            panelNPC.SetActive(false);
        }
    }


    /*private void onTriggerEnter(Collider other)
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
    }*/

    public void NO()
    {
        panelNPC.SetActive(true);
        panelNPC2.SetActive(false);
        seMostroPanel2 = false;
    }

    public void SI()
    {
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }

}
