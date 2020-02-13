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
    float currentScore;

    public LayerMask layerMask;



    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float temp = 0;

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) {
            Debug.Log(hit.collider.name);
            temp = hit.collider.gameObject.GetComponent<Collectible>().points;
            }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
        
            if (temp == 1) {
                inventory.inventory.Add(collectibles[2]);
            } else if (temp == 2) {
                inventory.inventory.Add(collectibles[1]);
            } else if (temp == 3) {
                inventory.inventory.Add(collectibles[0]);
            }
            Destroy(hit.collider.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            score.text = "Score:" + calculateScore() + "  Kay Olecki";
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

