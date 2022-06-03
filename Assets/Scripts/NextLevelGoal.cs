using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLevelGoal : MonoBehaviour
{
    public Button Levels;
    public CanvasGroup nextLevelScreen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            nextLevelScreen.alpha = 1;
        }
       
    }


    public void GoLeve2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
    public void GoLeve3()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }
    public void GoLeve4()
    {
        SceneManager.LoadScene("Level4", LoadSceneMode.Single);
    }


   public void ResetLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);

    }
    public void ResetLevel2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);

    }
    public void ResetLevel3()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);

    }
}
