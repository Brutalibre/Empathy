using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour {

    private SpriteRenderer rend;
    private Color baseCol;
    public Color HighlightColor = new Color(1, 0.929f, 0.0f);
   
	// Use this for initialization
	void Start () {
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
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cursor")
        {
            rend.color = baseCol;
        }
    }
}
