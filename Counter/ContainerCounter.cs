using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField] private IngredientsSO ingredientsSO;
    [SerializeField]private ContainerCounterVisual containerCounterVisual;
    
    public override void Interact(Player player)
    {
        if (player.IsHasIngredient()) return;

        CreateIngredient(ingredientsSO.prefab);

        TransferIngredient(this, player);
        containerCounterVisual.PlayOpen();
    }

}
