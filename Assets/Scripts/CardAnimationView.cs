using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class CardAnimationView : CardView
{
    [SerializeField] private float _animationDuration = 0.5f;

    public void MoveTarget(Vector2 startPosition, Vector2 target, Action completeAction)
    {
        transform.position = startPosition;

        var animation = DOTween.Sequence();
        animation.Append(transform.DOMove(target, _animationDuration));
        animation.OnComplete(OnComplete);

        void OnComplete()
        {
            completeAction?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
