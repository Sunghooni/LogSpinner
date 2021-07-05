using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    public GameObject blackPanel;
    public GameObject inGameUI;

    private string targetScene;
    private bool isBlackOuted = false;

    private void Awake()
    {
        instance = GetComponent<LoadManager>();
    }

    private void Start()
    {
        StartCoroutine(WhiteOut());
    }

    private void Update()
    {
        if (isBlackOuted)
        {
            SceneManager.LoadScene(targetScene);
        }
    }

    public void LoadScene(string sceneName)
    {
        targetScene = sceneName;
        StartCoroutine(BlackOut());
    }

    private IEnumerator BlackOut()
    {
        float speed = 2f, delay = 0.25f;
        Image image = blackPanel.GetComponent<Image>();
        image.color = image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

        inGameUI.SetActive(false);

        while (image.color.a < 1)
        {
            float alpha = Mathf.Clamp(image.color.a + Time.deltaTime * speed, 0, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            yield return null;
        }

        yield return new WaitForSeconds(delay);
        isBlackOuted = true;
    }

    private IEnumerator WhiteOut()
    {
        float speed = 2f;
        Image image = blackPanel.GetComponent<Image>();
        image.color = image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);

        while (image.color.a > 0)
        {
            float alpha = Mathf.Clamp(image.color.a - Time.deltaTime * speed, 0, 1);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);

            yield return null;
        }

        inGameUI.SetActive(true);
    }
}
