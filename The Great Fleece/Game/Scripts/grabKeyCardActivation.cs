using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabKeyCardActivation : MonoBehaviour
{
    public GameObject sleepingGuardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            sleepingGuardCutscene.SetActive(true);
            gameManager.Instance.HasCard = true;
        }
    }
}
