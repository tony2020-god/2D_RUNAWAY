using UnityEngine;

public class Car : MonoBehaviour
{
    public Gamemanerger GM;
    public Animator ani;
    public AudioSource aud;
    public AudioClip crash;
    public Rigidbody2D rig;
    public int speed;
    public bool stop;
    public void Start()
    {
        speed = 4;
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        GM = GameObject.Find("遊戲管理器").GetComponent<Gamemanerger>();
        aud = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "玩家")//碰到怪物物件玩家
        {
            if (GM.lose == false)
            {
                aud.PlayOneShot(crash, 1);
                stop = true;
                GM.lose = true;
                GM.Lose();
            }
        }
        else if (other.gameObject.tag == "警察") stop = true;
        else if (other.gameObject.tag == "損毀點") Destroy(gameObject);
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "警察") stop = false;
    }
    public void Update()
    {
        MoveMethod();
    }
    private void MoveMethod()
    {
            if (stop == false)
            {
              if(gameObject.tag == "up")   transform.Translate(0, speed * Time.deltaTime, 0, Space.World);
              if (gameObject.tag == "down") transform.Translate(0, -speed * Time.deltaTime, 0, Space.World);
            }
    }
}
