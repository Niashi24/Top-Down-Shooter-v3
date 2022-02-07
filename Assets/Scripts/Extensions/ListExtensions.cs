using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ListExtensions
{
    public static TOut[] Map<TList, TOut>(this List<TList> list, Func<TList,TOut> func) {
        TOut[] output = new TOut[list.Count];
        for (int i = 0; i < output.Length; i++) {
            output[i] = func(list[i]);
        }
        return output;
    }

    public static void RemoveNull<T>(this List<T> list) {
        for (int i = list.Count - 1; i >= 0; i--){
            if (list[i] == null)
                list.RemoveAt(i);
        }
    }

    public static Vector2 RotateTowards(this Vector2 subject, Vector2 target, float? maxAngleDelta = null) {
        if (maxAngleDelta == null) return target.normalized * subject.magnitude;

        var angleDelta = Vector2.SignedAngle(subject, target);
        if (angleDelta <= maxAngleDelta.Value) return target.normalized * subject.magnitude;

        return subject.Rotate(maxAngleDelta.Value);
    }

    public static Vector2 Rotate(this Vector2 subject, float angle) {
        return new Vector2(
            subject.x * Mathf.Cos(angle) - subject.y * Mathf.Sin(angle),
            subject.x * Mathf.Sin(angle) + subject.y * Mathf.Sin(angle)
        );
    }

    public static T Log<T>(this T log) {
        Debug.Log(log);
        return log;
    }
}