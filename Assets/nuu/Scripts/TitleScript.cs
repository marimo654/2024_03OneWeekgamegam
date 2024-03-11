using UnityEngine;
using UnityEngine.SceneManagement;

namespace nuuspace
{
    public class TitleScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnButtonClicked()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}