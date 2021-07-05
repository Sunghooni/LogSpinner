using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public PlayerMove playerMove;
    public GameObject pausePanel;
    public GameObject selections;

    public void PauseButtonOnclicked()
    {
        if (!selections.activeSelf)
        {
            Time.timeScale = 0f;
            selections.SetActive(true);
            playerMove.isInputable = false;
        }
    }

    public void ExitButtonOnclicked()
    {
        Time.timeScale = 1f;
        FinishManager.instance.LoadScene("Tutorial");
    }

    public void BackButtonOnclicked()
    {
        Time.timeScale = 1f;
        selections.SetActive(false);
        playerMove.isInputable = true;
    }
}
