using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] float randomFactor = 0.2f;

    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    bool hasStarted = false;

    //State
    Vector2 paddleToBallVector;

    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LookBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    public void LaunchOnMouseClick()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
            //GetComponent<AudioSource>().Play();
        }
    }

    private void LookBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor),Random.Range(0f,randomFactor));
        if (hasStarted)
        {
            AudioClip clip = audioClips[Random.Range(0, audioClips.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }
    }
}
