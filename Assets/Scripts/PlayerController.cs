using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.5f;
    public float health;
    private float gold;
    public GameObject blood;
    public float horizontalInput;
    public float verticalInput;
    public AudioClip hit;
    private AudioSource hitsound;
    private float xRange = 10f;
    private float zRange = 10f;
    private string bulletType = "Blue";
    public float stage = 0;
    private AsyncOperation asyncLoadLevel;
    private CharacterController controller;

    public bool HellicopterReady { get; set; }

    // Start is called before the first frame update
    void Start()
    {
      PlayerPrefs.SetFloat("Health", 100f);
      //health = PlayerPrefs.GetFloat("Health", 100f);
      //gold = PlayerPrefs.GetFloat("Gold", 0);
        hitsound = GetComponent<AudioSource>();
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            var x = PlayerPrefs.GetFloat("x");
            var y = PlayerPrefs.GetFloat("y");
            var z = PlayerPrefs.GetFloat("z");
            Vector3 posVec = new Vector3(x, y, z);
            gameManager2.player.transform.position = posVec;
        }

        controller = GetComponent<CharacterController>();
        HellicopterReady = false;
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


        //Shooting Mechanics
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletType == "Blue")
            {
                GameObject pew = (GameObject)Instantiate(Resources.Load("Objects/BlueBullet"), transform.position, transform.rotation);
            }
            if (bulletType == "Green")
            {
                GameObject pew = (GameObject)Instantiate(Resources.Load("Objects/GreenBullet"), transform.position, transform.rotation);
            }
            if (bulletType == "Red")
            {
                GameObject pew = (GameObject)Instantiate(Resources.Load("Objects/RedBullet"), transform.position, transform.rotation);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            bulletType = "Blue";
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            bulletType = "Green";
        } else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            bulletType = "Red";
        }

        //The following code ensures the player moves around despite direction it faces (which is towards mouse)
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        controller.Move(Vector3.forward * Time.deltaTime * speed * verticalInput);
        controller.Move(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if((stage == 1) && (transform.position.y != 0.94f))
        {
            transform.position = new Vector3(transform.position.x, 0.94f, transform.position.z);
        }
        else if ((stage == 4) && (transform.position.y != 2.8f))
        {
            transform.position = new Vector3(transform.position.x, 2.8f, transform.position.z);
        }
        else if ((stage == 8) && (transform.position.y != 1f))
        {
            transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Here");

        if (other.gameObject.name.StartsWith("Spitball"))
        {
            Debug.Log("Inside");

            health -= Random.Range(1, 3);
            PlayerPrefs.SetFloat("Health", health);
            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
            float x = Random.Range(0, 3);
            if (x == 1)
            {
                hitsound.PlayOneShot(hit, 1.0f);
            }

            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("BombZombie"))
        {
            health -= 5;
            PlayerPrefs.SetFloat("Health", health);
            float x = Random.Range(0, 3);
            if(x == 1)
            {
                hitsound.PlayOneShot(hit, 1.0f);
            }
        }
        else if (collision.gameObject.name.StartsWith("RegularZombieNavMesh"))
        {
            health -= 3;
            PlayerPrefs.SetFloat("Health", health);
            float x = Random.Range(0, 3);
            if(x == 1)
            {
                hitsound.PlayOneShot(hit, 1.0f);
            }
        }
        else if (collision.gameObject.name.StartsWith("RegularZombie"))
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
        if (collision.gameObject.name.StartsWith("Tiger"))
        {
            health -= Random.Range(3, 5);
            PlayerPrefs.SetFloat("Health", health);
            GameObject oof = (GameObject)Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(oof, 3);
            float x = Random.Range(0, 3);
            if (x == 1)
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
            //.LoadScene(13);

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
            SceneManager.LoadScene(12);
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
               // SceneManager.LoadScene(7);
                SceneManager.LoadScene(13);

            }
        }
        if (collision.gameObject.name.StartsWith("DoorToStage2"))
        {
            SceneManager.LoadScene(6);
        }
        //if (collision.gameObject.name.StartsWith("Army_Bunker"))
        //{
        //    SceneManager.LoadScene(8);
        //}
        if (collision.gameObject.name.StartsWith("SceneFourCar")){
            SceneManager.LoadScene(17);
        }
        if (collision.gameObject.name.StartsWith("StreetRail (60)"))
        {
            SceneManager.LoadScene(14);
        }
        if (HellicopterReady && collision.gameObject.name.StartsWith("Heli1"))
        {
            SceneManager.LoadScene(23);    //game over
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
