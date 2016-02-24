using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade : MonoBehaviour
{
    public bool onEvent = true;
    public bool endOnEventOnly = false;

    public float fadeTo = 1;
    public float initialWaiting = 2;
    public float transitionTime = 3;

    public float backTo = 0;
    public float fillWaiting = 3;
    public float transitionTimeBack = 3;

    private Text guiTextComponent;
    private bool waited = false;
    private bool finish = false;

    void Start()
    {
        guiTextComponent = GetComponent<UnityEngine.UI.Text>();

        if (!onEvent)
        {
            StartCoroutine(InitialWaiting());
        }
    }

    public void Begin()
    {
        StartCoroutine(InitialWaiting());
    }

    public void End()
    {
        waited = false;
        finish = true;
    }

    void Update()
    {
        if (waited)
        {
            StartCoroutine(FadeTo(fadeTo, transitionTime));
            waited = false;
        }
        if (finish)
        {
            StartCoroutine(FadeTo(backTo, transitionTimeBack));
            finish = false;
            StartCoroutine(Disable(transitionTimeBack));
        }
    }

    IEnumerator Disable(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime * 1.5F);
        enabled = false;
    }

        IEnumerator InitialWaiting()
    {
        yield return new WaitForSeconds(initialWaiting);
        waited = true;
        if (!endOnEventOnly)
        {
            yield return new WaitForSeconds(fillWaiting);
            End();
        }
        StopAllCoroutines();
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = guiTextComponent.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            guiTextComponent.color = newColor;
            yield return null;
        }
    }
}