using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] GameObject Strawberry, Carrot, Snake, Strawberrys, Carrots, Snakes;
    public bool SnakeSpawned, StrawberrySpawned, CarrotSpawned;
    int RandomSans;

    private void Start()
    {
        Strawberrys = GameObject.Find("Strawberrys");
        Carrots = GameObject.Find("Carrots");
        Snakes = GameObject.Find("Snakes");
    }
    public void CarrotSpawn(Vector3 position)
    {
        position = new Vector3(Random.Range(position.x - 0.3f, position.x + 0.3f), position.y + 0.5f, 0);

        RandomSans = Random.Range(0, 100);
        if (RandomSans < 30)
        {
            var carrot = Instantiate(Carrot, position, Quaternion.identity);
            carrot.transform.SetParent(Carrots.transform, false);
            CarrotSpawned = true;
        }
    }
    public void SnakeSpawn(Vector3 position)
    {
        position = new Vector3(Random.Range(position.x - 0.3f, position.x + 0.3f), position.y + 0.5f, 0);

        RandomSans = Random.Range(0, 100);
        if (RandomSans < 50)
        {
            var snake = Instantiate(Snake, position, Quaternion.identity);
            snake.transform.SetParent(Snakes.transform, false);
            SnakeSpawned = true;
        }
    }
    public void StrawberrySpawn(Vector3 position)
    {
        position = new Vector3(Random.Range(position.x - 0.3f, position.x + 0.3f), position.y + 0.5f, 0);

        RandomSans = Random.Range(0, 100);
        if (RandomSans < 20)
        {
            var strawberry = Instantiate(Strawberry, position, Quaternion.identity);
            strawberry.transform.SetParent(Strawberrys.transform, false);
            StrawberrySpawned = true;
        }
    }
}
