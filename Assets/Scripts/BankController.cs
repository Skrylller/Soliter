using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankController
{
    private ICardFieldController _cardFieldController;
    private CardsData _cardsData;

    private BankView _bankView;
    private Stack<CardController> _bankCardControllers = new Stack<CardController>();

    public BankController(ICardFieldController cardFieldController, BankView bankView, CardsData cardsData)
    {
        _cardFieldController = cardFieldController;
        _cardsData = cardsData;
        _bankView = bankView;
        _bankCardControllers.Clear();
    }

    public void PushCard(CardModel cardModel)
    {
        CardController cardController = new CardController();
        cardController.SetCardController(_cardsData, cardModel, _bankView.NewCard(cardModel, _cardsData), ClickCardInBank);
        _bankCardControllers.Push(cardController);
    }

    public void Clear()
    {
        _bankView.Clear();
        _bankCardControllers.Clear();
    }

    public void ClickCardInBank()
    {
        if (_bankCardControllers.Count == 0)
            return;

        _bankCardControllers.Peek().view.gameObject.SetActive(false);
        _cardFieldController.SetUpperCard(_bankCardControllers.Pop());
    }
}
