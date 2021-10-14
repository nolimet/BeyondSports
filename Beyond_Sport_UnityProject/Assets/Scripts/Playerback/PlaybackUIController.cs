using BeyondSports.Playerback;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlaybackUIController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<bool> OnLoadingFirstFrame;

    private PlaybackController playbackController;
    private (long start, long end) frameRange;

    [Inject]
    public void Inject(PlaybackController playbackController)
    {
        this.playbackController = playbackController;
    }

    public async void LoadFirstFrame()
    {
        OnLoadingFirstFrame?.Invoke(true);
        frameRange = await playbackController.LoadFirstFrame();
        OnLoadingFirstFrame?.Invoke(false);
    }

    public async void SetFirstFrame()
    {
        await playbackController.JumpToFrame(frameRange.start);
    }

    public async void JumpToFrame(int value)
    {
        await playbackController.JumpToFrame(value);
    }

    public void SetPlaying(bool isPlaying)
    {
        playbackController.SetPlaying(isPlaying);
    }
}