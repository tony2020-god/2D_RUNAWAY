using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject Target;
    [Header("滑入顏色覆蓋")]
    public Color colorMouseEnter = new Color(108 / 2295f, 79 / 255f, 255 / 255f);
    public SpriteRenderer spr;
    public GameObject AI;
    public Gamemanerger GM;
    public void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        AI = GameObject.Find("自動尋路系統");
        GM = GameObject.Find("遊戲管理器").GetComponent<Gamemanerger>();
    }
    public void PushTool()
    {
        transform.eulerAngles = new Vector3(180, 0, 0);
        transform.position = new Vector3(Target.transform.position.x,Target.transform.position.y,Target.transform.position.z);
    }


    public void OnMouseEnter()
    {
        if (GM.StartGame) spr.color = colorMouseEnter;
    }
    public void OnMouseExit()
    {
        spr.color = Color.white;
    }
    public void OnMouseDown()
    {
        if(GM.StartGame)
        {
            PushTool();
            Invoke("Scan", 0.1f);
        }
    }
    public void Scan()
    {
        AI.GetComponent<AstarPath>().Scan();
    }
}
