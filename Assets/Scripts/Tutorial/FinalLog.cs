using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLog : MonoBehaviour
{
    public PlayerMove playerMove;

    private Log log;
    private bool finishing = false;

    private void Awake()
    {
        log = GetComponent<Log>();
    }

    private void Update()
    {
        if (IsFinished() && !finishing)
        {
            Invoke(nameof(LoadStageScene), 1f);

            finishing = true;
            playerMove.isInputable = false;
        }
    }

    private bool IsFinished()
    {
        if (log.isUsed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void LoadStageScene()
    {
        LoadManager.instance.LoadScene("Tutorial");
    }
}
