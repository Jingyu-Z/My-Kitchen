using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class IngredientIconUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    public void Show(Sprite sprite)
    {
        gameObject.SetActive(true);
        iconImage.sprite = sprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
