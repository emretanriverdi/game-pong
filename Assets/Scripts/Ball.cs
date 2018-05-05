using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

    public float speed = 35.0f;
    private Rigidbody2D rb;
    public Text scoreLeft;
    public Text scoreRight;
    public GameObject paddleRight;
    public GameObject paddleLeft;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.collider.name.Contains("paddle")) {
            HandlePaddleHit(collision);
            SoundManager.instance.Play(SoundManager.instance.hitPaddle);
        }

        if (collision.collider.name.Equals("wall_left")) {
            IncreaseScore(scoreRight);
            ResetPosition(paddleRight);
            SoundManager.instance.Play(SoundManager.instance.goalBloop);

        } else if (collision.collider.name.Equals("wall_right")) {
            IncreaseScore(scoreLeft);
            ResetPosition(paddleLeft);
            SoundManager.instance.Play(SoundManager.instance.goalBloop);
        }

        if (collision.collider.name.Equals("wall_top") || collision.collider.name.Equals("wall_bottom")) {
            SoundManager.instance.Play(SoundManager.instance.wallBloop);
        }
    }
    private void ResetPosition(GameObject paddle) {
        gameObject.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        Thread.Sleep(50);
        rb.velocity = (paddle.transform.position - gameObject.transform.position * speed);
    }

    private void IncreaseScore(Text text) {
        text.text = (int.Parse(text.text) + 1).ToString();
    }

    private void HandlePaddleHit(Collision2D collision) {
        Vector2 direction = new Vector2();

        float y = GetPaddleHitPosition(gameObject.transform.position, collision.collider.transform.position, collision.collider.bounds.size.y);

        if (collision.collider.name.Contains("left"))
            direction = new Vector2(1.0f, y).normalized;
        else if (collision.collider.name.Contains("right"))
            direction = new Vector2(-1.0f, y).normalized;

        rb.velocity = direction * speed;
    }

    private float GetPaddleHitPosition(Vector3 ballPosition, Vector3 paddlePosition, float y) {
        return (ballPosition.y - paddlePosition.y) / y;
    }


    public Boolean isEnded() {
        if (int.Parse(scoreLeft.text) == 10 || int.Parse(scoreRight.text) == 10)
            return true;
        return false;
    }
}
