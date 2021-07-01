using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    private GameObject player;
    private PlayerMove playerMove;
    private Transform target;

    private Vector3 startPos;
    private Transform finalLog;

    private const float heightDist = 20f;
    private const float lerpSpeed = 0.1f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMove>();
        target = player.transform;

        startPos = transform.position;
        finalLog = GameObject.FindGameObjectWithTag("FinalLog").transform;
    }

    private void Update()
    {
        CheckTarget();
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 toPos = target.transform.position + target.transform.up * heightDist;
        toPos.z = Mathf.Clamp(toPos.z, startPos.z, finalLog.transform.position.z);
        toPos.x = transform.position.x;

        transform.position = Vector3.Lerp(transform.position, toPos, lerpSpeed);
    }

    private void CheckTarget()
    {
        if (playerMove.isholding && target != playerMove.holdingLog)
        {
            target = playerMove.holdingLog.transform;
        }
        else if (target != player)
        {
            target = player.transform;
        }
    }
}
