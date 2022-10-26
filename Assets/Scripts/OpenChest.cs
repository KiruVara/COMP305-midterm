using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private bool isOpen;
    private Animator anim;
    public GameObject star;
    public GameObject spawnPoint;
    private float starTotal = 20;
    private float starCount = 0;
    private float starDelay = 2; 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isOpen", isOpen);
    }

    public void Open()
    {
        
        isOpen = true;
        while (starCount < starTotal)
        {
            Instantiate(star, spawnPoint.transform.position, spawnPoint.transform.rotation);
            Delay(); 
            starCount++; 
        }

    }

    public IEnumerable Delay()
    {
        yield return new WaitForSeconds(starDelay);

    }
}
