using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoringCollectables : MonoBehaviour
{
    private int _scoreCoin = 1;
    
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            if (this.CompareTag("Coin"))
            {
                GameObject.FindWithTag("Player").GetComponent<Player>().RelayScore(1);
                Destroy(this.gameObject);
            }
        }
       
    }
}