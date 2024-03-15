using UnityEngine;

namespace nuuspace
{
    public class Star : BacteriaItemGetScript
    {
        AudioSource audioSource;
        [SerializeField] AudioClip starAudio;
        BacteriaManager bacteriaManager;
        void Start()
        {
            bacteriaManager = GameObject.Find("BacteriaManager").GetComponent<BacteriaManager>();
            audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        }
        protected override void OnDestroy()
        {
            if (isContacted && isClicked)
            {
                audioSource.PlayOneShot(starAudio);
                bacteriaManager.GetStar();
                isClicked = false;
                isContacted = false;
            }
        }
    }
}
