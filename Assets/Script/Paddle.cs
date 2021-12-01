using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //config para
    [SerializeField] float unitWidth = 16f;
    [SerializeField] float min, max;

    //cached reference
    GameStatus gameStatus;
    Ball ball;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        Vector3 paddlePosInUnit = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        paddlePosInUnit.x = Mathf.Clamp(PaddlePosition(), min, max);
        transform.position = paddlePosInUnit;
    }

    float PaddlePosition()
    {
        if (gameStatus.GetAutoPlay())
        {
            return ball.transform.position.x;
        }
        return Input.mousePosition.x / Screen.width * unitWidth;
    }
}
