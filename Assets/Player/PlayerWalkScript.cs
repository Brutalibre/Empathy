using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkScript : MonoBehaviour {

    Rigidbody2D rb;
    public float speed = 4.0f;

    public Animator anim;
    private PlaySoundRandom soundScript;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        soundScript = GetComponent<PlaySoundRandom>();
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));

        if (h != 0 || v != 0)
        {
            rb.velocity = (Vector3.right * Input.GetAxis("Horizontal") * speed) + (Vector3.up * Input.GetAxis("Vertical") * speed);
            soundScript.PlaySound();
        }
        else
        {
            rb.velocity = new Vector3 (0, 0, 0);
        }
	}
}
