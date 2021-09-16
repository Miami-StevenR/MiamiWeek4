using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public enum State { Menu, Running, Paused };

    private static GameManager _instance;

    private State _currentState = State.Menu;

    public static State CurrentState => _instance._currentState;
    public static UnityEvent<State> StateChanged { get; private set; } = new UnityEvent<State>();

    void Awake()
    {
        //Check to see if there is already an existing gameManager
        //If so, destroy this instance
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Unity will put this GameObject in a special scene that doesn't get cleared
        // between scene loads
        DontDestroyOnLoad(gameObject);
        _instance = this;
        ResumeGame();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void TogglePause()
    {
        if (_instance._currentState == State.Running)
        {
            _instance._currentState = State.Paused;
        }
        else if (_instance._currentState == State.Paused)
        {
            _instance._currentState = State.Running;
        }

        StateChanged.Invoke(_instance._currentState);
    }

    public static void ResumeGame()
    {
        _instance._currentState = State.Running;
        StateChanged.Invoke(_instance._currentState);
    }
}