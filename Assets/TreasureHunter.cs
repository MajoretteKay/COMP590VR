using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureHunter : MonoBehaviour
{
    public OVRCameraRig oVRCameraRig;
    public OVRManager oVRManager;
    public OVRHeadsetEmulator oVRHeadsetEmulator;
    public Camera camera;
    public List<Collectible> collectibles;
    public TreasureHunterInventory inventory;
    public TextMeshPro score;
    public TextMeshPro win;
    float currentScore;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            if (!(this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Contains(collectibles[0]))) {
                this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Add(collectibles[0]);
            }
     } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
         if (!(this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Contains(collectibles[1]))) {
                this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Add(collectibles[1]);
            }
     } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
         if (!(this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Contains(collectibles[2]))) {
                this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Add(collectibles[2]);
            }
     } else if (Input.GetKeyDown(KeyCode.Alpha4)) {
             score.text = "Score:" + calculateScore() + " (" + this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Count + " items)";
     }
     if (this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Contains(collectibles[0]) && this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Contains(collectibles[1]) && this.gameObject.GetComponent<TreasureHunterInventory>().inventory.Contains(collectibles[2])) {
          win.text = "You won!";
     }
    }

    float calculateScore() {
        List<Collectible> collected = this.gameObject.GetComponent<TreasureHunterInventory>().inventory;
        float totalScore=0;
        foreach(Collectible item in collected) {
            totalScore+=item.points;
        }
        currentScore = totalScore;
        return totalScore;
    }   
}
