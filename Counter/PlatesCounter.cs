using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    [SerializeField] private IngredientsSO plateSO;
    [SerializeField] private float spawnRate = 3;
    [SerializeField] private int plateCountMax = 5;

    private List<Ingredients> platesList = new List<Ingredients>();

    private float timer = 0;

    private void Update()
    {
        if (platesList.Count < plateCountMax)
        {
            timer += Time.deltaTime;
        }

        if (timer > spawnRate)
        {
            timer = 0;
            SpawnPlate();
        }
    }
    public override void Interact(Player player)
    {
        if (player.IsHasIngredient() == false)
            if (platesList.Count > 0)
            {
                player.AddIngredients(platesList[platesList.Count - 1]);
                platesList.RemoveAt(platesList.Count - 1);
            }
    }


    public void SpawnPlate()
    {
        if (platesList.Count >= plateCountMax)
        {
            timer = 0;
            return;
        }
        Ingredients ingredients = GameObject.Instantiate(plateSO.prefab, GetHoldPoint()).GetComponent<Ingredients>();
        ingredients.transform.localPosition = Vector3.zero + Vector3.up * 0.1f * platesList.Count;
        platesList.Add(ingredients);
    }
}
