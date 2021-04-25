using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    
    [SerializeField] private SpawnManager _spawnManager;
    
    // variables concerning movement
    [SerializeField] private float _speed = 13f;
    [SerializeField] private float _jumpStrength = 200f;
    public bool isGrounded;

    // Sprinkle attack
    [SerializeField] private float _shootRate = 0.3f;
    [SerializeField] private float _timeToShoot = -0.5f;
    public GameObject sprinklePrefab;

    [SerializeField] private int _lives = 3;
    [SerializeField] private float _powerUpTimeout = 5f;
    
    private bool _powerUpActivated = false; 
    
    private void Update()
    {
        //TODO cam spins because it targets the player! FIX THIS
        //transform.Rotate(Vector3.right * _spinSpeed * Time.deltaTime);
        PlayerMovement();
        PlayerJump();
        PlayerShoot();

    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical) * _speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
        
    }

    void PlayerJump()
    {
        // only let player jump when on ground
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * _jumpStrength);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    
    void PlayerShoot()
    {
        if(Input.GetKey(KeyCode.Mouse0) && Time.time > _timeToShoot)
        {
            _timeToShoot = Time.time + _shootRate;
            Instantiate(sprinklePrefab,
                transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);

        }
    }

    public void Damage_Player()
    {
        _lives -= 1;
        _uiManager.ReduceLives(_lives);
        // if health is 0, destroy player
        if (_lives == 0)
        {
            _uiManager.ShowGameOver();
            this.gameObject.SetActive(false);
            // Destroy(this.gameObject);
        }
    }
    
    public void RelayScore(int score)
    {
        _uiManager.AddScore(score);
    }
}
