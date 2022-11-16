using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScope : MonoBehaviour
{
    Animator anim;
    bool isScoped;

    public GameObject sniperCrossHair;
    public GameObject weaponCam;
    Camera mainCamera;

    public float scopedFOV = 15f;
    private float normalFOV;

    private void Start()
    {
        anim = GetComponent<Animator>();
        isScoped = false;
        mainCamera = Camera.main;
        //sniperCrossHair = GameObject.Find("SniperCrossHair");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isScoped = !isScoped;
            anim.SetBool("Scope", isScoped);

            if (isScoped)
            {
                StartCoroutine(OnScoped()); // set delay for zoom in
            }
            else OffScoped();
        }
    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f); // same as animation duration time
        sniperCrossHair.SetActive(true);
        weaponCam.SetActive(false);
        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;
    }

    void OffScoped()
    {
        sniperCrossHair.SetActive(false);
        weaponCam.SetActive(true);
        mainCamera.fieldOfView = normalFOV;
    }
}
