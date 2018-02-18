using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkScript : MonoBehaviour {

    Rigidbody2D rb;
    public float PPU = 16;
    public float Speed = 4.0f;
    public float Treshold = 0.1f;

    public Animator anim;
    private PlaySoundRandom soundScript;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        soundScript = GetComponent<PlaySoundRandom>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        anim.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxis("Vertical"));

        if (Mathf.Abs(h) > Treshold || Mathf.Abs(v) > Treshold)
        {
            // rb.velocity = (Vector3.right * Input.GetAxis("Horizontal") * speed) + (Vector3.up * Input.GetAxis("Vertical") * speed);
            soundScript.PlaySound();
        }
        /*
        else
        {
            rb.velocity = new Vector3 (0, 0, 0);
        }*/

        Vector3 position = transform.position;

        if (h > Treshold)
        {
            position.x += Speed / PPU;
        }
        else if (h < -Treshold)
        {
            position.x -= Speed / PPU;
        }

        if (v > Treshold)
        {
            position.y += Speed / PPU;
        }
        else if (v < -Treshold)
        {
            position.y -= Speed / PPU;
        }

        transform.position = position;

    }
}
