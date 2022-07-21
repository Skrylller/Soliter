using System.Collections.Generic;
using UnityEngine;

namespace CardFieldGenerator
{
    /// <summary>
    /// Генератор карточных комбинаций.
    /// </summary>
    public class CardGenerator
    {
        public static CardsFieldModel GenerateCardsCombinations(FieldData fieldData, CardsData cardData, int fieldSize)
        {
            List<CardsCombinationModel> cardsCombinations = new List<CardsCombinationModel>();

            int generatedCard = 0;

            while (generatedCard < fieldSize)
            {
                int combinationCardCount = GenerateCombinationCardCount(fieldData, fieldSize, generatedCard);
                generatedCard += combinationCardCount - 1;

                cardsCombinations.Add(new CardsCombinationModel(GenerateCombination(fieldData, cardData, combinationCardCount)));
            }


            return new CardsFieldModel(cardsCombinations);

        }

        private static int GenerateCombinationCardCount(FieldData fieldData, int fieldSize, int generatedCard)
        {
            int maxCardCombination = fieldData.maxCardCombination;

            if (fieldSize - generatedCard < fieldData.maxCardCombination)
            {
                return fieldSize - generatedCard + 1;
            }
            else if (fieldSize - generatedCard < fieldData.maxCardCombination + fieldData.minCardCombination - 1)
            {
                maxCardCombination = fieldData.maxCardCombination - ((fieldData.maxCardCombination + fieldData.minCardCombination) - (fieldSize - generatedCard));
            }

            return Random.Range(fieldData.minCardCombination, maxCardCombination + 1);
        }

        private static CardModel[] GenerateCombination(FieldData fieldData, CardsData cardData, int combinationCardCount)
        {
            CardModel[] combinationCards = new CardModel[combinationCardCount];

            combinationCards[0] = new CardModel(Random.Range(0, cardData.SuitCount()), Random.Range(0, cardData.cardValueMax));

            Debug.Log($"Start combination:");
            Debug.Log($"{combinationCards[0].cardValue} {combinationCards[0].suit}");

            int difference = 1;

            if (Chance(fieldData.decrementChance))
            {
                difference = -1;
            }

            for (int i = 1; i < combinationCards.Length; i++)
            {
                int cardValue = combinationCards[i - 1].cardValue + difference;

                if (cardValue < 0)
                    cardValue = cardData.cardValueMax - 1;

                if (cardValue >= cardData.cardValueMax)
                    cardValue = 0;

                combinationCards[i] = new CardModel(Random.Range(0, cardData.SuitCount()), cardValue);

                Debug.Log($"{combinationCards[i].cardValue} {combinationCards[i].suit}");

                if (i < combinationCards.Length - 2 && Chance(fieldData.reverseChance))
                {
                    difference = -difference;
                }
            }

            return combinationCards;
        }

        private static bool Chance(int chance)
        {
            return Random.Range(0, 100) < chance;
        }
    }
}
