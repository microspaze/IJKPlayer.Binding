using System;
using System.Runtime.InteropServices;
using CoreMedia;
using ObjCRuntime;
using UIKit;
//using static IJKPlayer.SJPlayer.SJBaseVideoPlayer;

namespace IJKPlayer.SJPlayer
{
    [Native]
    public enum SJOrientation :  ulong
    {
        Portrait = (int)UIDeviceOrientation.Portrait,
        LandscapeLeft = (int)UIDeviceOrientation.LandscapeLeft,
        LandscapeRight = (int)UIDeviceOrientation.LandscapeRight
    }

    [Flags]
    [Native]
    public enum SJOrientationMask : ulong
    {
        Portrait = 1 << (int)SJOrientation.Portrait,
        LandscapeLeft = 1 << (int)SJOrientation.LandscapeLeft,
        LandscapeRight = 1 << (int)SJOrientation.LandscapeRight,
        All = Portrait | LandscapeLeft | LandscapeRight
    }

    [Native]
    public enum SJNetworkStatus : long
    {
        NotReachable = 0,
        ReachableViaWWAN = 1,
        ReachableViaWiFi = 2
    }

    [Native]
    public enum SJPlaybackType : long
    {
        Unknown,
        Live,
        Vod,
        File
    }

    [Native]
    public enum SJAssetStatus : long
    {
        Unknown,
        Preparing,
        ReadyToPlay,
        Failed
    }

    [Native]
    public enum SJPlaybackTimeControlStatus : long
    {
        Paused,
        WaitingToPlay,
        Playing
    }

    [Native]
    public enum SJDefinitionSwitchStatus : long
    {
        Unknown,
        Switching,
        Finished,
        Failed
    }

    //[iOS(14, 0)]
    [Native]
    public enum SJPictureInPictureStatus : ulong
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
    public enum SJPlayerGestureType : ulong
    {
        SingleTap,
        DoubleTap,
        Pan,
        Pinch,
        LongPress
    }

    [Flags]
    [Native]
    public enum SJPlayerGestureTypeMask : ulong
    {
        None,
        SingleTap = 1 << (int)SJPlayerGestureType.SingleTap,
        DoubleTap = 1 << (int)SJPlayerGestureType.DoubleTap,
        Pan_H = 0x100,
        Pan_V = 0x200,
        Pan = Pan_H | Pan_V,
        Pinch = 1 << (int)SJPlayerGestureType.Pinch,
        LongPress = 1 << (int)SJPlayerGestureType.LongPress,
        Default = SingleTap | DoubleTap | Pan | Pinch,
        All = Default | LongPress
    }

    [Native]
    public enum SJPanGestureMovingDirection : ulong
    {
        H,
        V
    }

    [Native]
    public enum SJPanGestureTriggeredPosition : ulong
    {
        Left,
        Right
    }

    [Native]
    public enum SJPanGestureRecognizerState : ulong
    {
        Began,
        Changed,
        Ended
    }

    [Native]
    public enum SJLongPressGestureRecognizerState : ulong
    {
        Began,
        Changed,
        Ended
    }

    [Native]
    public enum SJViewFlipTransition : ulong
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
    public enum SJPlayerEvent : ulong
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
    public enum SJPlayerEventMask : ulong
    {
        URLAssetWillChange = 1 << (int)SJPlayerEvent.URLAssetWillChange,
        PlaybackControllerWillDeallocate = 1 << (int)SJPlayerEvent.PlaybackControllerWillDeallocate,
        PlaybackDidPause = 1 << (int)SJPlayerEvent.PlaybackDidPause,
        PlaybackWillStop = 1 << (int)SJPlayerEvent.PlaybackWillStop,
        PlaybackWillRefresh = 1 << (int)SJPlayerEvent.PlaybackWillRefresh,
        ApplicationDidEnterBackground = 1 << (int)SJPlayerEvent.ApplicationDidEnterBackground,
        ApplicationWillTerminate = 1 << (int)SJPlayerEvent.ApplicationWillTerminate,
        PlaybackEvents = PlaybackControllerWillDeallocate | PlaybackWillStop | PlaybackWillRefresh | PlaybackDidPause,
        ApplicationEvents = ApplicationDidEnterBackground | ApplicationWillTerminate,
        All = (URLAssetWillChange | PlaybackEvents | ApplicationEvents)
    }

    //[Introduced(PlatformName.iOS, 13, 0, message: "deprecated!")]
    //[Deprecated(PlatformName.iOS, 16, 0, message: "deprecated!")]
    [Flags]
    [Native]
    public enum SJSafeAreaInsetsMask : ulong
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
    public enum SJSmallViewLayoutPosition : long
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    [Native]
    public enum SJWatermarkLayoutPosition : ulong
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    [Native]
    public enum SJVideoPlayerAppState : ulong
    {
        Active,
        Inactive,
        Background
    }
}
