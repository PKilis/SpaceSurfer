using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlnetGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    private void Start()
    {
        StartCoroutine(Generator());
    }


    IEnumerator Generator()
    {
        while (true)
        {
            for (int i = 0; i < planets.Length; i++)
            {
                int spawnIndex = Random.Range(0,planets.Length);
                yield return new WaitForSeconds(3);
                Instantiate(planets[spawnIndex], new Vector3(41.23f,Random.Range(20f, 39f),40.46f), transform.rotation);
            }
        }
        
    }
}
