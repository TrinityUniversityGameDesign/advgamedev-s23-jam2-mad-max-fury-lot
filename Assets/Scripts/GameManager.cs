using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public enum GameState
{
    StartScreen, 
    Paused,
    Racing,
    Upgrade,
    Race_Select
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private GameState _state;


    public UnityEvent StartScreenEnter = new UnityEvent();
    public UnityEvent PausedEnter = new UnityEvent();
    public UnityEvent RacingEnter = new UnityEvent();
    public UnityEvent UpgradeEnter = new UnityEvent();
    public UnityEvent Race_SelectEnter = new UnityEvent();
    public UnityEvent StartupNewRace = new UnityEvent();

    public UnityEvent StartScreenEnd = new UnityEvent();
    public UnityEvent PausedEnd = new UnityEvent();
    public UnityEvent RacingEnd = new UnityEvent();
    public UnityEvent UpgradeEnd = new UnityEvent();
    public UnityEvent Race_SelectEnd = new UnityEvent();
    public UnityEvent EndRace = new UnityEvent();



    #region Race Variables
    public GameObject enemyPrefab;
    public GameObject enemies;

    public GameObject finishLine;
    public GameObject startLine;

    public int SelectedLevel = 1;
    #endregion

    #region Player Variables
    public int coinAmt;

    public int maxSpeed;
    public int acceleration;
    public int grip; //Max Steer Angle
    public int handling; //turn force/steering speed
    public int brakes; // Breakforce 
    #endregion

    private void Awake()
    {
        Instance = this;
        Instance.coinAmt = PlayerPrefs.GetInt("coins");
        Instance.maxSpeed = PlayerPrefs.GetInt("speed");
        Instance.acceleration = PlayerPrefs.GetInt("accel");
        Instance.grip = PlayerPrefs.GetInt("grip");
        Instance.handling = PlayerPrefs.GetInt("handling");
        Instance.brakes = PlayerPrefs.GetInt("brakes");
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        OnStateEnter(GameState.StartScreen);

        EndRace.AddListener(EndRace_GameManager);
        StartupNewRace.AddListener(StartNewRace_GameManager);
    }

    // Update is called once per frame
    void Update()
    {
        TickState();
    }

    void TickState()
    {
        switch (Instance._state)
        {
            case GameState.StartScreen:
                break;
            case GameState.Paused:
                break;
            case GameState.Racing:
                break;
            case GameState.Upgrade:
                break;
            case GameState.Race_Select:
                break;
            default:
                break;
        }
    }

    public void OnStateEnter(GameState newState)
    {
        OnStateExit();
        Instance._state = newState;

        switch (Instance._state)
        {
            case GameState.StartScreen:
                StartScreenEnter.Invoke();
                Debug.Log("Entering Start Screen");
                break;
            case GameState.Paused:
                PausedEnter.Invoke();
                break;
            case GameState.Racing:
                RacingEnter.Invoke();
                break;
            case GameState.Upgrade:
                UpgradeEnter.Invoke();
                break;
            case GameState.Race_Select:
                Race_SelectEnter.Invoke();
                break;
            default:
                break;
        }
    }

    void OnStateExit()
    {
        switch (Instance._state)
        {
            case GameState.StartScreen:
                StartScreenEnd.Invoke();
                break;
            case GameState.Paused:
                PausedEnd.Invoke();
                break;
            case GameState.Racing:
                RacingEnd.Invoke();
                break;
            case GameState.Upgrade:

                PlayerPrefs.SetInt("coins", Instance.coinAmt);
                PlayerPrefs.SetInt("speed", Instance.maxSpeed);
                PlayerPrefs.SetInt("accel", Instance.acceleration);
                PlayerPrefs.SetInt("grip", Instance.grip);
                PlayerPrefs.SetInt("handling", Instance.handling);
                PlayerPrefs.SetInt("brakes", Instance.brakes);

                UpgradeEnd.Invoke();
                break;
            case GameState.Race_Select:
                Race_SelectEnd.Invoke();
                break;
            default:
                break;
        }
    }

    void EndRace_GameManager()
    {
        PlayerPrefs.SetInt("coins", Random.Range(0, 30));
    }

    void StartNewRace_GameManager()
    {
        //Spawn enemies and change scenes to the one the player wnats
        SceneManager.LoadScene(Instance.SelectedLevel + 1);
        OnStateEnter(GameState.Racing);
    }
}
