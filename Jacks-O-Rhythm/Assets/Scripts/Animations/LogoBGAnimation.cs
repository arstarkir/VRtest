using System.Collections.Generic;
using UnityEngine;

public class LogoBGAnimation : MonoBehaviour
{
    public List<GameObject> lines = new List<GameObject>();

    public float rotationSpeed = 30f;
    public bool rotateAround = false;

    public float pulsateSpeed = 2f;
    public float pulsateAmount = 0.3f;

    void Update()
    {
        if(!rotateAround)
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].transform.Rotate(0.001f * rotationSpeed, 0, 0);
                foreach (Transform child in lines[i].transform)
                {
                    float scaleX = 1 + Mathf.Sin(Time.time * pulsateSpeed) * pulsateAmount;
                    child.localScale = new Vector3(scaleX, child.localScale.y, child.localScale.z);
                }
            }
        else
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].transform.Rotate(0.001f * rotationSpeed, 0, 0);

                //lines[i].transform.RotateAround(new Vector3(1, 1, 0), Vector3.right, 0.001f * rotationSpeed);

            }

        }
            
    }
}
