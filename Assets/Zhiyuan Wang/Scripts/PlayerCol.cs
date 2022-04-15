using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerCol : MonoBehaviour
{
    public Text coinText;
    private int coinInt = 0;
    public GameObject win;
    public GameObject lose;

    private float timer = 0;
    public float titleTime = 60;
    private bool isWin = false;
    public Text timeText;

    public GameObject coins;

    public GameObject effect;

    public AudioSource buttonSource;
    void Start()
    {

    }

    void Update()
    {
        coinText.text = "Coin:" + coinInt;

        if (timer < titleTime && isWin == false)
        {
            timer += Time.deltaTime;
            int time = (int)(titleTime - timer);
            timeText.text = "CountDown:" + time;
            if (timer >= titleTime)
            {
                lose.SetActive(true);
                Destroy(coins);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp")
        {
            coinInt++;
            if (coinInt >= 10)
            {
                win.SetActive(true);
                isWin = true;
            }
            Destroy(other.gameObject);
            GameObject go = Instantiate(effect, other.transform.position, Quaternion.Euler(-90, 0, 0));
            Destroy(go, 2);
            GetComponent<AudioSource>().Play();
        }
    }

    public void InvokeScene()
    {
        Invoke("ChangeScene", 0.5f);
    }

    void ChangeScene()
    {
        buttonSource.Play();
        SceneManager.LoadScene("ZhiyuanWangScene");
    }
}
