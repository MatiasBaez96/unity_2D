using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShothingFuntions : MonoBehaviour
{
    void Start()
    {

    }
    void Update()
    {

    }
    public static void Shot()
    {
       
        Vector3 direction;

        if (Variables.ScaleObcjet.localScale.x == 1.0f) direction = Vector2.right;
        //else if (transform.localScale.x == -1.0f) direction = Vector2.left;(creo que al no estar el valor definido da error mandando la direccion , "Else" queda defimnido con un valor y lo permite )
        else direction = Vector2.left;

        GameObject BulletObject = Instantiate(Variables.BulletGO, Variables.PositionObcjet.position + direction * 0.2F, Quaternion.identity);//Vectore tienen que ser del mismo tipo / direction * 0.1f (en la direccion que este le agrega 0.1 en ofset)
        BulletObject.GetComponent<Bullet>().SetDirection(direction);
    }
    public static void DisparoDeLados()
    {
        if (Input.GetKey(KeyCode.J) && Time.time > Variables.LastSghot + 0.25f && !Variables.DiagonalActivated && !Variables.LookingDownBool) //Si el ultimo disparo fue en el seg 3 le sumamos 0.25f, en el segundo 3.25 volve a disparar (Time.time" tiene que ser mas grande)
        {
           // Variables.AnimatorVar.SetBool("ShootingStanding", true);
            Variables.LastSghot = Time.time; //Almacenamos el tiempo en la variable cuando disparamos             
            Shot();
        }
        else if ((Input.GetKey(KeyCode.J)))
        {
            //quisas los segundos sumados en el primer condicional,provocan que "Else" se ejecute entre disparos
            Animations.ShothingStandingTrue();
        }
        else
        {
            Animations.ShothingStandingFalse();
        }
    }
    public static void ShoothingDiagonalFuntion()
    {
        

        if (Input.GetKey(KeyCode.J) && Time.time > Variables.LastSghot + 0.25f && !Variables.LookingDownBool) //Si el ultimo disparo fue en el seg 3 le sumamos 0.25f, en el segundo 3.25 volve a disparar (Time.time" tiene que ser mas grande)
        {
            Variables.LastSghot = Time.time; //Almacenamos el tiempo en la variable cuando disparamos

            DifferentShot();
        }
        if ((Input.GetKey(KeyCode.J)) && Input.GetKey(KeyCode.W))
        {
            Animations.ShothingStandingDiagonalTrue();
        }
        else
        {
            Animations.ShothingStandingDiagonalFalse();
        }
    }
    private static void DifferentShot()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Variables.BulletSound);
        GameObject Bullet = Instantiate(Variables.VariantBullet, Variables.FirePoint.position, Variables.FirePoint.transform.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(Variables.FirePoint.up * Variables.BulletVelocity, ForceMode2D.Impulse);
    }
    private void PointingDown() //Cambiarla a la funcio "MovementsFuntions" 
    {
        if (Input.GetKey(KeyCode.S))//Boolean
        {
            Variables.LookingDownBool = true;
            //DisableScript.enabled = false;
            Animations.LookingDownTrue();        
            MovementsFuntions.LookingDown(); //Cambiar el nombre A "Shothing" pasawrlo a la clase "ShothingFuntions"

            ShothingDown();
        }
        else
        {          
            Variables.LookingDownBool = false;
            Animations.LookingDownFalse();
            Animations.DownShotFalse();
            //DisableScript.enabled = true;
        }
        if (Variables.Horizontal != 0.0 && Input.GetKey(KeyCode.S))
        {
            Animations.RunningShotDownTrue();
        }
        else
        {
            Animations.RunningShotDownFalse();
        }
    }
     void ShothingDown()
    {
        // NEW FUNTION
        //Quisas meter la parte que dispara dentro de una funcion (Crear funcion con nombre : Disparar hacia abajo)
        if (Input.GetKey(KeyCode.J) && transform.localScale == new Vector3(-1, 1, 1) && Time.time > Variables.LastSghot + 0.25)
        {
            Variables.LastSghot = Time.time;
            LeftDirection(); //Cabiar nombre a :"LeftDirection" 
        }
        if (Input.GetKey(KeyCode.J))
        {
            Animations.DownShotTrue();
        }
        else
        {
            Animations.DownShotFalse();
        }
    }
    private void LeftDirection()
    {
        Vector2 DiagonalLeftDirection = new Vector2(-0.218f, -0.155f);

        Camera.main.GetComponent<AudioSource>().PlayOneShot(Variables.BulletSound);
        GameObject Bullet = Instantiate(Variables.VariantBullet, Variables.DownShotNegative.position, Variables.DownShotNegative.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(DiagonalLeftDirection * Variables.Velocity, ForceMode2D.Impulse);
    }
    public static void RightDirection()
    {
        Variables.DiagonalDirection = new Vector2(0.118f, -0.116f);

        Camera.main.GetComponent<AudioSource>().PlayOneShot(Variables.BulletSound);
        GameObject Bullet = Instantiate(Variables.VariantBullet, Variables.DownShotPoint.position, Variables.DownShotPoint.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(Variables.DiagonalDirection * Variables.Velocity, ForceMode2D.Impulse);
    }
}
