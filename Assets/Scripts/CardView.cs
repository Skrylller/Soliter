using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image _frontImage;
    [SerializeField] private Image _backImage;

    public CardView(Sprite frontSprite, Sprite backSprite)
    {
        _frontImage.sprite = frontSprite;
        _backImage.sprite = backSprite;
    }
}
