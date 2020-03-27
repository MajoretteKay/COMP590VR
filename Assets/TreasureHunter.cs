using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TreasureHunter : MonoBehaviour
{
    // public OVRCameraRig oVRCameraRig;
    // public OVRManager oVRManager;
    // public OVRHeadsetEmulator oVRHeadsetEmulator;
    // public Camera camera;
    // switched to HTCVive
    public List<Collectible> collectibles;
    public TreasureHunterInventory inventory;
    public Camera camera;
    



    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameS
    void Update()
    {
        // A7 code start here
        // hit RaycastHit;
        // if (Input.GetMouseButtonDown(0)){ // if left mouse button pressed...
        //  // get ray starting at camera position and passing through the mouse pointer:
        //  Raycast ray = camera.ScreenPointToRay(Input.mousePosition);
        //  RaycastHit hit; // allocate variable RaycastHit
        //  if (Physics.Raycast(ray, hit)){ // if something hit...
        //    print("Clicked on "+ hit.transform.name); // name of hit object
        //    inventory.inventory.Add(hit.transform.GameObject); // add to inventory
        //  } else {
        //    print("Nothing hit");
        //  }
   }

    
        // A4 Code commented out for A7
        // float temp = 0;

        //     RaycastHit hit;
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     if (Physics.Raycast(ray, out hit)) {
        //     Debug.Log(hit.collider.name);
        //     temp = hit.collider.gameObject.GetComponent<Collectible>().points;
        //     }
        // if (Input.GetKeyDown(KeyCode.Alpha1)) {
        
        //     if (temp == 1) {
        //         inventory.inventory.Add(collectibles[2]);
        //     } else if (temp == 2) {
        //         inventory.inventory.Add(collectibles[1]);
        //     } else if (temp == 3) {
        //         inventory.inventory.Add(collectibles[0]);
        //     }
        //     Destroy(hit.collider.gameObject);
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha2)) {
        //     score.text = "Score:" + calculateScore() + "  Kay Olecki";
        // }
        // itemsCollected();
        //score.text = "Score: " + calculateScore() + " Total: " + inventory.inventory.Count + " Kay Olecki and Alan Patterson";

}
    
    // public void itemsCollected() {
    //     List<Collectible> collected = this.gameObject.GetComponent<TreasureHunterInventory>().inventory;
    //     float common=0;
    //     float uncommon=0;
    //     float rare=0;
    //     float ultra=0;
    //     foreach(Collectible item in collected) {
    //         if (item.points == 1) {
    //             common++;
    //         }
    //         if (item.points == 2) {
    //             uncommon++;
    //         }
    //         if (item.points == 3) {
    //             rare++;
    //         }
    //         if (item.points == 4) {
    //             ultra++;
    //         }  
    //    }
    //    commont.text = "Common:" + common;
    //    uncommont.text = "Uncommon:" + uncommon;
    //    raret.text = "Rare:" + rare;
    //    ultrat.text = "Ultra Rare:" + ultra;

    // }

//     float calculateScore() {
//        List<Collectible> collected = this.gameObject.GetComponent<TreasureHunterInventory>().inventory;
//        float totalScore=0;
//        foreach(Collectible item in collected) {
//            totalScore+=item.points;
//        }
//        currentScore = totalScore;
//        return totalScore;
//     }   
 

