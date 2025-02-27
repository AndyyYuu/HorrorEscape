
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;  // 当前播放的音频源
    public AudioClip newAudioClip;   // 要播放的新音频

    void Start()
    {
        // 初始化时播放音频（如果需要）
        if (audioSource != null && newAudioClip != null)
        {
            audioSource.Play();
        }
    }

    public void ClickAction(){
        // 检查用户是否点击了鼠标或按下了某个键
        
            PlayNewAudio();
        
    }

    void PlayNewAudio()
    {
        if (audioSource != null && newAudioClip != null)
        {
            // 停止当前播放的音频
            audioSource.Stop();

            // 播放新的音频
            audioSource.clip = newAudioClip;
            audioSource.Play();

            Debug.Log("正在播放新音频...");
        }
        else
        {
            Debug.LogWarning("音频源或音频剪辑为空！");
        }
    }
}
