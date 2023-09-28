using System;
using System.Runtime.InteropServices;
using CoreMedia;
using ObjCRuntime;
using UIKit;
//using static IJKPlayer.SJPlayer.SJBaseVideoPlayer;

namespace IJKPlayer.SJPlayer
{
    [Native]
    public enum SJOrientation
    {
        Portrait = (int)UIDeviceOrientation.Portrait,
        LandscapeLeft = (int)UIDeviceOrientation.LandscapeLeft,
        LandscapeRight = (int)UIDeviceOrientation.LandscapeRight
    }

    [Flags]
    [Native]
    public enum SJOrientationMask
    {
        Portrait = 1 << SJOrientation.Portrait,
        LandscapeLeft = 1 << SJOrientation.LandscapeLeft,
        LandscapeRight = 1 << SJOrientation.LandscapeRight,
        All = Portrait | LandscapeLeft | LandscapeRight
    }

    [Native]
    public enum SJNetworkStatus
    {
        NotReachable = 0,
        ReachableViaWWAN = 1,
        ReachableViaWiFi = 2
    }

    [Native]
    public enum SJPlaybackType
    {
        Unknown,
        Live,
        Vod,
        File
    }

    [Native]
    public enum SJAssetStatus
    {
        Unknown,
        Preparing,
        ReadyToPlay,
        Failed
    }

    [Native]
    public enum SJPlaybackTimeControlStatus
    {
        Paused,
        WaitingToPlay,
        Playing
    }

    [Native]
    public enum SJDefinitionSwitchStatus
    {
        Unknown,
        Switching,
        Finished,
        Failed
    }

    //[iOS(14, 0)]
    [Native]
    public enum SJPictureInPictureStatus
    {
        Unknown,
        Starting,
        Running,
        Stopping,
        Stopped
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SJSeekingInfo
    {
        public bool isSeeking;

        public CMTime time;
    }

    [Native]
    public enum SJPlayerGestureType
    {
        SingleTap,
        DoubleTap,
        Pan,
        Pinch,
        LongPress
    }

    [Flags]
    [Native]
    public enum SJPlayerGestureTypeMask
    {
        None,
        SingleTap = 1 << SJPlayerGestureType.SingleTap,
        DoubleTap = 1 << SJPlayerGestureType.DoubleTap,
        Pan_H = 0x100,
        Pan_V = 0x200,
        Pan = Pan_H | Pan_V,
        Pinch = 1 << SJPlayerGestureType.Pinch,
        LongPress = 1 << SJPlayerGestureType.LongPress,
        Default = SingleTap | DoubleTap | Pan | Pinch,
        All = Default | LongPress
    }

    [Native]
    public enum SJPanGestureMovingDirection
    {
        H,
        V
    }

    [Native]
    public enum SJPanGestureTriggeredPosition
    {
        Left,
        Right
    }

    [Native]
    public enum SJPanGestureRecognizerState
    {
        Began,
        Changed,
        Ended
    }

    [Native]
    public enum SJLongPressGestureRecognizerState
    {
        Began,
        Changed,
        Ended
    }

    [Native]
    public enum SJViewFlipTransition
    {
        Identity,
        Horizontally
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SJTimeRange
    {
        public double start;

        public double duration;
    }

    static class SJBaseVideoPlayerCFunctions
    {
        // SJTimeRange SJMakeTimeRange (NSTimeInterval start, NSTimeInterval duration);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern SJTimeRange SJMakeTimeRange(double start, double duration);

        // BOOL SJTimeRangeContainsTime (NSTimeInterval time, SJTimeRange range);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern bool SJTimeRangeContainsTime(double time, SJTimeRange range);

        // extern BOOL SJRotationIsFullscreenOrientation (SJOrientation orientation);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern bool SJRotationIsFullscreenOrientation(SJOrientation orientation);

        // extern BOOL SJRotationIsSupportedOrientation (SJOrientation orientation, SJOrientationMask supportedOrientations);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern bool SJRotationIsSupportedOrientation(SJOrientation orientation, SJOrientationMask supportedOrientations);
    }

    [Native]
    public enum SJPlayerEvent
    {
        URLAssetWillChange,
        PlaybackControllerWillDeallocate,
        PlaybackDidPause,
        PlaybackWillStop,
        PlaybackWillRefresh,
        ApplicationDidEnterBackground,
        ApplicationWillTerminate
    }

    [Flags]
    [Native]
    public enum SJPlayerEventMask
    {
        URLAssetWillChange = 1 << SJPlayerEvent.URLAssetWillChange,
        PlaybackControllerWillDeallocate = 1 << SJPlayerEvent.PlaybackControllerWillDeallocate,
        PlaybackDidPause = 1 << SJPlayerEvent.PlaybackDidPause,
        PlaybackWillStop = 1 << SJPlayerEvent.PlaybackWillStop,
        PlaybackWillRefresh = 1 << SJPlayerEvent.PlaybackWillRefresh,
        ApplicationDidEnterBackground = 1 << SJPlayerEvent.ApplicationDidEnterBackground,
        ApplicationWillTerminate = 1 << SJPlayerEvent.ApplicationWillTerminate,
        PlaybackEvents = PlaybackControllerWillDeallocate | PlaybackWillStop | PlaybackWillRefresh | PlaybackDidPause,
        ApplicationEvents = ApplicationDidEnterBackground | ApplicationWillTerminate,
        All = (URLAssetWillChange | PlaybackEvents | ApplicationEvents)
    }

    //[Introduced(PlatformName.iOS, 0xd, 0x0, message: "deprecated!")]
    //[Deprecated(PlatformName.iOS, 0x10, 0x0, message: "deprecated!")]
    [Flags]
    [Native]
    public enum SJSafeAreaInsetsMask
    {
        None = 0x0,
        Top = 1 << 0,
        Left = 1 << 1,
        Bottom = 1 << 2,
        Right = 1 << 3,
        Horizontal = Left | Right,
        Vertical = Top | Right,
        All = Horizontal | Vertical
    }

    [Native]
    public enum SJSmallViewLayoutPosition
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    [Native]
    public enum SJWatermarkLayoutPosition
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    [Native]
    public enum SJVideoPlayerAppState
    {
        Active,
        Inactive,
        Background
    }
}
