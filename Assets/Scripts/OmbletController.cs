using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmbletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 2f);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
