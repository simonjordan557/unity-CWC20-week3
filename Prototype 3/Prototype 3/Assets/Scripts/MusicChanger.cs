using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour
{
    public AudioSource musicPlayer;
    public PlayerController playerControllerScript;
    

    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        musicPlayer.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isDashing)
        {
            musicPlayer.pitch = 1.4f;
        }

        else
        {
            musicPlayer.pitch = 1.0f;
        }
        
    }
}
