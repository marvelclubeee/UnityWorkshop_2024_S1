# Instructions for the Workshop
The <b>Sample</b> project is the completed version of the workshop project for referencing in your free time, you are encouraged to follow the workshop instructions and try your own before referencing it.  

# Art assets for the Workshop
Art assets(CC0) can be downloaded at this link:  https://brackeysgames.itch.io/brackeys-platformer-bundle

# Source code for Singleton
```
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
                    Debug.Log("Loaded New Manager: " + _instance.name + " as Singleton");
                }
                else
                {
                    Debug.Log("Loaded Old Manager");
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
        
        Initialize();


    }

    protected virtual void Initialize(){}
}
``` 
