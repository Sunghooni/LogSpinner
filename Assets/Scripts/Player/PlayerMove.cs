using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMove : MonoBehaviour
{
    [HideInInspector] public GameObject holdingLog;
    [HideInInspector] public bool isholding;
    [HideInInspector] public bool isInputable;

    private GameObject spinner;
    private Vector3 rotateAxis;

    private float moveSpeed = 10f;
    private const float maxMoveSpeed = 15f;
    private const float minMoveSpeed = 5f;

    private void Update()
    {
        InputManage();
        SpeedManage();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (isholding)
        {
            RotateAroundLog();
        }
        else
        {
            MoveForward();
        }
    }

    private void InputManage()
    {
        if (!isInputable || !isholding) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isholding = false;
            transform.SetParent(null);
            SoundManager.instance.PlaySound("Throw", gameObject);
        }
        else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                isholding = false;
                transform.SetParent(null);
                SoundManager.instance.PlaySound("Throw", gameObject);
            }
        }
    }

    private void MoveForward()
    {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
    }

    private void RotateAroundLog()
    {
        float logRadius = holdingLog.transform.localScale.x;

        spinner.transform.Rotate(rotateAxis * moveSpeed / logRadius);
    }

    private void SpeedManage()
    {
        float speedChangeValue = isholding ? Time.deltaTime * 1.5f : Time.deltaTime * -2f;

        moveSpeed = Mathf.Clamp(moveSpeed + speedChangeValue, minMoveSpeed, maxMoveSpeed);
    }

    private void ChangeMoveDir()
    {
        float rotY = transform.eulerAngles.y;

        transform.LookAt(holdingLog.transform);

        int rotateDir = Mathf.DeltaAngle(rotY, transform.eulerAngles.y) > 0 ? 1 : -1;

        transform.eulerAngles += transform.up * -90 * rotateDir;
        rotateAxis = holdingLog.transform.up * rotateDir;
    }

    private void CatchLog(GameObject log)
    {
        SoundManager.instance.PlaySound("Catch", gameObject);
        log.transform.GetComponent<Log>().isUsed = true;
        holdingLog = log;
        isholding = true;

        spinner = holdingLog.transform.Find("Spinner").gameObject;
        transform.SetParent(spinner.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Log") && !isholding)
        {
            CatchLog(collision.gameObject);
            ChangeMoveDir();
        }
    }
}
