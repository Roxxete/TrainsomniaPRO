using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas OpcionesCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EmpezarJuego()
    {
        SceneManager.LoadScene("MundoPrueba");
    }

    public void Cerrar()
    {
        Application.Quit();
    }

    public void Opciones()
    {
        
    }
}
