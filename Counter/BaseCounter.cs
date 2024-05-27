using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : IngredientsHolder
{
    [SerializeField] private GameObject selectedCounter;
     public virtual void Interact(Player player)
    {
        Debug.LogWarning("no interactive method");
        // if (GetIngredients() == null)
        // {
        //     Ingredients ingredients = GameObject.Instantiate(ingredientsSO.prefab, GetHoldPoint()).GetComponent<Ingredients>();
        //     SetIngredient (ingredients);
        // }
        // else
        // {
        //     TransferIngredient(this, Player.Instance);
        // }
    }

    public virtual void InteractOperate(Player player)
    {

    }

      public void SelectedCounter()
    {
        selectedCounter.SetActive(true);
    }
    public void CancelSelected()
    {
        selectedCounter.SetActive(false);
    }

}
