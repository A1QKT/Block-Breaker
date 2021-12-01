using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    //config parameter
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] float poinPerDestroyBlock = 12;
    [SerializeField] float currentPoint;
    [SerializeField] bool autoPlay;

    //cached reference
    [SerializeField] TextMeshProUGUI score;

    private void Awake()
    {
        int countGameStatus = FindObjectsOfType<GameStatus>().Length;
        if(countGameStatus > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
                DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        currentPoint = 0;
    }

  
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void GainPoint()
    {
        currentPoint += poinPerDestroyBlock;
        score.text = currentPoint.ToString();
    }

    public void DestroyItSelt()
    {
        Destroy(gameObject);
    }

    public bool GetAutoPlay()
    {
        return autoPlay;
    }
}
