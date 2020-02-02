using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenMan : MonoBehaviour
{
    public UnityEngine.UI.Image WinScreen;
    public UnityEngine.UI.Image LoseScreen;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hide()
    {
        if (LoseScreen != null)
        {
            LoseScreen.enabled = false;
        }
        if (WinScreen != null)
        {
            WinScreen.enabled = false;
        }
    }

    public void ShowWinScreen()
    {
        if (LoseScreen != null)
        {
            LoseScreen.enabled = false;
        }
        if (WinScreen != null)
        {
            WinScreen.enabled = true;
        }
    }

    public void ShowLoseScreen()
    {
        if (LoseScreen != null)
        {
            LoseScreen.enabled = true;
        }
        if (WinScreen != null)
        {
            WinScreen.enabled = false;
        }
    }
}
