using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteRecompensa : MonoBehaviour
{
    int Health = 3;
   
    public VidaRecivida RecompensaScript;

    public GameObject Jonh;

    private float LastShot;
    public GameObject BulletGO;

    void Start()
    {
        
        
    }   
    void Update()
    {
        if (Jonh == null) return; //Return nos saca de la funcion y el codigo no se ejecuta mas 

        Vector3 Direction = Jonh.transform.position - transform.position;
        if (Direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); //Direction.x >= 0.0f: si es positiba them...(si el jugador pasa al enemigo es positivo)
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f); //Si esta antes del enemigo:es negativo 

        float Distance = Mathf.Abs(Jonh.transform.position.x - transform.position.x); //si Jonh esta a 5 de distancia ,y enemigo a 2 = 3,entonces 3 es la distancia
                                                                                      //pero si Jonh esta en la posicion 3 y enemigo en la 5 va a dar NEGATIVO,para evitarlo: Mathf.Abs(): de lo contrario no mide la distancia y siempre dispara 

        if (Distance < 1.3f && Time.time > LastShot + 0.50f)
        {
            LastShot = Time.time;

            ShotDiferentHight();
        }
    }
    private void ShotDiferentHight()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject BulletObject = Instantiate(BulletGO, transform.position + direction * 0.1f, Quaternion.identity);//Vectore tienen que ser del mismo tipo / direction * 0.1f (en la direccion que este le agrega 0.1 en ofset)
        BulletObject.GetComponent<Bullet>().SetDirection(direction);
    }
    public void HitEnemy2()
    {
        Health = Health - 1;
        if (Health <= 0) Muerte();
    }
    private void Muerte()
    {
        Destroy(gameObject);
        RecompensaScript.ActivarObjeto();
    }
}
