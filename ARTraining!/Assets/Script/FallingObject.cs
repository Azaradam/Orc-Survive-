using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Plane")
        {
            var controller = GameObject.Find("ObstacleManager").GetComponent<ObstacleController>();
            var smoke = Instantiate(controller.smokeParticle, gameObject.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
            var spawn = GameObject.Find("ObstacleManager").GetComponent<ObstacleController>();
            spawn.ScoreModifier();
            Destroy(smoke, 2f);
        }
        if(other.tag == "Manager")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            var spawn = GameObject.Find("ObstacleManager").GetComponent<ObstacleController>();
            spawn.HpModifier("minus");
            var audio = other.GetComponent<AudioSource>();
            audio.Play(0);
            Destroy(gameObject);
        }

    }
}
