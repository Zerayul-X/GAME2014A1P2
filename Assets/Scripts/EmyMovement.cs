using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyMovement : MonoBehaviour
{
    int direction = 1;
    // Update is called once per frame
    void Update()
    {
        if(direction > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        transform.position += new Vector3(direction * 0.5f, 0.0f, 0.0f) * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = -direction;
    }
}