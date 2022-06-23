using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public static AudioManager audioManager;
    

    private void Awake() {
        if(audioManager==null){
            audioManager=this;
        }else{
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(audioManager);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    
}
