using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{//make obstacles move to left 
    public float speed;
    public float normalSpeed = 10;
    public float extraSpeed = 20;
    
    private PlayerControllr playerControllerScript;
    float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllr>(); // find game of object in hierrarchy "Player" and get component from this object, in this case component PlayerControllr. Odwo?anie do skryptu
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftShift)))
        {
            speed = extraSpeed;
        }
        else
        {
            speed = normalSpeed;
        }

        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
