using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public GameManager manager;

    public float speed;
    public bool isFlipped = false;

    public float timer = 2f;
    public float[] randomTimer = { 0.2f, 0.5f, 1f, 2f, 4f };

    public Transform dropEggPosition;
    public GameObject egg;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.IsGameOver == false)
        {
            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                int randomNumber = Random.Range(0, randomTimer.Length);

                timer = randomTimer[randomNumber];
                Debug.Log(timer);

                Instantiate(egg, dropEggPosition.position, dropEggPosition.rotation);
            }

            //Debug.Log(timer);

            if (isFlipped == false && transform.position.x < 2f)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (isFlipped == false && transform.position.x >= 2f)
            {
                isFlipped = true;
                spriteRenderer.flipX = isFlipped;
            }

            if (isFlipped == true && transform.position.x > -2f)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            else if (isFlipped == true && transform.position.x <= -2f)
            {
                isFlipped = false;
                spriteRenderer.flipX = isFlipped;
            }
        }
    }
}
