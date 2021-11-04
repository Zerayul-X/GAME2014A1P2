using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class BossController : MonoBehaviour
{
    public int health = 10000;
    public TMP_Text HealthText;
    public PlayerController player;

    public GameObject BossRevenge;
    // Update is called once per frame
    void Update()
    {
        HealthText.text = "Boss Health: " + health;
        if (health <= 0)
        {
            Destroy(gameObject, 0);

            SceneManager.LoadScene("VictoryScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "up" || collision.gameObject.tag == "down" || collision.gameObject.tag == "left" || collision.gameObject.tag == "right")
        {
            health -= player.Damage;
            if (collision.gameObject.tag == "up")
            {
                SoundManager.PlaySound("fire");
                FireBack(0);
            }
            if (collision.gameObject.tag == "down")
            {
                SoundManager.PlaySound("fire");
                FireBack(1);
            }
            if (collision.gameObject.tag == "left")
            {
                SoundManager.PlaySound("fire");
                FireBack(2);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            if (collision.gameObject.tag == "right")
            {
                SoundManager.PlaySound("fire");
                FireBack(3);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    private void FireBack(int direction)
    {
        GameObject fire = null;
        fire = Instantiate(BossRevenge);
        switch (direction)
        {
            case 0:
                fire.tag = "d";
                break;
            case 1:
                fire.tag = "u";
                break;
            case 2:
                fire.tag = "r";
                break;
            case 3:
                fire.tag = "l";
                break;
            default:
                break;
        }
        MakeFire(fire);
    }

    private GameObject MakeFire(GameObject fire)
    {
        //rotate and position
        if (fire.tag == "u")
        {
            fire.transform.Rotate(Vector3.forward * 180);
            fire.transform.position = transform.position + new Vector3(0.0f, 2.00f, 0.0f);
        }
        if (fire.tag == "l")
        {
            fire.transform.Rotate(Vector3.forward * 270);
            fire.transform.position = transform.position + new Vector3(-2.00f, 0.0f, 0.0f);
        }
        if (fire.tag == "r")
        {
            fire.transform.Rotate(Vector3.forward * 90);
            fire.transform.position = transform.position + new Vector3(2.00f, 0.0f, 0.0f);
        }
        if (fire.tag == "d")
        {
            fire.transform.position = transform.position + new Vector3(0.0f, -2.00f, 0.0f);
        }
        return fire;
    }
}
