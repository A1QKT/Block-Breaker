using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    //config parameter
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject prefabSparkles;
    [SerializeField] Sprite[] healthSprite;
    [SerializeField] int health;

    //cached reference
    LoadWonGame instance;
    GameStatus gameStatus;

    private void Start()
    {
        if (tag == "Breakable")
        {
            instance = FindObjectOfType<LoadWonGame>();
            instance.addCount();

            gameStatus = FindObjectOfType<GameStatus>();
            health = healthSprite.Length;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        if (health == 0)
        {
            Destroy(gameObject);
            InstantiateParkle();
            instance.minusCount();
            gameStatus.GainPoint();

        }
        health--;
        GetComponent<SpriteRenderer>().sprite = healthSprite[health];
        
    }

    void InstantiateParkle()
    {
        GameObject sparkles = Instantiate(prefabSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);
    }
}
