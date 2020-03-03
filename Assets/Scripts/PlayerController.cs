using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.5f;
    public float health = PlayerPrefs.GetFloat("Health", 100f);
    private float gold = PlayerPrefs.GetFloat("Gold", 0);
    public GameObject blood, bullet;
    public float horizontalInput;
    public float verticalInput;
    public AudioClip hit;
    private AudioSource hitsound;
    private float xRange = 10f;
    private float zRange = 10f;
    private AsyncOperation asyncLoadLevel;
    // Start is called before the first frame update
    void Start()
    {
        hitsound = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            var x = PlayerPrefs.GetFloat("x");
            var y = PlayerPrefs.GetFloat("y");
            var z = PlayerPrefs.GetFloat("z");
            Vector3 posVec = new Vector3(x, y, z);
            gameManager2.player.transform.position = posVec;
        } else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if (PlayerPrefs.GetInt("HasKey", 0) == 1)
            {
                gameManager2.player.transform.position = new Vector3(-77, 1, -207);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetFloat("Health", 100f) < 0)
        {
            PlayerPrefs.SetFloat("Health", 0);
        }
        //Provided by https://answers.unity.com/questions/653798/character-always-facing-mouse-cursor-position.html
        //The following code makes the player aim at the mouse.
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            transform.LookAt(hit.point);
        }

        //The following code makes sure the player does not go over map.
        // if (transform.position.x < -xRange)
        // {
        //     transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        // }
        // if (transform.position.x > xRange)
        // {
        //     transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        // }
        // if(transform.position.z < -zRange)
        // {
        //     transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        // }
        // if(transform.position.z > zRange)
        // {
        //     transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        // }

        //Shooting Mechanics
        if (Input.GetMouseButtonDown(0))
        {
            GameObject pew = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
        }

        //The following code ensures the player moves around despite direction it faces (which is towards mouse)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput, Space.World);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput, Space.World);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("Zombie"))
        {
            health -= Random.Range(1, 3);
            PlayerPrefs.SetFloat("Health", health);
            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
            float x = Random.Range(0, 3);
            if(x == 1)
            {
                hitsound.PlayOneShot(hit, 1.0f);
            }
        }
        if (collision.gameObject.name.StartsWith("GoldCoin"))
        {
            System.Random rnd = new System.Random();
            gold += rnd.Next(100, 501);
            PlayerPrefs.SetFloat("Gold", gold);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.StartsWith("key_gold"))
        {
            PlayerPrefs.SetInt("HasKey", 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.StartsWith("SedanSmall"))
        {
            if (PlayerPrefs.GetInt("HasKey", 0) == 1)
            {
                print("car enterable");
            }
            else
            {
                print("key is missing");
            }
        }
        if (collision.gameObject.name.StartsWith("FriendHouse"))
        {
            SceneManager.LoadScene(6);
        }
        if (collision.gameObject.name.StartsWith("DoorToKey"))
        {
            PlayerPrefs.SetFloat("x", this.transform.position.x);
            PlayerPrefs.SetFloat("y", this.transform.position.y);
            PlayerPrefs.SetFloat("z", this.transform.position.z+1);
            SceneManager.LoadScene(4);
        }
        if (collision.gameObject.name.StartsWith("DoorToFriend"))
        {
            PlayerPrefs.SetFloat("x", this.transform.position.x);
            PlayerPrefs.SetFloat("y", this.transform.position.y);
            PlayerPrefs.SetFloat("z", this.transform.position.z-1);
            SceneManager.LoadScene(5);
        }
        if (collision.gameObject.name.StartsWith("DoorToOutside"))
        {
            if (PlayerPrefs.GetInt("HasKey", 0) == 1)
            {
                SceneManager.LoadScene(7);
            }
        }
        if (collision.gameObject.name.StartsWith("DoorToStage2"))
        {
            SceneManager.LoadScene(6);
        }
        if (collision.gameObject.name.StartsWith("Army_Bunker"))
        {
            SceneManager.LoadScene(8);
        }
    }
    public void Awake()
    {
        gameManager2.player = this;
    }

    public float getHealth()
    {
        return PlayerPrefs.GetFloat("Health", 100f);
    }
    public float getGold()
    {
        return PlayerPrefs.GetFloat("Gold", 0);
    }

}
