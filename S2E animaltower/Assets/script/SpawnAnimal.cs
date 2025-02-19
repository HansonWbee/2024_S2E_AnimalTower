using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimal : MonoBehaviour
{
    public GameObject[] animals;
    GameObject currentAnimal;

    bool LetItGo;

    float angle = 0.0f;
    public float turnAngle = 10.0f;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //SpawnAnimal
        if (currentAnimal == null)
        {


            if (Input.GetKeyDown(KeyCode.F))
            {

                spawnAnimal();

            }

        }



        float movement = 0.5f;

        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("MoveLeft");          
            Vector3 spawnerPos = transform.position;
            spawnerPos.x += movement * (-1);
            transform.position = spawnerPos;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("MoveRight");
            Vector3 spawnerPos = transform.position;
            spawnerPos.x += movement * (1);
            transform.position = spawnerPos;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("MoveLeft");          
            Vector3 spawnerPos = transform.position;
            spawnerPos.x += movement * (1);
            transform.position = spawnerPos;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            angle += turnAngle;
            Vector3 rot = new Vector3(0.0f, 0.0f, angle);
            transform.eulerAngles = rot;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            angle -= turnAngle;
            Vector3 rot = new Vector3(0.0f, 0.0f, angle);
            transform.eulerAngles = rot;
        }

        if (currentAnimal != null && LetItGo == false)
        {
            currentAnimal.transform.position = transform.position;
            currentAnimal.transform.rotation = transform.rotation;
        }
        if (currentAnimal != null && Input.GetKeyDown(KeyCode.Space))
        {
            LetItGo = true;
            //currentAnimal.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            currentAnimal.GetComponent<Rigidbody2D>().simulated = true;

            currentAnimal = null;
        }

    }



    void spawnAnimal()
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

}
