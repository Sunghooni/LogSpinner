using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLog : MonoBehaviour
{
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
        FinishManager.instance.LoadScene("Tutorial");
    }
}
