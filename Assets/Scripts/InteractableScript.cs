using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableScript : TalkableScript {

    public UnityEvent CallbackFunction;

	// Update is called once per frame
	void Update () {
		if (isColliding && Input.GetButtonDown("Fire1"))
        {
            CallbackFunction.Invoke();
        }
	}
}
