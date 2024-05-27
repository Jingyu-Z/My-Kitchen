using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public event EventHandler StateChanged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    private enum State
    {
        WaitingForStart,
        CountDown,
        GamePlaying,
        GameOver
    }

    [SerializeField] private Player player;
    private State state;

    private float waitingforstartTimer = 1;
    private float countdownTimer = 3;
    private float gameplayingTimer = 100;
    private float gamePlayingTimeTotal;
    private bool isGamePause = false; 
    void Awake()
    {
        Instance = this;
        gamePlayingTimeTotal = gameplayingTimer;
    }
    // Start is called before the first frame update
    private void Start() 
    {
        TurnToWaitingForStart();
        GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
    }
    private void GameInput_OnPauseAction (object sender, EventArgs e) 
    {
        ToggleGame();
    }
    
    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case State.WaitingForStart:
            waitingforstartTimer-= Time.deltaTime;
            if(waitingforstartTimer <= 0)
            {
                TurnToCountDown();
            }
            break;
            case State.CountDown:
            countdownTimer -=Time.deltaTime;
            if(countdownTimer <= 0)
            {
                TurnToGamePlaying();
            }
            break;
            case State.GamePlaying:
            gameplayingTimer -= Time.deltaTime;
            if(gameplayingTimer <= 0)
            {
                TurnToGameOver();
            }
            break;
            case State.GameOver:
            break;
        }
    }
    private void TurnToWaitingForStart()
    {
        state = State.WaitingForStart;
        DisablePlayer();
        StateChanged?.Invoke(this,EventArgs.Empty);
    }
    private void TurnToCountDown()
    {
        state = State.CountDown;
        DisablePlayer();
        StateChanged?.Invoke(this,EventArgs.Empty);
    }
    
    private void TurnToGamePlaying()
    {
        state = State.GamePlaying;
        EnablePlayer();
        StateChanged?.Invoke(this,EventArgs.Empty);
    }
    private void TurnToGameOver()
    {
        state = State.GameOver;
        DisablePlayer();
        StateChanged?.Invoke(this,EventArgs.Empty);
    }
    private void DisablePlayer()
    {
        player.enabled = false;
    }
    private void EnablePlayer()
    {
        player.enabled = true;
    }
    public bool isWaitingForStartState()
    {
        return state == State.WaitingForStart;
    }
    public bool CountDownState()
    {
        return state == State.CountDown;
    }
    public bool isPlayingState()
    {
        return state == State.GamePlaying;
    }
    public bool IsGameOverState()
    {
        return state == State.GameOver;
    }
    public float GetCountDownTimer()
    {
        return countdownTimer;
    }
    public void ToggleGame()
    {
        isGamePause = !isGamePause;
        if(isGamePause)
        {
            Time.timeScale = 0;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1;
            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }

    public float GetGamePlayingTimer()
    {
        return gameplayingTimer;
    }

    public float GetGamePlayingTimerNormalized()
    {
        return gameplayingTimer/gamePlayingTimeTotal;
    }
}
