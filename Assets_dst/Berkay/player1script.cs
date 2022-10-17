using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1script : MonoBehaviour
{
    public float speed;
    [SerializeField] private Vector3 jump;
    public bool isStartFly;
    public Rigidbody rb;
    public Vector2 lastPosition;
    [SerializeField] private BallScript gm;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private Animator playerAnim;


    private void Start()
    {
        isStartFly = false;
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0,2f,0);
    }
    private void Update()
    {

        if (transform.position.y <= 13.44933f && gm.isFalseStart)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }

        
        var tapCount = Input.touchCount;
            for (var i = 0; i < tapCount; i++)
            {

                var tocSpeed = Input.GetTouch(0);

            if(gm.isGameStart)
            {
                if (isStartFly == false)
                {
                    if (tocSpeed.phase == TouchPhase.Began)
                    {
                        Debug.Log("Dokundu");
                        lastPosition = tocSpeed.position;

                    }

                    if (tocSpeed.phase == TouchPhase.Moved)
                    {
                        Debug.Log("Hareket");
                        var direction = tocSpeed.position - lastPosition;
                        rb.AddForce(speed * direction.x, speed * direction.y, 0);

                        lastPosition = tocSpeed.position;
                    }
                }
                else
                {
                    if(tocSpeed.phase == TouchPhase.Stationary)
                    {
                        rb.AddForce(jump * speed, ForceMode.Impulse);
                        playerAnim.SetBool("Fly",true);
                    }
                    else
                    {
                        playerAnim.SetBool("Fly", false);
                    }
                  
                }
             }

        }
        
       


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fuel")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Planet")
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }


}
