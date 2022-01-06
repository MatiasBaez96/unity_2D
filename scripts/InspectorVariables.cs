using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorVariables : MonoBehaviour
{
    [SerializeField]private int HealthVarValue = 35;
    [SerializeField]private int CurrentHealth;
    [SerializeField]private int Damage = 20;
    [SerializeField]private int Energia1 = 20;
    [SerializeField]private int Muerte = 100;

    [SerializeField]private bool Ground;
    [SerializeField]private bool WalkingAnimation;
    [SerializeField]private bool DiagonalActivated;
    [SerializeField]private bool OtroScriptBool;
    [SerializeField]private bool LookingDownBool;
    [SerializeField] private bool HorizontalBool;

    [SerializeField]private float JumpForce = 160f;
    [SerializeField]private float Speed = 1f;
    [SerializeField]private float Horizontal;
    [SerializeField]private float LastSghot;
    [SerializeField]private float WalkingLastTime;
    [SerializeField]private float ValorFadeOutObjetivo;
    [SerializeField]private float BulletVelocity = 8.0f;
    [SerializeField]private float Velocity = 50f;

    [SerializeField]private Transform FirePoint;
    [SerializeField]private Transform DownShotPoint;
    [SerializeField]private Transform DownShotNegative;

    [SerializeField]private Rigidbody2D BulletRigidBody;
    [SerializeField]private Rigidbody2D PlayerRigidBody;  

    [SerializeField]private Vector2 DiagonalDirection;

    [SerializeField]private Animator AnimatorVar;
    [SerializeField]private Animator DustRunnAnimator;   

    [SerializeField]private GameObject BulletGO;
    [SerializeField]private GameObject VariantBullet;
    [SerializeField]private GameObject DustRunnGO;

    [SerializeField]private AudioClip JumpSound;
    [SerializeField]private AudioClip BulletHurt;
    [SerializeField]private AudioClip TakeLife;
    [SerializeField]private AudioClip BulletSound;
    [SerializeField]private AudioClip Audio;
    [SerializeField]private AudioSource Steps;

    [SerializeField]private ScriptVar ScriptVarComp; //--Reemplazada 

    [SerializeField]private VidaRecivida HeartLife;
       
    [SerializeField]private UnityEngine.UI.Image FadeIn;
    
    //public Bullet DisableScript;    
    void Start()
    {
        BulletRigidBody = BulletGO.GetComponent<Rigidbody2D>(); //Creo no sirve para nada

        DustRunnGO = GameObject.Find("DustRunn");//cambiar 
        DustRunnAnimator = DustRunnGO.GetComponent<Animator>();

        Variables.CurrentHealth = Variables.HeartVarValue;
        ScriptVar.ScriptVarVariable.SetMaxHealth(Variables.HeartVarValue);

        PlayerRigidBody = GetComponent<Rigidbody2D>();
        AnimatorVar = GetComponent<Animator>();

        Steps = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Values();
    }
    private void Values()
    {
        HealthVarValue = Variables.HeartVarValue;
        Damage = Variables.Damage;
        Muerte = Variables.Muerte;
        Energia1 = Variables.Energia1;

        Ground = Variables.Ground;
        WalkingAnimation = Variables.WalkingAnimation;
        DiagonalActivated = Variables.DiagonalActivated;
        OtroScriptBool = Variables.OtroScriptBool;
        LookingDownBool = Variables.LookingDownBool;
        HorizontalBool = Variables.HorizontalBool;

        JumpForce = Variables.JumpForce;
        Speed = Variables.Speed;
        Horizontal = Variables.Horizontal;
        LastSghot = Variables.LastSghot;
        WalkingLastTime = Variables.WalkingLastTime;
        ValorFadeOutObjetivo = Variables.ValorFadeOutObjetivo;
        BulletVelocity = Variables.BulletVelocity;
        Velocity = Variables.Velocity;

        FirePoint = Variables.FirePoint;
        DownShotPoint = Variables.DownShotPoint;
        DownShotNegative = Variables.DownShotNegative;
        //Transform ScaleObject ;
        //Transform PositionObject ;

        BulletRigidBody = Variables.BulletRigidBody;
        PlayerRigidBody = Variables.PlayerRigidBody;

        DiagonalDirection = Variables.DiagonalDirection;

        AnimatorVar = Variables.AnimatorVar;

        BulletGO = Variables.BulletGO;
        VariantBullet = Variables.VariantBullet;
        DustRunnGO = Variables.DustRunnGO;

        Variables.JumpSound = JumpSound;
        BulletHurt = Variables.BulletHurt;
        TakeLife = Variables.TakeLife;
        BulletSound = Variables.BulletSound;
        Audio = Variables.Audio;
        Steps = Variables.Steps;
    }
}
