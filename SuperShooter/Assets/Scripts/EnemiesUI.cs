using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesUI : MonoBehaviour
{
    TMPro.TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Remaining Enemies: " + EnemiesManager.instance._enemies().Count;
    }
}
