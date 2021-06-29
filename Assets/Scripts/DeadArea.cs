using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArea : MonoBehaviour
{
    public List<GameObject> nearLogs = new List<GameObject>();
    private bool isDestroyed = false;

    private void Update()
    {
        if (!isDestroyed)
        {
            CheckIsUsed();
        }
    }

    private void CheckIsUsed()
    {
        for (int i = 0; i < nearLogs.Count; i++)
        {
            if (nearLogs[i].GetComponent<Log>().isUsed)
            {
                DisableSelf();
            }
        }
    }

    private void DisableSelf()
    {
        isDestroyed = true;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerLife>().isDead = true;
        }
    }
}
