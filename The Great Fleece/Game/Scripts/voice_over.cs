using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voice_over : MonoBehaviour
{
    public AudioClip clipToPlay;
    Collider col;


    private void Start()
    {
         col = this.gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.Instance.givenInstruction = true;
            
            
            AudioManager.Instance.PlayVoiceOver(clipToPlay);
            col.isTrigger = false;
            
            
        }
       
    }

    
}
