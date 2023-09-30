using System;
using System.Runtime.InteropServices;
using ObjCRuntime;
using UIKit;
//using static IJKPlayer.SJPlayer.SJVideoPlayer;

namespace IJKPlayer.SJPlayer
{
    /*
    [Native]
    public enum SJClipsStatus : ulong
    {
        Unknown,
        Recording,
        Cancelled,
        Paused,
        Finished
    }

    [Native]
    public enum SJVideoPlayerClipsOperation : ulong
    {
        Unknown,
        Screenshot,
        Export,
        Gif
    }

    [Native]
    public enum SJClipsResultUploadState : ulong
    {
        Unknown,
        Uploading,
        Failed,
        Successfully,
        Cancelled
    }

    [Native]
    public enum SJClipsExportState : ulong
    {
        Unknown,
        Exporting,
        Failed,
        Success,
        Cancelled
    }

    [Native]
    public enum SJMaskStyle : ulong
    {
        bottom,
        top
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SJEdgeInsets
    {
        public nfloat front;

        public nfloat rear;
    }

    static class SJVideoPlayerCFunctions
    {
        // SJEdgeInsets SJEdgeInsetsMake (CGFloat front, CGFloat rear);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern SJEdgeInsets SJEdgeInsetsMake(nfloat front, nfloat rear);

        // extern BOOL sj_view_isDisappeared (UIView * _Nonnull view);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern bool sj_view_isDisappeared(UIView view);

        // extern void sj_view_initializes (UIView * _Nonnull view);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_initializes(UIView view);

        // extern void sj_view_initializes (NSArray<UIView *> * _Nonnull views) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_initializes(UIView[] views);

        // extern void sj_view_makeAppear (NSArray<UIView *> * _Nonnull views, BOOL animated, void (^ _Nullable)(void) completionHandler);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeAppear(UIView[] views, bool animated, Action? completionHandler);

        // extern void sj_view_makeAppear (UIView * _Nonnull view, BOOL animated) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeAppear(UIView view, bool animated);

        // extern void sj_view_makeAppear (UIView * _Nonnull view, BOOL animated, void (^ _Nullable)(void) completionHandler) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeAppear(UIView view, bool animated, Action? completionHandler);

        // extern void sj_view_makeAppear (NSArray<UIView *> * _Nonnull views, BOOL animated) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeAppear(UIView[] views, bool animated);

        // extern void sj_view_makeDisappear (NSArray<UIView *> * _Nonnull views, BOOL animated, void (^ _Nullable)(void) completionHandler);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeDisappear(UIView[] views, bool animated, Action? completionHandler);

        // extern void sj_view_makeDisappear (UIView * _Nonnull view, BOOL animated) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeDisappear(UIView view, bool animated);

        // extern void sj_view_makeDisappear (UIView * _Nonnull view, BOOL animated, void (^ _Nullable)(void) completionHandler) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeDisappear(UIView view, bool animated, Action? completionHandler);

        // extern void sj_view_makeDisappear (NSArray<UIView *> * _Nonnull views, BOOL animated) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sj_view_makeDisappear(UIView[] views, bool animated);
    }

    [Native]
    public enum SJButtonItemPlaceholderType : ulong
    {
        Unknown,
        SJButtonItemPlaceholderType_49x49,
        SJButtonItemPlaceholderType_49xAutoresizing,
        SJButtonItemPlaceholderType_49xFill,
        SJButtonItemPlaceholderType_49xSpecifiedSize
    }

    [Native]
    public enum SJAdapterLayoutType : ulong
    {
        VerticalLayout,
        HorizontalLayout,
        FrameLayout
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SJ_Screen
    {
        public nfloat max;

        public nfloat min;

        public bool is_iPhoneXSeries;
    }

    [Native]
    public enum SJDraggingProgressPopupViewStyle : ulong
    {
        Normal,
        Fullscreen,
        FitOnScreen
    }

    [Native]
    public enum SJViewDisappearAnimation : ulong
    {
        None,
        Top,
        Left,
        Bottom,
        Right,
        HorizontalScaling,
        VerticalScaling
    }

    [Native]
    public enum SJClipsSaveResultToAlbumFailedReason : ulong
    {
        SJClipsSaveResultToAlbumFailedReasonAuthDenied
    }
    */
}
