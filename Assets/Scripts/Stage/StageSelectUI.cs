using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    public string stageName;
    public void ButtonOnclick()
    {
        LoadManager.instance.LoadScene(stageName);
    }
}
