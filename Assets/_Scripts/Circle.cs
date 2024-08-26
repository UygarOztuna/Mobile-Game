using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public static Circle Instance;

    public GameObject skillTimerCounter;
    public TextMeshProUGUI timerText;
    public float timeRemaining = 10f;
    public float timeRemainingReset;
    public bool timerIsRunning = false;
    public bool timeEnds;
    public bool isCirle = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //public LineRenderer lineRenderer;
    private List<Vector2> touchPositions = new List<Vector2>();
    private bool isDrawing = false;
    public float circleThreshold = 0.1f; // Daire algýlama hassasiyeti
    public float minDistance = 0.1f; // Dokunma noktalarýnýn minimum mesafesi
    public float maxStartEndDistance = 0.5f; // Baþlangýç ve bitiþ noktalarýnýn maksimum mesafesi

    private void Start()
    {
        timeRemainingReset = timeRemaining;
        timeEnds = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPositions.Clear();
            //lineRenderer.positionCount = 0;
            isDrawing = true;
        }

        if (Input.GetMouseButton(0) && isDrawing)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPositions.Count == 0 || Vector2.Distance(touchPosition, touchPositions[touchPositions.Count - 1]) > minDistance)
            {
                touchPositions.Add(touchPosition);
                //lineRenderer.positionCount = touchPositions.Count;
                //lineRenderer.SetPosition(touchPositions.Count - 1, touchPosition);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
            AnalyzeShape();
        }

        Timer();
    }

    public void Timer()
    {
        if (timerIsRunning)
        {
           

            if (timeRemaining > 0)
            {
                // Geri sayýmý yap
                timeRemaining -= Time.deltaTime;
                timerText.text = Mathf.Ceil(timeRemaining).ToString();
            }
            else
            {
                // Geri sayým bittiðinde timer'ý durdur
                timeRemaining = 0;
                timeEnds = true;
                timeRemaining = timeRemainingReset;
                timerIsRunning = false;
                skillTimerCounter.SetActive(false);
                timerText.text = "Süre Doldu!";
            }
        }
    }

    void AnalyzeShape()
    {
        if (IsCircle(touchPositions) && timeEnds)
        {
            isCirle = true;
            timerIsRunning = true;
            timeEnds = false;
            skillTimerCounter.SetActive(true);
            Debug.Log("Daire çizildi!");
        }
        else
        {
            Debug.Log("Daire algýlanamadý.");
        }
    }

    bool IsCircle(List<Vector2> points)
    {
        if (points.Count < 5)
        {
            return false; // Daire kontrolü için yeterli nokta yok
        }

        // Baþlangýç ve bitiþ noktalarýnýn yakýnlýðýný kontrol et
        if (Vector2.Distance(points[0], points[points.Count - 1]) > maxStartEndDistance)
        {
            return false;
        }

        // Ortalama merkez noktayý hesapla
        Vector2 center = Vector2.zero;
        foreach (Vector2 point in points)
        {
            center += point;
        }
        center /= points.Count;

        // Ortalama yarýçapý hesapla
        float radius = 0;
        foreach (Vector2 point in points)
        {
            radius += Vector2.Distance(point, center);
        }
        radius /= points.Count;

        // Tüm noktalarýn bu yarýçap çevresinde olup olmadýðýný kontrol et
        foreach (Vector2 point in points)
        {
            float distance = Vector2.Distance(point, center);
            if (Mathf.Abs(distance - radius) > circleThreshold)
            {
                return false;
            }
        }

        return true;
    }
}
