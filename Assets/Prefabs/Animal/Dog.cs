using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour {


    public Animator DogAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAnimationToMad()
    {
        DogAnimator.SetBool("Close_Circle", true);
    }

    public void ChangeAnimationToIdle()
    {
        DogAnimator.SetBool("Close_Circle", false);
    }
}
