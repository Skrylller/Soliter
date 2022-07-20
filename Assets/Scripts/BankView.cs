using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankView : MonoBehaviour
{
    [SerializeField] private CardView _cardViewPrefab;
    private List<CardView> _bankCardViews = new List<CardView>();

    private const float _cardIndent = -0.3f;

    public CardView NewCard(CardModel cardModel, CardsData cardsData)
    {
        CardView newCard;

        newCard = FindFreeCardView();

        if (newCard != null)
        {
            newCard.gameObject.SetActive(true);
        }
        else
        {
            newCard = Instantiate(_cardViewPrefab, transform);
            _bankCardViews.Add(newCard);
        }

        newCard.SetCardSprite(cardsData.CardSprite(cardModel.suit, cardModel.cardValue), cardsData.backSprite);

        SetBankPosition();

        return newCard;
    }

    public void Clear()
    {
        foreach (CardView card in _bankCardViews)
        {
            card.gameObject.SetActive(false);
        }
    }

    private CardView FindFreeCardView()
    {
        foreach (CardView card in _bankCardViews)
        {
            if (card.gameObject.activeSelf == false)
                return card;
        }

        return null;
    }

    private void SetBankPosition()
    {
        for (int i = _bankCardViews.Count - 1, counter = 0; i >= 0; i--)
        {
            if (_bankCardViews[i].gameObject.activeSelf)
            {
                _bankCardViews[i].transform.position = new Vector2(transform.position.x + _cardIndent * counter, _bankCardViews[i].transform.position.y);
                counter++;
            }
        }
    }
}
