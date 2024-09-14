# Workshop Intructions
Before starting the workshop, if you have not set up your Unity by following https://drive.google.com/file/d/1Fj05PuDXmRuF79LuKJz2u1NqVII-gHph/view?usp=sharing, **please install Unity Hub from https://unity.com/download**  

After that, open Unity Hub and install the Editor application by going to **Installs -> Install Editor, and then Choose the recommended LTS version** and press **Install**, **do not include Android Build Support in the window that popped out** as it will take a long time to finish installing.

After you have done the above, you can open an empty 2D project from Unity Hub by going to **Projects -> New Project -> All Templates -> 2D (Built-in Render Pipeline)**, leave everything as default and press **Create Project**.

The <b>Sample</b> project above in this repository is the completed version of the workshop project for referencing in your free time, you are encouraged to follow the workshop instructions and try your own before referencing it.  

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
