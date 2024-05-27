using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnThrowRubbish;
    public override void Interact(Player player)
    {
        if(player.IsHasIngredient())
        {
            player.DestroyIngredient();
            OnThrowRubbish?.Invoke(this, EventArgs.Empty);
        }
    }

    public static void ClearStaticData () {
        OnThrowRubbish= null;
    }
}
