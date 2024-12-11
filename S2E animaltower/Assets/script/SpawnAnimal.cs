using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0.5f;
        if(Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("MoveLeft");
            Vector3 spawnerPos = transform.position;
            spawnerPos.x += movement * (-1);
            transform.position = spawnerPos;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("MoveRight");
            Vector3 spawnerPos = transform.position;
            spawnerPos.x += movement * (1);
            transform.position = spawnerPos;
        }
    }
}
