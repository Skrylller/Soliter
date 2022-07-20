using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankModel
{
    private Stack<CardController> _bankCardsControllers = new Stack<CardController>();

    public CardController PopCard()
    {
        return _bankCardsControllers.Pop();
    }

    public void PushCard(CardController cardController)
    {
        _bankCardsControllers.Push(cardController);
    }
}
