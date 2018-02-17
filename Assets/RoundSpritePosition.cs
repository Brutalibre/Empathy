using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSpritePosition : MonoBehaviour {

    public int PPU = 16;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        Transform parentTransform = GetComponentInParent<Transform>();
        Vector3 pos = transform.position;

        pos.x = (Mathf.Round(parentTransform.position.x * PPU) / PPU) - parentTransform.position.x;
        pos.y = (Mathf.Round(parentTransform.position.y * PPU) / PPU) - parentTransform.position.y;

        transform.position = pos;
    }
}
