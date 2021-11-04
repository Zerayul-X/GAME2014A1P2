using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EmyBullet : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "u")
        {
            transform.position += new Vector3(0.0f, 3.0f, 0.0f) * Time.deltaTime;
        }
        if (gameObject.tag == "l")
        {
            transform.position += new Vector3(-3.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
        if (gameObject.tag == "r")
        {
            transform.position += new Vector3(3.0f, 0.0f, 0.0f) * Time.deltaTime;
        }
        if (gameObject.tag == "d")
        {
            transform.position += new Vector3(0.0f, -3.0f, 0.0f) * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        SoundManager.PlaySound("explosion");
        if (collision.gameObject.tag == "tree")
        {
            Destroy(collision.gameObject, 0);
        }
        if (collision.gameObject.tag == "up" || collision.gameObject.tag == "down" || collision.gameObject.tag == "left" || collision.gameObject.tag == "right")
        {
            Destroy(collision.gameObject, 0);
        }
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject, 0);
        }
        if (collision.gameObject.tag == "Mountain")
        {

            Destroy(collision.gameObject, 0);
            Destroy(gameObject, 0);
        }
        if (collision.gameObject.tag == "DragonBall")
        {
            Destroy(gameObject, 0);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(gameObject, 0);
        }
        if (collision.gameObject.tag == "Character")
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
