using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientGridUI : MonoBehaviour
{
    [SerializeField] private IngredientIconUI iconTemplateUI;

    private void Start() 
    {
        iconTemplateUI.Hide();
    }
    public void ShowIngredientsUI(IngredientsSO ingredientsSO)
    {
       IngredientIconUI newIconUI = GameObject.Instantiate (iconTemplateUI, transform);
       newIconUI.Show(ingredientsSO.sprite);
    }
}
