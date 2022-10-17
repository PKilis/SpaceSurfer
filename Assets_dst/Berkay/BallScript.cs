using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] GameObject Walls;
    [SerializeField] GameObject particalEffect;
    [SerializeField] Animator glassAnim;
    [SerializeField] Animator blackScreen;
    [SerializeField] GameObject game1;
    [SerializeField] GameObject game2;
    [SerializeField] player1script player;
    [SerializeField] GameObject generator;
    [SerializeField] GameObject object1, object2, object3;
    [SerializeField] Text GlassBreakCounter;
    [SerializeField] int glassBreakINT;
    
    
    public bool isGameStart;
    public GameObject cam;
    public bool isStart;
    public bool isFalseStart;

    private void Start()
    {
        glassBreakINT = 10;
        Application.targetFrameRate = 60;
        isGameStart = false;
        isFalseStart = false;
         isStart = false;
    }

    IEnumerator GlassBreak()
    {
        yield return new WaitForSeconds(9);
        player.isStartFly = true;
        yield return new WaitForSeconds(1);
        glassAnim.SetTrigger("Glass");
        GlassBreakCounter.gameObject.SetActive(false);
        StartCoroutine(Break());

    }
    IEnumerator Break()
    {
        
        particalEffect.SetActive(true);
        Walls.SetActive(false);
        object1.SetActive(true);
        object2.SetActive(true);
        object3.SetActive(true);
        player.rb.constraints = RigidbodyConstraints.FreezeRotation;
        yield return new WaitForSeconds(0.5f);
      isStart = true;
        yield return new WaitForSeconds(1f);
        isStart = false;
        
        player.rb.useGravity = enabled;
        generator.SetActive(true);
        player.speed = 1f;
        yield return new WaitForSeconds(2f);
        isFalseStart = true;
        //game1.SetActive(false);
        //game2.SetActive(true);

    }

    private void Update()
    {
        if (isStart)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(6.23f, 30.79f, 24.17f), Time.deltaTime * 2);
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(0, 34.57f, 0), 4 * Time.deltaTime);

            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(16.99f, 29.75f, 40.1f), Time.deltaTime * 2);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(0, 90f, 0), 4 * Time.deltaTime);
        }
    }


    public void StartGame()
    {
        
        isGameStart = true;
        StartCoroutine(glassBreakCount());
        StartCoroutine(GlassBreak());
    }

    public void TryAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    IEnumerator glassBreakCount()
    {
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                yield return new WaitForSeconds(1);
                glassBreakINT -= 1;
                GlassBreakCounter.text = glassBreakINT.ToString();

            }
        }
    }
}
