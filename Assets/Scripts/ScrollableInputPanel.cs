using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScrollableInputPanel : MonoBehaviour 
{

    // adapted from: https://stackoverflow.com/questions/35072522/how-to-resize-view-when-touchscreen-keyboard-is-visible-on-android-with-unity
    
    // Assign panel here in order to adjust its height when TouchScreenKeyboard is shown
    public GameObject panel;

    private TMP_InputField  inputField;
    private RectTransform panelRectTrans;
    private Vector2 panelOffsetMinOriginal;
    private float panelHeightOriginal;
    private float currentKeyboardHeightRatio;

    public void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField >();
        panelRectTrans = panel.GetComponent<RectTransform>();
        panelOffsetMinOriginal = panelRectTrans.offsetMin;
        panelHeightOriginal = panelRectTrans.rect.height;
    }

    public void LateUpdate()
    {
        if (inputField.isFocused)
        {
            float newKeyboardHeightRatio = GetKeyboardHeightRatio();
            if (currentKeyboardHeightRatio != newKeyboardHeightRatio)
            {
                currentKeyboardHeightRatio = newKeyboardHeightRatio;
                panelRectTrans.offsetMin = new Vector2(panelOffsetMinOriginal.x, panelHeightOriginal * currentKeyboardHeightRatio);
            }
        }   
        else if (currentKeyboardHeightRatio != 0f)
        {
            if (panelRectTrans.offsetMin != panelOffsetMinOriginal)
            {
                Invoke("DelayedReset", 0.3f);
            }
            currentKeyboardHeightRatio = 0f;
        }
    }

    private float GetKeyboardHeightRatio()
    {
        
        if (Application.isEditor) {
            return 0.0f; // adjust value to replicate effect in editor        
        }

        #if UNITY_ANDROID        
            using (AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");
                using (AndroidJavaObject rect = new AndroidJavaObject("android.graphics.Rect"))
                {
                    View.Call("getWindowVisibleDisplayFrame", rect);
                    return (float)(Screen.height - rect.Call<int>("height")) / Screen.height;
                }
            }
        #else
            return (float)TouchScreenKeyboard.area.height / Screen.height;
        #endif

    }

    private void DelayedReset()
    {
        panelRectTrans.offsetMin = panelOffsetMinOriginal; 
    }

}