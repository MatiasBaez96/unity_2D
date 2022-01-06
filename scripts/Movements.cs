using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public Rigidbody2D RigidBody2D; //Modificamos la velocidad de Jonh 

    float JumpForce = 160f;
    float Speed = 1f;

    public Animator AnimatorVar;
    
    private float Horizontal;    

    public GameObject BulletGO;
    public GameObject VariantBullet;

    private int Damage = 20;

    private float LastSghot; //Almacena el tiempo en el que se efectuo el ultimo disparo (ej: seg 3 5 )

    public int HealthVarValue = 35;
    private int CurrentHealth;

    public ScriptVar ScriptVarComp;

    private int Muerte = 100;

    public VidaRecivida HeartLife;
    private int Energia1 = 20;

    public AudioClip JumpSound;
    public AudioClip BulletHurt;
    public AudioClip TakeLife;
    public AudioClip BulletSound;
    public AudioSource Steps;

    private bool Ground;
    public bool WalkingAnimation;
    bool DiagonalActivated;
    public bool OtroScriptBool;

    float WalkingLastTime;

    public UnityEngine.UI.Image FadeIn;
    float ValorFadeOutObjetivo;

    public Bullet DisableScript;

    public GameObject DustRunnGO;
    public Animator DustRunnAnimator;

    public Transform FirePoint;
    public Transform DownShotPoint;
    public Transform DownShotNegative;
   
    float BulletVelocity = 8.0f;

    public Rigidbody2D BulletRigidBody;

    bool LookingDownBool;

    float Velocity = 50f;

    Vector2 DiagonalDirection;

    bool HorizontalBool;
    void Start()
    {
        
        Debug.Log("valor cambiado de la variable : " + Variables.JumpSound);

        BulletRigidBody = BulletGO.GetComponent<Rigidbody2D>();

        DustRunnGO = GameObject.Find("DustRunn");
        DustRunnAnimator = DustRunnGO.GetComponent<Animator>();

        Variables.CurrentHealth = Variables.HeartVarValue;
        ScriptVar.ScriptVarVariable.SetMaxHealth(Variables.HeartVarValue);

        RigidBody2D = GetComponent<Rigidbody2D>();
        AnimatorVar = GetComponent<Animator>();

        Steps = GetComponent<AudioSource>();
    }
    void Update()
    {
        //ComprobacionMovimiento();//1

        //ComprobacionSalto();//1

       // DisparoDeLados();//2

        ComprobacionPasos(); //Ejecuta el sonido () 3

        MuertePorCaida(); //4 

        //DisparosDiagonalArriba();//2  (Reemplazo)MovementsFuntions.Apuntados();

        ComprobacionDustAnimaton();//3

        DisparoHaciaAbajo();//2 (Varias funciones dentro)




        //Nuevo 
        MovementsFuntions.ComprobacionMovimiento();
        MovementsFuntions.ComprobacionSalto();
        MovementsFuntions.Apuntados();

        ShothingFuntions.DisparoDeLados();
        



    }
    private void AnimacionAcostado()
    {
        if (Horizontal != 0.0f)
        {
            AnimatorVar.SetBool("Acostado", false);
            transform.gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.1200228f, 0.1772738f);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            transform.gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.1200228f, 0.1772738f);
            AnimatorVar.SetBool("Acostado", false);
        }
        
    }

    private void DisparoHaciaAbajo()
    {
        if (Input.GetKey(KeyCode.S))//Boolean
        {
            Debug.Log("Animacion mirando hacia abajo ");

            LookingDownBool = true;
            //DisableScript.enabled = false;
            AnimatorVar.SetBool("LookingDown", true);//quisas se setea constantemente esta animacion y no cambia la animacion(poco probable )        
            LookingDown();

            if (Input.GetKey(KeyCode.J) && transform.localScale == new Vector3(-1, 1, 1) && Time.time > LastSghot + 0.25)
            {
                Debug.Log("Shothig Down Left Size : If ");
                
                LastSghot = Time.time;
                DownShotLeft();
            }
            if (Input.GetKey(KeyCode.J))
            {                
                AnimatorVar.SetBool("DownShot", true);             
            }         
            else
            {            
                AnimatorVar.SetBool("DownShot", false);
            }        
        }
        else
        {
            Debug.Log("Soltar la tecla S : Else ");

            LookingDownBool = false;
            AnimatorVar.SetBool("LookingDown", false);
            AnimatorVar.SetBool("DownShot", false);
           //DisableScript.enabled = true;
        }
      
        if (Horizontal != 0.0 && Input.GetKey(KeyCode.S))
        {
            Debug.Log("Animacion de correr mirando hacia abajo : If");
            AnimatorVar.SetBool("Running Shot Down", true);
        }
        else
        {
            Debug.Log("Animacion de correr mirando hacia abajo : Else ");
            AnimatorVar.SetBool("Running Shot Down", false);
        }
    }

    private void ComprobacionDustAnimaton()
    {
        if (Horizontal != 0 && Ground) Dust();
        else
        {
            DustRunnAnimator.SetBool("DustRun", false);
        }
    }
    private void DisparosDiagonalArriba()
    {
        if (Horizontal != 0.0 && Input.GetKey(KeyCode.W))
        {
            DiagonalShothingAnimation();  //Comprobar que este en el piso 
        }
        else
        {
            AnimatorVar.SetBool("WhileRunning", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            DiagonalActivated = true;
            StandingDiagonalFuntion();
        }
        else
        {
            DiagonalActivated = false;
            AnimatorVar.SetBool("StandingDiagonal", false);
            AnimatorVar.SetBool("ShoothingDiagonal", false);
            DisableScript.enabled = true;
        }
    }
    private void MuertePorCaida()
    {
        if (transform.position.y < -4.888)
        {
            Variables.CurrentHealth = 0;
            if (Variables.CurrentHealth <= 0) Die();
            ScriptVarComp.SetHealth(Muerte);
        }
        //if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
    }
    private void ComprobacionPasos()
    {
        if (WalkingAnimation = Horizontal != 0.0 && Time.time > WalkingLastTime + 0.3f)
        {
            WalkingLastTime = Time.time;

            if (Ground) WalkingSound();
        }
    }
    private void DisparoDeLados()
    {
        if (Input.GetKey(KeyCode.J) && Time.time > LastSghot + 0.25f && !DiagonalActivated && !LookingDownBool) //Si el ultimo disparo fue en el seg 3 le sumamos 0.25f, en el segundo 3.25 volve a disparar (Time.time" tiene que ser mas grande)
        {
            AnimatorVar.SetBool("ShootingStanding", true);
            LastSghot = Time.time; //Almacenamos el tiempo en la variable cuando disparamos             
            Shot();
        }
        else if ((Input.GetKey(KeyCode.J)))
        {
            //quisas los segundos sumados en el primer condicional,provocan que "Else" se ejecute entre disparos
            AnimatorVar.SetBool("ShootingStanding", true);
        }
        else
        {
            AnimatorVar.SetBool("ShootingStanding", false);
        }//Done
    }
    private void ComprobacionSalto()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.2f, Color.red);

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.2f)) //Si el rayo invisible Colisiona es true , sino "False" 
        {
            Ground = true;
        }
        else
        {
            Ground = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Ground) //Salto Vetical/Diagonal 
        {
            Jump();
        }
    }
    private void ComprobacionMovimiento()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");   //Valores de -1 a 1 en funcion del tde las teclas que estams usando(A D)
        //Null Refeerence
        AnimatorVar.SetBool("Running", Horizontal != 0.0f  );  // Horizontal != 0.0f(si horizontal no es igual a 0.0f va a valer true)

        if (Horizontal < 0) transform.localScale = new Vector3(-1, 1, 1);
        else if (Horizontal > 0) transform.localScale = new Vector3(1, 1, 1); //Si pongo else mira hacia la derecha sino presionamos A

        if (Horizontal != 0.0 ) //Problema Solucionar 
        {
            if (Input.GetKey(KeyCode.J) && Time.time > LastSghot + .25f && !DiagonalActivated && !LookingDownBool) //Agregar Boolean para que no dispare cuando no queremso
            {
                LastSghot = Time.time;
                Shot();
            }
            else if (Input.GetKey(KeyCode.J))
            {
                AnimatorVar.SetBool("Run Shot Front",true);
            }
            else
            {
                AnimatorVar.SetBool("Run Shot Front", false);
            }
        }    
        else
        {
            AnimatorVar.SetBool("Run Shot Front", false);
        }
    }

    private void LookingDown()
    {
       

        if (Input.GetKey(KeyCode.J) && Time.time > LastSghot + 0.25f && transform.localScale == new Vector3(1, 1, 1))
        {
            Debug.Log("Shothing Down Right Size : If ");
            AnimatorVar.SetBool("DownShot", true);
            LastSghot = Time.time;
            DownShotRight();//comprobar si crear nueva funcion
        }
        else
        {
            Debug.Log("Shothing Down Right Size : Else  ");
            AnimatorVar.SetBool("DownShot",false);
        }
    }
    private void Dust()
    {
        DustRunnAnimator.SetBool("DustRun", true);
    }
    private void StandingDiagonalFuntion()
    {
        
        AnimatorVar.SetBool("StandingDiagonal", true);
        //DisableScript.enabled = false ;
        ShoothingDiagonalFuntion();
    }

    private void DiagonalShothingAnimation()
    {
        AnimatorVar.SetBool("WhileRunning", true);
    }

    private void WalkingSound()
    {
        Steps.Play();
    }

    public void Acostado()
    {
        AnimatorVar.SetBool("Acostado", true);
        transform.gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.1200228f, 0.0001f);
    }

    private void Shot()
    {
        Vector3 direction;

        if (transform.localScale.x == 1.0f) direction = Vector2.right;
        //else if (transform.localScale.x == -1.0f) direction = Vector2.left;(creo que al no estar el valor definido da error mandando la direccion , "Else" queda defimnido con un valor y lo permite )
        else direction = Vector2.left;

        GameObject BulletObject = Instantiate(BulletGO, transform.position + direction * 0.2F, Quaternion.identity);//Vectore tienen que ser del mismo tipo / direction * 0.1f (en la direccion que este le agrega 0.1 en ofset)
        BulletObject.GetComponent<Bullet>().SetDirection(direction); 
    }

    private void Jump()
    {
        Debug.Log("Jump Funtion");
        AnimatorVar.SetBool("Jump", true);
        Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpSound);
        RigidBody2D.AddForce(Vector2.up * JumpForce); //(0,1) la X=0 y l Y=1,significa que va hacia arriba(comprobar que tenga la suficiente fuerza dsino no saltara )

        if (Ground) AnimatorVar.SetBool("Jump",false);
    }
    private void FadeOutFuntion()
    {
        ValorFadeOutObjetivo = 2;
    }
    private void FixedUpdate()       
    {
                                                                                       //Cuando trabajamos acon fisicas necesitamos actualizarlo constantemente (es constante los fames no se modifican)
        RigidBody2D.velocity = new Vector2(Horizontal * Speed, RigidBody2D.velocity.y);  //RigidBody2D.velocity.y: no queremos rotacion en el objeto(lo igualamos a la posicion en la que esta eje y)

        float ValorAlfa = Mathf.Lerp(FadeIn.color.a, ValorFadeOutObjetivo, .05f); //(Posicion Actual,Objetivo, Time)

        FadeIn.color = new Color(0, 0, 0, ValorAlfa); //R,G,B (0,0,0 (COLOR negro))
    }

    public void Hit()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletHurt);
        ScriptVarComp.SetHealth(Damage);
        Variables.CurrentHealth -= Damage;
        if (Variables.CurrentHealth <= 0) Die();
    }

    private void Die()
    {
        //Destroy(gameObject);//Si el Objeto se destruye,se destruye el Script junto con el Jugador(No llega a invokarse la funcion "DetenerSonido")

        //Desactivar el collider ( por seguridad )

        //Anim Muerte 
        AnimatorVar.SetTrigger("MuerteAnimacion");

        RigidBody2D.velocity = new Vector2(0, 5);    
    
        Invoke("DestruirJugador", 0.4f);

        FadeOutFuntion();
    }

    private void DestruirJugador()
    {
        gameObject.SetActive(false);
    }

    public void Energia()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(TakeLife);
        HeartLife.gameObject.SetActive(false);
        Variables.CurrentHealth += 20;
        ScriptVarComp.RecibeVida(Energia1);
    }

    private void ShoothingDiagonalFuntion()
    {
        if (Input.GetKey(KeyCode.J) && Time.time > LastSghot + 0.25f && !LookingDownBool) //Si el ultimo disparo fue en el seg 3 le sumamos 0.25f, en el segundo 3.25 volve a disparar (Time.time" tiene que ser mas grande)
        {  
            LastSghot = Time.time; //Almacenamos el tiempo en la variable cuando disparamos
            
            DifferentShot();      
        }
        if ((Input.GetKey(KeyCode.J)) && Input.GetKey(KeyCode.W))
        {           
            AnimatorVar.SetBool("ShoothingDiagonal", true);
        }
        else
        {
            AnimatorVar.SetBool("ShoothingDiagonal", false);
        }
    }   

        private void DifferentShot()
        {
        
          Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletSound); 
          GameObject Bullet = Instantiate(VariantBullet, FirePoint.position, FirePoint.transform.rotation);
          Bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * BulletVelocity, ForceMode2D.Impulse);
        }

    private void DownShotRight()
    {  
            DiagonalDirection = new Vector2(0.118f, -0.116f);
            
            Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletSound);
            GameObject Bullet = Instantiate(VariantBullet, DownShotPoint.position, DownShotPoint.rotation);
            Bullet.GetComponent<Rigidbody2D>().AddForce(DiagonalDirection * Velocity, ForceMode2D.Impulse);
    }
    private void DownShotLeft()
    {
        Vector2 DiagonalLeftDirection = new Vector2(-0.218f, -0.155f);

        Camera.main.GetComponent<AudioSource>().PlayOneShot(BulletSound);
        GameObject Bullet = Instantiate(VariantBullet , DownShotNegative.position, DownShotNegative.rotation);
        Bullet.GetComponent<Rigidbody2D>().AddForce(DiagonalLeftDirection * Velocity , ForceMode2D.Impulse);
    }
  //crear otra Funcion 
}

//tambien podria desactivar la imagen del objeto y crear la funcion de musica final aca 



/*if (Input.GetKey(KeyCode.J) && Time.time > LastSghot + 0.25f)
 * {
 * Se cumple este condiciona;l cada siertos segundos <entre esos segundo se ejecuta lo que hay en Else )
 * }
 
else 
{

}
*/ 
   


//voy corriendo y disparando (DisparosDiagonalArriba(): agregarlo detro de la funcion ComprobacionMovimiento()"Fluidez*+
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//
//"?