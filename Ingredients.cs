using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
  [SerializeField] private IngredientsSO ingredientsSO;
  public IngredientsSO GetIngredientsSO()
  {
    return ingredientsSO;
  }
}
