using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float speed = 30.0f;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = new Vector2(0.0f, 0.0f);
        if (Input.GetAxis("Vertical") != 0)
            rb.velocity = new Vector2(0.0f, Input.GetAxis("Vertical") * speed);
	}
}
