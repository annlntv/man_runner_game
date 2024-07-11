using System.Collections;
using UnityEngine;

public class CharacterAutoMove : MonoBehaviour
{
    public Transform[] waypoints; // массив точек пути
    public float moveSpeed = 5f; // скорость движения
    public float rotationSpeed = 10f; // скорость поворота
    private int currentWaypointIndex = 0; // индекс текущей точки
    private bool isMoving = false; // флаг движения

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

            // Проверка длины вектора перед попыткой поворота
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
            isMoving = false; // отключаем движение по достижении конца пути
        }
    }
}
