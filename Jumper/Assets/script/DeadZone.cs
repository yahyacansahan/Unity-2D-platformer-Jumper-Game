using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] PlatformGenerator platformGenerator;

    private void Start()
    {
        platformGenerator = GameObject.Find("PlatformGenerator").GetComponent<PlatformGenerator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Snake")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Strawberry")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Carrot")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Platform" || collision.tag == "Platform2")
        {
            Destroy(collision.gameObject);
            platformGenerator.PlatformSpawn();
        }
    }
}
