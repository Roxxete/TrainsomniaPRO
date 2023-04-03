using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovimientoPersonaje : MonoBehaviour
{
    [SerializeField] float velocidad = 6.0f;
    [SerializeField] float salto = 8.0f;
    [SerializeField] float gravedad = 20.0f;
    [SerializeField] float distanciaDash = 20.0f;
    [SerializeField] float tiempoDash = 20.0f;

    CharacterController characterController;
    [SerializeField] TextMeshProUGUI textoDash;

    private float tiempoActual;

    private Vector3 movimiento = Vector3.zero;

    void Start()
    {
        tiempoActual = tiempoDash;
        textoDash.text = tiempoActual.ToString();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            movimiento = new Vector3();
            movimiento.x = Input.GetAxis("Horizontal");
            movimiento *= velocidad;
            

            if (Input.GetButton("Jump"))
            {
                movimiento.y = salto;
            }
        }
        else
        {
            movimiento.x = Input.GetAxis("Horizontal");
            movimiento.x *= velocidad;         
        }

        Vector3 giro = new Vector3(0, 0, Input.GetAxis("Horizontal"));
        if (giro != Vector3.zero)
        {
            gameObject.transform.forward = giro;
        }

        movimiento.y -= gravedad * Time.deltaTime;
        characterController.Move(movimiento * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        if (tiempoActual < tiempoDash)
        {
            tiempoActual += Time.fixedDeltaTime;
            int tiempoEntero = Mathf.RoundToInt(tiempoActual);
            textoDash.text = tiempoEntero.ToString();
        }

        Dash();
    }

    void Dash()
    {
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && tiempoActual >= tiempoDash)
        {
            Vector3 dash;
            if (transform.eulerAngles.y == 0f)
            {
                dash = new Vector3(distanciaDash * 10, 0, 0);
                characterController.Move(dash * Time.deltaTime);
            }
            else if (transform.eulerAngles.y == 180f)
            {
                dash = new Vector3(-distanciaDash * 10, 0, 0);
                characterController.Move(dash * Time.deltaTime);
            }
            tiempoActual = 0;
        }
    }
}
