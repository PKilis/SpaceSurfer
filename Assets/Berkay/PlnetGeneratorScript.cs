using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlnetGeneratorScript : MonoBehaviour
{
    [SerializeField] private GameObject[] planets;
    [SerializeField] private GameObject fuel;
    private void Start()
    {
        StartCoroutine(Generator());
        StartCoroutine(FuelGenerator());
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

    IEnumerator FuelGenerator()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            Instantiate(fuel, new Vector3(41.23f, Random.Range(20f, 39f), 42.85f), transform.rotation);

        }
    }
}
