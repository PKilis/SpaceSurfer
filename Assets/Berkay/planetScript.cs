using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetScript : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector3 go;
    private void Start()
    {
        go = new Vector3(-1, 0, 0);
    }
    void Update()
    {
        transform.position += go * speed * Time.deltaTime;
             
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            Time.timeScale = 0;
        }
    }
}
