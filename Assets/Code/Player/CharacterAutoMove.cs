using System.Collections;
using UnityEngine;

public class CharacterAutoMove : MonoBehaviour
{
    public Transform[] waypoints; // ������ ����� ����
    public float moveSpeed = 5f; // �������� ��������
    public float rotationSpeed = 10f; // �������� ��������
    private int currentWaypointIndex = 0; // ������ ������� �����
    private bool isMoving = false; // ���� ��������

    void Update()
    {
        if (isMoving)
        {
            MoveAlongPath();
        }
    }

    public void StartMovement()
    {
        if (waypoints.Length > 0)
        {
            isMoving = true;
            currentWaypointIndex = 0;
            //transform.position = waypoints[currentWaypointIndex].position;
        }
    }

    private void MoveAlongPath()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWaypoint = waypoints[currentWaypointIndex];
            Vector3 direction = (targetWaypoint.position - transform.position).normalized;

            // �������� ����� ������� ����� �������� ��������
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex++;
            }
        }
        else
        {
            isMoving = false; // ��������� �������� �� ���������� ����� ����
        }
    }
}
