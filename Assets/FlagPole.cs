using UnityEngine;
using System.Collections;
public class FlagPole : MonoBehaviour
{
    [SerializeField] private float startPoint;
    [SerializeField] private float endPoint;
    [SerializeField] NewSceneLoader sceneLoader;
    [SerializeField] GameObject flag;
    private float interp =0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "player"){
           StartCoroutine(LowerFlag());
        }
    }
    IEnumerator LowerFlag(){
        interp += Time.deltaTime;
        while (interp < 1.0f){
            interp += Time.deltaTime;
            flag.transform.position = 
                new Vector3(flag.transform.position.x, 
                Mathf.Lerp(startPoint, endPoint, interp), 
                flag.transform.position.z);
            yield return null;
        }   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
