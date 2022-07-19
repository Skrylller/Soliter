using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel
{
    public readonly int suit;

    public readonly int cardValue;

    public CardModel(int suit, int cardValue)
    {
        this.suit = suit;
        this.cardValue = cardValue;
    }
}
