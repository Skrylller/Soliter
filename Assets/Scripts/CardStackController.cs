using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardStackController
{
    [SerializeField] private List<CardView> _cardsView = new List<CardView>();
    private int useCards = 0;

    public CardView CardView(int num)
    {
        if (_cardsView.Count <= num || num < 0)
            return null;

        return _cardsView[num];
    }

    public int CardsViewCount()
    {
        return _cardsView.Count;
    }

    public void Reset()
    {
        useCards = 0;
    }

    public bool FreeCardView()
    {
        if (_cardsView.Count <= useCards)
            return false;

        return true;
    }

    public int NextCardNum()
    {
        if (!FreeCardView())
        {
            Debug.LogError("Card stack is full");
            return 0;
        }

        return useCards++;
    }
}

