using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class OrderUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI orderNameText;
    [SerializeField]private Transform ingredientParent;
    [SerializeField]private Image iconUITemplate;

    private void Start()
    {
        iconUITemplate.gameObject.SetActive(false);
    }
    public void UpdateUI(RecipeSO recipeSO)
    {
        orderNameText.text = recipeSO.recipeName;
        foreach(IngredientsSO ingredientsSO in recipeSO.ingredientsSOList)
        {
            Image newIcon = GameObject.Instantiate (iconUITemplate);
            newIcon.transform.SetParent(ingredientParent);
            newIcon.sprite = ingredientsSO.sprite;
            newIcon.gameObject.SetActive(true);
        }
    }
}
