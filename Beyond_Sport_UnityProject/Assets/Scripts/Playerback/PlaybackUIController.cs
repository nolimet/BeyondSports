using BeyondSports.Playerback;
using UnityEngine;
using Zenject;

public class PlaybackUIController : MonoBehaviour
{
    private PlaybackController playbackController;
    private (long start, long end) frameRange;

    [Inject]
    public void Inject(PlaybackController playbackController)
    {
        this.playbackController = playbackController;
    }

    public async void LoadFirstFrame()
    {
        frameRange = await playbackController.LoadFirstFrame();
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