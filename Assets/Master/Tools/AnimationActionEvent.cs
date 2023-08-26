using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dimas.Animation
{
    public class AnimationActionEvent : MonoBehaviour
    {
        [System.Serializable]
        public struct EventTrack
		{
            public string nameTrack;
            public UnityEngine.Events.UnityEvent eventToExecuted;
		}

        [SerializeField]
        public EventTrack[] _trackEvent;

        public void ExecutedEvent(string nameEvent)
		{
			for (int i = 0; i < _trackEvent.Length; i++)
			{
				if (_trackEvent[i].nameTrack == nameEvent)
				{
					_trackEvent[i].eventToExecuted.Invoke();

					break;
				}
			}
		}
    }
}


