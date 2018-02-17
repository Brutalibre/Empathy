using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealableScript : TalkableScript {

    // 1 Pain = 1 Player HP
    [Header("Healing")]
    public float BasePain = 5.0f;
    public float CurrentPain;
    public float HealSpeed = 1.0f;

    [Header("Health display")]
    public Canvas PainBar;
    public Image CurrentPainGauge;
    public Image PainGaugeBG;

    [Header("After healing")]
    public Color HealedColor = new Color(1, 0.929f, 0.0f);
    private bool isHealed = false;
    private RPGTalk rpgTalk;
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

        // Get RPGTalk instance and text file
        rpgTalk = GetComponent<RPGTalk>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        if (isColliding && CurrentPain > 0)
        {
            DisplayPain();

            if (Input.GetButton("Fire2"))
            {
                MakeLink();
                CurrentPain -= Time.deltaTime * HealSpeed;
                Player.HP -= Time.deltaTime * HealSpeed;

                if (CurrentPain <= 0)
                {
                    CurrentPain = 0;
                    NowHealed();
                }
            }
        }
        else
        {
            lineRenderer.enabled = false;
            PainBar.enabled = false;
        }
    }

    private void MakeLink()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, originPoint.position);
        lineRenderer.SetPosition(1, PlayerCenter.position);
    }

    private void DisplayPain()
    {
        PainBar.enabled = true;
        CurrentPainGauge.rectTransform.sizeDelta = new Vector2(CurrentPain * 10, CurrentPainGauge.rectTransform.rect.height);
    }

    // Call once when the Healable has been totally healed. Triggers text change and color change.
    private void NowHealed()
    {
        HighlightColor = HealedColor;
        rend.color = HighlightColor;

        rpgTalk.txtToParse = NewText;
    }
}
