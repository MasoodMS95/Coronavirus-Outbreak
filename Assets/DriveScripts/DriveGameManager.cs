using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DriveGameManager : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0f;
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void incrementSpeed(float incrementAmount)
    {
        speed += incrementAmount;
    }

    public void decrementSpeed(float decrementAmount)
    {
        speed -= decrementAmount;
    }
}
