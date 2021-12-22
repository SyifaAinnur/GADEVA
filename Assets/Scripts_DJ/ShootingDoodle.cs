using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDoodle : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 80f;

    private bool isStarted = false;
    private bool allowShoot = false;

    public GameObject panel;


    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        {
            if (PauseMenu.isPause == true)
            {
                isStarted = false;
                allowShoot = false;
            }
            if (PauseMenu.isPause == false)
            {
                isStarted = true;
                allowShoot = true;
            }
            
        }

        if(PauseMenu.isPause == false)
        {
            if (Input.GetButtonDown("Fire1") && isStarted == true && allowShoot == true)
            {
                Shoot();
            }
        }

        if(panel.activeInHierarchy)
        {
            allowShoot = false;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

         Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        SoundManagerDoodle.PlaySound("shoot");
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    //public void StopShoot()
    //{
    //    isStarted = false;
    //}
}
