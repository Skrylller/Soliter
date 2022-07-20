using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardFieldGenerator;

public class CardsFieldController : MonoBehaviour, ICardFieldController
{
    [SerializeField] private CardsData _cardsData;
    [SerializeField] private FieldData _fieldData;

    [SerializeField] private List<CardStackController> _cardsStacks = new List<CardStackController>();
    [SerializeField] private BankView _bankView;
    [SerializeField] private CardController _upperCard;

    [SerializeField] private CardAnimationsController _cardAnimationsController;
    [SerializeField] private UIView _uiView;

    private BankController _bankController;
    private CardsFieldModel _cardsFieldModel;

    private void Start()
    {
        FieldInicialize();
        GenerateField();
    }

    public void ClickOnStack(CardController cardController, CardStackController cardStack)
    {

        if(Mathf.Abs(_upperCard.model.cardValue - cardController.model.cardValue) == 1 || 
            (_upperCard.model.cardValue == _cardsData.cardValueMax - 1 && cardController.model.cardValue == 0) ||
            (_upperCard.model.cardValue == 0 && cardController.model.cardValue == _cardsData.cardValueMax - 1))
        {
            cardController.view.gameObject.SetActive(false);
            cardStack.SetSideCards();
            SetUpperCard(cardController);
            CheckCompleteField();
        }
    }

    public void SetUpperCard(CardController cardController)
    {
        _upperCard.SetModel(cardController.model);

        _cardAnimationsController.CardAnimation(_cardsData, cardController, _upperCard.view.transform.position, OnComplete);

        void OnComplete()
        {
            _upperCard.SetCardController(_cardsData, cardController.model);
        }
    }

    public void GenerateField()
    {
        ResetField();

        int cardViewCount = 0;

        foreach (CardStackController cardStack in _cardsStacks)
        {
            cardViewCount += cardStack.CardsControllerCount();
        }

        _cardsFieldModel = CardGenerator.GenerateCardsCombinations(_fieldData, _cardsData, cardViewCount);

        for (int i = _cardsFieldModel.cardsCombinationData.Count - 1; i >= 0; i--)
        {
            CardsCombinationModel combination = _cardsFieldModel.cardsCombinationData[i];

            for (int i2 = combination.cardModels.Length - 1; i2 > 0; i2--)
            {
                int stackNum;
                int tryIteration = 0;

                do
                {
                    tryIteration++;
                    stackNum = Random.Range(0, _cardsStacks.Count);
                }
                while (!_cardsStacks[stackNum].CheckNextCard() && tryIteration < 100);

                _cardsStacks[stackNum].NewCard(_cardsData, combination.cardModels[i2]);
            }

            if(i == 0)
            {
                _upperCard.SetCardController(_cardsData, combination.cardModels[0]);
            }
            else
            {
                _bankController.PushCard(combination.cardModels[0]);
            }
        }

        foreach (CardStackController stack in _cardsStacks)
        {
            stack.SetSideCards();
        }
    }

    private void ResetField()
    {
        foreach (CardStackController stack in _cardsStacks)
        {
            stack.Reset();
        }
        _bankController.Clear();
    }

    private void FieldInicialize()
    {
        foreach (CardStackController stack in _cardsStacks)
        {
            stack.Inicialization(this);
        }
        _bankController = new BankController(this, _bankView, _cardsData);
    }

    private void CheckCompleteField()
    {
        foreach (CardStackController stack in _cardsStacks)
        {
            if (!stack.CheckCompleteStack())
                return;
        }

        _uiView.OpenCompletePanel();
    }
}

