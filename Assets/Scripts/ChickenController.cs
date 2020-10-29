using UnityEngine;

public class ChickenController : MonoBehaviour
{
    public GameManager manager;
    private AudioManager audioManager;

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
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.IsGameOver == false)
        {
            //Timer is used to drop egg in random Time.
            timer -= Time.deltaTime;

            if (timer < 0f)
            {
                int randomNumber = Random.Range(0, randomTimer.Length);

                timer = randomTimer[randomNumber];
                Debug.Log(timer);

                audioManager.PlayClip(audioManager.dropEggClip);
                Instantiate(egg, dropEggPosition.position, dropEggPosition.rotation);
            }

            //For Moving Right and Flip to move Left.
            if (isFlipped == false && transform.position.x < 2f)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (isFlipped == false && transform.position.x >= 2f)
            {
                isFlipped = true;
                spriteRenderer.flipX = isFlipped;
            }

            //For Moving Left and Flip to move Right.
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
