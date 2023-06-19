using UnityEngine;

public class Gun : MonoBehaviour
{
    public int damage = 20;
    public float fireRate = 0.1f;
    public float reloadTime = 2f;
    public int maxAmmo = 30;
    
    private int currentAmmo;
    private bool isReloading = false;
    private bool isShooting = false;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (isShooting)
        {
            Shoot();
        }
    }

    public void StartShooting()
    {
        isShooting = true;
    }

    public void StopShooting()
    {
        isShooting = false;
    }

    private void Shoot()
    {
        if (currentAmmo <= 0)
        {
            return;
        }

        // 총 발사 동작 구현
        Debug.Log("총을 발사합니다.");
        currentAmmo--;
        // 데미지 입히는 로직 등을 추가로 구현할 수 있습니다.
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("장전 중...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        Debug.Log("장전이 완료되었습니다.");
    }
}
