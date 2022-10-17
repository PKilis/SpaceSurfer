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
    public AudioSource music_BG, rocketEfect, glassBreakSound;
    public bool isGameStart;
    public GameObject cam;
    public bool isStart;
    public bool isFalseStart;
    [SerializeField] Text glassBreakCounter;
    [SerializeField] int glassbreakIndex;

    public int playerSpeedDrag;
    public int playerFuel;

    public int playerSpeedDragIndex;
    public int playerFuelIndex;
    public int playerMoneyIndex;

    public GameObject speedUpButton;
    public GameObject fuelUpButton;
    public GameObject moneyButton;
    public GameObject JoystickImage;
    public int money;
    public Text moneyText;

    private void Start()
    {
        money = PlayerPrefs.GetInt("money");
        glassbreakIndex = 10;
        Application.targetFrameRate = 60;
        isGameStart = false;
        isFalseStart = false;
         isStart = false;
        playerSpeedDragIndex = PlayerPrefs.GetInt("playerSpeed");
        playerFuelIndex = PlayerPrefs.GetInt("playerFuel");
        playerMoneyIndex = PlayerPrefs.GetInt("playerMoneyIndex");
        PlayerStats();
    }

     void PlayerStats()
    {
        //playerSpeed
        if(playerSpeedDragIndex == 0)
        {
            playerSpeedDrag = 3;
            speedUpButton.SetActive(true);
        }
        else
        {
            playerSpeedDrag = 2;
            speedUpButton.SetActive(false);
        }
        player.rb.drag = playerSpeedDrag;

        //FuelUp

        if(playerSpeedDragIndex == 0)
        {
            playerFuel = 50;
            fuelUpButton.SetActive(true);
        }
        else
        {
            playerFuel = 75;
            fuelUpButton.SetActive(false);
        }
         player.fuel = playerFuel;

        //IncomeUp
    }

    IEnumerator GlassBreak()
    {
        yield return new WaitForSeconds(9);
        player.isStartFly = true;
        yield return new WaitForSeconds(1);
        glassAnim.SetTrigger("Glass");
        glassBreakCounter.gameObject.SetActive(false);
        StartCoroutine(Break());
        JoystickImage.SetActive(false);

    }
    IEnumerator Break()
    {
        
        particalEffect.SetActive(true);
        Walls.SetActive(false);
        object1.SetActive(true);
        object2.SetActive(true);
        object3.SetActive(true);
        player.rb.constraints = RigidbodyConstraints.FreezeRotation;
        glassBreakSound.Play();

        yield return new WaitForSeconds(0.5f);
      isStart = true;
        yield return new WaitForSeconds(1f);
        isStart = false;
        
        player.rb.useGravity = enabled;
        generator.SetActive(true);
        player.speed = 1f;
        yield return new WaitForSeconds(2f);
        isFalseStart = true;
        StartCoroutine(player.fuelDecrase());
        //game1.SetActive(false);
        //game2.SetActive(true);

    }

    private void Update()
    {

        moneyText.text = PlayerPrefs.GetInt("money").ToString();

        if (isStart)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(6.23f, 30.79f, 24.17f), Time.deltaTime * 2);
            cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, Quaternion.Euler(0, 34.57f, 0), 4 * Time.deltaTime);

            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(16.99f, 29.75f, 40.1f), Time.deltaTime * 2);
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.Euler(0, 90f, 0), 4 * Time.deltaTime);
        }

        if(playerSpeedDragIndex == 0)
        {
            speedUpButton.SetActive(true);
        }
        else
        {
            speedUpButton.SetActive(false);
        }

        if (playerFuelIndex == 0)
        {
            fuelUpButton.SetActive(true);
        }
        else
        {
            //fuelUpButton.SetActive(false);
        }

        if (playerMoneyIndex == 0)
        {
            moneyButton.SetActive(true);
        }
        else
        {
            moneyButton.SetActive(false);
        }
    }


    public void StartGame()
    {
        isGameStart = true;
        StartCoroutine(glassBreakCount());
        StartCoroutine(GlassBreak());
        JoystickImage.SetActive(true);
    }
    IEnumerator glassBreakCount()
    {
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                yield return new WaitForSeconds(1);
                glassbreakIndex -= 1;
                glassBreakCounter.text = glassbreakIndex.ToString();
            }
        }
    }

    public void TryAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }




    public void SpeedUp()
    {
        if(PlayerPrefs.GetInt("money") >= 500)
        {
            playerSpeedDragIndex = 1;
            PlayerPrefs.SetInt("playerSpeed", playerSpeedDragIndex);
            money -= 500;
            PlayerPrefs.SetInt("money", money);
        }
       
    }
    public void FuelUp()
    {
        if(PlayerPrefs.GetInt("money") >= 500)
        {
            playerFuelIndex = 1;
            PlayerPrefs.SetInt("playerFuel", playerFuelIndex);
            money -= 500;
            PlayerPrefs.SetInt("money", money);
        }

       
    }
    public void IncomeUp()
    {
        if(PlayerPrefs.GetInt("money") >= 500)
        {
            playerMoneyIndex = 1;
            PlayerPrefs.SetInt("playerMoneyIndex", playerMoneyIndex);
            money -= 500;
            PlayerPrefs.SetInt("money", money);
        }
        
    }

}
