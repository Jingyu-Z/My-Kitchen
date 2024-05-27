using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientsHolder : MonoBehaviour
{
    public static event EventHandler OnDrop;
    public static event EventHandler OnPickUp;
    [SerializeField] private Transform holdPoint;
    private Ingredients ingredients;
    public Ingredients GetIngredients()
    {
        return ingredients;
    }
    public IngredientsSO GetIngredientsSO()
    {
        return ingredients.GetIngredientsSO();
    }
    public bool IsHasIngredient()
    {
        return ingredients != null;
    }
    public void SetIngredient(Ingredients ingredients)
    {
        if (this. ingredients != ingredients && ingredients !=  null && this is BaseCounter)
        {
            OnDrop?. Invoke(this, EventArgs.Empty);
        }
        else if(this. ingredients != ingredients && ingredients !=  null && this is Player)
        {
             OnPickUp?. Invoke(this, EventArgs.Empty);
        }
        this.ingredients = ingredients;
        ingredients.transform.localPosition = Vector3.zero;

        
    }
    public Transform GetHoldPoint()
    {
        return holdPoint;
    }
    public void TransferIngredient(IngredientsHolder sourceHolder, IngredientsHolder targetHolder)
    {
        if (sourceHolder.GetIngredients() == null)
        {
            Debug.LogWarning("Transfer failed, no ingredients at source holder");
            return;
        }
        if (targetHolder.GetIngredients() != null)
        {
            Debug.LogWarning("Transfer failed, ingredients already existed at target holder");
            return;
        }
        targetHolder.AddIngredients(sourceHolder.GetIngredients());
        sourceHolder.ClearIngredient();
    }
    public void AddIngredients(Ingredients ingredients)
    {
        ingredients.transform.SetParent(holdPoint);
        SetIngredient(ingredients);
    }



    public void ClearIngredient()
    {
        this.ingredients = null;
    }
    public void DestroyIngredient()
    {
        Destroy(ingredients.gameObject);
        ClearIngredient();
    }
    public void CreateIngredient(GameObject ingredientsPrefab)
    {
        Ingredients ingredients = GameObject.Instantiate(ingredientsPrefab, GetHoldPoint()).GetComponent<Ingredients>();
        SetIngredient(ingredients);
    }

    public static void ClearStaticData () {
        OnDrop = null;
        OnPickUp = null;
    }
}
