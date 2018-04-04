using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    public TextAsset TextFile;
    public Canvas Overlay;
    public Text TextObject;

    private bool isTalking = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckTalk()
    {
        if (!Talking())
        {
            StartTalk();
        }
        else
        {
            StopTalk();
        }
    }

    public void StartTalk()
    {
        Overlay.gameObject.SetActive(true);
        TextObject.text = TextFile.text;
        isTalking = true;
    }

    public void StopTalk()
    {
        if (Talking())
        {
            Overlay.gameObject.SetActive(false);
            TextObject.text = "";
            isTalking = false;
        }
    }

    public bool Talking()
    {
        return isTalking;
    }
}
