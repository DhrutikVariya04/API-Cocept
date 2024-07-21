using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class API : MonoBehaviour
{
    public GameObject Pref,Space;

    [System.Obsolete]
    void Start()
    {
        StartCoroutine(RunAPI());
    }

    [System.Obsolete]
    IEnumerator RunAPI()
    {
        string link = "https://dummyjson.com/comments";
        WWW www = new WWW(link);
      
        yield return www;

        var responce = www.text;
        var json = JsonUtility.FromJson<CommentModel>(responce);

        for (int i = 0; i < json.comments.Count; i++)
        {
            var A = Instantiate(Pref,Space.transform);
            A.transform.GetChild(0).GetComponent<Text>().text = (i + 1)+".";
            A.transform.GetChild(1).GetComponent<Text>().text = json.comments[i].body;
            A.transform.GetChild(2).GetComponent<Text>().text = json.comments[i].user.username;
        }
    }
}

[System.Serializable]
class CommentModel
{
    public List<Comments> comments;
    public int total;
    public int skip;
    public int limit;
}

[System.Serializable]
class Comments
{
    public int id;
    public string body;
    public int postId;
    public user user;
}

[System.Serializable]
class user
{
    public int id;
    public string username;
}