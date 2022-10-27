using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyStar : MonoBehaviour
{

    OpenChest openChestScript;
    private Rigidbody2D rBody;
    private Animator anim;
    [SerializeField] private float shootUp = 10.0f;
    [SerializeField] private float destroyDelay = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rBody.velocity = new Vector2(rBody.velocity.x + (Random.Range(-20, 20)), shootUp);     
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObjectDelayed(); 
    }
    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, destroyDelay + (Random.Range(1, 20)));
    }

}
