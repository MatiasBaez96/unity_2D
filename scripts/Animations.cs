using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{       
    public static void AnimationCorrer()
    {
        Variables.AnimatorVar.SetBool("Running", Variables.Horizontal != 0.0f);  // Horizontal != 0.0f(si horizontal no es igual a 0.0f va a valer true)
    }
    public static void RunShotFrontTrue()
    {
        Variables.AnimatorVar.SetBool("Run Shot Front", true);
    }
    public static void RunShotFrontFalse()
    {
      Variables.AnimatorVar.SetBool("Run Shot Front", false);
    }
    public static void JumpTrue()
    {
        Variables.AnimatorVar.SetBool("Jump", true);
    }
    public static void JumpFalse()
    {
        Variables.AnimatorVar.SetBool("Jump",false);
    }
    public static void ShothingStandingTrue()
    {
        Variables.AnimatorVar.SetBool("ShootingStanding", true);
    }
    public static void ShothingStandingFalse()
    {
        Variables.AnimatorVar.SetBool("ShootingStanding", false);
    }
    public static void WhileRunningTrue()
    {
        Variables.AnimatorVar.SetBool("WhileRunning", true);
    }
    public static void WhileRunningFalse()
    {
        Variables.AnimatorVar.SetBool("WhileRunning", false);
    }
    public static void StandingDiagonalTrue()
    {
        Variables.AnimatorVar.SetBool("StandingDiagonal", true);
    }
    public static void StandingDiagonalFalse()
    {
        Variables.AnimatorVar.SetBool("StandingDiagonal", false);
    }
    public static void ShothingStandingDiagonalTrue()
    {
        Variables.AnimatorVar.SetBool("ShoothingDiagonal", true);
    }
    public static void ShothingStandingDiagonalFalse()
    {
        Variables.AnimatorVar.SetBool("ShoothingDiagonal", false);
    }
    public static void DownShotTrue()
    {
        Variables.AnimatorVar.SetBool("DownShot", true);
    }
    public static void DownShotFalse()
    {
        Variables.AnimatorVar.SetBool("DownShot", false);
    }
    public static void LookingDownTrue()
    {
        Variables.AnimatorVar.SetBool("LookingDown", true);
    }
    public static void LookingDownFalse()
    {
        Variables.AnimatorVar.SetBool("LookingDown", false);
    }
    public static void RunningShotDownTrue()
    {
        Variables.AnimatorVar.SetBool("Running Shot Down", true);
    }
    public static void RunningShotDownFalse()
    {
        Variables.AnimatorVar.SetBool("Running Shot Down", false);
    }
}
