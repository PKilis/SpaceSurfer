using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public GameObject cam;
    [SerializeField] private bool isStart;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject Kure;
    [SerializeField] private float speed;
    public Vector3 jump;
    private Rigidbody rb;
    

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
        //anim.SetBool("Start",true);
        
    }


    private void Update()
    {
        if(isStart)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(6.23f, 30.79f, 24.17f), Time.deltaTime * 2);
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(0, 34f, 0), 4 * Time.deltaTime);
        }



        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(jump * speed,ForceMode.Impulse);
            anim.SetBool("Fly",true);
        }
        else
            anim.SetBool("Fly", false);


        
    }

    public void CameraOnStart()
    {
        isStart = true;
    }
    public void CameraOnStop()
    {
        anim.SetBool("Start", false);
        //anim.enabled = false;
        Kure.SetActive(false);
        StartCoroutine(GravityOn());
    }
    IEnumerator GravityOn()
    {
        yield return new WaitForSeconds(0.8f);
        //rb.useGravity = true;

    }
}
