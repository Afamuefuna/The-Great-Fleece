﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyesGuard : MonoBehaviour
{
    public GameObject gameOverCutscene;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            gameOverCutscene.SetActive(true);
        }
    }
}
