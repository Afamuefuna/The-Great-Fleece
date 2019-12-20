using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityCamera : MonoBehaviour
{
    public GameObject gameOverCutscene;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            MeshRenderer renderer = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, .1f, .1f, .3f);
            renderer.material.SetColor("_TintColor", color);
            anim.enabled = false;
            StartCoroutine(AlertRoutine());
            
        }
    }

    IEnumerator AlertRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverCutscene.SetActive(true);
    }
}
