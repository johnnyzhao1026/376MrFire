using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{

    public float zoomInAmountFOV = 40f;
    public float zoomOutAmountFOV = 60f;

    Camera fpsCam;

    bool zoomedInToggle = false;

    public float zoomInSensitivity = 200f;
    public float zoomOutSensitivity = 200f;

    Transform pistol_Transform;

    bool isScoped;
    Animator anim;

    /*public Vector3 pistolModelZoomInPos,pistolModelZoomOutPos;*/
    
    // Start is called before the first frame update
    void Start()
    {
        fpsCam = Camera.main;
        zoomOutSensitivity = fpsCam.GetComponent<MouseLook>().mouseSensitivity; // default mouse sensitivity
        isScoped = false;
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {   
                zoomedInToggle = !zoomedInToggle;
                //anim.SetBool("Scope", zoomedInToggle);

                if (zoomedInToggle)
                {
                    fpsCam.fieldOfView = zoomInAmountFOV;
                    fpsCam.GetComponent<MouseLook>().mouseSensitivity = zoomInSensitivity;
                }
               else // zoom out
                {
                    fpsCam.fieldOfView = zoomOutAmountFOV;
                    fpsCam.GetComponent<MouseLook>().mouseSensitivity = zoomOutSensitivity;
                }
             
        }
    }
}
