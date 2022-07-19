using System.Collections.Generic;
using UnityEngine;

namespace CardFieldGenerator
{
    public class CardGenerator
    {
        public static CardsFieldModel GenerateCardsCombinations(FieldData fieldData, CardsData cardData)
        {
            List<CardsCombinationModel> cardsCombinations = new List<CardsCombinationModel>();

            int generatedCard = 0;

            while (generatedCard < fieldData.cardCount)
            {
                int combinationCardCount = GenerateCombinationCardCount(fieldData, generatedCard);
                generatedCard += combinationCardCount;

                cardsCombinations.Add(new CardsCombinationModel(GenerateCardModels(fieldData, cardData, combinationCardCount)));
            }


            return new CardsFieldModel(cardsCombinations);

        }

        private static int GenerateCombinationCardCount(FieldData fieldData, int generatedCard)
        {
            int maxCardCombination = fieldData.maxCardCombination;

            if (fieldData.cardCount - generatedCard < fieldData.maxCardCombination)
            {
                maxCardCombination = fieldData.cardCount - generatedCard;
            }
            else if (fieldData.cardCount - generatedCard < fieldData.maxCardCombination + fieldData.minCardCombination)
            {
                maxCardCombination = fieldData.maxCardCombination - ((fieldData.maxCardCombination + fieldData.minCardCombination) - (fieldData.cardCount - generatedCard));
            }

            return Random.Range(fieldData.minCardCombination, maxCardCombination + 1);
        }

        private static List<CardModel> GenerateCardModels(FieldData fieldData, CardsData cardData, int combinationCardCount)
        {
            List<CardModel> combinationCards = new List<CardModel>(combinationCardCount);

            combinationCards[0] = new CardModel(Random.Range(0, cardData.cardValueMax), Random.Range(0, cardData.cardValueMax));

            int difference = 1;

            if (Chance(fieldData.decrementChance))
            {
                difference = -1;
            }

            for (int i = 1; i < combinationCards.Count; i++)
            {
                combinationCards[0] = new CardModel(combinationCards[i + difference].cardValue + 1, Random.Range(0, cardData.cardValueMax));

                if (Chance(fieldData.reverseChance))
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
