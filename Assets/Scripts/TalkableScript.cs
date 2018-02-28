using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkableScript : MonoBehaviour {

    protected SpriteRenderer rend;
    private Color baseCol;
    public Color HighlightColor = new Color(1, 0.929f, 0.0f);

    protected bool isColliding = false;
    protected bool canCollide = false;
   
	// Use this for initialization
	protected void Start () {
        rend = GetComponent<SpriteRenderer>();
        if (!rend)
            rend = GetComponentInChildren<SpriteRenderer>();

        baseCol = rend.color;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cursor")
        {
            ChangeColor();
            Collide(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Cursor")
        {
            ChangeColor();
            Collide(false);
        }
    }

    public void Collide (bool isCol)
    {
        if (canCollide)
            isColliding = isCol;

        else
            isColliding = false;
    }

    public void ChangeColor()
    {
        if (canCollide)
            rend.color = (rend.color == baseCol) ? HighlightColor : baseCol;

        else
            rend.color = baseCol;
    }

    // These functions are invoked when the player steps in or out an Outer Circle.
    public void CanCollide()
    {
        canCollide = true;
    }

    public void CannotCollide()
    {
        canCollide = false;
    }
}
