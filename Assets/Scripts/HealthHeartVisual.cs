using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartVisual : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;
    
    public Player Player;

    List<HealthHeart> hearts = new List<HealthHeart>();

    private void OnEnable()
    {
        Player.OnPlayerDamaged += DrawHearts;
    }

    private void OnDisable()
    {
        Player.OnPlayerDamaged -= DrawHearts;
    }

    private void Start()
    {
        DrawHearts();
    }

    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }

    public void DrawHearts()
    {
        ClearHearts();

        for (int i = 0; i < Player.maxHealth; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = Mathf.Clamp(Player.health - i, 0, 1);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }

    public void ClearHearts()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }

}
