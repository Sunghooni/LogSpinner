using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
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
        gameObject.SetActive(false);
    }
}
