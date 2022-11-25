using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour, INeedBeSingle
{
    private static T _instance;
    
    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;
            var instances = FindObjectsOfType<T>();
            var count = instances.Length;
            if (count > 0) //Set new instance
            {
                if (count == 1) return _instance = instances[0];
                for (int i = 1; i < count; i++) Destroy(instances[i]); //Destroy extra object
                return _instance = instances[0];
            }
            string name = typeof(T).ToString();
            Debug.Log($"Instance {name}, because need one in the scene");
            return _instance = new GameObject(name).AddComponent<T>(); //Create new instance if it isn't found
        }
    }

}
