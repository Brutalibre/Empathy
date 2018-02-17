using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerHP : MonoBehaviour {

    private Text txt;

    public Image Gauge;

    public PlayerScript Player;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = "HP: " + Mathf.Round(Player.HP);
        Gauge.rectTransform.sizeDelta = new Vector2(Player.HP * 10, Gauge.rectTransform.rect.height);

    }
}
