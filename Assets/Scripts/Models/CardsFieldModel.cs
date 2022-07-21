using System.Collections.Generic;

/// <summary>
/// Хранит карточные комбинации.
/// </summary>
public class CardsFieldModel
{
    public readonly List<CardsCombinationModel> cardsCombinationData = new List<CardsCombinationModel>();

    public CardsFieldModel(List<CardsCombinationModel> cardsCombination)
    {
        cardsCombinationData = cardsCombination;
    }
}
