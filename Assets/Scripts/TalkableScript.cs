﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkableScript : MonoBehaviour {

    protected SpriteRenderer rend;
    private Color baseCol;
    public Color HighlightColor = new Color(1, 0.929f, 0.0f);

    protected bool isColliding = false;
   
	// Use this for initialization
	protected void Start () {
        rend = GetComponent<SpriteRenderer>();
        baseCol = rend.color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cursor") {
            rend.color = HighlightColor;
            isColliding = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cursor")
        {
            rend.color = baseCol;
            isColliding = false;
        }
    }
}