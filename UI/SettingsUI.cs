using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public static SettingsUI Instance{get; private set;}
    [SerializeField]private GameObject uiParent;
    [SerializeField] private Button soundButton;
    [SerializeField] private TextMeshProUGUI soundButtonText;
    [SerializeField] private Button musicButton;
    [SerializeField] private TextMeshProUGUI musicButtonText;
    [SerializeField] private Button closeButton;

    [SerializeField] private Button upKeyButton;
    [SerializeField] private Button downKeyButton;
    [SerializeField] private Button leftKeyButton;
    [SerializeField] private Button rightKeyButton;
    [SerializeField] private Button operationKeyButton;
    [SerializeField] private Button cuttingKeyButton;
    [SerializeField] private Button PauseKeyButton;

    [SerializeField] private TextMeshProUGUI upKeyButtonText;
    [SerializeField] private TextMeshProUGUI downKeyButtonText;
    [SerializeField] private TextMeshProUGUI leftKeyButtonText;
    [SerializeField] private TextMeshProUGUI rightKeyButtonText;
    [SerializeField] private TextMeshProUGUI operationKeyButtonText;
    [SerializeField] private TextMeshProUGUI cuttingKeyButtonText;
    [SerializeField] private TextMeshProUGUI PauseKeyButtonText;
    [SerializeField] private GameObject rebindingHint;

    private void Awake() {
        Instance = this;
    }
    private void Start() {
        Hide();
        UpdateVisual();
        soundButton.onClick.AddListener(()=>{
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(()=>{
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        closeButton.onClick.AddListener(()=>{
            Hide();
        });

        upKeyButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Up);});
        downKeyButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Down);});
        leftKeyButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Left);});
        rightKeyButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Right);});
        cuttingKeyButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Interact);});
        operationKeyButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Operate);});
        PauseKeyButton.onClick.AddListener(() =>{ReBinding(GameInput.BindingType.Pause);});
    }
    public void Show()
    {
        uiParent.SetActive(true);
    }

    private void Hide()
    {
        uiParent.SetActive(false);
    }

    void UpdateVisual()
    {
        soundButtonText.text = "Sound Effect Volume: "+SoundManager.Instance.GetVolume();
        musicButtonText.text = "Background Music Volume: " + MusicManager.Instance.GetVolume();
        upKeyButtonText.text = GameInput.Instance.GetBindingDisplayString(GameInput.BindingType.Up);
        downKeyButtonText.text = GameInput.Instance.GetBindingDisplayString(GameInput.BindingType.Down);
        leftKeyButtonText.text = GameInput.Instance.GetBindingDisplayString(GameInput.BindingType.Left);
        rightKeyButtonText.text = GameInput.Instance.GetBindingDisplayString(GameInput.BindingType.Right);
        operationKeyButtonText.text = GameInput.Instance.GetBindingDisplayString(GameInput.BindingType.Operate);
        cuttingKeyButtonText.text = GameInput.Instance.GetBindingDisplayString(GameInput.BindingType.Interact);
        PauseKeyButtonText.text = GameInput.Instance.GetBindingDisplayString(GameInput.BindingType.Pause);
    }

    private void ReBinding(GameInput.BindingType bindingType)
    {
        rebindingHint.SetActive(true);
        GameInput.Instance.ReBinding(bindingType,()=>
        {
            rebindingHint.SetActive(false);
            UpdateVisual();
        });
    }
}
