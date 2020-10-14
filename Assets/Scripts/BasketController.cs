using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public GameManager manager;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.IsGameOver == false)
        {
            float horizontal = Input.GetAxis("Horizontal");

            if (transform.position.x <= 2f && horizontal > 0f)
            {
                transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
            }
            else if (transform.position.x >= -2f && horizontal < 0f)
            {
                transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
            }
        }
    }
}
