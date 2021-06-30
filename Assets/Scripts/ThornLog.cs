using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornLog : MonoBehaviour
{
    private readonly float rotSpeed = 10f;

    private void FixedUpdate()
    {
        RotateSelf();
    }

    private void RotateSelf()
    {
        transform.Rotate(transform.forward * rotSpeed, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerLife>().isDead = true;
        }
    }
}
