using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    [SerializeField]
    private int speed;

    public int jumpHeight;

    private CharacterController controller;
    private PlayerInput input;
    private Vector3 velocity;

    private bool grounded;

    public float gravityValue = -9.81f;

    public TMP_Text ScoreText;

    private int health = 3;
    private int score = 0;

    public Image mask;
    private float originalSize;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
        ScoreText.text = "Score: " + score;
        originalSize = mask.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
        if (grounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        Vector2 inputMove = input.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(inputMove.x, 0, inputMove.y);
        controller.Move(move * Time.deltaTime * speed);

        if (input.actions["Jump"].triggered && grounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (health <= 0)
        {
            LoadScene("test scene");
        }
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

}
