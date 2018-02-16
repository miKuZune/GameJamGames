using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

    public RawImage Eimg;
    public Text height;

    private void Start()
    {
        HideEButton();
    }

    public void UpdateHeight(float newH)
    {
        height.text = newH + "";
    }

    public void ShowEButton()
    {
        Eimg.enabled = true;
    }

    public void HideEButton()
    {
        Eimg.enabled = false;
    }
}
