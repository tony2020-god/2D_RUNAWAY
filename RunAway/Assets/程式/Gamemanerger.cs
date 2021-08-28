using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;//引用系統集合、管理API(協同程式:非同步處理)
public class Gamemanerger : MonoBehaviour
{
    public static Gamemanerger instance; //對戰管理實體物件
    public float StartTimer;
    public bool StartGame;
    public bool isCount;
    public bool win;
    public bool lose;
    public GameObject passscreen;
    public GameObject losescreen;
    public Text StartTimerText;
    public AudioClip trunsound;
    public AudioClip Countsound;
    public AudioClip gosound;
    public AudioSource aud;
    public AudioSource aud2;
    public GameObject gameView;
    public float imageCD = 0f;
    public static int LV = 1;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        StartTimer = 3f;
        aud = gameObject.GetComponent<AudioSource>();
    }
    public IEnumerator StartCountDown()
    {
        isCount = true;
        yield return new WaitForSeconds(1f);
        isCount = false;
        aud.PlayOneShot(trunsound, 1);
        while (StartTimer > 1)
        {
            aud2.PlayOneShot(Countsound, 0.5f);
            StartTimer -= 1;
            int timer = (int)StartTimer;
            StartTimerText.text = timer.ToString();
            isCount = true;
            yield return new WaitForSeconds(1f);
            isCount = false;
        }
            StartTimerText.text = "RUN!";
            aud2.PlayOneShot(gosound, 1);
            StartGame = true;
            yield return new WaitForSeconds(1f);
            StartTimerText.text = "";
    }
    public void Update()
    {
        if (StartGame == false)
        {
            if (isCount == false) StartCoroutine(StartCountDown());
        } 
    }
    public IEnumerator Endloadingimage()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        ao.allowSceneActivation = false;
        gameView.SetActive(true); //關閉遊戲載入畫面
        while (imageCD < 1)        //迴圈 while(布林值) "當布林值為 true 時執行敘述"
        {
            imageCD = imageCD + 0.01f;
            gameView.GetComponent<Image>().fillAmount = imageCD / 0.9f;                            //更新載入吧條
                                                                            //等待
            if (imageCD >= 0.9f)    //判斷式 if(布林值) "當布林值為true時執行一次"  
            {
                gameView.SetActive(false); //關閉遊戲載入畫面
                ao.allowSceneActivation = true;    //允許自動載入場景
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void Lose() //失敗:我方基地血量小於0，遊戲顯示失敗畫面
    {
       losescreen.SetActive(true);
    }
    public void Win() //過關:敵方基地血量小於0，遊戲顯示過關畫面
    {
        if(LV < 5)
        {
            LV += 1;
            print(LV);
            passscreen.SetActive(true);
        }
        else
        {
            StartCoroutine(Endloadingimage());
            Invoke("NextLV", 2);
        }

    }
    public void NextLV()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
