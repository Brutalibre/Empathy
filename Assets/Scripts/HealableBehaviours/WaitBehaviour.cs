using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitBehaviour : HealableBehaviour {
    public float TimeToWait = 4.0f;
    private float Timer = 0.0f;

    public void StartTimer()
    {
        Timer = 0.0f;
    }

    public new bool CheckCondition ()
    {
        if (Timer >= TimeToWait)
        {
            StartTimer();
            return true;
        }
        else
        {
            Debug.Log(Timer);
            Timer += Time.deltaTime;
            return false;
        }
    }
}
