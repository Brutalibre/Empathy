using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSprite : MonoBehaviour {

    public Sprite NewSprite;
    private Sprite OldSprite;
    private bool state = false;

	// Use this for initialization
	void Start () {
        OldSprite = GetComponent<SpriteRenderer>().sprite;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SwitchSprites()
    {
        state = !state;
        GetComponent<SpriteRenderer>().sprite = state ? NewSprite : OldSprite;
    }
}
