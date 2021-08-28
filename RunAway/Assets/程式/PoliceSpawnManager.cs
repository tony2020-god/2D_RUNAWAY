using UnityEngine;
using System.Collections;

public class PoliceSpawnManager : MonoBehaviour
{
    [Header("生成資料")]
    public LVData data;
    public bool isspawn = false;
    private Gamemanerger Gm;
    private void Start()
    {
        Gm = FindObjectOfType<Gamemanerger>();
    }

    private void Update()
    {
        if (Gm.StartGame && isspawn == false)
        {
            isspawn = true;
            StartCoroutine(StartSpawn());
        }
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < data.spawn.Length; i++)
        {
            yield return new WaitForSeconds(data.spawn[i].time);
            for (int j = 0; j < data.spawn[i].monsters.Length; j++)
            {
                Vector3 pos = new Vector3(data.spawn[i].monsters[j].x, data.spawn[i].monsters[j].y, 0); //座標
                GameObject temp = Instantiate(data.spawn[i].monsters[j].monster, pos, data.spawn[i].monsters[j].monster.transform.rotation); //生成
            }
        }
    }
}