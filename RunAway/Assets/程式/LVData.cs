using UnityEngine;

[CreateAssetMenu(fileName = "關卡資料", menuName = "RunAway/關卡資料")]
public class LVData : ScriptableObject
{
    public SpawnTime[] spawn;
}

[System.Serializable] //序列化:讓底下class顯示在屬性面板(class專用)
public class SpawnTime
{
    public string name = "時間";
    public float time;
    public SpawnMonster[] monsters;
}
[System.Serializable]
public class SpawnMonster
{
    public GameObject monster;
    public float x;
    public float y;
}