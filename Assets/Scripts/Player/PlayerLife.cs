using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject brokenParts;
    public bool isDead = false;

    private void Update()
    {
        if (isDead)
        {
            DeathMotion();
        }
    }

    private void DeathMotion()
    {
        SoundManager.instance.PlaySound("Broken", brokenParts);
        brokenParts.transform.SetParent(null);
        gameObject.SetActive(false);

        for (int i = 0; i < brokenParts.transform.childCount; i++)
        {
            GameObject part = brokenParts.transform.GetChild(i).gameObject;
            part.SetActive(true);
            part.GetComponent<Rigidbody>().AddExplosionForce(5f, brokenParts.transform.position, 1f, 0f, ForceMode.Impulse);
        }

        Invoke(nameof(ReloadScene), 1f);
    }

    private void ReloadScene()
    {
        LoadManager.instance.LoadScene("Tutorial");
    }
}
