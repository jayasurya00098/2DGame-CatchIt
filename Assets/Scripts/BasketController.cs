using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public GameManager manager;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(manager.IsGameOver == false)
        {
            //gets input values
            float horizontal = Input.GetAxis("Horizontal");

            //blocks movement beyond 2f or -2f
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
