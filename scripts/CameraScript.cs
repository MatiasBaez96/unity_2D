using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Jonh;
    public AudioSource CameraAudio;

    
    void Start()
    {
       
    }
    void Update()
    {
        if (Jonh == null) return;

        Vector3 Position = transform.position; //Tomamos la posicion de la camra 

        Position.x = Jonh.transform.position.x; // Solo en el eje "X" (de izquierda a derecha )copiamos la posicion de Jonh 

        transform.position = Position ; //igualamos la posicion de la camara a la posicion de Jonh almacenada en el Eje "X"           
    }
 
}
