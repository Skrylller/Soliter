using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ��������� view �������� ����. ������� ���� ��������.
/// </summary>
public class CardAnimationsController : MonoBehaviour
{
    [SerializeField] private CardAnimationView _cardAnimationPrefab;

    private List<CardAnimationView> _cardAnimations = new List<CardAnimationView>();

    public void CardAnimation(CardsData cardsData, CardController cardController, Vector2 target, Action completeAction, bool playAnimationChangeSide)
    {
        CardAnimationView cardAnimationView;

        if (FindFreeCardAnimationView())
        {
            cardAnimationView = FindFreeCardAnimationView();
        }
        else
        {
            _cardAnimations.Add(Instantiate(_cardAnimationPrefab, transform));
            cardAnimationView = _cardAnimations[_cardAnimations.Count - 1];
        }

        cardAnimationView.SetCardSprite(cardsData.CardSprite(cardController.model.suit, cardController.model.cardValue), cardsData.backSprite);
        cardAnimationView.gameObject.SetActive(true);
        cardAnimationView.ChangeSideCard(true, playAnimationChangeSide);
        cardAnimationView.MoveTarget(cardController.view.transform.position, target, completeAction);
    }

    private CardAnimationView FindFreeCardAnimationView()
    {
        for (int i = 0; i < _cardAnimations.Count; i++)
        {
            if (_cardAnimations[i].gameObject.activeSelf == false)
                return _cardAnimations[i];
        }

        return null;
    }
}
