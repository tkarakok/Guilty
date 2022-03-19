using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void StateAction();
    public StateAction MainMenu;
    public StateAction InGame; 

    public delegate void NewDefendat();
    public NewDefendat NextDefendat;

    private void Start() {
        MainMenu += SubscribeAllEvent;
        MainMenu();
    }

    void SubscribeAllEvent(){
        InGame += () => StateManager.Instance.State = State.InGame;
        InGame += DefendatsGenerateManager.Instance.StartTour;
        InGame += UIManager.Instance.ResetFilesPanel;

        
        NextDefendat += DefendatsGenerateManager.Instance.StartTour;
        NextDefendat += UIManager.Instance.ResetFilesPanel;
    }

}
