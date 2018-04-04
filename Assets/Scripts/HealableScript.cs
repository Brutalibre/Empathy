using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class Step
{
    public float MaximumPercentage;
    public float MinimumPercentage;

    public TextAsset TextDuringThisStep;

    public bool CurrentStep;
    public bool LockedStep;

    public HealableBehaviour ConditionForUnlock;
}


public class HealableScript : TalkableScript {

    // 1 Pain = 1 Player HP
    [Header("Healing")]
    public float BasePain = 5.0f;
    public float CurrentPain;
    public float HealSpeed = 1.0f;

    [Header("Healing steps")]
    public Step[] Steps;
    private int LockedStep = -1;
    private int CurrentStep = -1;

    [Header("Health display")]
    public Canvas PainBar;
    public Image CurrentPainGauge;
    public Image PainGaugeBG;

    [Header("After healing")]
    public Color HealedColor = new Color(1, 0.929f, 0.0f);
    public TextAsset NewText;

    [Header("Line")]
    public Transform originPoint;
    public Transform PlayerCenter;

    public LineRenderer lineRenderer;

    [Header("Player")]
    public PlayerScript Player;

    public void Reset()
    {
        HighlightColor = new Color(0.0f, 0.792f, 1.0f);
    }

    protected new void Start()
    {
        base.Start();
        CurrentPain = BasePain;

        // Set Canvas & Gauges sizes depending on Base Pain.
        PainBar.GetComponent<RectTransform>().sizeDelta = new Vector2(BasePain * 10, PainBar.GetComponent<RectTransform>().rect.height);
        CurrentPainGauge.rectTransform.sizeDelta        = new Vector2(BasePain * 10, CurrentPainGauge.rectTransform.rect.height);
        PainGaugeBG.rectTransform.sizeDelta             = new Vector2(BasePain * 10, PainGaugeBG.rectTransform.rect.height);
    }

    // Update is called once per frame
    void Update()
    {
        float percentPain = CurrentPain / BasePain * 100;
        // From TalkableScript. Checks on Fire1.
        CheckTalk();

        // Not locked
        if (LockedStep == -1)
        {
            // Check which step we are in ; and change text file according to it.
            for (int i = 0; i < Steps.Length; i++)
            {
                // Check for every step that is not current step to change status and file.
                if (!Steps[i].CurrentStep && (percentPain <= Steps[i].MaximumPercentage && percentPain > Steps[i].MinimumPercentage))
                {
                    Steps[i].CurrentStep = true;
                    CurrentStep = i;
                    dialogScript.TextFile = Steps[i].TextDuringThisStep;
                }
            }
        }

        float delta = Time.deltaTime;
        if (isColliding && CurrentPain > 0)
        {
            DisplayPain();

            if (Input.GetButton("Fire2"))
            {
                MakeLink();

                if (LockedStep == -1 || percentPain > Steps[LockedStep].MinimumPercentage)
                {
                    CurrentPain -= Time.deltaTime * HealSpeed;
                    Player.HP -= Time.deltaTime * HealSpeed;
                }
                else if (percentPain <= Steps[LockedStep].MinimumPercentage) {
                    CurrentPain = Steps[LockedStep].MinimumPercentage * BasePain / 100;
                }

                if (CurrentPain <= 0)
                {
                    CurrentPain = 0;
                    NowHealed();
                }
            }

            else
            {
                DestroyLink();
            }
        }
        else
        {
            DestroyLink();
            PainBar.enabled = false;
        }
    }

    private void MakeLink()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, originPoint.position);
        lineRenderer.SetPosition(1, PlayerCenter.position);
    }

    private void DestroyLink()
    {
        lineRenderer.enabled = false;
    }

    private void DisplayPain()
    {
        PainBar.enabled = true;
        CurrentPainGauge.rectTransform.sizeDelta = new Vector2(CurrentPain * 10, CurrentPainGauge.rectTransform.rect.height);
    }

    // Call once when the Healable has been totally healed. Triggers text change and color change.
    private void NowHealed()
    {
        DestroyLink();
        HighlightColor = HealedColor;
        rend.color = HighlightColor;

        dialogScript.TextFile = NewText;
    }

    public void LockStep(int index)
    {
        Steps[index].LockedStep = true;
        LockedStep = index;
        Debug.Log("Locking step #" + index);

        // Every other step is unlocked, except [index].
        for (int i = 0; i < Steps.Length; i++)
        {
            if (i != index && Steps[i].LockedStep)
            {
                Debug.Log("Unlocking step #" + i);
                Steps[i].LockedStep = false;
            }
        }
    }

    public void LockCurrentStep ()
    {
        LockStep(CurrentStep);
    }
}
