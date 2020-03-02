using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class PickUpPutDown : MonoBehaviour
{
    public TreasureHunter body;
    public Camera head;
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
        if (grab.GetStateDown(pose.inputSource)){
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
        name = current.gameObject.name;

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
        Collider[] collision = Physics.OverlapSphere((head.transform.position - new Vector3(0,0.5f,0)), 0.25f);
            for(var i = 0; i < collision.Length; i++) {
                if (collision[i].gameObject == current.gameObject) {
                    if (current.points == 1) {
                        body.inventory.inventory.Add(body.collectibles[0]);
                        //clear variables
                        contacted.Remove(collision[i].gameObject.GetComponent<Collectible>());
                        current.active = null;
                        current = null;
                        
                        
                        Destroy(collision[i].gameObject); // not the script one, still didn't work fml
                        break;
                        
                    } 
                    if (current.points == 2) {
                        body.inventory.inventory.Add(body.collectibles[1]);
                        contacted.Remove(collision[i].gameObject.GetComponent<Collectible>());
                        //clear variables
                        current.active = null;
                        current = null;
                        
                        Destroy(collision[i].gameObject);
                        break;
                        
                    } 
                    if (current.points == 3) {
                        body.inventory.inventory.Add(body.collectibles[2]);
                        contacted.Remove(collision[i].gameObject.GetComponent<Collectible>());
                        //clear variables
                        current.active = null;
                        current = null;
                       
                        Destroy(collision[i].gameObject);
                        break;
                        
                    } 
                    if (current.points == 4) {
                        body.inventory.inventory.Add(body.collectibles[3]);
                        contacted.Remove(collision[i].gameObject.GetComponent<Collectible>());
                        //clear variables
                        current.active = null;
                        current = null;
                       
                        Destroy(collision[i].gameObject);
                        break;
                        
                    } 
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
