using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
   public Button Levels;
   public GameObject start;
   public GameObject stop;
   public Button GoBack;


   public void GoNextLevel()
   {
    SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
   }

   public void GoLeve2()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

   /*public void OnMouseDown() 
   {
    AudioSource[] audios = FindObjectsOfType<AudioSource>();
    foreach (AudioSource a in audios)
    {
        a.Play();
    }
    else
    {
     AudioSource[] audios = FindObjectsOfType<AudioSource>();    
     foreach (AudioSource a in audios)
     {
        a.Pause();
     }
    }
   }*/

   
}
