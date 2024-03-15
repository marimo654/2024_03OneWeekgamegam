using nuuspace;
using UnityEngine;

public class TemperatureUpScript : BacteriaItemGetScript
{
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    protected override void OnDestroy()
    {
        gameManager.TemperatureIncrease();
    }
}
