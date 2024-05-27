
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {get; private set;}
    private const string SOUNDMANAGER_VOLUME = "SoundManagerVolume";
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private int volume = 5;

    private void Awake()
    {
        Instance = this;
        LoadVolume();
    }
    private void Start()
    {
        OrderManager.Instance.OnOrderSuccessed += OrderManager_OnrecipeSuccessed;
        OrderManager.Instance.OnOrderFailed += OrderManager_OnrecipeFailed;
        CuttingCounter.OnCut +=CuttingCounter_OnCut;
        IngredientsHolder.OnDrop += IngredientsHolder_OnDrop;
        IngredientsHolder.OnPickUp += IngredientsHolder_OnPickUp;
        TrashCounter.OnThrowRubbish += TrashCounter_OnThrowRubbish;

    }

    private void OrderManager_OnrecipeSuccessed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliverySuccessed);
    }
    public void PlayWarningSound()
    {
        PlaySound(audioClipRefsSO.warning);
    }
    public void PlayCountDownSound()
    {
        PlaySound(audioClipRefsSO.warning);
    }
     private void OrderManager_OnrecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.deliveryFailed);
    }
    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop);
    }
    private void IngredientsHolder_OnDrop (object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.drop);
    }
    private void IngredientsHolder_OnPickUp (object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.pickup);
    }
    private void TrashCounter_OnThrowRubbish (object sender, System.EventArgs e)
    {
        print("trashed");
        PlaySound(audioClipRefsSO.trash);
    }
    public void PlayStepSound(float volumeMultiply = 1f)
    {
        PlaySound(audioClipRefsSO.footstep, volume);
    }
    private void PlaySound(AudioClip[] clips, float volumeMultiply = 1.0f)
    {
        PlaySound(clips, Camera.main.transform.position, volumeMultiply);
    }
    private void PlaySound(AudioClip[] clips, Vector3 position, float volumeMultiply = 1.0f)
    {
        if(volume == 0) return;
        int index = Random.Range(0, clips.Length);
        AudioSource.PlayClipAtPoint(clips[index], position, volumeMultiply*(volume/10.0f));
    }
    public void ChangeVolume()
    {
        volume++;
        if(volume>10)
        {
            volume = 0;
        }
        SaveVolume();
    }

    public int GetVolume()
    {
        return volume;
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetInt(SOUNDMANAGER_VOLUME,volume);
    }
    private void LoadVolume()
    {
        volume = PlayerPrefs.GetInt(SOUNDMANAGER_VOLUME, volume);
    }
}
