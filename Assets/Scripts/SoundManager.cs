using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip moveL, moveR, explosion, fire, item;
    static AudioSource audioSource;

    private void Start()
    {
        moveL = Resources.Load<AudioClip> ("Walk_L");
        moveR = Resources.Load<AudioClip>("Walk_R");
        explosion = Resources.Load<AudioClip>("Explosion");
        fire = Resources.Load<AudioClip>("fireball");
        item = Resources.Load<AudioClip>("ItemCollected");

        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "moveL":
                audioSource.PlayOneShot(moveL);
                break;
            case "moveR":
                audioSource.PlayOneShot(moveR);
                break;
            case "explosion":
                audioSource.PlayOneShot(explosion);
                break;
            case "fire":
                audioSource.PlayOneShot(fire);
                break;
            case "item":
                audioSource.PlayOneShot(item);
                break;
            default:
                break;
        }
    }
}
