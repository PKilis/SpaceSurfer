using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class fuelbarscript : MonoBehaviour
{
    [SerializeField] private Image fuelBar;
    public float currentFuel;
    private float maxFuel = 100f;
    player1script player;

    void Start()
    {
        fuelBar = GetComponent<Image>();
        player = FindObjectOfType<player1script>();
    }

    
    void Update()
    {
        currentFuel = player.fuel;
        fuelBar.fillAmount = currentFuel / maxFuel;
    }
}
