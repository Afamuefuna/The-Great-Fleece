using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winStateActivation : MonoBehaviour
{
    public GameObject winCutScene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(gameManager.Instance.HasCard == true)
            {
                winCutScene.SetActive(true);
            }
            else
            {
                Debug.Log("you need the keycard");
            }
        }
    }
}
