using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardFieldGenerator;

public class CardsFieldController : MonoBehaviour
{
    [SerializeField] private CardsData _cardsData;
    [SerializeField] private FieldData _fieldData;

    [SerializeField] private List<CardStackController> _cardsStacks = new List<CardStackController>();
    [SerializeField] private BankView _bankView;

    private BankController _bankController;
    private List<CardController> _cardControllers = new List<CardController>();
    private CardsFieldModel _cardsFieldModel;

    private void Start()
    {
        BankInicialize();
        GenerateField();
    }

    public void GenerateField()
    {
        ResetField();

        int cardViewCount = 0;

        foreach (CardStackController cardStack in _cardsStacks)
        {
            cardViewCount += cardStack.CardsViewCount();
        }

        _cardsFieldModel = CardGenerator.GenerateCardsCombinations(_fieldData, _cardsData, cardViewCount);

        for (int i = _cardsFieldModel.cardsCombinationData.Count - 1; i >= 0; i--)
        {
            CardsCombinationModel combination = _cardsFieldModel.cardsCombinationData[i];

            for (int i2 = combination.cardsData.Length - 1; i2 > 0; i2--)
            {
                int stackNum;
                int tryIteration = 0;

                do
                {
                    tryIteration++;
                    stackNum = Random.Range(0, _cardsStacks.Count);
                }
                while (!_cardsStacks[stackNum].FreeCardView() && tryIteration < 100);

                _cardControllers.Add(new CardController(_cardsData, combination.cardsData[i2], _cardsStacks[stackNum], _cardsStacks[stackNum].NextCardNum()));
            }

            _bankController.PushCard(combination.cardsData[0]);
        }

    }

    private void ResetField()
    {
        foreach (CardStackController stack in _cardsStacks)
        {
            stack.Reset();
        }
        _bankController.Clear();
        _cardControllers.Clear();
    }

    private void BankInicialize()
    {
        _bankController = new BankController(_bankView, _cardsData);
    }
}

