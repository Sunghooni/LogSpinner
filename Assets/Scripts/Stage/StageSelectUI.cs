using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    public GameObject checker;
    public string stageName;

    public void ButtonOnclick()
    {
        if (checker.activeSelf) return;

        SoundManager.instance.PlaySound("Button", Camera.main.gameObject);
        LoadManager.instance.LoadScene(stageName);
        checker.SetActive(true);
    }
}
