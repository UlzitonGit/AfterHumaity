using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    [SerializeField] ParticleSystem[] flame;
    [SerializeField] GameObject flameHitbox;
    bool useFlame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && useFlame == false)
        {
            useFlame = true;
            for (int i = 0; i < flame.Length; i++)
            {
                flame[i].maxParticles = 2000;
                flameHitbox.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            useFlame = false ;
            for (int i = 0; i < flame.Length; i++)
            {
                flame[i].maxParticles = 0;
                flameHitbox.SetActive(false);
            }
        }
    }
}
