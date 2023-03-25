using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public int lvl = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        gameObject.GetComponent<Button>().onClick.AddListener(()=>{
            GameManager.Instance.SelectedLevel = lvl;
            Debug.Log(lvl);
            GameManager.Instance?.StartupNewRace.Invoke();
            });    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
