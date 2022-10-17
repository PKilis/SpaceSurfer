using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarCreator : MonoBehaviour
{
    [SerializeField] private GameObject Bar;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Text feetText;
    [SerializeField] private int feetIndex;
    [SerializeField] private Text GameOverFeet;
    
    private void Start()
    {
        feetIndex = 1000;
        StartCoroutine(BarCreate());
        StartCoroutine(FeetCounter());
    }

    private void Update()
    {
        feetText.text = feetIndex.ToString() + " ft.";
        GameOverFeet.text = feetIndex.ToString() + " ft.";
    }
    IEnumerator FeetCounter()
    {
        while (true)
        {
            for (int i = 0; i < 9999999; i++)
            {
                yield return new WaitForSeconds(0.5f);
                feetIndex += 10 ;
            }
        }
        
       

    }
    IEnumerator BarCreate()
    {
        
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                yield return new WaitForSeconds(5);

                GameObject ftBar  = Instantiate(Bar);
                ftBar.transform.parent = gamePanel.transform;
                ftBar.transform.position = spawnPos.position;
              
            }
        }
        

    }

}
