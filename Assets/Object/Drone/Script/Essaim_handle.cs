using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essaim_handle : MonoBehaviour
{

    public List<GameObject> List_Drone;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            List_Drone.Add(child.gameObject);
        }
    }
        // Update is called once per frame
        void Update()
        {

        }


        void UpdateDrone()
        {
            List_Drone.Clear();
            foreach (Transform child in transform)
            {
                List_Drone.Add(child.gameObject);
            }
        }
 }
