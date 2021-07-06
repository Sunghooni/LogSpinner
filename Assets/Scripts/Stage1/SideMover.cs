using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMover : Log
{
    private Animator anim;

    private void Awake()
    {
        anim = gameObject.transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isUsed)
        {
            anim.enabled = false;
        }
    }
}
