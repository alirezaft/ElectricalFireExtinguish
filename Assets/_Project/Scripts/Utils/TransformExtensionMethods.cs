using UnityEngine;

public static class TransformExtensionMethods
{
    public static void MoveChildTo(this Transform parent, Transform child, Vector3 targetPosition)
    {
        if (child == null)
        {
            Debug.LogError("Child cannot be null.");
            return;
        }

        if (!child.IsChildOf(parent))
        {
            Debug.LogError($"{child.name} is not a child of {parent.name}.");
            return;
        }

        parent.position += targetPosition - child.position;
    }
}
