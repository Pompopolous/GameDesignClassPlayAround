using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public int scoreValue = 10;
    public GameObject explosion;

    private GameController gameControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("Can not find game controller script on Game Controller Object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // something has collided
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            gameControllerScript.GameOver();
        }
        // create an explosion // animation of explosion // Line 2: Add to score
        Instantiate(explosion, transform.position, transform.rotation);
        gameControllerScript.AddtoScore(scoreValue);
        // delete that other object
        Destroy(other.gameObject);
        // delete this object
        Destroy(this.gameObject);

    }
}
