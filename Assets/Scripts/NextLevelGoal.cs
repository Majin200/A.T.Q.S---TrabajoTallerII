using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLevelGoal : MonoBehaviour
{
    public Button Levels;
    public CanvasGroup nextLevelScreen;
    public GameObject victoryCanvas;

    public void Start()
    {
        nextLevelScreen.alpha = 0;
        victoryCanvas.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            nextLevelScreen.alpha = 1;
            victoryCanvas.SetActive(true);
        }
       
    }


   
}
