using UnityEngine;

[CreateAssetMenu(menuName = "Objects/FieldData")]
public class FieldData : ScriptableObject
{
    [Range(0,100)]
    [SerializeField] private int _decrementChance;
    [Range(0, 100)]
    [SerializeField] private int _reverseChance;
    [SerializeField] private int _maxCardCombination;
    private const int _minCardCombination = 2;

    public int decrementChance { get { return _decrementChance; } }
    public int reverseChance { get { return _reverseChance; } }
    public int maxCardCombination { get { return _maxCardCombination; } }
    public int minCardCombination { get { return _minCardCombination; } }
}
