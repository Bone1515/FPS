using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform bulletSpawnPoint; // 총알 생성 위치
    public float fireRate = 0.1f; // 총 발사 속도
    private float lastFireTime; // 마지막 발사 시간

    public void Fire()
    {
        if (Time.time - lastFireTime >= fireRate) // 발사 속도 체크
        {
            // 총알 프리팹을 총알 생성 위치에서 생성
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

            // 생성된 총알에 속도를 줌 (총기가 바라보는 방향으로 발사)
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = transform.forward * 10f; // 총알의 속도 및 방향 조정

            lastFireTime = Time.time; // 발사 시간 업데이트
        }
    }
}
