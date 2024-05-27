using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeListSO : ScriptableObject
{
    public List <FryingRecipe> list;
     public bool TryGetFryingRecipe(IngredientsSO input,out FryingRecipe fryingRecipe)
    {
        foreach (FryingRecipe recipe in list)
        {
            if(recipe.input == input)
            {
                fryingRecipe = recipe; return true;
            }
        }
        fryingRecipe = null;
        return false;
    }
}

    [Serializable]
    public class FryingRecipe
    {
        public IngredientsSO input;
        public IngredientsSO output;
        public float fryingTime;

    }

