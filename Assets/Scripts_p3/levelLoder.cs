using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoder : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public int total_scenes_count = 6;
    public IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            EventBus.Publish<StageStatus>(new StageStatus((levelIndex + 1) % total_scenes_count));
        }
    }
}