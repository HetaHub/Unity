using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    Button button;
    
    void Awake(){
        button = GetComponent<Button>();
        button.onClick.AddListener(Quit);
    }

    void Quit(){
        print("Quitting");
        Application.Quit();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
