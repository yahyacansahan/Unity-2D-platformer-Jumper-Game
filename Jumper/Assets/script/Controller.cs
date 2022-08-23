using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class Controller : MonoBehaviour
{
    float movement = 0f, Score = 0.0f, HeightScore = 0.0f, forceJump = 10.0f;
    [SerializeField] int movementSpeed = 35;
    [SerializeField] PlatformGenerator platformGenerator;
    [SerializeField] Scoreboard scoreboard;
    [SerializeField] Text ScoreText;
    [SerializeField] GameObject DeathScene;
    [SerializeField] Rigidbody2D PlayerRigid;


    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        scoreboard = GetComponent<Scoreboard>();
        platformGenerator = GameObject.Find("PlatformGenerator").GetComponent<PlatformGenerator>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = PlayerRigid.velocity;
        velocity.x = movement;
        PlayerRigid.velocity = velocity;

        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        float offset = 0.45f;

        if (Input.GetMouseButton(0))
        {
            Debug.Log("" + Input.mousePosition.x);
            if (Input.mousePosition.x < (Screen.width / 2))
            {
                Debug.Log("sol" + Input.mousePosition.x);
                PlayerRigid.AddForce(new Vector2(-35 * movementSpeed, 0f));
            }
            else
            {
                Debug.Log("sag" + Input.mousePosition.x);
                PlayerRigid.AddForce(new Vector2(35 * movementSpeed, 0f));
            }
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x < (Screen.width / 2))
            {
                PlayerRigid.AddForce(new Vector2(-35 * movementSpeed, 0f));
            }
            else
            {
                PlayerRigid.AddForce(new Vector2(35 * movementSpeed, 0f));
            }
        }
        if (transform.position.x > -topLeft.x + offset)
        {
            transform.position = new Vector3(topLeft.x - offset, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < topLeft.x - offset)
        {
            transform.position = new Vector3(-topLeft.x + offset, transform.position.y, transform.position.z);
        }
    }


    void Update()
    {
        if (PlayerRigid.velocity.y > 0 && transform.position.y > HeightScore)
        {
            HeightScore = transform.position.y;
        }
        scoreboard.score = Score + HeightScore;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerRigid.velocity.y < 0.1)
        {
            PlayerRigid.velocity = Vector2.up * forceJump;
            if (collision.gameObject.tag == "Platform2")
            {
                Destroy(collision.gameObject);
                platformGenerator.PlatformSpawn();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Carrot"))
        {
            Score += 20;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Snake"))
        {
            DeathScene.SetActive(true);
            Time.timeScale = 0f;
        }

        if (collision.gameObject.CompareTag("Strawberry"))
        {
            PlayerRigid.velocity = Vector2.up * 20;
            Destroy(collision.gameObject);
        }

        if (collision.tag == "dead")
        {
            DeathScene.SetActive(true);
            ScoreText = GameObject.Find("DeathScene").GetComponentInChildren<Text>();
            ScoreText.text = "Score : " + Mathf.Round(scoreboard.score).ToString();
            Time.timeScale = 0f;
        }
    }
}
