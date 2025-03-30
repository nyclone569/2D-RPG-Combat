using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    [SerializeField] private string transitionName;

    private float waitToLoadTime = 1f;

    private void Start() {
        if (transitionName == SceneManagement.Instance.SceneTransitionName){
            UIFade.Instance.FadeToClear();
            StartCoroutine(LoadSceneRoutine());
            PlayerController.Instance.transform.position = this.transform.position;
            CameraController.Instance.SetPlayerCameraFollow();            
        }
    }

    private IEnumerator LoadSceneRoutine(){
        yield return new WaitForSeconds(waitToLoadTime);
    }
}
