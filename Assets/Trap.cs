using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    public Collectible cube;
    public Rigidbody ground;
    public Rigidbody table;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cube.active != null) {
            ground.useGravity = true;
            ground.isKinematic= false;
            table.useGravity = true;
            table.isKinematic= false;
            
        }
    }
}
