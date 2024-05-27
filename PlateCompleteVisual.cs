using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public class IngredientsSO_Model
    {
        public IngredientsSO ingredientsSO;
        public GameObject model;
    }
    [SerializeField]private List<IngredientsSO_Model>modelMap;
    public void ShowIngredients(IngredientsSO ingredientsSO)
    {
        foreach(IngredientsSO_Model item in modelMap)
        {
            if(item.ingredientsSO == ingredientsSO)
            {
                item.model.SetActive(true);
                return;
            }
        }
    }
}
