using System;
using System.Runtime.InteropServices;
using CoreVideo;
using ObjCRuntime;

namespace IJKPlayer.SJPlayer;

#region IJKMediaEnums

    [Native]
    public enum IJKMPMovieScalingMode : long
    {
        None,
        AspectFit,
        AspectFill,
        Fill
    }

    [Native]
    public enum IJKMPMoviePlaybackState : long
    {
        Stopped,
        Playing,
        Paused,
        Interrupted,
        SeekingForward,
        SeekingBackward
    }

    [Native]
    public enum IJKMPMovieLoadState : ulong
    {
        Unknown = 0,
        Playable = 1 << 0,
        PlaythroughOK = 1 << 1,
        Stalled = 1 << 2
    }

    [Native]
    public enum IJKMPMovieFinishReason : long
    {
        PlaybackEnded,
        PlaybackError,
        UserExited
    }

    [Native]
    public enum IJKMPMovieTimeOption : long
    {
        NearestKeyFrame,
        Exact
    }

    [Native]
    public enum IJKMediaEvent : long
    {
        Event_WillHttpOpen = 1,
        Event_DidHttpOpen = 2,
        Event_WillHttpSeek = 3,
        Event_DidHttpSeek = 4,
        Ctrl_WillTcpOpen = 131073,
        Ctrl_DidTcpOpen = 131074,
        Ctrl_WillHttpOpen = 131075,
        Ctrl_WillLiveOpen = 131077,
        Ctrl_WillConcatSegmentOpen = 131079
    }

    public enum IJKFFOptionCategory : long
    {
        Format = 1,
        Codec = 2,
        Sws = 3,
        Player = 4,
        Swr = 5
    }

    public enum IJKAVDiscard
    {
        None = -16,
        Default = 0,
        Nonref = 8,
        Bidir = 16,
        Nonkey = 32,
        All = 48
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct IJKOverlay
    {
        public int w;

        public int h;

        public uint format;

        public int planes;

        public unsafe ushort pitches;

        public unsafe byte pixels;

        public int sar_num;

        public int sar_den;

        public unsafe CVPixelBuffer pixel_buffer;
    }

    public enum IJKLogLevel : long
    {
        Unknown = 0,
        Default = 1,
        Verbose = 2,
        Debug = 3,
        Info = 4,
        Warn = 5,
        Error = 6,
        Fatal = 7,
        Silent = 8
    }

    //static class CFunctions
    //{
    //    // extern void IJKFFIOStatDebugCallback (const char *url, int type, int bytes);
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatDebugCallback(sbyte url, int type, int bytes);

    //    // extern void IJKFFIOStatRegister (void (* cb)(const char *, int, int));
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatRegister(Action<sbyte, int, int> cb);

    //    // extern void IJKFFIOStatCompleteDebugCallback (const char *url, int64_t read_bytes, int64_t total_size, int64_t elpased_time, int64_t total_duration);
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatCompleteDebugCallback(sbyte* url, long read_bytes, long total_size, long elpased_time, long total_duration);

    //    // extern void IJKFFIOStatCompleteRegister (void (* cb)(const char *, int64_t, int64_t, int64_t, int64_t));
    //    [DllImport("__Internal")]
    //    static extern unsafe void IJKFFIOStatCompleteRegister(Action<sbyte, long, long, long, long> cb);
    //}

#endregion

#region SJUIKitEnums

    [Native]
    public enum SJUTVerticalAlignment : ulong
    {
        Default = 0,
        Center = 1
    }

    [Native]
    public enum SJAttributeRegexpInsertPosition : ulong
    {
        Left,
        Right
    }

    static class SJUIKitCFunctions
    {
        // extern NSMutableAttributedString * _Nonnull sj_makeAttributesString (void (^ _Nonnull)(SJAttributeWorker * _Nonnull) block);
        //[DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //static extern NSMutableAttributedString sj_makeAttributesString(SJAttributeWorkerArgumentAction block);

        // extern NSMutableAttributedString * _Nonnull sj_makeAttributesString (void (^ _Nonnull)(SJAttributeWorker *) block);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSMutableAttributedString sj_makeAttributesString(SJAttributeWorkerArgumentAction? block);

        // extern BOOL SJUTRangeContains (NSRange main, NSRange sub);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern bool SJUTRangeContains(NSRange main, NSRange sub);

        // extern NSRange SJUTGetTextRange (NSAttributedString * _Nonnull text);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSRange SJUTGetTextRange(NSAttributedString text);

        // extern SJKVOObserverToken sjkvo_observe (id _Nonnull target, NSString * _Nonnull keyPath, SJKVOObservedChangeHandler _Nonnull handler);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern nint sjkvo_observe(NSObject target, NSString keyPath, SJKVOObservedChangeHandler handler);

        // extern SJKVOObserverToken sjkvo_observe (id _Nonnull target, NSString * _Nonnull keyPath, NSKeyValueObservingOptions options, SJKVOObservedChangeHandler _Nonnull handler) __attribute__((overloadable));
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern nint sjkvo_observe(NSObject target, NSString keyPath, NSKeyValueObservingOptions options, SJKVOObservedChangeHandler handler);

        // extern void sjkvo_remove (id _Nonnull target, SJKVOObserverToken token);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern void sjkvo_remove(NSObject target, nint token);

        // extern NSString * _Nonnull sj_sqlite3_obj_get_default_table_name (Class _Nonnull cls);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_obj_get_default_table_name(Class cls);

        // extern id _Nonnull sj_sqlite3_obj_filter_obj_value (id _Nonnull value);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSObject sj_sqlite3_obj_filter_obj_value(NSObject value);

        // extern NSString * _Nonnull sj_sqlite3_stmt_create_table (SJSQLiteTableInfo * _Nonnull table);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_create_table(SJSQLiteTableInfo table);

        // extern NSString * _Nonnull sj_sqlite3_stmt_insert_or_update (SJSQLiteObjectInfo * _Nonnull objInfo);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_insert_or_update(SJSQLiteObjectInfo objInfo);

        // extern NSString * _Nonnull sj_sqlite3_stmt_get_column_value (SJSQLiteColumnInfo * _Nonnull column, id _Nonnull value);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_get_column_value(SJSQLiteColumnInfo column, NSObject value);

        // extern NSString * _Nullable sj_sqlite3_stmt_get_primary_values_json_string (NSArray * _Nonnull models, NSString * _Nonnull primaryKey);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke), Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        static extern NSString sj_sqlite3_stmt_get_primary_values_json_string(NSObject[] models, NSString primaryKey);

        // extern NSArray<id> * _Nullable sj_sqlite3_stmt_get_primary_values_array (NSString * _Nonnull jsonString);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //[return: NullAllowed]
        static extern NSObject[] sj_sqlite3_stmt_get_primary_values_array(NSString jsonString);

        // extern NSString * _Nonnull sj_sqlite3_stmt_get_last_row (SJSQLiteTableInfo * _Nonnull table);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSString sj_sqlite3_stmt_get_last_row(SJSQLiteTableInfo table);

        // extern int sj_sqlite3_obj_exec_each_result_callback (void * _Nonnull para, int ncolumn, char * _Nullable * _Nullable columnvalue, char * _Nullable * _Nullable columnname);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe int sj_sqlite3_obj_exec_each_result_callback(void* para, int ncolumn, sbyte** columnvalue, sbyte** columnname);

        // extern BOOL sj_sqlite3_obj_open_database (NSString * _Nonnull path, void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe bool sj_sqlite3_obj_open_database(NSString path, void* db);

        // extern BOOL sj_sqlite3_obj_close_database (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe bool sj_sqlite3_obj_close_database(void* db);

        // extern NSArray<NSDictionary *> * _Nullable sj_sqlite3_obj_exec (void * _Nonnull db, NSString * _Nonnull sql, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //[return: NullAllowed]
        static extern unsafe NSDictionary[] sj_sqlite3_obj_exec(void* db, NSString sql, out NSError error);

        // extern void sj_sqlite3_obj_begin_transaction (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_begin_transaction(void* db);

        // extern void sj_sqlite3_obj_commit (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_commit(void* db);

        // extern void sj_sqlite3_obj_rollback (void * _Nonnull db);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_rollback(void* db);

        // extern BOOL sj_sqlite3_obj_table_exists (void * _Nonnull db, NSString * _Nonnull name);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe bool sj_sqlite3_obj_table_exists(void* db, NSString name);

        // extern void sj_sqlite3_obj_drop_table (void * _Nonnull db, NSString * _Nonnull name, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_drop_table(void* db, NSString name, out NSError error);

        // extern void sj_sqlite3_obj_delete_row_datas (void * _Nonnull db, SJSQLiteTableInfo * _Nonnull table, NSArray<id> * _Nonnull primaryKeyValues, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern unsafe void sj_sqlite3_obj_delete_row_datas(void* db, SJSQLiteTableInfo table, NSObject[] primaryKeyValues, out NSError error);

        // extern NSDictionary * _Nullable sj_sqlite3_obj_get_row_data (void * _Nonnull db, SJSQLiteTableInfo * _Nonnull table, id _Nonnull primaryKeyValue, NSError * _Nullable * _Nullable error);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        //[return: NullAllowed]
        static extern unsafe NSDictionary sj_sqlite3_obj_get_row_data(void* db, SJSQLiteTableInfo table, NSObject primaryKeyValue, out NSError error);

        // extern NSArray<id> * _Nonnull SJFoundationExtendedValuesForKey (NSString * _Nonnull key, NSArray<NSDictionary *> * _Nonnull array);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSObject[] SJFoundationExtendedValuesForKey(NSString key, NSDictionary[] array);

        // extern NSError * _Nonnull sqlite3_error_make_error (NSString * _Nonnull error_msg);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_make_error(NSString error_msg);

        // extern NSError * _Nonnull sqlite3_error_get_table_failed (Class _Nonnull cls);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_get_table_failed(Class cls);

        // extern NSError * _Nonnull sqlite3_error_get_column_failed (Class _Nonnull cls);
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_get_column_failed(Class cls);

        // extern NSError * _Nonnull sqlite3_error_invalid_parameter ();
        [DllImport("__Internal")]
        //[Verify(PlatformInvoke)]
        static extern NSError sqlite3_error_invalid_parameter();
    }

    [Native]
    public enum SJPresentationPriority : ulong
    {
        Droppable,
        Low,
        Normal,
        High,
        VeryHigh
    }

    [Native]
    public enum SJSQLite3Relation : long
    {
        LessThanOrEqual = -1,
        Equal,
        GreaterThanOrEqual,
        Unequal,
        LessThan,
        GreaterThan
    }

#endregion

#region SJBaseVideoPlayerEnums

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

#endregion

#region SJVideoPlayerEnums


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

#endregion