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
        int cardIndex;

        cardIndex = FindFreeCardView();

        if (cardIndex >= 0)
        {
            _bankCardViews[cardIndex].gameObject.SetActive(true);
        }
        else
        {
            _bankCardViews.Add(Instantiate(_cardViewPrefab, transform));
            cardIndex = _bankCardViews.Count - 1;
        }

        _bankCardViews[cardIndex].SetCardSprite(cardsData.CardSprite(cardModel.suit, cardModel.cardValue), cardsData.backSprite);
        _bankCardViews[cardIndex].ChangeSideCard(false);

        SetBankPosition();

        return _bankCardViews[cardIndex];
    }

    public void Clear()
    {
        foreach (CardView card in _bankCardViews)
        {
            card.gameObject.SetActive(false);
        }
    }

    private int FindFreeCardView()
    {
        for (int i = 0; i < _bankCardViews.Count; i++)
        {
            if (_bankCardViews[i].gameObject.activeSelf == false)
                return i;
        }

        return -1;
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
