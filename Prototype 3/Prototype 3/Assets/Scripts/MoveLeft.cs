using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float slowSpeed = 10;
    private float dashSpeed = 15;
    private float speed;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.gameOver && playerControllerScript.gameCanStart)
        {
            if (playerControllerScript.isDashing)
            {
                speed = dashSpeed;
            }

            else
            {
                speed = slowSpeed;
            }

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
