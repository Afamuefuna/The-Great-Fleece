using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLookAt : MonoBehaviour
{
    public GameObject player;

    public Transform startCamera;

    // Update is called once per frame

    private void Start()
    {
        transform.position = startCamera.position;
        transform.rotation = startCamera.rotation;
    }
    void Update()
    {
        transform.LookAt(player.transform);
    }
}
