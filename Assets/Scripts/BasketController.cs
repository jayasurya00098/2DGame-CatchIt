using UnityEngine;

public class BasketController : MonoBehaviour
{
    public GameManager manager;
    public float speed;

    private Vector2 startPoint = Vector2.zero;
    private Vector2 currentPoint = Vector2.zero;

    // Update is called once per frame
    void Update()
    {
        if(manager.IsGameOver == false)
        {
#if UNITY_EDITOR
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
#elif UNITY_ANDROID
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPoint = touch.position;
                    break;
                case TouchPhase.Moved:
                    currentPoint = touch.position;
                    if(startPoint.x > currentPoint.x && transform.position.x >= -2f)
                    {
                        float hor = startPoint.x - currentPoint.x;
                        transform.Translate(Vector2.left * (hor / 10) * speed * Time.deltaTime);
                    }
                    else if(startPoint.x < currentPoint.x && transform.position.x <= 2f)
                    {
                        float hor = currentPoint.x - startPoint.x;
                        transform.Translate(Vector2.right * (hor / 10) * speed * Time.deltaTime);
                    }
                    startPoint = currentPoint;
                    break;
                case TouchPhase.Ended:
                    startPoint = Vector2.zero;
                    currentPoint = Vector2.zero;
                    break;
            }
#endif
        }
    }
}
