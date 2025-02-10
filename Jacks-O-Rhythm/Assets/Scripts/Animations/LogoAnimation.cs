using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimation : MonoBehaviour
{
    [SerializeField] List<OpenTransform> animation = new List<OpenTransform>();
    float curTime = 0;
    int currentIndex = 0;
    void Update()
    {
        if (animation.Count < 2) return;

        curTime += Time.deltaTime;

        if (currentIndex >= animation.Count - 1) return;

        OpenTransform start = animation[currentIndex];
        OpenTransform end = animation[currentIndex + 1];

        if (curTime >= end.time)
        {
            currentIndex++;
            if (currentIndex >= animation.Count - 1) return;

            start = animation[currentIndex];
            end = animation[currentIndex + 1];
        }

        float t = Mathf.InverseLerp(start.time, end.time, curTime);

        transform.position = Vector3.Lerp(start.pos, end.pos, t);
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(start.rot), Quaternion.Euler(end.rot), t);
        transform.localScale = Vector3.Lerp(start.scale, end.scale, t);
    }
}

[Serializable]
public class OpenTransform
{
    public float time;
    public Vector3 scale;
    public Vector3 rot;
    public Vector3 pos;
}