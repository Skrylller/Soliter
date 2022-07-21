using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

/// <summary>
/// Управляет визуалом карты. Отслеживает нажатие на карту.
/// </summary>
public class CardView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _frontImage;
    [SerializeField] private Image _backImage;

    [SerializeField] protected float _animationDuration = 0.5f;

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

    public void ChangeSideCard(bool isfront, bool playAnimation)
    {
        if (playAnimation)
        {
            var animation = DOTween.Sequence();
            _frontImage.gameObject.SetActive(!isfront);
            _backImage.gameObject.SetActive(isfront);
            animation.Append(transform.DORotate(new Vector3(0, 90, 0), _animationDuration / 2));
            animation.OnComplete(CompleteAnimation);
        }
        else
        {
            SetSide();
        }

        void CompleteAnimation()
        {
            transform.DORotate(new Vector3(0, 0, 0), _animationDuration / 2);
            SetSide();
        }

        void SetSide()
        {
            _frontImage.gameObject.SetActive(isfront);
            _backImage.gameObject.SetActive(!isfront);
        }
    }
}
