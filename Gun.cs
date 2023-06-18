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

//Unity 에디터에서 새로운 스크립트 파일을 만들고 위의 코드를 붙여넣습니다. 파일 이름은 "Gun.cs"와 같이 지정해야 합니다.

//필요한 경우, 사용할 총알 프리팹을 미리 준비합니다.

//총기 오브젝트에 해당 스크립트를 연결합니다. 총기 오브젝트를 선택한 후, Inspector 창에서 "Add Component" 버튼을 클릭하고, 스크립트의 이름을 입력하여 추가합니다.

//총기가 발사될 위치를 결정하기 위해 게임 오브젝트의 특정 Transform을 할당합니다. 예를 들어, 총기 앞쪽에 빈 게임 오브젝트를 배치하고 해당 Transform을 bulletSpawnPoint에 할당합니다.

//총기의 발사 속도를 조정하기 위해 fireRate 변수 값을 원하는 값으로 설정합니다.
