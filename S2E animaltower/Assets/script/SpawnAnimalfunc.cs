using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimalfunc : MonoBehaviour
{
    AudioSource SE;

    public float UpValue = 0.5f;

    public GameObject[] animals;
    GameObject currentAnimal;

    bool LetItGo;

    float angle = 0.0f;
    public float turnAngle = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        SE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //2. SpawnAnimal
        if (Input.GetKeyDown(KeyCode.F))
        {
            spawnAnimal();
        }


        //1. Spawner Movement
        //float movement = 0.5f;
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight();
        }

        //Spawner Rotate, CCW
        //if(Input.GetKeyDown(KeyCode.Q))
        if (Input.GetKey(KeyCode.Q))
        {
            rotateCCW();
        }

        //Spawner Rotate, CW
        if (Input.GetKey(KeyCode.E))
        {
            rotateCW();
        }


        //3. Animal Follow
        if (currentAnimal != null && LetItGo == false)
        {
            currentAnimal.transform.position = transform.position;
            currentAnimal.transform.rotation = transform.rotation;
        }

        //4. Let it Go
        if (Input.GetKeyDown(KeyCode.Space))
        {
            letGo();
        }

    }

    void moveUp()
    {
        //Debug.Log("MoveLeft");
        Vector3 spawnerPos = transform.position;
        spawnerPos.y += UpValue;
        transform.position = spawnerPos;
    }



    public void spawnAnimal()
    {
        if (currentAnimal == null)
        {
            int index = Random.Range(0, animals.Length);

            currentAnimal = Instantiate(animals[index]);
            currentAnimal.transform.position = transform.position;

            //currentAnimal.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            currentAnimal.GetComponent<Rigidbody2D>().simulated = false;
            LetItGo = false;
        }
    }

    public void moveLeft()
    {
        float movement = 0.5f;
        //Debug.Log("MoveLeft");
        Vector3 spawnerPos = transform.position;
        spawnerPos.x += movement * (-1);
        transform.position = spawnerPos;
    }

    public void moveRight()
    {
        float movement = 0.5f;
        //Debug.Log("MoveRight");
        Vector3 spawnerPos = transform.position;
        spawnerPos.x += movement * (1);
        transform.position = spawnerPos;
    }

    //CCW, Counter Clockwise
    public void rotateCCW()
    {
        angle += turnAngle;
        Vector3 rot = new Vector3(0.0f, 0.0f, angle);
        transform.eulerAngles = rot;
    }

    public void rotateCW()
    {
        angle -= turnAngle;
        Vector3 rot = new Vector3(0.0f, 0.0f, angle);
        transform.eulerAngles = rot;
    }

    public void letGo()
    {
        if (currentAnimal != null)
        {
            LetItGo = true;
            //currentAnimal.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            currentAnimal.GetComponent<Rigidbody2D>().simulated = true;
            currentAnimal = null;

            moveUp();
            SE.Play();
        }
    }


}

