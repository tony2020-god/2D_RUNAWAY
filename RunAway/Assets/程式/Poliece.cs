using UnityEngine;

public class Poliece : MonoBehaviour
{
    public Gamemanerger GM;
    public GameObject Target;


    public void Start()
    {
        Target = GameObject.Find("玩家");
        GM = GameObject.Find("遊戲管理器").GetComponent<Gamemanerger>();
        gameObject.GetComponent<Pathfinding.AIDestinationSetter>().target = Target.transform;
    }
    public void Stop()
    {
        
        gameObject.GetComponent<Pathfinding.AIPath>().canMove = false;
        
    }

    public void FixedUpdate()
    {
        if (GM.win || GM.lose) Stop();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "玩家")//碰到怪物物件玩家
        {
            GM.lose = true;
            GM.Lose();
        }
    }
}

