using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public GameObject JonhGo;
    public Movements Jonh;

    void Start()
    {
        JonhGo = GameObject.Find("john");
        Jonh = JonhGo.GetComponent<Movements>();
    }


    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Evento de Collision");
        Jonh = collision.GetComponent<Movements>();
        if (Jonh != null) Jonh.Energia();
        Destroy(gameObject);
    }
}
