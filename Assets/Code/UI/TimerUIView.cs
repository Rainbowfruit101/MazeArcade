using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimerUIView: MonoBehaviour
    {
        [SerializeField] private TimerController controller;
        [SerializeField] private TMP_Text valuePlace;

        [SerializeField] private Button start;
        [SerializeField] private Button pause;
        [SerializeField] private Button reset;

        private void Awake()
        {
            controller.OnTimerEnded += TimerEnded;
            controller.OnTimerTick += TimerTick;
            
            if (start != null)
            {
                start.onClick.AddListener(controller.StartTimer);
            }

            if (pause != null)
            {
                pause.onClick.AddListener(controller.PauseTimer);
            }

            if (reset != null)
            {
                reset.onClick.AddListener(controller.ResetTimer);
            }
        }
        
        private void OnDestroy()
        {
            controller.OnTimerEnded -= TimerEnded;
            controller.OnTimerTick -= TimerTick;
        }

        private void Start()
        {
            valuePlace.text = controller.Value.ToString();
        }

        private void TimerTick(int value)
        {
            valuePlace.text = value.ToString();
        }

        private void TimerEnded()
        {
            valuePlace.color = Color.cyan;
        }
    }
}