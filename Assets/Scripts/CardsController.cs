using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardFieldGenerator;

public class CardsController : MonoBehaviour
{
    [System.Serializable]
    private class CardsStack
    {
        public List<CardView> cardsView;
    }

    private class CardController
    {
        private CardModel _model;
        private CardView _view;

        private CardView _nextCard;
        private CardView _previousCard;

        public CardController(CardModel model, CardsStack stack, int stackPosition)
        {
            _model = model;
            _view = stack.cardsView[stackPosition];

            _nextCard = stack.cardsView[stackPosition + 1];
            _previousCard = stack.cardsView[stackPosition - 1];
        }
    }

    [SerializeField] private CardsData _cardsData;
    [SerializeField] private FieldData _fieldData;

    [SerializeField] private List<CardsStack> _cardsStacks = new List<CardsStack>();
    private List<CardController> _cardControllers = new List<CardController>();
    private CardsFieldModel _cardsFieldModel;

    private void GenerateField()
    {
        _cardsFieldModel = CardGenerator.GenerateCardsCombinations(_fieldData, _cardsData);
        
        for(int i = 0; i < _cardsFieldModel.cardsCombinationData.Count; i++)
        {
            CardsCombinationModel combination = _cardsFieldModel.cardsCombinationData[i];

            for (int i2 = 0; i2 < combination.cardsData.Count; i2++)
            {
                combination.cardsData[i2];

                int stackNum = Random.Range(0, _cardsStacks.Count);

                _cardControllers = new CardController(combination.cardsData[i2], _cardsStacks[sta]);
            }
        }
    }
}

