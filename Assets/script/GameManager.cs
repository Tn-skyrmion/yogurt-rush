using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    public List<GameObject> players = new List<GameObject>();
    public int activeIndex = 0;

    void Start()
    {
        SpawnPlayer();
    }

    void Update()
    {
        // K 分身 / 切换控制
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (players.Count == 1)
            {
                Split();
            }
            else
            {
                activeIndex = (activeIndex + 1) % players.Count;
            }
        }

        // 自动合体
        if (players.Count == 2)
        {
            var a = players[0];
            var b = players[1];
            if (Vector2.Distance(a.transform.position, b.transform.position) < 0.8f)
            {
                Merge();
            }
        }

        // 控制切换
        for (int i = 0; i < players.Count; i++)
        {
            var pc = players[i].GetComponent<PlayerController>();
            if (i == activeIndex)
                pc.enabled = true;
            else
                pc.enabled = false;
        }
    }

    void SpawnPlayer()
    {
        var p = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        players.Add(p);
    }

    void Split()
    {
        var p = players[0];
        Vector3 pos = p.transform.position;

        Destroy(p);

        players.Clear();

        var p1 = Instantiate(playerPrefab, pos + Vector3.left * 0.5f, Quaternion.identity);
        var p2 = Instantiate(playerPrefab, pos + Vector3.right * 0.5f, Quaternion.identity);

        p1.GetComponent<PlayerController>().SetState("split");
        p2.GetComponent<PlayerController>().SetState("split");

        players.Add(p1);
        players.Add(p2);

        activeIndex = 0;
    }

    void Merge()
    {
        var a = players[0];
        var b = players[1];
        Vector3 pos = (a.transform.position + b.transform.position) / 2;

        Destroy(a);
        Destroy(b);

        players.Clear();

        var p = Instantiate(playerPrefab, pos, Quaternion.identity);
        players.Add(p);
        activeIndex = 0;
    }
}
