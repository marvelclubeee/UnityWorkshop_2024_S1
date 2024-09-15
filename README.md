# Workshop Intructions  
Before starting the workshop, if you have not set up your Unity and opened an empty 2D project by following the set-up guide in the link below:  
https://drive.google.com/file/d/1Fj05PuDXmRuF79LuKJz2u1NqVII-gHph/view?usp=sharing  
**Please do it before the workshop begins.**  

The <b>Sample</b> project above in this repository is the completed version of the workshop project for referencing in your free time, you are encouraged to follow the workshop instructions and try your own before referencing it.  

# Resources Needed for the Workshop  
## Art assets for the Workshop  
Art assets(CC0) can be downloaded at this link:  https://brackeysgames.itch.io/brackeys-platformer-bundle  
You can scroll down to the bottom to find the download button.  
PS: we only need the sprites for this workshop.  

## Source code for Singleton  
**To use it**  
1. Create a C# script in Unity project called ```GlobalSingleton.cs``` and replace everything with the code below.  
2. Let your ```GameManager``` class inherit from ```GlobalSingleton``` class. (e.g. ```public class GameManager : GlobalSingleton<GameManager> {}```)   

You do not need to worry about what Singleton is at this stage, just remember that it is a way to make a script component **unique and globally accessible** through the game software's life cycle.  
It is a common programming pattern in game development to keep global game states such as the player's score.  
if you are curious, can check out this link https://refactoring.guru/design-patterns/singleton which gives a detailed explanation of Singleton pattern.  

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
``` 
