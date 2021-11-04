using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "up")
        {
            transform.position += new Vector3(0.0f, 3.0f, 0.0f) * Time.deltaTime;
        }
        if (gameObject.tag == "left")
        {
            transform.position += new Vector3(-3.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
        if (gameObject.tag == "right")
        {
            transform.position += new Vector3(3.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
        if (gameObject.tag == "down")
        {
            transform.position += new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        SoundManager.PlaySound("explosion");
        if (collision.gameObject.tag != "Character")
        {
            if (collision.gameObject.tag == "tree")
            {
                Destroy(collision.gameObject, 0);
            }
            Destroy(gameObject, 0);
        }
    }
}
