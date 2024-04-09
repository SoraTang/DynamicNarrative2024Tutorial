using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; // ��Ҷ����Transform���
    public float followRadius = 5f; // ��ɫ��ʼ������ҵİ뾶
    public float followSpeed = 2f; // ��ɫ������ҵ��ٶ�
    public Vector3 followOffset; // ����λ��ƫ��

    private bool isFollowing = false; // �Ƿ����ڸ������

    void Update()
    {
        // �����ɫ�����֮��ľ���
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // �����ҽ����˸��淶Χ����ʼ�������
        if (distanceToPlayer <= followRadius)
        {
            isFollowing = true;
        }
        else
        {
            isFollowing = false;
        }

        // ������ڸ�����ң����½�ɫλ��
        if (isFollowing)
        {
            // ����Ŀ��λ�ã����ϸ���λ��ƫ��
            Vector3 targetPosition = player.position + followOffset;

            // ����ɫ����Ŀ��λ���ƶ�S
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    void OnDrawGizmosSelected()
    {
        // ��Scene��ͼ�л���һ��Բ�Σ���ʾ���淶Χ
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, followRadius);
    }
}
