using UnityEngine;

public class OverrideAnimations : MonoBehaviour 
{
    [SerializeField] Animator animatorToOverride;
    [SerializeField] private AnimatorOverrideController[] overrideControllers;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SkinSelected"))
        {
            OverrideAnimator(PlayerPrefs.GetInt("SkinSelected"));
        }
    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        animatorToOverride.runtimeAnimatorController = overrideController;
    }

    public void OverrideAnimator(int value)
    {
        SetAnimations(overrideControllers[value]);
        PlayerPrefs.SetInt("SkinSelected", value);
    }
}
