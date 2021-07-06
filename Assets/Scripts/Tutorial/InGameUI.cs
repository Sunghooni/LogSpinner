using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject player;
    public GameObject pausePanel;
    public GameObject selections;

    private PlayerMove playerMove;
    private PlayerLife playerLife;

    private void Awake()
    {
        playerMove = player.GetComponent<PlayerMove>();
        playerLife = player.GetComponent<PlayerLife>();
    }

    public void PauseButtonOnclicked()
    {
        if (!selections.activeSelf)
        {
            SoundManager.instance.PlaySound("Button", Camera.main.gameObject);
            Time.timeScale = 0f;
            selections.SetActive(true);
            playerMove.isInputable = false;
        }
    }

    public void ExitButtonOnclicked()
    {
        SoundManager.instance.PlaySound("Button", Camera.main.gameObject);
        BackButtonOnclicked();

        if (!playerLife.isDead)
        {
            LoadManager.instance.LoadScene("Main");
        }
    }

    public void BackButtonOnclicked()
    {
        SoundManager.instance.PlaySound("Button", Camera.main.gameObject);
        Time.timeScale = 1f;
        selections.SetActive(false);
        playerMove.isInputable = true;
    }
}
