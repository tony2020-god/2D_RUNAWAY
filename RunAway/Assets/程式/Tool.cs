using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject Target;
    [Header("滑入顏色覆蓋")]
    public Color colorMouseEnter = new Color(207 / 255f, 87 / 255f, 93 / 255f);
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

    /// <summary>
    /// 滑鼠滑入的效果
    /// </summary>
    public void MouseEnterEffect()
    {
        spr.color = colorMouseEnter;
    }
    /// <summary>
    /// 滑鼠滑出的效果
    /// </summary>
    public void MouseExitEffect()
    {
        spr.color = Color.white;
    }
    public void OnMouseEnter()
    {
        if (GM.StartGame) MouseEnterEffect();
    }
    public void OnMouseExit()
    {
        MouseExitEffect();
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
