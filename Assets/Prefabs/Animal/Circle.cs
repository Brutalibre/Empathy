using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Palier
{
    public float MinimumPercentage;
    public float MaximumPercentage;
}

[System.Serializable]
public class State
{
    public int AnimationValue;
    public Sprite NewSprite;
    protected Sprite OldSprite;
    public AudioClip Sound;
}

[System.Serializable]
public struct StateAndPalier
{
    public State Etat;
    public Palier Palier;
}

public class Circle : MonoBehaviour {

    public HealableScript HealableScript;
    public Dog Character;
    public SpriteRenderer SpriteRend;
    public UnityEvent SteppingIn;
    public UnityEvent CursorIn;
    public UnityEvent SteppingOut;
    public UnityEvent CursorOut;

    public StateAndPalier[] StatesAndPaliers;

    private void Reset()
    {
        StatesAndPaliers = new StateAndPalier[Character.Paliers.Length];
    }

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

    public int CheckPalier()
    {
        float percentPain = HealableScript.CurrentPain / HealableScript.BasePain * 100;

        for (int i = 0; i < StatesAndPaliers.Length; i++)
        {
            // Check which Palier we are in.
            if (percentPain >= StatesAndPaliers[i].Palier.MinimumPercentage && percentPain <= StatesAndPaliers[i].Palier.MaximumPercentage)
            {
                return i;
            }
        }

        return -1;

    }

    public void ChangeStateWithPalier ()
    {
        ChangeState(StatesAndPaliers[CheckPalier()].Etat);
    }

    private void ChangeState(State state)
    {
        Character.GetComponent<AudioSource>().clip = state.Sound;
        Character.GetComponent<AudioSource>().Play();

        Character.Animator.SetInteger(Character.AnimationInt, state.AnimationValue);

        SpriteRend.sprite = state.NewSprite;
    }

    public void CancelAnimationAndSound()
    {
        Character.GetComponent<AudioSource>().Stop();
        Character.Animator.SetInteger(Character.AnimationInt, Character.DefaultAnimationValue);
    }
}
