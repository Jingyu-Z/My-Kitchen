using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI numberText;
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        GameManager.Instance.StateChanged += GameManager_StateChanged;
    }

    private void GameManager_StateChanged(object sender, System.EventArgs e)
    {
        if(GameManager.Instance.IsGameOverState())
        {
            Show();
        }
    }

    private void Show () {
        numberText.text = OrderManager.Instance.GetSuccessOrderCount().ToString();
        uiParent.SetActive(true);
    }
    private void Hide () {
        uiParent.SetActive(false);
    }
}
