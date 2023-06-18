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
//Unity 에디터에서 새로운 스크립트 파일을 만들고 위의 코드를 붙여넣습니다. 파일 이름은 "CharacterController.cs"와 같이 지정해야 합니다.

//필요한 경우, 사용할 총알 프리팹을 미리 준비하고 캐릭터 오브젝트에 연결합니다.

//총알이 발사될 위치를 결정하기 위해 게임 오브젝트의 특정 Transform을 할당합니다. 예를 들어, 빈 게임 오브젝트를 생성하여 캐릭터 앞쪽에 배치하고 해당 Transform을 bulletSpawnPoint에 할당합니다.
