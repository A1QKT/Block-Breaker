using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceLoader : MonoBehaviour
{

    public void LoadScence()
    {
      
        int currentScence = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(GetNextScence(currentScence));
        if (currentScence + 1 == SceneManager.sceneCountInBuildSettings - 1)
            FindObjectOfType<GameStatus>().DestroyItSelt();
    }
    private int GetNextScence(int index)
    {
        if (index == SceneManager.sceneCountInBuildSettings - 1)
            return 0;
        return index + 1; 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
