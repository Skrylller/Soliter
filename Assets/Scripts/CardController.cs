using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class CardController
{
    [SerializeField] private CardView _view;
    public CardView view { get { return _view; } }
    public CardModel model { get; private set; }

    public void SetCardController(CardsData cardsData, CardModel model, CardView view, Action clickAction)
    {
        this.model = model;
        _view = view;

        if(clickAction != null)
            _view.clickAction = clickAction;

        _view.SetCardSprite(cardsData.CardSprite(model.suit, model.cardValue), cardsData.backSprite);
    }

    public void SetCardController(CardsData cardsData, CardModel model)
    {
        SetCardController(cardsData, model, _view, null);
    }

    public void SetModel(CardModel model)
    {
        this.model = model;
    }
}
