
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public bool isDead;
    public bool won;
    public int dabloons;
    public GameObject winUI, loseUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        if(dabloons >= 3 && !won)
        {
            Win();
        }

        if(Input.GetKeyDown(KeyCode.R) && isDead)
        {
            Respawn();
        }


        rigidbody2D.linearVelocity += new Vector2(input * 25 * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "KillBox")
        {
            Die();
        }
        else if(other.tag == "Dabloon")
        {
            Dabloon dabloon = other.gameObject.GetComponent<Dabloon>();
            if (dabloon.dabloonActive)
            {               
                dabloon.TakeDabloon();
                dabloons++;
            }
        }
    }

    void Die(bool showUI = true)
    {
        isDead = true;
        Time.timeScale = 0;
        dabloons = 0;
        if (showUI)
        {
            
        loseUI.SetActive(true);
        }
    }
    void Win()
    {
        Die(false);
        Time.timeScale = 0;
        isDead = true;

        winUI.SetActive(true);
    }

    void Respawn()
    {
        isDead = false;
        Time.timeScale = 1;
        transform.position = Vector3.up * 5;
        winUI.SetActive(false);
        loseUI.SetActive(false);
        won = false;
        dabloons = 0;
        rigidbody2D.linearVelocity = Vector2.zero;
    }
}
