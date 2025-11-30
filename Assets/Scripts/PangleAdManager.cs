using System;
using UnityEngine;

public class PangleAdManager : MonoBehaviour
{
    public static PangleAdManager Instance;

    private const string APP_ID = "5760082"; // 从穿山甲平台获取
    private const string REWARD_VIDEO_AD_ID = "103744974"; // 从穿山甲平台获取

    private AndroidJavaObject rewardVideoAd;
    private Action onAdRewardedCallback;
    private Action onAdFailedCallback;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeSDK();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 初始化穿山甲SDK
    /// </summary>
    private void InitializeSDK()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            
            // 初始化穿山甲SDK
            AndroidJavaClass pangleSDK = new AndroidJavaClass("com.bytedance.sdk.openadsdk.api.PAGSdk");
            AndroidJavaObject config = new AndroidJavaClass("com.bytedance.sdk.openadsdk.api.PAGConfig$Builder")
                .Call<AndroidJavaObject>("appId", APP_ID)
                .Call<AndroidJavaObject>("build");
            
            pangleSDK.CallStatic("init", currentActivity, config, new PangleInitCallback());
            
            Debug.Log("穿山甲SDK初始化成功");
        }
        catch (Exception e)
        {
            Debug.LogError("穿山甲SDK初始化失败: " + e.Message);
        }
#else
        Debug.Log("仅在Android平台上初始化穿山甲SDK");
#endif
    }

    /// <summary>
    /// 加载激励视频广告
    /// </summary>
    public void LoadRewardVideoAd()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        try
        {
            AndroidJavaClass rewardVideoAdClass = new AndroidJavaClass("com.bytedance.sdk.openadsdk.api.reward.PAGRewardedAd");
            AndroidJavaObject request = new AndroidJavaClass("com.bytedance.sdk.openadsdk.api.reward.PAGRewardedRequest")
                .Call<AndroidJavaObject>("PAGRewardedRequest");
            
            rewardVideoAdClass.CallStatic("loadAd", REWARD_VIDEO_AD_ID, request, new RewardVideoAdLoadCallback());
            
            Debug.Log("开始加载激励视频广告");
        }
        catch (Exception e)
        {
            Debug.LogError("加载激励视频广告失败: " + e.Message);
        }
#endif
    }

    /// <summary>
    /// 显示激励视频广告
    /// </summary>
    public void ShowRewardVideoAd(Action onRewarded, Action onFailed)
    {
        onAdRewardedCallback = onRewarded;
        onAdFailedCallback = onFailed;

#if UNITY_ANDROID && !UNITY_EDITOR
        if (rewardVideoAd != null)
        {
            try
            {
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                
                rewardVideoAd.Call("show", currentActivity, new RewardVideoAdInteractionCallback());
                
                Debug.Log("显示激励视频广告");
            }
            catch (Exception e)
            {
                Debug.LogError("显示激励视频广告失败: " + e.Message);
                onAdFailedCallback?.Invoke();
            }
        }
        else
        {
            Debug.LogWarning("激励视频广告未加载");
            LoadRewardVideoAd();
            onAdFailedCallback?.Invoke();
        }
#else
        // 编辑器模式下模拟广告观看成功
        Debug.Log("编辑器模式：模拟广告观看成功");
        onRewarded?.Invoke();
#endif
    }

    /// <summary>
    /// 广告加载成功回调
    /// </summary>
    public void OnAdLoaded(AndroidJavaObject ad)
    {
        rewardVideoAd = ad;
        Debug.Log("激励视频广告加载成功");
    }

    /// <summary>
    /// 广告加载失败回调
    /// </summary>
    public void OnAdLoadFailed(int code, string message)
    {
        Debug.LogError($"激励视频广告加载失败: Code={code}, Message={message}");
    }

    /// <summary>
    /// 广告播放完成并获得奖励
    /// </summary>
    public void OnAdRewarded()
    {
        Debug.Log("用户观看完广告，获得奖励");
        onAdRewardedCallback?.Invoke();
    }

    /// <summary>
    /// 广告关闭
    /// </summary>
    public void OnAdClosed()
    {
        Debug.Log("广告关闭");
        // 重新加载广告
        LoadRewardVideoAd();
    }

    /// <summary>
    /// 广告播放失败
    /// </summary>
    public void OnAdFailed()
    {
        Debug.LogError("广告播放失败");
        onAdFailedCallback?.Invoke();
    }
}

// ============ 回调类 ============

/// <summary>
/// SDK初始化回调
/// </summary>
public class PangleInitCallback : AndroidJavaProxy
{
    public PangleInitCallback() : base("com.bytedance.sdk.openadsdk.api.PAGSdk$PAGInitCallback") { }

    public void success()
    {
        Debug.Log("穿山甲SDK初始化成功回调");
    }

    public void fail(int code, string msg)
    {
        Debug.LogError($"穿山甲SDK初始化失败: Code={code}, Message={msg}");
    }
}

/// <summary>
/// 激励视频加载回调
/// </summary>
public class RewardVideoAdLoadCallback : AndroidJavaProxy
{
    public RewardVideoAdLoadCallback() : base("com.bytedance.sdk.openadsdk.api.PAGLoadListener") { }

    public void onAdLoaded(AndroidJavaObject ad)
    {
        if (PangleAdManager.Instance != null)
        {
            PangleAdManager.Instance.OnAdLoaded(ad);
        }
    }

    public void onError(int code, string message)
    {
        if (PangleAdManager.Instance != null)
        {
            PangleAdManager.Instance.OnAdLoadFailed(code, message);
        }
    }
}

/// <summary>
/// 激励视频交互回调
/// </summary>
public class RewardVideoAdInteractionCallback : AndroidJavaProxy
{
    public RewardVideoAdInteractionCallback() : base("com.bytedance.sdk.openadsdk.api.PAGRewardedAdInteractionListener") { }

    public void onAdShowed()
    {
        Debug.Log("广告展示");
    }

    public void onAdClicked()
    {
        Debug.Log("广告被点击");
    }

    public void onAdDismissed()
    {
        if (PangleAdManager.Instance != null)
        {
            PangleAdManager.Instance.OnAdClosed();
        }
    }

    public void onUserEarnedReward(AndroidJavaObject rewardItem)
    {
        if (PangleAdManager.Instance != null)
        {
            PangleAdManager.Instance.OnAdRewarded();
        }
    }

    public void onUserEarnedRewardFail(int code, string msg)
    {
        Debug.LogError($"获得奖励失败: Code={code}, Message={msg}");
        if (PangleAdManager.Instance != null)
        {
            PangleAdManager.Instance.OnAdFailed();
        }
    }
}