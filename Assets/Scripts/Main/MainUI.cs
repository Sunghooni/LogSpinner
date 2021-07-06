using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    private bool isChanging = false;

    public void StageButtonOnclicked()
    {
        if (!isChanging)
        {
            SoundManager.instance.PlaySound("Button", Camera.main.gameObject);
            LoadManager.instance.LoadScene("Stage");
            isChanging = true;
        }
    }

    public void OptionButtonOnclicked()
    {
        return;

        if (!isChanging)
        {
            SoundManager.instance.PlaySound("Button", Camera.main.gameObject);
            LoadManager.instance.LoadScene("Option");
            isChanging = true;
        }
    }

    public void ExitButtonOnclicked()
    {
        if (!isChanging)
        {
            Application.Quit();
            isChanging = true;
        }
    }
}
