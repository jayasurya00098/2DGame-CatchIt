using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    private GameManager manager;
    private AudioManager audioManager;

    public GameObject omblet;
    public Transform dropOmbletPosition;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        audioManager = AudioManager.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioManager.PlayClip(audioManager.crackingEgg);
            manager.ReduceLife();

            Instantiate(omblet, dropOmbletPosition.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Basket"))
        {
            audioManager.PlayClip(audioManager.collectingEggClip);

            manager.Score += 10;

            Destroy(gameObject);
        }
    }
}
