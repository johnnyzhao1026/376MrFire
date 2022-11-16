using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{


    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public AudioSource sound_Gunfire;
    public ParticleSystem muzzleFlash;
    public AudioSource sound_NoAmmo;

    private float nextTimeToFire = 0f;

    public Ammo ammoSlot;
    public AmmoType ammoType;

    public int ammoInSlot;
    public int slotSize;
    private bool isReloading = false;

    private Camera mainCamera;

    [SerializeField] private Animator gunAnimator;
    // Start is called before the first frame update
    private void Awake()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > slotSize)
        {
            ammoInSlot = slotSize;
        }
        else ammoInSlot = ammoSlot.GetCurrentAmmo(ammoType);

        mainCamera = Camera.main;

        ammoSlot.ReduceCurrentAmmo(ammoType, ammoInSlot); // the first slot is filled with ammo, so we need to reduce the total ammo amount
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.R)) // reload ammo if slot is not full and has ammo to reload
        {
            if (ammoInSlot < slotSize && ammoSlot.GetCurrentAmmo(ammoType) > 0)
            {
                StartCoroutine(ReloadAmmo());
                return;
            }
            else return;
        }

        if (gameObject.transform.name == "PistolGun" || gameObject.tag == "Pistol" || gameObject.tag == "Sniper")
        {
            Shoot();
        }
        else if(gameObject.transform.name == "M4")
        {
            ContinueShoot();
        }
        
    }


    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            if (ammoInSlot > 0)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                ammoInSlot--;
                ProcessSoundAndFX();
                if(!muzzleFlash.isPlaying) muzzleFlash.Play();
                gunAnimator.SetTrigger("Fire"); 

                // process Raycast
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
                {
                    Debug.Log(hit.transform.name);
                    EnemyHealth targetHealth = hit.transform.GetComponent<EnemyHealth>();
                    if (targetHealth != null)
                    {
                        targetHealth.TakeDamage(damage);
                    }
                }
            }
            else if (ammoInSlot <= 0) // no ammo in slot
            {
                sound_NoAmmo.Play();
            }
        }
  
    }

    void ContinueShoot()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            if (ammoInSlot > 0)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                ammoInSlot--;
                ProcessSoundAndFX();
                gunAnimator.SetTrigger("Fire");
                // process Raycast
                RaycastHit hit;
                if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
                {
                    Debug.Log(hit.transform.name);
                    EnemyHealth  enemyHealth = hit.transform.GetComponent<EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damage);
                    }
                }

            }
            else if (ammoInSlot <= 0)
            {
                sound_NoAmmo.Play();
            }
        }
    }

    void ProcessSoundAndFX()
    {
        
        sound_Gunfire.Play();
        
       
          muzzleFlash.Play();
        
        
    }

    IEnumerator ReloadAmmo()
    {
        isReloading = true;
        gunAnimator.SetBool("Reloading", true);
        yield return new WaitForSeconds(1f);
        int ammoToReload = slotSize - ammoInSlot;
            ammoInSlot += ammoToReload;
        isReloading = false;
       // yield return new WaitForSeconds(2f);
        gunAnimator.SetBool("Reloading", false);
         
        ammoSlot.ReduceCurrentAmmo(ammoType, ammoToReload); // reduce the total ammo amount
    }

/*    void ProcessAnimation()
    {
        gunAnimator.SetTrigger("Fire");
    }*/

}// end class
