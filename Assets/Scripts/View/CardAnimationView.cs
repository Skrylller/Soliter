using UnityEngine;
using System;
using DG.Tweening;

/// <summary>
/// View ����� � ������������ ������ �������� ����������� �� ����� ����� � ������.
/// </summary>
public class CardAnimationView : CardView
{
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
