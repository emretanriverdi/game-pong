using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {

    public Ball ball;

    public float speed = 30.0f;

    private Rigidbody2D rb;

    public float lerp = 2.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 dir = new Vector2();

        if (ball.transform.position.y > gameObject.transform.position.y)
            dir = new Vector2(0.0f, 1.0f).normalized;
        else if (ball.transform.position.y < gameObject.transform.position.y)
            dir = new Vector2(0.0f, -1.0f).normalized;
        else
            dir = new Vector2(0.0f, 0.0f).normalized;

        rb.velocity = Vector2.Lerp(rb.velocity, dir * speed, lerp * Time.deltaTime);
    }
}
