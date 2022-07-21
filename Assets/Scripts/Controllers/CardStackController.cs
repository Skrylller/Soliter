using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Стопка карт нужна для правильной визуализации в инспекторе, для возможности создания поля из игрового редактора.
/// </summary>
[System.Serializable]
public class CardStackController
{
    private ICardFieldController _cardFieldController;

    [SerializeField] private List<CardView> _cardView = new List<CardView>();
    private List<CardController> _cardControllers = new List<CardController>();

    public void Inicialization(ICardFieldController cardFieldController)
    {
        _cardFieldController = cardFieldController;
        _cardControllers.Clear();

        for (int i = 0; i < _cardView.Count; i++)
        {
            _cardControllers.Add(new CardController());
        }
    }
    public int CardsControllerCount()
    {
        return _cardControllers.Count;
    }

    public void Reset()
    {
        for (int i = 0; i < _cardControllers.Count; i++)
        {
            _cardControllers[i] = new CardController();
        }
    }

    public void NewCard(CardsData cardsData, CardModel cardModel)
    {
        int index = NextCardNum();
        _cardControllers[index].SetCardController(cardsData, cardModel, _cardView[index], ClickCardInStack);
        _cardControllers[index].view.gameObject.SetActive(true);
    }

    public bool CheckNextCard()
    {
        foreach (CardController cardController in _cardControllers)
        {
            if (cardController.model == null)
                return true;
        }
        return false;
    }

    public int NextCardNum()
    {
        for (int i = 0; i < _cardControllers.Count; i++)
        {
            if (_cardControllers[i].model == null)
                return i;
        }
        return -1;
    }

    public void ClickCardInStack()
    {
        for (int i = _cardControllers.Count - 1; i >= 0; i--)
        {
            if (_cardControllers[i].view.gameObject.activeSelf)
            {
                _cardFieldController.ClickOnStack(_cardControllers[i], this);
                return;
            }
        }
    }

    public void SetSideCards()
    {
        for (int i = 0; i < _cardControllers.Count; i++)
        {
            _cardControllers[i].view.ChangeSideCard(false, false);
        }

        for (int i = _cardControllers.Count - 1; i >= 0; i--)
        {
            if (_cardControllers[i].view.gameObject.activeSelf)
            {
                _cardControllers[i].view.ChangeSideCard(true, true);
                return;
            }
        }
    }

    public bool CheckCompleteStack()
    {
        foreach(CardController card in _cardControllers)
        {
            if (card.view.gameObject.activeSelf)
                return false;
        }

        return true;
    }
}

