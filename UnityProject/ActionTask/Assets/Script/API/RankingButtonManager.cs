using UnityEngine;
using UnityEngine.SceneManagement;

public class RankingButtonManager : MonoBehaviour
{
    public void OnClickTitle()
    {
        SceneManager.LoadScene("Titlle");
    }
}