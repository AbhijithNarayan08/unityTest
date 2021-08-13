

using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine.UI;
using UnityEngine;

public class CharController : MonoBehaviour
{
   public float speed = 10f;
   public GameObject player;
   public int score = 0;
   public Image fuelImage;

   public Text ScoreText ;

   public Text HiScoreTxt;

   int highscore = 0;

   public List<GameObject> Coins;

   public GameObject win;

   public GameObject loose;

   public GameObject gOscreen;


   void Start() 
   {
       HiScoreTxt.text = PlayerPrefs.GetInt("hiscore").ToString();
   }


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        if (Input.GetKey("w"))
        {
            pos.y += speed *Time.deltaTime;
            fuelImage.fillAmount -= 0.0001f;
        }
        if (Input.GetKey("s"))
        {
             pos.y -= speed *Time.deltaTime;
             fuelImage.fillAmount -=  0.0001f;
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed *Time.deltaTime;
            fuelImage.fillAmount -= 0.0001f;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed *Time.deltaTime;
            fuelImage.fillAmount -=  0.0001f;
        }
        player.transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("enemy"))
        {
            GameOver(false);
        }
        if(other.gameObject.CompareTag("coin"))
        {
            score++;
            ScoreText.text = score.ToString();
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("goal"))
        {
            GameOver(true);
        }


    }

    public void GameOver(bool hit)
    {
        if(PlayerPrefs.GetInt("hiscore")<score)
        {
            PlayerPrefs.SetInt("hiscore",score);
        }

        ShowGameOverScreen(hit);
        
    }

    void ShowGameOverScreen(bool hitgoal)
    {
        gOscreen.SetActive(true);
        win.SetActive(hitgoal);
        loose.SetActive(hitgoal);

    }
}
