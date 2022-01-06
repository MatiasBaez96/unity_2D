using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptVar : MonoBehaviour
{
   public Slider Slider;
    public GameObject EndMusicGO;
    public AudioSource EndMusic;
    public AudioClip EndMusicClip;

    public static ScriptVar ScriptVarVariable;  

    private void Start()
    {
        EndMusicGO = GameObject.Find("HolderVar");
        EndMusic = EndMusicGO.GetComponent<AudioSource>();

        Slider = GetComponent<Slider>();
    }
    private void Update()
    {
       
    }
    public void SetMaxHealth(int Valor)
    {
        Slider.maxValue = Valor ;     //Null Reference 
        Slider.value = Valor;
    }
    public void SetHealth(int Health)
    {
        Slider.value -= Health ;
        if (Slider.value <= 0) MusicaMuerte();
        if (Slider.value <= 0) DetenerSonido();
    }
    public void RecibeVida(int Valor)
    {
        Slider.value += Valor;
    }
    public void DetenerSonido()
    {        
        Camera.main.GetComponent<AudioSource>().Stop();
    }
    private void MusicaMuerte()
    {
      
        EndMusic.PlayOneShot(EndMusicClip);
        
    }
}
