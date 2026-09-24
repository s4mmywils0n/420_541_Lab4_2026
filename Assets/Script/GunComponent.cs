using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0.0f;
            isCharging = true;
        }

        if(Input.GetButton("Fire1") && isCharging)
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0 , maxChargeTime);
        }

        if(Input.GetButtonUp("Fire1") && isCharging)
        {
            isCharging = false;
            ShootBullet();
        }

    }

    void ShootBullet()
    {
      
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position,
            bulletSpawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        float bulletImpulse = bulletMaxImpulse * (chargeTime / maxChargeTime);

        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);

        chargeTime = 0.0f;

    }
}
