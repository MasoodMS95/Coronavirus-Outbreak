using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrivePlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float maxSpeed = 40.0f;
    private float turnSpeed = 55.0f;
    public bool isTouchingObstacle;
    private DriveGameManager gameManager;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Health", 100);
        gameManager = GameObject.Find("DriveGameManager").GetComponent<DriveGameManager>();
        gameController = GameObject.Find("GameManager").GetComponent<GameController>();
        gameManager.setSpeed(0f);
        maxSpeed = 40.0f;
        isTouchingObstacle = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Gas is on.  Move forwards
        if (verticalInput > 0)
        {
            if (gameManager.getSpeed() < maxSpeed)
            {
                if (gameManager.getSpeed() < 0)
                {
                    gameManager.incrementSpeed(2);
                }
                gameManager.incrementSpeed(0.6f);
            }
            
            else
            {
                gameManager.setSpeed(maxSpeed);
            }
        }
        // Reverse is on.  Move backwards
        else if (verticalInput < 0)
        {
            if (gameManager.getSpeed() > -maxSpeed)
            {
                if (gameManager.getSpeed() > 0)
                {
                    gameManager.decrementSpeed(2);
                }
                gameManager.decrementSpeed(0.6f);
            }
            if (gameManager.getSpeed() < -maxSpeed)
            {
                gameManager.setSpeed(-maxSpeed);
            }
        }
        // Car is not getting gas.  Slow down
        else if (verticalInput == 0)
        {
            // Car is moving forwards
            if (gameManager.getSpeed() > 0)
            {
                gameManager.decrementSpeed(1.0f);
                
                if (gameManager.getSpeed() < 0)
                {
                    gameManager.setSpeed(0);
                }
            }
            // Car is moving backwards
            else if (gameManager.getSpeed() < 0)
            {
                gameManager.incrementSpeed(1.0f);

                if (gameManager.getSpeed() > 0)
                {
                    gameManager.setSpeed(0);
                }
            }
            
        }

        transform.Translate(Vector3.forward * gameManager.getSpeed() * Time.deltaTime);

        if (gameManager.getSpeed() > 0)
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * horizontalInput);
        }
        else if (gameManager.getSpeed() < 0)
        {
            transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime * -horizontalInput);
        }

        if (isTouchingObstacle)
        {
            if (gameManager.getSpeed() > 0)
            {
                gameManager.decrementSpeed(1.5f);
                if (gameManager.getSpeed() < 0)
                {
                    gameManager.setSpeed(0);
                }
            }
            if (gameManager.getSpeed() < 0)
            {
                gameManager.incrementSpeed(1.5f);
                if (gameManager.getSpeed() > 0)
                {
                    gameManager.setSpeed(0);
                }
            }
        }
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isTouchingObstacle = true;
            if(gameManager.getSpeed() >= 40)
            {
                PlayerPrefs.SetFloat("Health", PlayerPrefs.GetFloat("Health") - 2f);
                if (PlayerPrefs.GetFloat("Health") < 0)
                {
                    PlayerPrefs.SetFloat("Health", 0);
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isTouchingObstacle = false;
        }
    }
}
