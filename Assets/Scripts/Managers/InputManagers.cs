using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManagers 
{

    private static GameControls gamecontrols;

    public static void Init(Player myPlayer)
    {
        gamecontrols = new GameControls(); 
        
        gamecontrols.Permanent.Enable();

        gamecontrols.InGame.Movement.performed += ctx => 
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector3>());
        };

        gamecontrols.InGame.Whatever.performed += ctx =>
        {
            myPlayer.SetFlyDirection(ctx.ReadValue<Vector2>());
        };

        gamecontrols.InGame.Whatever.performed += ctx =>
        {
            myPlayer.SetLandDirection(ctx.ReadValue<Vector2>());
        };
    }

    public static void SetGameControls()
    {
        gamecontrols.InGame.Enable();
        gamecontrols.UI.Disable();
    }

    public static void SetUIControls()
    {
        gamecontrols.UI.Enable();
        gamecontrols.InGame.Disable();
    }

}
