using System.Collections.Generic;
using UnityEngine;

public class TrajectoryController : MonoBehaviour
{
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private int dotCount = 2;
    [SerializeField] private float dotSpacing = 0.1f;
    [SerializeField] private Transform dotParent;

    private List<Transform> dots = new List<Transform>();
    private Vector2 gravity;

    private void Awake()
    {
        gravity = Physics2D.gravity;
        GenerateDots();
    }

    private void GenerateDots()
    {
        for (int i = 0; i < dotCount; i++)
        {
            GameObject dot = Instantiate(dotPrefab, Vector3.zero, Quaternion.identity, dotParent);
            dot.SetActive(false);
            dots.Add(dot.transform);
        }
    }

    public void ShowTrajectory(Vector2 startPos, Vector2 velocity)
    {
        for (int i = 0; i < dots.Count; i++)
        {
            float t = i * dotSpacing;
            Vector2 pos = startPos + velocity * t + 0.5f * gravity * t * t;
            dots[i].position = pos;
            dots[i].gameObject.SetActive(true);
        }
    }

    public void HideTrajectory()
    {
        foreach (Transform dot in dots)
        {
            dot.gameObject.SetActive(false);
        }
    }
}
