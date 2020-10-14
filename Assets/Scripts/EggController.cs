using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    private GameManager manager;

    public GameObject omblet;
    public Transform dropOmbletPosition;

    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            manager.ReduceLife();

            Instantiate(omblet, dropOmbletPosition.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Basket"))
        {
            manager.Score += 10;

            Destroy(gameObject);
        }
    }
}
