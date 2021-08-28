using UnityEngine;

public class RotationRoad : MonoBehaviour
{
    [Header("滑鼠進入的顏色")]
    public Color colorMouseEnter = new Color(108 / 2295f, 79 / 255f, 255 / 255f);
    public SpriteRenderer spr;
    public GameObject AI;
    public Gamemanerger GM;
    public bool trun;
    public void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        AI = GameObject.Find("自動尋路系統");
        GM = GameObject.Find("遊戲管理器").GetComponent<Gamemanerger>();
    }
    public void TrunRoad()
    {
        if(trun == false)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            trun = true;
        }
        else if(trun == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            trun = false;
        }
    }

    public void OnMouseEnter()
    {
        spr.color = colorMouseEnter;
    }
    public void OnMouseExit()
    {
        spr.color = Color.white;
    }
    public void OnMouseDown()
    {
        if (GM.StartGame)
        {
            TrunRoad();
            Invoke("Scan", 0.1f);
        }
    }
    public void Scan()
    {
        AI.GetComponent<AstarPath>().Scan();
    }
}
