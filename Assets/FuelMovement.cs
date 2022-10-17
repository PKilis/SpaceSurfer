using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelMovement : MonoBehaviour
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
}
