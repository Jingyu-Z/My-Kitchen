using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIngredient : Ingredients
{
    [SerializeField] private List <IngredientsSO> validIngredientSOList;
    [SerializeField] private PlateCompleteVisual plateCompleteVisual;

    [SerializeField] private IngredientGridUI ingredientGridUI;
    private List <IngredientsSO> ingredientsSOList = new List<IngredientsSO>();
    public bool AddIngredientsSO(IngredientsSO ingredientsSO)
    {
        if(ingredientsSOList.Contains(ingredientsSO))
        {
            return false;
        }
        if(validIngredientSOList.Contains(ingredientsSO)==false)
        {
            return false;
        }
        plateCompleteVisual.ShowIngredients(ingredientsSO);
        ingredientGridUI.ShowIngredientsUI(ingredientsSO);
        ingredientsSOList.Add(ingredientsSO);
        return true;
    }

    public List <IngredientsSO> GetIngredientSOList()
    {
        return ingredientsSOList;
    }
}
