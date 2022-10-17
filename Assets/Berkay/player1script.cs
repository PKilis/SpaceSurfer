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
    public float fuel;
    [SerializeField] private BallScript gm;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private GameObject fireEfekt;

    public Joystick joy;

    private void Start()
    {
        
        isStartFly = false;
        rb = gameObject.GetComponent<Rigidbody>();
        jump = new Vector3(0,2f,0);
    }

    public IEnumerator fuelDecrase()
    {
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                yield return new WaitForSeconds(1);
                fuel -= 2.4f;
            }
        }
        
    }
    private void Update()
    {

        if(fuel >= 100)
        {
            fuel = 100;
        }
        else if(fuel <= 0)
        {
            fuel = 0;
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
        }
        if (transform.position.y <= 13.44933f && gm.isFalseStart)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            
        }
        


        //float x = Input.GetAxisRaw("Horizontal");
        //float y = Input.GetAxisRaw("Vertical");
        //gameObject.transform.Translate(new Vector3(x, y, 0) * speed * Time.deltaTime);
        //rb.constraints = RigidbodyConstraints.FreezeRotation;

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
                        fireEfekt.SetActive(true);


                    }

                    if (tocSpeed.phase == TouchPhase.Moved)
                    {
                        Debug.Log("Hareket");
                        var direction = tocSpeed.position - lastPosition;
                        rb.AddForce(speed * direction.x + joy.result.x, speed * direction.y + joy.result.y, 0);

                        lastPosition = tocSpeed.position;
                    }
                    else if (tocSpeed.phase == TouchPhase.Canceled)
                    {
                        fireEfekt.SetActive(false);
                    }
                }
                else
                {
                    if(tocSpeed.phase == TouchPhase.Stationary)
                    {
                        
                        rb.AddForce(jump * speed, ForceMode.Impulse);

                    }
                  
                }
             }

        }
        
       


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fuel")
        {
            fuel += 12.5f;

            Destroy(other.gameObject);
        }
        if(other.tag == "Planet")
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0;

            if(PlayerPrefs.GetInt("playerMoneyIndex") == 0)
            {
                gm.money += 100;
                PlayerPrefs.SetInt("money", gm.money);
            }
            else
            {
                gm.money += 400;
                PlayerPrefs.SetInt("money", gm.money);
            }

           
        }
    }
}
