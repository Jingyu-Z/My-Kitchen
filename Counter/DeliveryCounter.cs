using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if(player.IsHasIngredient() && player.GetIngredients().TryGetComponent<PlateIngredient>(out PlateIngredient plateIngredient))
        {
            //match with order
            OrderManager.Instance.Delivery(plateIngredient);
            player.DestroyIngredient();
        }
    }
}
