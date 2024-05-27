using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeListSO fryingRecipeList;
    [SerializeField] private FryingRecipeListSO burningRecipeList;
    [SerializeField] private StoveCounterVisual stoveCounterVisual;
    [SerializeField] private ProgressBarUI progressBarUI;
    [SerializeField] private AudioSource sound;
    public enum StoveState
    {
        Idel,
        Frying,
        Burning
    }
    private FryingRecipe fryingRecipe;
    private float fryingTimer = 0;
    private StoveState state = StoveState.Idel;
    private WarningControl warningControl;

    private void Start() {
        warningControl = GetComponent<WarningControl>();
    }

    public override void Interact(Player player)
    {
        if (player.IsHasIngredient())
        {
            //Player has ingrendient 
            if (IsHasIngredient() == false)
            {
                //the target counter is empty
                if (fryingRecipeList.TryGetFryingRecipe(player.GetIngredients().GetIngredientsSO(), out FryingRecipe fryingRecipe))
                {
                    TransferIngredient(player, this);
                    StartFrying(fryingRecipe);
                }
                else if (burningRecipeList.TryGetFryingRecipe(player.GetIngredients().GetIngredientsSO(), out FryingRecipe burningRecipe))
                {
                    TransferIngredient(player, this);
                    StartBurning(burningRecipe);
                }
                else
                {

                }
            }
            else
            {
                //the target counter is occupied
            }
        }
        else
        {
            //Player has no ingredient
            if (IsHasIngredient() == false)
            {
                //the target counter is empty
            }
            else
            {
                //target counter is occupied
                TurnToIdel();
                TransferIngredient(this, player);
            }
        }
    }

    private void Update()
    {
        switch (state)
        {
            case StoveState.Idel:
                break;
            case StoveState.Frying:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer/fryingRecipe.fryingTime);
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyIngredient();
                    CreateIngredient(fryingRecipe.output.prefab);


                    burningRecipeList.TryGetFryingRecipe(GetIngredients().GetIngredientsSO(), out FryingRecipe newFryingRecipe);
                    StartBurning(newFryingRecipe);
                }
                break;
            case StoveState.Burning:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer/fryingRecipe.fryingTime);
                float warningTimeNormalize = .5f;
                if(fryingTimer/ fryingRecipe.fryingTime > warningTimeNormalize)
                {
                    warningControl.ShowWarning();
                }
                if (fryingTimer >= fryingRecipe.fryingTime)
                {
                    DestroyIngredient();
                    CreateIngredient(fryingRecipe.output.prefab);
                    TurnToIdel();
                }
                break;
            default:
                break;
        }
    }
    private void StartFrying(FryingRecipe fryingRecipe)
    {
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Frying;
        stoveCounterVisual.ShowStoveEffect();
        sound.Play();
    }

    private void StartBurning(FryingRecipe fryingRecipe)
    {
        if (fryingRecipe == null)
        {
            Debug.LogWarning("Can not get Burning Recipe, can not be 'Burning'");
            TurnToIdel();
            return;
        }
        stoveCounterVisual.ShowStoveEffect();
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = StoveState.Burning;
        sound.Play();
    }
    private void TurnToIdel()
    {
        progressBarUI.Hide();
        state = StoveState.Idel;
        stoveCounterVisual.HideStoveEffect();
        sound.Pause();
        warningControl.StopWarning();
    }
}
