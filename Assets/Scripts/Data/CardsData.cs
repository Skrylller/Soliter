using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/CardData")]
public class CardsData : ScriptableObject
{
    private const int _cardValueMax = 13;
    private const int _cardValueSuitCount = 4;

    [SerializeField] private Sprite _backSprite;

    [System.Serializable]
    public class Suit
    {
        [SerializeField] public List<Sprite> cardSprites = new List<Sprite>(_cardValueMax);
    }

    [SerializeField] private List<Suit> _SuitsSprites = new List<Suit>(_cardValueSuitCount);


    public int cardValueMax { get { return _cardValueMax; } }
    public int _ardValueSuitCount { get { return _cardValueSuitCount; } }
    public Sprite backSprite { get { return _backSprite; } }

    public Sprite CardSprite(int suit, int cardValue)
    {
        return _SuitsSprites[suit].cardSprites[cardValue];
    }

    public int SuitCount()
    {
        return _SuitsSprites.Count;
    }
}

