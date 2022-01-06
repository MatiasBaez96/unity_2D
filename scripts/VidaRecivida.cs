using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaRecivida : MonoBehaviour
{    
    public GameObject JonhGo;
    public Movements Jonh;
                                 
    void Start()
    {
        JonhGo = GameObject.Find("john");
        Jonh = JonhGo.GetComponent<Movements>();

        gameObject.SetActive(false);
    }
    public void ActivarObjeto()
    {      
        gameObject.SetActive(true);       
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        InteracPlayer Player = collision.GetComponent<InteracPlayer>();
        if (Player != null) Jonh.Energia();

        //El objeto equipado con este tiene que tener IsTrigger
    }

    //Puedo hacer Una colision entre el enemigo y la vida para que se active la funcion 
}

// CREAR OTRO SCRIPT Y HACER LA COMCPROBACION CON UN NUEVO CODIGO ,PARA QUE SOLO REACCIONE CON LA INTERACCION DEL JUGADOR 