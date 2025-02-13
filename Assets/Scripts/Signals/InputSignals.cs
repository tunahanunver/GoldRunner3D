using UnityEngine;
using UnityEngine.Events;

public class InputSignals : MonoBehaviour
{
    #region Singleton
        
        public static InputSignals Instance;
        
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

    #endregion

    public UnityAction<float> onInputTaken = delegate { };
}