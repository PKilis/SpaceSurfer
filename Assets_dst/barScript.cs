using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private void Start()
    {
        StartCoroutine(Destroy());
    }
    void Update()
    {
        transform.position += new Vector3(1 * speed * Time.deltaTime,0,0);
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
