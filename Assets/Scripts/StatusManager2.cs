using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager2 : MonoBehaviour {

    GameObject full;

    public void Start()
    {
        full = GameObject.FindWithTag("FullEnergy");
    }


    public void ChangeStatus()
    {
        full.transform.position = new Vector3(-200, 0, 0);
    }
}
