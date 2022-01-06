using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{   //Integers 
    public static int HeartVarValue =100 ;
    public static int CurrentHealth;
    public const int Damage = 20;
    public const int Muerte = 100;
    public const int Energia1 = 20;

    //Bools 
    public static bool Ground ;
    public static bool WalkingAnimation;
    public static bool DiagonalActivated;
    public static bool OtroScriptBool;
    public static bool LookingDownBool;
    public static bool HorizontalBool;

    //Floats 
    public static float JumpForce = 160f;
    public static float Speed = 1f;
    public static float Horizontal;
    public static float LastSghot;
    public static float WalkingLastTime;
    public static float ValorFadeOutObjetivo;
    public static float BulletVelocity = 8.0f;
    public static float Velocity = 50f;

    //Tranforms 
    public static Transform FirePoint;
    public static Transform DownShotPoint;
    public static Transform DownShotNegative;
    public static Transform ScaleObcjet;
    public static Transform PositionObcjet;

    //RigidBody
    public static Rigidbody2D BulletRigidBody;
    public static Rigidbody2D PlayerRigidBody;

    //Vector2
    public static Vector2 DiagonalDirection;

    //Animator
    public static Animator AnimatorVar;

    //Game Obcjets
    public static GameObject BulletGO;
    public static GameObject VariantBullet;
    public static  GameObject DustRunnGO;

    //Variables Sounds 
    public static AudioClip JumpSound;
    public static AudioClip BulletHurt;
    public static AudioClip TakeLife;
    public static AudioClip BulletSound;
    public static AudioClip Audio;
    public static AudioSource Steps;
}
