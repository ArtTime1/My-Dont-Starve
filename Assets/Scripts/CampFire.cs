using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    private float _timeFireRemaining = 0;
    private bool _timerFireRemaining = false;
    [SerializeField] Light _light;
  
    void Update()
    {
        FireLifeTime();
        StopFire();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WoodLog"))
        {
            LightFire();
            Destroy(other.gameObject);
        }
    }
    private void StopFire()
    {
        if (!_timerFireRemaining)
        {
            _particleSystem.Stop();
            _light.gameObject.SetActive(false);
        }       
    }

    private void LightFire()
    {
        _particleSystem.Play();
        _timeFireRemaining += 10;
        _light.gameObject.SetActive(true);
        _timerFireRemaining = true;     
    }
     
    private void FireLifeTime()
    {
        if (_timeFireRemaining > 0)
        {
            _timeFireRemaining -= Time.deltaTime;          
        }
        else
        {
            _timeFireRemaining = 0;
            _timerFireRemaining = false;
        }
    }
}
