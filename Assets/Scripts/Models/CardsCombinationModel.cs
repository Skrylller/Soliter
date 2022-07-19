using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCombinationModel
{
    public readonly List<CardModel> cardsData = new List<CardModel>();

    public CardsCombinationModel(List<CardModel> cards)
    {
        cardsData = cards;
    }
}
