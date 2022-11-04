using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageLogo : Manager
{
    void Start()
    {
        SetFade("Canvas");
        FadeIn();
        Invoke("DelayFadeOut", 4f);
    }

    void DelayFadeOut()
    {
        FadeOut("Title");
    }

}
