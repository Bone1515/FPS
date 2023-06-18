using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // 캐릭터 이동 속도
    public GameObject bulletPrefab; // 총알 프리팹
    public Transform bulletSpawnPoint; // 총알 생성 위치
    public Transform pickUpPoint; // 총기 주울 위치
    private GameObject pickedUpGun; // 주운 총기 저장 변수

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

        // 총기 주울 처리
        if (Input.GetKeyDown(KeyCode.E) && pickedUpGun == null) // E 키 입력 시 주운 총기가 없는 상태에서 주울 수 있음
        {
            PickUpGun();
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

    void PickUpGun()
    {
        Collider[] colliders = Physics.OverlapSphere(pickUpPoint.position, 1f); // 픽업 지점 근처에 있는 콜라이더 검색

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Gun")) // 태그가 "Gun"인 총기를 찾음
            {
                pickedUpGun = collider.gameObject;
                pickedUpGun.transform.parent = pickUpPoint; // 총기를 주울 위치의 자식으로 설정
                pickedUpGun.transform.localPosition = Vector3.zero; // 총기를 주울 위치로 이동
                pickedUpGun.transform.localRotation = Quaternion.identity; // 총기의 회전을 초기화
                break;
            }
        }
    }
