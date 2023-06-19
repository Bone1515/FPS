using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int health = 100;
    public bool hasGun = false;
    public GameObject gun;
    public Transform gunHolder;
    
    private bool isReloading = false;

    private void Update()
    {
        // 플레이어 이동
        float moveSpeed = 5f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime);

        // 총 쏘기
        if (hasGun && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // 총 줍기
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupGun();
        }

        // 장전하기
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    private void Shoot()
    {
        if (!isReloading)
        {
            Debug.Log("총을 쏩니다.");
            // 총을 쏘는 동작 구현
        }
    }

    private void PickupGun()
    {
        if (!hasGun)
        {
            Debug.Log("총을 줍습니다.");
            // 총을 주워서 gunHolder에 붙이는 동작 구현
            gun.transform.parent = gunHolder;
            gun.transform.localPosition = Vector3.zero;
            gun.transform.localRotation = Quaternion.identity;
            hasGun = true;
        }
    }

    private void Reload()
    {
        if (!isReloading)
        {
            Debug.Log("장전합니다.");
            // 장전하는 동작 구현
            isReloading = true;
            // 장전 시간 동안의 딜레이나 애니메이션 등을 구현할 수 있습니다.
            // 장전이 완료되면 isReloading을 false로 변경합니다.
            isReloading = false;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("체력이 0이 되었습니다.");
            // 플레이어 사망 처리
        }
        else
        {
            Debug.Log($"{damage}의 데미지를 입었습니다. 현재 체력: {health}");
        }
    }
}
