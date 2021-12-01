using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameter
    Vector3 paddleToBall;
    bool hasStarted;
    [SerializeField] float randomSize = 0.2f;

    //cached reference
    AudioSource myAudio;
    [SerializeField] Paddle paddle1;
    [SerializeField] AudioClip[] ballSounds;

    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
        hasStarted = false;
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            shoot();
        }
        
    }

    private void LockBallToPaddle()
    {
        transform.position = paddle1.transform.position + paddleToBall;
    }

    private void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length - 1)];
        if (hasStarted)
        {
            myAudio.PlayOneShot(clip);
        }
        GetComponent<Rigidbody2D>().velocity += new Vector2(Random.Range(0f, randomSize), Random.Range(0f, randomSize));
    }
}
