using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreOnDeath : MonoBehaviour
{
    public int amount;

    void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(GivePoints);
    }

    void OnDestroy()
    {
        var life = GetComponent<Life>();
        life.onDeath.RemoveListener(GivePoints);
    }
    void GivePoints()
    {
        if (this.enabled)
        {
            ScoreManager.instance.amount += amount;
        }
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
