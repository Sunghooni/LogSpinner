using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubText : MonoBehaviour
{
    public InGameText preText;
    public float term = 1f;

    private TextMeshPro tmp;
    private const float alphaSpeed = 0.75f;
    private float timer = 0f;
    private bool isShowed = false;
    private bool isDisappeared = false;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();   
    }

    private void Start()
    {
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, 0);
    }

    void Update()
    {
        if (preText.isDisappeared)
        {
            ShowText();
            DisappearText();
        }
    }

    private void ShowText()
    {
        if (isShowed) return;

        float alphaValue = Mathf.Clamp(tmp.color.a + Time.deltaTime * alphaSpeed, 0, 1);

        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, alphaValue);

        if (alphaValue == 1)
        {
            isShowed = true;
        }
    }

    private void DisappearText()
    {
        if (!isShowed || isDisappeared) return;

        if (IsTermDelayed())
        {
            float alphaValue = Mathf.Clamp(tmp.color.a - Time.deltaTime * alphaSpeed, 0, 1);

            tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, alphaValue);

            if (alphaValue == 0)
            {
                isDisappeared = true;
            }
        }
    }

    private bool IsTermDelayed()
    {
        timer += Time.deltaTime;

        if (timer > term)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
