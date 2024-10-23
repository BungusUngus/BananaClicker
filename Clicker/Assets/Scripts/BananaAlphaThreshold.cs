using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaAlphaThresh : MonoBehaviour
{
    private Image _BananaImage;

    private void Awake()
    {
        _BananaImage = GetComponent<Image>();
        _BananaImage.alphaHitTestMinimumThreshold = 0.001f;
    }

}
