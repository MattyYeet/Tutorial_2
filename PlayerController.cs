using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator anim;
    SpriteRenderer sprites;
    public GameObject wall;
    public GameObject floor;
    public GameObject enemies;
    public GameObject coins;

    private Rigidbody2D rd2d;

    public float speed;
    private float hozMovement;
    private float vertMovement;

    public Text score;
    public Text lives;
    public Text end;

    private int scoreValue = 0;
    private int livesValue = 3;

    public bool win = false;

    public AudioClip winMusic;
    public AudioClip loopMusic;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprites = GetComponent<SpriteRenderer>();
        anim.SetInteger("State", 0);
        rd2d = GetComponent<Rigidbody2D>();
        score.text = "Coins: " + scoreValue.ToString();
        lives.text = "Lives: " + livesValue.ToString();
        end.text = "";

        musicSource.clip = loopMusic;
        musicSource.Play();
        musicSource.loop = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hozMovement = Input.GetAxisRaw("Horizontal");
        vertMovement = Input.GetAxis("Vertical");
        Animations();
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = "Coins: " + scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            if(scoreValue == 1){
                this.transform.position = new Vector3(67.67f, -0.74f, 0.0f);
                livesValue = 3;
                lives.text = "Lives: " + livesValue.ToString();
            }
            Win(win);
        }
        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            lives.text = "Lives: " + livesValue.ToString();
            Destroy(collision.collider.gameObject);
            if(livesValue == 0){
                end.text = "Better Luck Next Time!\nYour score was " + scoreValue.ToString() +"\nThis was made by Matthew Neet";
                score.text = "";
                lives.text = "";
                wall.SetActive(false);
                floor.SetActive(false);
                coins.SetActive(false);
                enemies.SetActive(false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(hozMovement, 3), ForceMode2D.Impulse);
            }
        }
    }

    private void Animations()
    {
        if(hozMovement == 0)
        {
            anim.SetInteger("State", 0);
        }
        if(hozMovement > 0)
        {
            anim.SetInteger("State", 2);
            sprites.flipX = false;
        }
        if(hozMovement < 0)
        {
            anim.SetInteger("State", 2);
            sprites.flipX = true;
        }
        if(livesValue == 0)
        {
            anim.SetInteger("State", 3);
        }
    }

    private void Win(bool win)
    {
        win = true;
        if(win == true)
        {
            if(scoreValue == 2)
            {
                musicSource.Stop();
                end.text = "Nice, You Win!"+"\nThis was made by Matthew Neet";
                score.text = "";
                lives.text = "";
                musicSource.clip = winMusic;
                musicSource.Play();
                musicSource.loop = true;
                wall.SetActive(false);
                floor.SetActive(false);
                coins.SetActive(false);
                enemies.SetActive(false);
                
            }
        }
    }
}