using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gameManager : MonoBehaviour
{
    private static gameManager _instance;

    public bool givenInstruction { get; set; }

    public static gameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("instance is null");
            }
            return _instance;
        }
    }

    public bool HasCard { get; set; }
    public PlayableDirector introCutscene;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            introCutscene.time = 64.0f;
          
        }
        if(introCutscene.time == 64.0f)
        {
            //AudioManager.Instance.PlayMusic();
        }
    }
}
