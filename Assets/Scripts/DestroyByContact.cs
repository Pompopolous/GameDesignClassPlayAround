using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        // something has collided
        // create an explosion // animation of explosion
        Instantiate(explosion, transform.position, transform.rotation);
        // delete that other object
        Destroy(other.gameObject);
        // delete this object
        Destroy(this.gameObject);

    }
}
