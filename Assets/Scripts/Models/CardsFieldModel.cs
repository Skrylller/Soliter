using System.Collections.Generic;

/// <summary>
/// ������ ��������� ����������.
/// </summary>
public class CardsFieldModel
{
    public readonly List<CardsCombinationModel> cardsCombinationData = new List<CardsCombinationModel>();

    public CardsFieldModel(List<CardsCombinationModel> cardsCombination)
    {
        cardsCombinationData = cardsCombination;
    }
}
