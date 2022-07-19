using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Objects/FieldData")]
public class FieldData : ScriptableObject
{
    [SerializeField] private int _cardCount;
    [SerializeField] private int _decrementChance;
    [SerializeField] private int _reverseChance;
    [SerializeField] private int _maxCardCombination;
    private const int _minCardCombination = 2;

    public int cardCount { get { return _cardCount; } }
    public int decrementChance { get { return _decrementChance; } }
    public int reverseChance { get { return _reverseChance; } }
    public int maxCardCombination { get { return _maxCardCombination; } }
    public int minCardCombination { get { return _minCardCombination; } }
}
