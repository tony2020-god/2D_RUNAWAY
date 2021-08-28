using UnityEngine;

public class Player : MonoBehaviour
{
    public Gamemanerger GM;
    public Animator ani;
    public AudioSource aud;
    public Rigidbody2D rig;
    public int speed;

    public void Start()
    {
        speed = 3;
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        GM = GameObject.Find("遊戲管理器").GetComponent<Gamemanerger>();
        //aud = GetComponent<AudioSource>();
    }
    public void Move()
    {    
        //水平浮點數 = 輸入 的 取得軸向("水平")-左右AD Vertical
        float h = Input.GetAxis("Horizontal");
        print("h"+h);
        float V = Input.GetAxis("Vertical");
        print("h" + V);
        //剛體 的 加速度 = 新 二維向量(水平浮點數 * 速度, 剛體的加速度Y)
        rig.velocity = new Vector2(h * speed, V * speed);
        //動畫的設定布林值(參數名稱，水平 不等於零時勾選)
        //keycode 列單(下拉式選單) 所有輸入的選項:滑鼠、鍵盤、搖桿
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.W) == false) //往右
        {
            //此物件的變形元件
            //eulerAngles 歐拉角度
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.W) == false) //往左
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.A)==false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.S) == true && Input.GetKey(KeyCode.W) == false) //往下
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.W) == true) //往上
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }
    public void Update()
    {
        if(GM.win ==false && GM.lose==false && GM.StartGame==true) Move();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "終點")//碰到怪物物件玩家
        {
            if(GM.lose == false)
            {
                GM.win = true;
                GM.Win();
            }
        }
    }
}
