using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button Levels;
    

    public void GoNextLevel()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
}
