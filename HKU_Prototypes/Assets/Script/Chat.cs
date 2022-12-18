using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Content
{
    public string Name;
    public string Contents;
}

public class Chat : MonoBehaviour
{
    public Text Name;
    public Text Content;

    public GameObject ChatBox;

    public List<Content> ContentList;

    public IEnumerator Dialog()
    {
        Debug.Log("asdasd");

        yield return null;

        for (int i = 0; i < ContentList.Count; i++)
        {
            this.Name.text = ContentList[i].Name;
            this.Content.text = ContentList[i].Contents;

            yield return new WaitForSeconds(3.0f);
        }

        ChatBox.gameObject.SetActive(false);
    }
}
