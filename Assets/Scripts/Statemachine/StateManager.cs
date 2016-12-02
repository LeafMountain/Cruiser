using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

    IGameState currentState;

    static StateManager stateManager;

    public GameObject pauseMenu;

    void Awake()
    {
        if (stateManager == null)
        {
            stateManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            DestroyImmediate(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        currentState = new PlayState(this);
    }
	
	public void ChangeState(IGameState newState)
    {
        currentState = newState;
    }

    void Update()
    {
        currentState.StateUpdate();
    }
}
