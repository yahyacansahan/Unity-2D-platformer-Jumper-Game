using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public ItemGenerator itemGenerator;
    public GameObject PlatformGO;
    Scoreboard scoreboard;
    public float increase;
    public int Score, Rounded;

    private void Start()
    {
        itemGenerator = GetComponent<ItemGenerator>();
        scoreboard = GetComponent<Scoreboard>();
        PlatformGO = GetComponent<GameObject>();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "dead")
        {
            Score = Mathf.RoundToInt(scoreboard.score);
            if (Score % 50 == 0 && Score <= 500)
            {
                Rounded = Mathf.FloorToInt(Score / 50);
                increase += 0.1f * Rounded;
            }
            else if (Score > 500)
            {
                increase = 1.0f;
            }



            Instantiate(PlatformGO, PlatformGO.transform.position, Quaternion.identity);



            itemGenerator.CarrotSpawn(transform.position);

            if (!itemGenerator.CarrotSpawned && !itemGenerator.StrawberrySpawned)
            {
                itemGenerator.StrawberrySpawn(transform.position);
            }
            else if (!itemGenerator.CarrotSpawned && !itemGenerator.StrawberrySpawned && !itemGenerator.SnakeSpawned)
            {
                itemGenerator.SnakeSpawn(transform.position);

            }

            itemGenerator.CarrotSpawned = false;
            itemGenerator.StrawberrySpawned = false;
            itemGenerator.SnakeSpawned = false;
        }
    }

}
