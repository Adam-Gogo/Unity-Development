using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;

    public int jumpForce;

    private float horizontal;
    private float vertical;

    public Rigidbody rb;

    public TMP_Text ScoreText;

    private int health = 3;
    private int score = 0;

    public Image mask;
    private float originalSize;

    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ScoreText.text = "Score: " + score;
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            grounded = false;
        }

        if (health <= 0)
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

    public void LoseHealth(int damage)
    {
        health -= damage;
        editMask(health/3.0f);
    }

    public int getHealth()
    {
        return health;
    }

    public void GainHealth()
    {
        health++;
        editMask(health/3.0f);
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

    public void editMask(float f)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
