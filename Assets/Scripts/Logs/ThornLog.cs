using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornLog : MonoBehaviour
{
    private readonly float rotSpeed = 10f;
    private Vector2 fixedRot;

    private void Awake()
    {
        fixedRot = new Vector2(transform.eulerAngles.x, transform.eulerAngles.y);
    }

    private void FixedUpdate()
    {
        RotateSelf();
    }

    private void RotateSelf()
    {
        transform.Rotate(transform.forward * rotSpeed, Space.World);
        transform.eulerAngles = new Vector3(fixedRot.x, fixedRot.y, transform.eulerAngles.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerLife>().isDead = true;
        }
    }
}
