using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    [SerializeField] ItemGenerator itemGenerator;
    [SerializeField] GameObject PlatformGO, Platform2GO;
    [SerializeField] Scoreboard scoreboard;
    GameObject Platforms;
    float increase, Platform2Chance, LevelminX = -2.5f, LevelmaxX = 2.5f;
    int Score, Rounded;
    public Vector3 PlatformPosition;

    void Start()
    {
        itemGenerator = GetComponent<ItemGenerator>();
        scoreboard = GameObject.Find("Player").GetComponent<Scoreboard>();
        Platforms = GameObject.Find("Platforms");

        for (int i = 0; i < 9; i++)
        {
            PlatformPosition = new Vector3(Random.Range(LevelminX, LevelmaxX), PlatformPosition.y + 1.5f + increase, 0);
            var platform = Instantiate(PlatformGO, PlatformPosition, Quaternion.identity);
            platform.transform.SetParent(Platforms.transform, false);
        }
        Platform2Chance = 0;
    }

    public void PlatformSpawn()
    {
        Score = Mathf.RoundToInt(scoreboard.score);
        Rounded = Mathf.FloorToInt(Score / 100);

        if (Rounded <= 9 && Rounded != 0)
        {
            increase = 0.25f * Rounded;
            Platform2Chance = 0.4f * Rounded;
        }
        else if (Score > 1000)
        {
            increase = 2.5f;
            Platform2Chance = 5;
        }

        PlatformPosition = new Vector3(Random.Range(LevelminX, LevelmaxX), PlatformPosition.y + 1.5f + increase, 0);

        if (Random.Range(0, 100) < (5 * Platform2Chance))
        {
            var platform = Instantiate(Platform2GO, PlatformPosition, Quaternion.identity);
            platform.transform.SetParent(Platforms.transform, false);
        }
        else
        {
            var platform = Instantiate(PlatformGO, PlatformPosition, Quaternion.identity);
            platform.transform.SetParent(Platforms.transform, false);
        }

        itemGenerator.CarrotSpawn(PlatformPosition);

        if (!itemGenerator.CarrotSpawned && !itemGenerator.StrawberrySpawned)
        {
            itemGenerator.StrawberrySpawn(PlatformPosition);
        }
        else if (!itemGenerator.CarrotSpawned && !itemGenerator.StrawberrySpawned && !itemGenerator.SnakeSpawned)
        {
            itemGenerator.SnakeSpawn(PlatformPosition);

        }

        itemGenerator.CarrotSpawned = false;
        itemGenerator.StrawberrySpawned = false;
        itemGenerator.SnakeSpawned = false;
    }
}
