using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScreen : MonoBehaviour {

    public Image blackScreen;
    public Color fadeToColor;

    public float fadeTimeMultiplier;

    void Start()
    {
        fadeToColor = Color.clear;
    }

    void FadeToBlack()
    {
        if(blackScreen.color.a > 0.05f)
            blackScreen.color = Color.Lerp(blackScreen.color, fadeToColor, Time.deltaTime * fadeTimeMultiplier);
    }

    void Update()
    {
        FadeToBlack();
    }
}
