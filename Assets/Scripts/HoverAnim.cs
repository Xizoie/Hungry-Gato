using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FWC
{
    public class HoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {

        [SerializeField] float scaleChange = 1.1f;

        [SerializeField] Button button;

        [SerializeField] AudioSource source;
        [SerializeField] AudioClip triggerClip;
        [SerializeField] AudioClip ClickClip;


        private void Start()
        {
            button.onClick.AddListener(PlayOnClick);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.localScale *= scaleChange;

            source.PlayOneShot(triggerClip, 0.9f);
        }

        public void PlayOnClick()
        {
            source.PlayOneShot(ClickClip, 0.9f);
        }
        

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
