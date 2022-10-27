using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool isOpen;
    private Animator anim;
    public GameObject star;
    public GameObject spawnPoint;
    private float starTotal = 40;
    private float starDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isOpen", isOpen);
        if (GameObject.FindGameObjectsWithTag("Star").Length >= starTotal)
        {
            CancelInvoke();
        }
        else if (isOpen && GameObject.FindGameObjectsWithTag("Star").Length < starTotal)
        {
            Open();
        }
    }

    public void Open()
    {
        
        isOpen = true;
        Instantiate(star, spawnPoint.transform.position, spawnPoint.transform.rotation);
        if ((GameObject.FindGameObjectsWithTag("Star").Length < starTotal))
        {
            InvokeRepeating("Open", 2, starDelay);
        }

    }

}
