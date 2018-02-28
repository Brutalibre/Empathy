using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Circle : MonoBehaviour {

    public TalkableScript TalkableScript;
    public UnityEvent SteppingIn;
    public UnityEvent CursorIn;
    public UnityEvent SteppingOut;
    public UnityEvent CursorOut;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            SteppingIn.Invoke();

        else if (other.tag == "Cursor")
            CursorIn.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            SteppingOut.Invoke();

        else if (other.tag == "Cursor")
            CursorOut.Invoke();
    }
}
