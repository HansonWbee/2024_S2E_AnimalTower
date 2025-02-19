using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollect : MonoBehaviour
{
    public GameObject gameOtext;
    AudioSource SE;




    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Something's Here");
        
        bool isAnimal = false;
        isAnimal = collision.gameObject.CompareTag("Animal");
        if(isAnimal)
        {
            //Debug.Log("It's an Animal!!");
            Destroy(collision.gameObject);
            Debug.Log("Game Over!!");
            gameOtext.SetActive(true);
        }
    }

}
