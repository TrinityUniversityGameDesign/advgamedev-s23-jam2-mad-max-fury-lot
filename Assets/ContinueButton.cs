using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=>{GameManager.Instance?.StartupNewRace.Invoke();});    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
