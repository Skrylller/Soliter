using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsFieldModel
{
    public readonly List<CardsCombinationModel> cardsCombinationData = new List<CardsCombinationModel>();

    public CardsFieldModel(List<CardsCombinationModel> cardsCombination)
    {
        cardsCombinationData = cardsCombination;
    }
}
