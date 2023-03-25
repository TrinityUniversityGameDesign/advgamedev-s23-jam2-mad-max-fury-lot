using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GmCom : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject UpgradeMenu;
    public GameObject PauseMenu;
    public GameObject MainButton;
    public GameObject UpgradeButton;
    
    // Start is called before the first frame update
    // void Start()
    // {
    //     Instantiate(MainMenu);
    //     Instantiate(UpgradeMenu);
    //     Instantiate(PauseMenu);
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void GetStartMainMenu(){
        GameManager.Instance?.OnStateEnter(GameState.StartScreen);
        // MainMenu.setActive(true);
        // UpgradeMenu.setActive(false);
        // PauseMenu.setActive(false);
    }

    public void GetUpgradeMenu(){
        GameManager.Instance?.OnStateEnter(GameState.Upgrade);
        // MainMenu.setActive(false);
        // UpgradeMenu.setActive(true);
        // PauseMenu.setActive(false);
    }

    public void GetPauseMenu(){
        GameManager.Instance?.OnStateEnter(GameState.Paused);
        // MainMenu.setActive(false);
        // UpgradeMenu.setActive(false);
        // PauseMenu.setActive(true);
    }
}
