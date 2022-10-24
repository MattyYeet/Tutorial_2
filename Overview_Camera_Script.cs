using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overview_Camera_Script : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 5, this.transform.position.z);
    }
}
