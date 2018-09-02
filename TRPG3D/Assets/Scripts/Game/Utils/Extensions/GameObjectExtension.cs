using UnityEngine;

public static class GameObjectExtension
{
    public static T AddComponentIfNotExist<T>(this GameObject self) where T : Component 
    {
        if (self == null)
        {
            return default(T);
        }

        T component = self.GetComponent<T>();
        if (component == null)
        {
            component = self.AddComponent<T>();
        }

        return component;
    }
}