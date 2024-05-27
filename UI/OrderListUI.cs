using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderListUI : MonoBehaviour
{
    [SerializeField]private Transform recipeParent;
   [SerializeField] private OrderUI orderUITemplate;

    private void Start()
    {
        orderUITemplate.gameObject.SetActive (false);
        OrderManager.Instance.OnRecipeSpawned += OrderManager_OnrecipeSpawned;
        OrderManager.Instance.OnOrderSuccessed += OrderManager_OnrecipeSuccessed;
    }

    private void OrderManager_OnrecipeSuccessed(object sender, System.EventArgs e)
    {
        UpdateUI();
    }
    private void OrderManager_OnrecipeSpawned(object sender, System.EventArgs e)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach(Transform child in recipeParent)
        {
            if (child!= orderUITemplate.transform)
            {
                Destroy (child.gameObject);
            }
        }

        List<RecipeSO> recipeSOList = OrderManager.Instance.GetOrderList();
        foreach (RecipeSO recipeSO in recipeSOList)
        {
            OrderUI orderUI = GameObject.Instantiate(orderUITemplate);
            orderUI.transform.SetParent(recipeParent);
            orderUI.gameObject.SetActive(true);
            orderUI.UpdateUI(recipeSO);
        }
    }
}
