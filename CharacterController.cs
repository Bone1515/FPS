using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform bulletSpawnPoint; // 총알 생성 위치

    void Update()
    {
        // 캐릭터 이동 처리
        float moveX = Input.GetAxis("Horizontal"); // 수평 방향 입력 (A, D 또는 왼쪽, 오른쪽 화살표 키)
        float moveZ = Input.GetAxis("Vertical"); // 수직 방향 입력 (W, S 또는 위, 아래 화살표 키)

        Vector3 movement = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime; // 이동 벡터 계산
        transform.Translate(movement); // 캐릭터 이동

        // 총알 발사 처리
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭 시
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        // 총알 프리팹을 총알 생성 위치에서 생성
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        
        // 생성된 총알에 속도를 줌 (캐릭터가 바라보는 방향으로 발사)
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * 10f; // 총알의 속도 및 방향 조정
    }
}
