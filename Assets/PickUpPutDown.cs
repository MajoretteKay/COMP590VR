using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class PickUpPutDown : MonoBehaviour
{
    public TreasureHunter body;
    public SteamVR_Action_Boolean grab = null;

    SteamVR_Behaviour_Pose pose = null;
    FixedJoint joint = null;
    Collectible current = null;
    List<Collectible> contacted = new List<Collectible>();

    

    private void Awake() {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    
    }

    // Update is called once per frame
    void Update()   {
        //Down
        if (grab.GetStateDown(pose.inputSource)) {
            PickUp();
        }
        //Up
        if (grab.GetStateUp(pose.inputSource)) {
            Drop();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(!other.gameObject.CompareTag("Interactable")) {
            return;
        }

        contacted.Add(other.gameObject.GetComponent<Collectible>());
    }

    private void OnTriggerExit(Collider other) {
        if(!other.gameObject.CompareTag("Interactable")) {
            return;
        }

        contacted.Remove(other.gameObject.GetComponent<Collectible>());
    }

    public void PickUp() {
        // get nearest
        current = GetNearest();
        // null check
        if (current == null) {
            return;
        }

        //is it being held by other controller
        if (current.active != null) {
            current.active.Drop();
        }
        //position to controller
        current.transform.position = transform.position;

        //attach to rigid body joint
        Rigidbody target = current.GetComponent<Rigidbody>();
        joint.connectedBody = target;
        //set acive hand
        current.active = this;

    }

    public void Drop() {
        // null
        if (current == null) {
            return;
        }
        //velocity
        Rigidbody target = current.GetComponent<Rigidbody>();
        target.velocity = pose.GetVelocity();
        target.angularVelocity = pose.GetAngularVelocity();
        //detach
        joint.connectedBody= null;
        // add to inventory if nearby body
        Collider[] collision = Physics.OverlapSphere(body.transform.position, 2);

        if (collision.Length > 0) {
           if (current.points == 1) {
               body.inventory.inventory.Add(body.collectibles[0]);
               Destroy(current);
           } 
           if (current.points == 2) {
               body.inventory.inventory.Add(body.collectibles[1]);
               Destroy(current);
           } 
           if (current.points == 3) {
               body.inventory.inventory.Add(body.collectibles[2]);
               Destroy(current);
           } 
           if (current.points == 4) {
               body.inventory.inventory.Add(body.collectibles[3]);
               Destroy(current);
           } 

        }

        //clear variables
        current.active = null;
        current = null;
    }

    private Collectible GetNearest() {
        Collectible nearest = null;
        float min = float.MaxValue;
        float distance = 0.0f;

        foreach(Collectible collected in contacted) {
            distance = (collected.transform.position - transform.position).sqrMagnitude;
        
            if(distance < min) {
                min = distance;
                nearest = collected;
            }
        }
        return nearest;
    }
}
