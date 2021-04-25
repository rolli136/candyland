using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    // animation things
    [SerializeField] private float _spinSpeed = 2;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float height = 1f;
    private Vector3 pos0ffset = new Vector3();
    private Vector3 tempPos = new Vector3();
    
    public int health = 2;

    private void Start()
    {
        pos0ffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,  0f * Time.deltaTime, _spinSpeed));
        
        
        tempPos = pos0ffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * speed) * height;

        transform.position = tempPos;

        // calculate what the new Y position will be
        // float newY = Mathf.Sin(Time.time * speed);
        // set the object's Y to the new calculated Y
       // transform.position = new Vector3(x:pos.x, y:newY, z:pos.z) * height;

    }

    // damage function
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage_Player();
        }
        else if (other.CompareTag("Sprinkle"))
        {
            health--;
            Destroy(other.gameObject);
        }

        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
