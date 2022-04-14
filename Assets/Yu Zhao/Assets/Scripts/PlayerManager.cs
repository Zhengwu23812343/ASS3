using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public int scoreNum;
    public Text scoreText;
    public Text scoreTextOver;
    public float timer;
    public Text timerText;

    public GameObject[] OverGame;

    public GameObject Effect;

    public int tarGetScore = 10;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public IEnumerator showEffect() {
        Effect.SetActive(true);
        yield return new WaitForSeconds(2f);
        Effect.SetActive(false);
        yield break;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) {

           
            timer = 0;
            timerText.text = "Time :" + timer.ToString("f2");
            scoreTextOver.gameObject.SetActive(true);
            if (scoreNum >= tarGetScore)
            {
                OverGame[0].SetActive(true);
                scoreTextOver.text = "Score :" + scoreNum.ToString();
            }
            else {
                OverGame[1].SetActive(true);
                scoreTextOver.text = "Score :" + scoreNum.ToString();
            }


            Time.timeScale = 0;
        }

        timerText.text = "Time :" + timer.ToString("f2");
        scoreText.text = "Score :" + scoreNum.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Item") {
            scoreNum++;
            audio.Play();
            Destroy(collision.gameObject);
            StartCoroutine(showEffect());
        }
    }

    public void OnControllerColliderHit(ControllerColliderHit hit) 
    { 
         if (hit.gameObject.tag == "Item") {
            scoreNum++;
            audio.Play();
            Destroy(hit.gameObject);
    StartCoroutine(showEffect());
}
    }
}
