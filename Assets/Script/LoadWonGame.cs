using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWonGame : MonoBehaviour
{
    int countBlock = 0;
    ScenceLoader loadWinScreen;

    private void Start()
    {
        loadWinScreen = FindObjectOfType<ScenceLoader>();
    }

    private void Update()
    {
        if(countBlock <= 0)
        {
            loadWinScreen.LoadScence();
        }
    }

    public void addCount()
    {
        countBlock++;
    }

    public void minusCount()
    {
        countBlock--;
    }
}
