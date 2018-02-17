using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealableScript : InteractableScript {

    public int HP;

    public Transform originPoint;
    public Transform PlayerCenter;

    public LineRenderer lineRenderer;

    public void Reset()
    {
        HighlightColor = new Color(0.0f, 0.792f, 1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isColliding && Input.GetButton("Fire2"))
        {
            MakeLink();
        }
        else
        {
            lineRenderer.enabled = false;

        }
    }

    private void MakeLink()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, originPoint.position);
        lineRenderer.SetPosition(1, PlayerCenter.position);
    }
}
