using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance {get; private set;}

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnOrderSuccessed;
    public event EventHandler OnOrderFailed;
    [SerializeField] private RecipeListSO recipeSOList;
    [SerializeField] private int orderMaxCount = 5;
    [SerializeField] private float orderRate= 2;
    private List <RecipeSO> orderRecipeSOList = new List<RecipeSO>();

    private float orderTimer = 0;
    private bool isStartOrder = false;
    private int orderCount= 0;
    private int SuccessOrderCount = 0;
    private void Awake() 
    {
        Instance = this;    
    }
    private void Start() {
        GameManager.Instance.StateChanged += GameManager_StateChanged;
    }
    private void GameManager_StateChanged(object sender, EventArgs e)
    {
        if(GameManager.Instance.isPlayingState())
        {
            SpawningOrder();
        }
    }

    private void Update () 
    {
        if(isStartOrder)
        {
            OrderUpdate();
        }    
    }

    private void OrderUpdate()
    {
        orderTimer += Time.deltaTime;
        if(orderTimer >= orderRate)
        {
            orderTimer = 0;
            NewOrder();
        }
    }

    private void NewOrder()
    {
        if(orderCount >= orderMaxCount) return;
        orderCount ++;
        int index= UnityEngine.Random.Range (0, recipeSOList.recipeSOList.Count);
        orderRecipeSOList.Add(recipeSOList.recipeSOList[index]);
        OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
    }

    public void Delivery(PlateIngredient plateIngredient)
    {
        RecipeSO correctRecipe = null;
        foreach(RecipeSO recipe in orderRecipeSOList)
        {
            if(isCorrect(recipe,plateIngredient))
            {
                correctRecipe = recipe;
                break;
            }
        }

        if (correctRecipe == null)
        {
            print ("Delivery Failed");
            OnOrderFailed?.Invoke(this,EventArgs.Empty);
            
        }
        else
        {
            orderRecipeSOList.Remove(correctRecipe);
            OnOrderSuccessed?.Invoke(this, EventArgs.Empty);
            SuccessOrderCount++;
            print ("Delivery Successed!");
        }
    }

    private bool isCorrect (RecipeSO recipe, PlateIngredient plateIngredient)
    {
        List<IngredientsSO> list1 = recipe.ingredientsSOList;
        List<IngredientsSO> list2 = plateIngredient.GetIngredientSOList();

        if(list1.Count != list2.Count) return false;
        foreach(IngredientsSO ingredientsSO in list1)
        {
            if(list2.Contains(ingredientsSO) == false)
            {
                return false;
            }
        }
        return true;
    }

    public List<RecipeSO> GetOrderList()
    {
        return orderRecipeSOList;
    }

    public void SpawningOrder ()
    {
        isStartOrder = true;   
    }
    public int GetSuccessOrderCount()
    {
        return SuccessOrderCount;
    }
}
