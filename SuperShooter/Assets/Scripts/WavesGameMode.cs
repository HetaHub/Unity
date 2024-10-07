using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this enabled the scene changing function.
using UnityEngine.SceneManagement;

public class WavesGameMode : MonoBehaviour
{
    [SerializeField] Life playerLife;
    [SerializeField] Life playerBaseLife;

    void OnPlayerLifeChanged()
    {
        if (playerLife.amount <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

    void OnPlayerBaseLifeChanged()
    {
        if (playerBaseLife.amount <= 0)
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerLife.onDeath.AddListener(OnPlayerLifeChanged);
        playerBaseLife.onDeath.AddListener(OnPlayerBaseLifeChanged);
        EnemiesManager.instance.onChanged.AddListener(CheckWinCondition);
        WavesManager.instance.onChanged.AddListener(CheckWinCondition);
    }

    // Update is called once per frame
    void CheckWinCondition()
    {
        if (WavesManager.instance._waves().Count <= 0 && EnemiesManager.instance._enemies().Count <= 0)
        {
            SceneManager.LoadScene("WinScreen");
        }

    }
}
