using UnityEngine;

//This class handles logic of creating singleton object that persists through scenes
public class GlobalSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    //load singleton into instance
                    _instance = new GameObject().AddComponent<T>();
                    _instance.name = typeof(T).ToString();
                    Debug.Log("Singleton " + _instance.name + " created");
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        //if there is already a instance, destroy
        if (_instance != null)
        {
            Debug.LogWarning("Duplicate " + _instance.name + " found, destroying new one");
            Destroy(this.gameObject);

        }
        else
        {
            _instance = this as T;
            DontDestroyOnLoad(this);
        }
    }

}