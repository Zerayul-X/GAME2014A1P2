using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerController : MonoBehaviour
{
    public GameObject FireBall;
    public TMP_Text DBtext;

    public int Damage = 1;
    private bool fireEnable = true;
    int counter = 0;
    int DBcounter = 0;

    private Vector3 SizeUp = new Vector3(0.01f, 0.01f, 0.0f);


    // Update is called once per frame
    void Update()
    {
        DBtext.text = "DragonBall: " + DBcounter;
        if (!fireEnable)
        {
            counter++;
            if (counter == 200)
            {
                counter = 0;
                fireEnable = true;
            }
        }
    }

    public void moveUp()
    {
        SoundManager.PlaySound("moveL");
        transform.position += new Vector3(0.0f, 0.5f, 0.0f);
    }
    public void moveLeft()
    {
        SoundManager.PlaySound("moveL");
        transform.position += new Vector3(-0.5f, 0.0f, 0.0f);
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    public void moveRight()
    {
        SoundManager.PlaySound("moveR");
        transform.position += new Vector3(0.5f, 0.0f, 0.0f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public void moveDown()
    {
        SoundManager.PlaySound("moveR");
        transform.position += new Vector3(0.0f, -0.5f, 0.0f);
    }
    public void fireUp()
    {
        if (fireEnable)
        {
            SoundManager.PlaySound("fire");
            GameObject fire = null;
            fire = Instantiate(FireBall);
            fire.tag = "up";

            fireEnable = false;
            fire = MakeFireBall(fire);
            fire = AutoSize(fire);
        }
    }
    public void fireLeft()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
        if (fireEnable)
        {
            SoundManager.PlaySound("fire");
            GameObject fire = null;
            fire = Instantiate(FireBall);

            fire.tag = "left";

            fireEnable = false;
            fire = MakeFireBall(fire);
            fire = AutoSize(fire);
        }
    }

    public void fireRight()
    {

        transform.localRotation = Quaternion.Euler(0, 0, 0);

        if (fireEnable)
        {
            SoundManager.PlaySound("fire");
            GameObject fire = null;
            fire = Instantiate(FireBall);

            fire.tag = "right";
           
            fireEnable = false;
            fire = MakeFireBall(fire);
            fire = AutoSize(fire);
        }
    }
    public void fireDown()
    {
        
        if (fireEnable)
        {
            SoundManager.PlaySound("fire");
            GameObject fire = null;
            fire = Instantiate(FireBall);

            fire.tag = "down";

            fireEnable = false;
            fire = MakeFireBall(fire);
            fire = AutoSize(fire);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DragonBall")
        {
            SoundManager.PlaySound("item");
            DBcounter++;
            Damage = Damage * 12;
            Destroy(collision.gameObject, 0);
        }
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("DeathScene");
        }
    }

    private GameObject MakeFireBall(GameObject fireball)
    {
        //rotate and position
        if (fireball.tag == "up")
        {
            fireball.transform.Rotate(Vector3.forward * 180);
            fireball.transform.position = transform.position + new Vector3(0.0f, 0.65f, 0.0f);
        }
        if(fireball.tag == "left")
        {
            fireball.transform.Rotate(Vector3.forward * 270);
            fireball.transform.position = transform.position + new Vector3(-0.65f, 0.0f, 0.0f);
        }
        if(fireball.tag == "right")
        {
            fireball.transform.Rotate(Vector3.forward * 90);
            fireball.transform.position = transform.position + new Vector3(0.65f, 0.0f, 0.0f);
        }
        if (fireball.tag == "down")
        {
            fireball.transform.position = transform.position + new Vector3(0.0f, -0.65f, 0.0f);
        }
        return fireball;
    }
    private GameObject AutoSize(GameObject fireball)
    {
        switch (DBcounter)
        {
            case 1:
                fireball.transform.localScale += SizeUp;
                break;

            case 2:
                fireball.transform.localScale += 2 * SizeUp;
                break;

            case 3:
                fireball.transform.localScale += 3 * SizeUp;
                break;

            default:
                break;
        }
        return fireball;
    }

}