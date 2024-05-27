using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ClearCounter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.IsHasIngredient())
        {
            if (player.GetIngredients().TryGetComponent<PlateIngredient>(out PlateIngredient plateIngredient))
            {
                //holding plate
                 if (IsHasIngredient() == false)
                {//Player has ingrendient 
                    //the target counter is empty
                    TransferIngredient(player, this);
                }
                else
                {
                    //the target counter is occupied
                    bool isSuccess = plateIngredient.AddIngredientsSO(GetIngredientsSO());
                    if(isSuccess)
                    {
                        DestroyIngredient();
                    }
                    
                }
            }
            else
            {
                //holding ingredients
                
                if (IsHasIngredient() == false)
                {//Player has ingrendient 
                    //the target counter is empty
                    TransferIngredient(player, this);
                }
                else
                {
                    //the target counter is occupied
                    if(GetIngredients().TryGetComponent<PlateIngredient>(out plateIngredient))
                    {
                        if(plateIngredient.AddIngredientsSO(player.GetIngredientsSO()))
                        {
                            player.DestroyIngredient();
                        }
                    }
                }
            }

        }
        else
        {
            //Player has no ingredient
            if (IsHasIngredient() == false)
            {
                //the target counter is empty
            }
            else
            {
                //target counter is occupied
                TransferIngredient(this, player);
            }
        }
    }

}
