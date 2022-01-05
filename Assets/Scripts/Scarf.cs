using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarf : MonoBehaviour {
    [SerializeField] float threshold = 0.1f;
    [SerializeField] int pointCount = 50;
    [SerializeField] float slope = 100.0f;

    private Vector3 previousGlobalPosition = Vector3.zero;
    private float time = 0.0f;
    private float length = 0.0f;
    private float max_length = 0.0f;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start() {
        previousGlobalPosition = gameObject.transform.position;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointCount;
        for (int i = 0; i < lineRenderer.positionCount; i++)
            lineRenderer.SetPosition(i, previousGlobalPosition + new Vector3(0, -i * threshold, 0));
        max_length = Mathf.Abs(previousGlobalPosition.z - lineRenderer.GetPosition(lineRenderer.positionCount - 1).y);
        length = max_length;
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (Vector3.Distance(previousGlobalPosition, gameObject.transform.position) >= threshold || length > max_length) {
            length = 0.0f;
            previousGlobalPosition = gameObject.transform.position;
            for (int i = 2; i < lineRenderer.positionCount; i++) {
                length += Vector3.Distance(lineRenderer.GetPosition(i), lineRenderer.GetPosition(i - 1));
                Vector3 lerp = Vector3.Lerp(lineRenderer.GetPosition(i), lineRenderer.GetPosition(i - 1), 0.5f);
                lineRenderer.SetPosition(i, lerp);
            }
            lineRenderer.SetPosition(0, gameObject.transform.parent.position);
            lineRenderer.SetPosition(1, previousGlobalPosition);
        }
        else {
            for (int i = 2; i < lineRenderer.positionCount; i++) {

                float x = gameObject.transform.position.x;
                float z = gameObject.transform.position.z;
                float y = gameObject.transform.position.y;

                x = x + Mathf.Sin(lineRenderer.GetPosition(i).y + time) * i / lineRenderer.positionCount / 4;

                Vector3 lerp = Vector3.Lerp(lineRenderer.GetPosition(i), new Vector3(x, y + -i * threshold, z), (.02f - i / slope));


                lineRenderer.SetPosition(i, lerp);
            }
        }
    }
}
