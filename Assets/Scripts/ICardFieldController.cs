using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICardFieldController
{
    void ClickOnStack(CardController controller, CardStackController stack);
    void SetUpperCard(CardController controller);
}
