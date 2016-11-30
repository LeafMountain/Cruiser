using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScreen : MonoBehaviour {

    public Image blackScreen;
    public Text title;
    public Color fadeToColor;
    public Color textColor;

    void FadeToBlack()
    {
        if (blackScreen.color.a < 0.99f)
            blackScreen.color = Color.Lerp(blackScreen.color, fadeToColor, Time.deltaTime);
        else if (blackScreen.color != fadeToColor)
            blackScreen.color = fadeToColor;
    }

    void FadeText()
    {
        if (title.color.a < 0.99f)
            title.color = Color.Lerp(title.color, textColor, Time.deltaTime);
        else if (title.color != textColor)
            title.color = textColor;
    }

    void Update()
    {
        FadeToBlack();
        FadeText();
    }
}
