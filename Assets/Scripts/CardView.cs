using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _frontImage;
    [SerializeField] private Image _backImage;

    public Action clickAction { private get; set; }

    public void SetCardSprite(Sprite frontSprite, Sprite backSprite)
    {
        _frontImage.sprite = frontSprite;
        _backImage.sprite = backSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickAction?.Invoke();
    }

    public void ChangeSideCard(bool isfront)
    {
        _frontImage.gameObject.SetActive(isfront);
        _backImage.gameObject.SetActive(!isfront);
    }
}
