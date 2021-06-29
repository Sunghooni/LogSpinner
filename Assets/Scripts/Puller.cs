using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puller : MonoBehaviour
{
    private Log log;
    private ParticleSystem particle;
    private readonly float lerpSpeed = 0.01f;

    private void Awake()
    {
        log = transform.parent.GetComponent<Log>();
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    { 
        if (log.isUsed)
        {
            SetInvisible();
        }
    }

    private void SetInvisible()
    {
        Color color = particle.startColor;
        particle.startColor = new Color(color.r, color.g, color.b, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !log.isUsed)
        {
            GameObject player = other.gameObject;
            Vector3 gap = transform.position - player.transform.position;
            Quaternion lookRot = Quaternion.LookRotation(gap).normalized;

            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, lookRot, lerpSpeed);
        } 
    }
}
