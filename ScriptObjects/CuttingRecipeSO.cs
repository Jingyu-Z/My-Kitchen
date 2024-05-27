using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] 
public class CuttingRecipe
{
    public IngredientsSO input;
    public IngredientsSO output;
    public int cuttingCountMax;
}
[CreateAssetMenu()]
public class CuttingRecipeListSO: ScriptableObject
{
    public List<CuttingRecipe> list;
    public IngredientsSO GetOutput (IngredientsSO input)
    {
        foreach (CuttingRecipe recipe in list)
        {
            if(recipe.input == input)
            {
                return recipe.output;
            }
        }
        return null;
    }
    public bool TryGetCuttingRecipe(IngredientsSO input,out CuttingRecipe cuttingRecipe)
    {
        foreach (CuttingRecipe recipe in list)
        {
            if(recipe.input == input)
            {
                cuttingRecipe = recipe; return true;
            }
        }
        cuttingRecipe = null;
        return false;
    }
}
