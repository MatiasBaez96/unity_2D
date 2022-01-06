using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementsFuntions : MonoBehaviour
{  
    void Start()
    {
     //Si almaceno una variable desde este codigo,funciona en los otros 'Scripts'??
    }
    public static void ComprobacionMovimiento()
    {
        Variables.Horizontal = Input.GetAxisRaw("Horizontal");   //Valores de -1 a 1 en funcion del tde las teclas que estams usando(A D)
                                                                 //Null Refeerence
        Animations.AnimationCorrer();

        if (Variables.Horizontal < 0) Variables.ScaleObcjet.localScale = new Vector3(-1, 1, 1);
        else if (Variables.Horizontal > 0) Variables .PositionObcjet.localScale = new Vector3(1, 1, 1); //Si pongo else mira hacia la derecha sino presionamos A

        if (Variables.Horizontal != 0.0) //Problema Solucionar 
        {
            if (Input.GetKey(KeyCode.J) && Time.time > Variables.LastSghot + .25f && !Variables.DiagonalActivated && !Variables.LookingDownBool) //Agregar Boolean para que no dispare cuando no queremso
            {
               Variables.LastSghot = Time.time;
               ShothingFuntions.Shot();   //Funtion(Agregar)
            }
            else if (Input.GetKey(KeyCode.J))
            {
                Animations.RunShotFrontTrue();
            }
            else
            {
                Animations.RunShotFrontFalse();
            }
        }
        else
        {
            Animations.RunShotFrontFalse();
        }
    }
    public static void ComprobacionSalto()
    {
        Debug.DrawRay(Variables.PositionObcjet.position, Vector3.down * 0.2f, Color.red);

        if (Physics2D.Raycast(Variables.PositionObcjet.position, Vector3.down, 0.2f)) //Si el rayo invisible Colisiona es true , sino "False" 
        {
            Variables.Ground = true;
        }
        else
        {
            Variables.Ground = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Variables.Ground) //Salto Vetical/Diagonal 
        {
            Jump();
        }
    }
    private static void Jump()
    {
        Animations.JumpTrue();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Variables.JumpSound);
        Variables.PlayerRigidBody.AddForce(Vector2.up * Variables.JumpForce); //(0,1) la X=0 y l Y=1,significa que va hacia arriba(comprobar que tenga la suficiente fuerza dsino no saltara )

        if (Variables.Ground) Animations.JumpFalse();
    }
    public static void LookingDown() //Cambiarla a Clase "ShothingFuntions"-----(DIVIDIR LAS FUNCIONES DE APUNTADO DE LOS DE DISPAROS)
    {
        if (Input.GetKey(KeyCode.J) && Time.time > Variables.LastSghot + 0.25f && Variables.ScaleObcjet.localScale == new Vector3(1, 1, 1))
        {
            Animations.DownShotTrue();
            Variables.LastSghot = Time.time;
            ShothingFuntions.RightDirection();   
        }
        else
        {
            Animations.DownShotFalse();
        }
    }
    public static void Apuntados() //CAMBIAR a LA CLASE "MOVEMENTS fUNTIONS"
    {
        if (Variables.Horizontal != 0.0 && Input.GetKey(KeyCode.W))
        {
            // DiagonalShothingAnimation();  //Comprobar que este en el piso  --------(arreglar))

            Animations.WhileRunningTrue(); //APUNTA (CAMBIAR)
        }
        else
        {
            Animations.WhileRunningFalse();
        }
        if (Input.GetKey(KeyCode.W))
        {
            Variables.DiagonalActivated = true;
            //StandingDiagonalFuntion();----------(Arreglar) {Agregar ShoothingDiagonalFuntion()Variables.AnimatorVar.SetBool("ShoothingDiagonal", true);;}
            ShothingFuntions.ShoothingDiagonalFuntion();
            Animations.StandingDiagonalTrue(); //APUNTA ESTANDO PARADO 
        }
        else
        {
            Variables.DiagonalActivated = false;
            Animations.StandingDiagonalFalse();
            Animations.ShothingStandingDiagonalFalse();
            //DisableScript.enabled = true; 
        }
    }
}
