using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameButtonView : BaseUIButton
{
    public override void Execute()
    {
        GameStarter.QuitGame();
        Debug.Log("Pew");
    }
}
