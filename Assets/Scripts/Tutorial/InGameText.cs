using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameText : MonoBehaviour
{
    public Transform targetObject;
    public bool isShowed = false;
    public bool isDisappeared = false;

    public float term = 0;
    private float timer = 0f;

    private TextMeshPro tmp;
    private Transform player;
    private Vector3 playerStartPos;

    private const float disappearSpeed = 0.75f;
    private const float fixedStartPosZ = 1.75f;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerStartPos = player.transform.position;
    }

    private void Start()
    {
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 0);
    }

    private void FixedUpdate()
    {
        if (!isShowed && CheckPlayerIsOnStartPos())
        {
            ShowTextByDistance();
        }
        else if (isShowed && IsTermDelayed())
        {
            DisappearText();
        }
    }

    private bool CheckPlayerIsOnStartPos()
    {
        if (targetObject == player) return true;

        if (targetObject.position.z + fixedStartPosZ <= player.transform.position.z)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ShowTextByDistance()
    {
        Vector3 startPos = targetObject == player ? playerStartPos : targetObject.position + targetObject.transform.forward * fixedStartPosZ;
        float totalDistance = Vector3.Distance(startPos, transform.position);
        float pastDistance = Vector3.Distance(startPos, player.transform.position);
        
        float progress = 255 * pastDistance / totalDistance;

        if (!isShowed && pastDistance > totalDistance)
        {
            isShowed = true;
        }

        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, progress/255f);
    }

    private bool IsTermDelayed()
    {
        timer += Time.deltaTime;

        if (timer >= term)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void DisappearText()
    {
        if (!isShowed || isDisappeared) return;

        float alphaValue = Mathf.Clamp(tmp.color.a - Time.deltaTime * disappearSpeed, 0, 1);

        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, alphaValue);

        if (alphaValue == 0)
        {
            isDisappeared = true;
        }
    }
}
