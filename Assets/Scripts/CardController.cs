using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController
{
    private CardModel _model;
    private CardView _view;

    private CardView _nextCard;
    private CardView _previousCard;

    public CardController(CardsData cardsData, CardModel model, CardStackController stack, int stackPosition)
    {
        _model = model;
        _view = stack.CardView(stackPosition);

        _nextCard = stack.CardView(stackPosition + 1);
        _previousCard = stack.CardView(stackPosition - 1);

        _view.SetCardSprite(cardsData.CardSprite(_model.suit, _model.cardValue), cardsData.backSprite);
    }
    public CardController(CardsData cardsData, CardModel model, CardView view)
    {
        _model = model;
        _view = view;

        _view.SetCardSprite(cardsData.CardSprite(_model.suit, _model.cardValue), cardsData.backSprite);
    }
}
