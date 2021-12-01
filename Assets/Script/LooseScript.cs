using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LooseScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int index = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene("Game Over");
        FindObjectOfType<GameStatus>().DestroyItSelt();
    }
}
