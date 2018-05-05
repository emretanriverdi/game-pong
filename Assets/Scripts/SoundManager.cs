using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static SoundManager instance;
    private AudioSource source;

    public AudioClip win;
    public AudioClip lose;
    public AudioClip wallBloop;
    public AudioClip goalBloop;
    public AudioClip hitPaddle;


    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = this;
        } else if (instance != this)
            Destroy(gameObject);

        source = GetComponent<AudioSource>();
	}
	
	public void Play(AudioClip clip) {
        source.PlayOneShot(clip);
    }
}
