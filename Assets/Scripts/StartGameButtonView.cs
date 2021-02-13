using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButtonView : BaseUIButton
{
    public override void Execute()
    {
        GameStarter.StartGame();
        Debug.Log("pew");
    }
}
