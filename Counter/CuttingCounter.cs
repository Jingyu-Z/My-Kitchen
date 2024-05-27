using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CuttingCounter : BaseCounter
{
    public static event EventHandler OnCut;
    [SerializeField]private CuttingRecipeListSO cuttingRecipelist;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField]private CuttingCounterVisual cuttingCounterVisual;
    private int cuttingCount= 0;
    public override void Interact(Player player)
    {
        if(player.IsHasIngredient())
        {
            //Player has ingrendient 
            if(IsHasIngredient()==false)
            {
                //the target counter is empty
                cuttingCount=0;
                TransferIngredient(player,this);
            }
            else
            {
                //the target counter is occupied
            }
        }
        else
        {
            //Player has no ingredient
            if(IsHasIngredient() == false)
            {
                //the target counter is empty
            }
            else
            {
                //target counter is occupied
                
                TransferIngredient(this, player);
                progressBarUI.Hide();
            }
        }
    }
    public override void InteractOperate(Player player)
    {
        if(IsHasIngredient())
        {
            Cut();
            if(cuttingRecipelist.TryGetCuttingRecipe(GetIngredients().GetIngredientsSO(), out CuttingRecipe cuttingRecipe))
            {
                progressBarUI.UpdateProgress((float)cuttingCount/cuttingRecipe.cuttingCountMax);
                if(cuttingCount == cuttingRecipe.cuttingCountMax)
                {
                DestroyIngredient();
                CreateIngredient(cuttingRecipe.output.prefab);
                }
            }
            
        }
    }
    public void Cut()
    {
        OnCut?.Invoke(this, EventArgs.Empty);
        cuttingCount++;
        cuttingCounterVisual.PlayCut();
    }

    public static void ClearStaticdata()
    {
        OnCut = null;
    }
}
