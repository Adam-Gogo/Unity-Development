using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;

    
    public int jumpForce;

    private float horizontal;
    private float vertical;

    Rigidbody rb;

    public TMP_Text HealthCounter;
    public TMP_Text ScoreText;

    private int health = 3;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HealthCounter.text = "Health: " + health;
        ScoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (health == 0)
        {
            LoadScene("test scene");
        }
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position;

        position.x += speed * horizontal * Time.deltaTime;
        position.z += speed * vertical * Time.deltaTime;

        rb.MovePosition(position);
    }

    public void LoseHealth()
    {
        health--;
        HealthCounter.text = "Health: " + health;
    }

    public int getHealth()
    {
        return health;
    }

    public void GainHealth()
    {
        health++;
        HealthCounter.text = "Health: " + health;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScore(int s)
    {
        score += s;
        if(score < 0)
        {
            score = 0;
        }
        ScoreText.text = "Score: " + score;
    }
}
