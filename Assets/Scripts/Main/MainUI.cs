using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public void StageButtonOnclicked()
    {
        LoadManager.instance.LoadScene("Stage");
    }

    public void OptionButtonOnclicked()
    {
        LoadManager.instance.LoadScene("Option");
    }

    public void ExitButtonOnclicked()
    {
        Application.Quit();
    }
}
