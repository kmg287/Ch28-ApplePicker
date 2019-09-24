using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Prefab for instantiating apples
    public GameObject applePrefab;

    //Speed at which the AppleTree moves in m/s
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    private void Start()
    {
        //Dropping Apples every second
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    private void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    private void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        //Changing DIrection
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }
    }
    private void FixedUpdate()
    {
        //Randomly change Direction
        if ( Random.value < chanceToChangeDirections)
        {
            speed *= -1; //Change Direction
        }
    }
}

