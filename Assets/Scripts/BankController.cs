using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankController
{
    private CardsData _cardsData;

    private BankView _bankView;
    private Stack<CardController> _bankCardControllers = new Stack<CardController>();

    public BankController(BankView bankView, CardsData cardsData)
    {
        _cardsData = cardsData;
        _bankView = bankView;
        _bankCardControllers.Clear();
    }

    public CardController PopCard()
    {
        return _bankCardControllers.Pop();
    }

    public void PushCard(CardModel cardModel)
    {
        _bankCardControllers.Push(new CardController(_cardsData, cardModel, _bankView.NewCard(cardModel, _cardsData)));
    }

    public void Clear()
    {
        _bankView.Clear();
        _bankCardControllers.Clear();
    }
}
