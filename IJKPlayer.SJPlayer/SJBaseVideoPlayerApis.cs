using System;
using AVFoundation;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using Foundation;
using ObjCRuntime;
//using static IJKPlayer.SJPlayer.SJBaseVideoPlayer;
//using static IJKPlayer.SJPlayer.SJUIKit;
using UIKit;

namespace IJKPlayer.SJPlayer
{
    // common argument actions
    delegate void SJFitOnScreenManagerArgumentAction(SJFitOnScreenManager arg0);
    delegate void SJRotationManagerArgumentAction(SJRotationManager arg0);
    delegate void SJFlipTransitionManagerArgumentAction(SJFlipTransitionManager arg0);
    
    // @protocol SJFitOnScreenManager <NSObject>
    /*
      Check whether adding [Model] to this declaration is appropriate.
      [Model] is used to generate a C# class that implements this protocol,
      and might be useful for protocols that consumers are supposed to implement,
      since consumers can subclass the generated class instead of implementing
      the generated interface. If consumers are not supposed to implement this
      protocol, then [Model] is redundant and will generate code that will never
      be used.
    */
    [Protocol]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ISJFitOnScreenManager
    {
        // @required -(instancetype _Nonnull)initWithTarget:(UIView * _Nonnull)target targetSuperview:(UIView * _Nonnull)superview;
        [Abstract]
        [Export("initWithTarget:targetSuperview:")]
        NativeHandle Constructor(UIView target, UIView superview);

        // @required -(id<SJFitOnScreenManagerObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJFitOnScreenManagerObserver Observer();

        // @required @property (readonly, getter = isTransitioning, nonatomic) BOOL transitioning;
        [Abstract]
        [Export("transitioning")]
        bool Transitioning { [Bind("isTransitioning")] get; }

        // @required @property (nonatomic) NSTimeInterval duration;
        [Abstract]
        [Export("duration")]
        double Duration { get; set; }

        // @required @property (getter = isFitOnScreen, nonatomic) BOOL fitOnScreen;
        [Abstract]
        [Export("fitOnScreen")]
        bool FitOnScreen { [Bind("isFitOnScreen")] get; set; }

        // @required -(void)setFitOnScreen:(BOOL)fitOnScreen animated:(BOOL)animated;
        [Abstract]
        [Export("setFitOnScreen:animated:")]
        void SetFitOnScreen(bool fitOnScreen, bool animated);

        // @required -(void)setFitOnScreen:(BOOL)fitOnScreen animated:(BOOL)animated completionHandler:(void (^ _Nullable)(id<SJFitOnScreenManager> _Nonnull))completionHandler;
        [Abstract]
        [Export("setFitOnScreen:animated:completionHandler:")]
        void SetFitOnScreen(bool fitOnScreen, bool animated, SJFitOnScreenManagerArgumentAction completionHandler);

        // @required @property (readonly, nonatomic, strong) UIView * _Nonnull superviewInFitOnScreen;
        [Abstract]
        [Export("superviewInFitOnScreen", ArgumentSemantic.Strong)]
        UIView SuperviewInFitOnScreen();
    }

    // @protocol SJFitOnScreenManagerObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJFitOnScreenManagerObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJFitOnScreenManager> _Nonnull) fitOnScreenWillBeginExeBlock;
        [Abstract]
        [NullAllowed, Export("fitOnScreenWillBeginExeBlock", ArgumentSemantic.Copy)]
        Action<SJFitOnScreenManager> FitOnScreenWillBeginExeBlock { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJFitOnScreenManager> _Nonnull) fitOnScreenDidEndExeBlock;
        [Abstract]
        [NullAllowed, Export("fitOnScreenDidEndExeBlock", ArgumentSemantic.Copy)]
        Action<SJFitOnScreenManager> FitOnScreenDidEndExeBlock { get; set; }
    }

    // @protocol SJRotationManager <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJRotationManager
    {
        // @required -(id<SJRotationManagerObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJRotationManagerObserver Observer();

        // @required @property (copy, nonatomic) BOOL (^ _Nullable)(id<SJRotationManager> _Nonnull) shouldTriggerRotation;
        [Abstract]
        [NullAllowed, Export("shouldTriggerRotation", ArgumentSemantic.Copy)]
        Func<SJRotationManager, bool> ShouldTriggerRotation { get; set; }

        // @required @property (getter = isDisabledAutorotation, nonatomic) BOOL disabledAutorotation;
        [Abstract]
        [Export("disabledAutorotation")]
        bool DisabledAutorotation { [Bind("isDisabledAutorotation")] get; set; }

        // @required @property (nonatomic) SJOrientationMask autorotationSupportedOrientations;
        [Abstract]
        [Export("autorotationSupportedOrientations", ArgumentSemantic.Assign)]
        SJOrientationMask AutorotationSupportedOrientations { get; set; }

        // @required -(void)rotate;
        [Abstract]
        [Export("rotate")]
        void Rotate();

        // @required -(void)rotate:(SJOrientation)orientation animated:(BOOL)animated;
        [Abstract]
        [Export("rotate:animated:")]
        void Animated(SJOrientation orientation, bool animated);

        // @required -(void)rotate:(SJOrientation)orientation animated:(BOOL)animated completionHandler:(void (^ _Nullable)(id<SJRotationManager> _Nonnull))completionHandler;
        [Abstract]
        [Export("rotate:animated:completionHandler:")]
        void Animated(SJOrientation orientation, bool animated, SJRotationManagerArgumentAction completionHandler);

        // @required @property (readonly, nonatomic) SJOrientation currentOrientation;
        [Abstract]
        [Export("currentOrientation")]
        SJOrientation CurrentOrientation();

        // @required @property (readonly, nonatomic) BOOL isFullscreen;
        [Abstract]
        [Export("isFullscreen")]
        bool IsFullscreen();

        // @required @property (readonly, getter = isRotating, nonatomic) BOOL rotating;
        [Abstract]
        [Export("rotating")]
        bool Rotating { [Bind("isRotating")] get; }

        // @required @property (readonly, getter = isTransitioning, nonatomic) BOOL transitioning;
        [Abstract]
        [Export("transitioning")]
        bool Transitioning { [Bind("isTransitioning")] get; }

        // @required @property (nonatomic, weak) UIView * _Nullable superview;
        [Abstract]
        [NullAllowed, Export("superview", ArgumentSemantic.Weak)]
        UIView Superview { get; set; }

        // @required @property (nonatomic, weak) UIView * _Nullable target;
        [Abstract]
        [NullAllowed, Export("target", ArgumentSemantic.Weak)]
        UIView Target { get; set; }
    }

    // @protocol SJRotationManagerProtocol <SJRotationManager>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJRotationManagerProtocol : ISJRotationManager
    {
    }

    // @protocol SJRotationManagerObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJRotationManagerObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJRotationManager> _Nonnull, BOOL) onRotatingChanged;
        [Abstract]
        [NullAllowed, Export("onRotatingChanged", ArgumentSemantic.Copy)]
        Action<SJRotationManager, bool> OnRotatingChanged { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJRotationManager> _Nonnull, BOOL) onTransitioningChanged;
        [Abstract]
        [NullAllowed, Export("onTransitioningChanged", ArgumentSemantic.Copy)]
        Action<SJRotationManager, bool> OnTransitioningChanged { get; set; }
    }

    // @protocol SJReachability <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJReachability
    {
        // @required -(id<SJReachabilityObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJReachabilityObserver Observer();

        // @required @property (readonly, nonatomic) SJNetworkStatus networkStatus;
        [Abstract]
        [Export("networkStatus")]
        SJNetworkStatus NetworkStatus();

        // @required @property (readonly, nonatomic, strong) NSString * _Nonnull networkSpeedStr;
        [Abstract]
        [Export("networkSpeedStr", ArgumentSemantic.Strong)]
        string NetworkSpeedStr();

        // @required -(void)startRefresh;
        [Abstract]
        [Export("startRefresh")]
        void StartRefresh();

        // @required -(void)stopRefresh;
        [Abstract]
        [Export("stopRefresh")]
        void StopRefresh();
    }

    // @protocol SJReachabilityObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJReachabilityObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJReachability> _Nonnull) networkStatusDidChangeExeBlock;
        [Abstract]
        [NullAllowed, Export("networkStatusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJReachability> NetworkStatusDidChangeExeBlock { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJReachability> _Nonnull) networkSpeedDidChangeExeBlock;
        [Abstract]
        [NullAllowed, Export("networkSpeedDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJReachability> NetworkSpeedDidChangeExeBlock { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJWaitingReason _Nonnull SJWaitingToMinimizeStallsReason;
        [Field("SJWaitingToMinimizeStallsReason", "__Internal")]
        NSString SJWaitingToMinimizeStallsReason { get; }

        // extern const SJWaitingReason _Nonnull SJWaitingWhileEvaluatingBufferingRateReason;
        [Field("SJWaitingWhileEvaluatingBufferingRateReason", "__Internal")]
        NSString SJWaitingWhileEvaluatingBufferingRateReason { get; }

        // extern const SJWaitingReason _Nonnull SJWaitingWithNoAssetToPlayReason;
        [Field("SJWaitingWithNoAssetToPlayReason", "__Internal")]
        NSString SJWaitingWithNoAssetToPlayReason { get; }

        // extern const SJFinishedReason _Nonnull SJFinishedReasonToEndTimePosition;
        [Field("SJFinishedReasonToEndTimePosition", "__Internal")]
        NSString SJFinishedReasonToEndTimePosition { get; }

        // extern const SJFinishedReason _Nonnull SJFinishedReasonToTrialEndPosition;
        [Field("SJFinishedReasonToTrialEndPosition", "__Internal")]
        NSString SJFinishedReasonToTrialEndPosition { get; }
    }

    // @protocol SJPictureInPictureController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    //[iOS(14, 0)]
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJPictureInPictureController
    {
        // @required +(BOOL)isPictureInPictureSupported;
        [Static, Abstract]
        [Export("isPictureInPictureSupported")]
        //[Verify(MethodToProperty)]
        bool IsPictureInPictureSupported();

        // @required @property (nonatomic) BOOL requiresLinearPlayback;
        [Abstract]
        [Export("requiresLinearPlayback")]
        bool RequiresLinearPlayback { get; set; }

        // @required @property (nonatomic) BOOL canStartPictureInPictureAutomaticallyFromInline __attribute__((availability(ios, introduced=14.2)));
        //[iOS(14, 2)]
        [Abstract]
        [Export("canStartPictureInPictureAutomaticallyFromInline")]
        bool CanStartPictureInPictureAutomaticallyFromInline { get; set; }

        [Wrap("WeakDelegate"), Abstract]
        [NullAllowed]
        SJPictureInPictureControllerDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<SJPictureInPictureControllerDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required @property (readonly, nonatomic) SJPictureInPictureStatus status;
        [Abstract]
        [Export("status")]
        SJPictureInPictureStatus Status();

        // @required -(void)startPictureInPicture;
        [Abstract]
        [Export("startPictureInPicture")]
        void StartPictureInPicture();

        // @required -(void)stopPictureInPicture;
        [Abstract]
        [Export("stopPictureInPicture")]
        void StopPictureInPicture();
    }

    // @protocol SJPictureInPictureControllerDelegate <NSObject>
    //[iOS(14, 0)]
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJPictureInPictureControllerDelegate
    {
        // @required -(void)pictureInPictureController:(id<SJPictureInPictureController> _Nonnull)controller statusDidChange:(SJPictureInPictureStatus)status;
        [Abstract]
        [Export("pictureInPictureController:statusDidChange:")]
        void StatusDidChange(SJPictureInPictureController controller, SJPictureInPictureStatus status);

        // @required -(void)pictureInPictureController:(id<SJPictureInPictureController> _Nonnull)controller restoreUserInterfaceForPictureInPictureStopWithCompletionHandler:(void (^ _Nonnull)(BOOL))completionHandler;
        [Abstract]
        [Export("pictureInPictureController:restoreUserInterfaceForPictureInPictureStopWithCompletionHandler:")]
        void RestoreUserInterfaceForPictureInPictureStopWithCompletionHandler(SJPictureInPictureController controller, Action<bool> completionHandler);
    }

    // @protocol SJVideoPlayerPlaybackController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerPlaybackController
    {
        // @required @property (nonatomic) NSTimeInterval periodicTimeInterval;
        [Abstract]
        [Export("periodicTimeInterval")]
        double PeriodicTimeInterval { get; set; }

        // @required @property (nonatomic) NSTimeInterval minBufferedDuration;
        [Abstract]
        [Export("minBufferedDuration")]
        double MinBufferedDuration { get; set; }

        // @required @property (readonly, nonatomic, strong) NSError * _Nullable error;
        [Abstract]
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error();

        [Wrap("WeakDelegate"), Abstract]
        [NullAllowed]
        SJVideoPlayerPlaybackControllerDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<SJVideoPlayerPlaybackControllerDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required @property (readonly, nonatomic) SJPlaybackType playbackType;
        [Abstract]
        [Export("playbackType")]
        SJPlaybackType PlaybackType();

        // @required @property (readonly, nonatomic, strong) __kindof UIView * _Nonnull playerView;
        [Abstract]
        [Export("playerView", ArgumentSemantic.Strong)]
        UIView PlayerView();

        // @required @property (nonatomic, strong) id<SJMediaModelProtocol> _Nullable media;
        [Abstract]
        [NullAllowed, Export("media", ArgumentSemantic.Strong)]
        SJMediaModelProtocol Media { get; set; }

        // @required @property (nonatomic, strong) SJVideoGravity _Nonnull videoGravity;
        [Abstract]
        [Export("videoGravity", ArgumentSemantic.Strong)]
        string VideoGravity { get; set; }

        // @required @property (readonly, nonatomic) SJAssetStatus assetStatus;
        [Abstract]
        [Export("assetStatus")]
        SJAssetStatus AssetStatus();

        // @required @property (readonly, nonatomic) SJPlaybackTimeControlStatus timeControlStatus;
        [Abstract]
        [Export("timeControlStatus")]
        SJPlaybackTimeControlStatus TimeControlStatus();

        // @required @property (readonly, nonatomic) SJWaitingReason _Nullable reasonForWaitingToPlay;
        [Abstract]
        [NullAllowed, Export("reasonForWaitingToPlay")]
        string ReasonForWaitingToPlay();

        // @required @property (readonly, nonatomic) NSTimeInterval currentTime;
        [Abstract]
        [Export("currentTime")]
        double CurrentTime();

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Abstract]
        [Export("duration")]
        double Duration();

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Abstract]
        [Export("playableDuration")]
        double PlayableDuration();

        // @required @property (readonly, nonatomic) NSTimeInterval durationWatched;
        [Abstract]
        [Export("durationWatched")]
        double DurationWatched();

        // @required @property (readonly, nonatomic) CGSize presentationSize;
        [Abstract]
        [Export("presentationSize")]
        CGSize PresentationSize();

        // @required @property (readonly, getter = isReadyForDisplay, nonatomic) BOOL readyForDisplay;
        [Abstract]
        [Export("readyForDisplay")]
        bool ReadyForDisplay { [Bind("isReadyForDisplay")] get; }

        // @required @property (nonatomic) float volume;
        [Abstract]
        [Export("volume")]
        float Volume { get; set; }

        // @required @property (nonatomic) float rate;
        [Abstract]
        [Export("rate")]
        float Rate { get; set; }

        // @required @property (getter = isMuted, nonatomic) BOOL muted;
        [Abstract]
        [Export("muted")]
        bool Muted { [Bind("isMuted")] get; set; }

        // @required @property (readonly, nonatomic) BOOL isPlayed;
        [Abstract]
        [Export("isPlayed")]
        bool IsPlayed();

        // @required @property (readonly, getter = isReplayed, nonatomic) BOOL replayed;
        [Abstract]
        [Export("replayed")]
        bool Replayed { [Bind("isReplayed")] get; }

        // @required @property (readonly, nonatomic) BOOL isPlaybackFinished;
        [Abstract]
        [Export("isPlaybackFinished")]
        bool IsPlaybackFinished();

        // @required @property (readonly, nonatomic) SJFinishedReason _Nullable finishedReason;
        [Abstract]
        [NullAllowed, Export("finishedReason")]
        string FinishedReason();

        // @required -(void)prepareToPlay;
        [Abstract]
        [Export("prepareToPlay")]
        void PrepareToPlay();

        // @required -(void)replay;
        [Abstract]
        [Export("replay")]
        void Replay();

        // @required -(void)refresh;
        [Abstract]
        [Export("refresh")]
        void Refresh();

        // @required -(void)play;
        [Abstract]
        [Export("play")]
        void Play();

        // @required @property (nonatomic) BOOL pauseWhenAppDidEnterBackground;
        [Abstract]
        [Export("pauseWhenAppDidEnterBackground")]
        bool PauseWhenAppDidEnterBackground { get; set; }

        // @required -(void)pause;
        [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)stop;
        [Abstract]
        [Export("stop")]
        void Stop();

        // @required -(void)seekToTime:(NSTimeInterval)secs completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Abstract]
        [Export("seekToTime:completionHandler:")]
        void SeekToTime(double secs, BoolArgumentAction completionHandler);

        // @required -(void)seekToTime:(CMTime)time toleranceBefore:(CMTime)toleranceBefore toleranceAfter:(CMTime)toleranceAfter completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Abstract]
        [Export("seekToTime:toleranceBefore:toleranceAfter:completionHandler:")]
        void SeekToTime(CMTime time, CMTime toleranceBefore, CMTime toleranceAfter, BoolArgumentAction completionHandler);

        // @required -(UIImage * _Nullable)screenshot;
        [Abstract]
        [NullAllowed, Export("screenshot")]
        //[Verify(MethodToProperty)]
        UIImage Screenshot();

        // @required -(void)switchVideoDefinition:(id<SJMediaModelProtocol> _Nonnull)media;
        [Abstract]
        [Export("switchVideoDefinition:")]
        void SwitchVideoDefinition(SJMediaModelProtocol media);

        // @required -(BOOL)isPictureInPictureSupported __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("isPictureInPictureSupported")]
        //[Verify(MethodToProperty)]
        bool IsPictureInPictureSupported();

        // @required @property (nonatomic) BOOL requiresLinearPlaybackInPictureInPicture __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("requiresLinearPlaybackInPictureInPicture")]
        bool RequiresLinearPlaybackInPictureInPicture { get; set; }

        // @required @property (nonatomic) BOOL canStartPictureInPictureAutomaticallyFromInline __attribute__((availability(ios, introduced=14.2)));
        //[iOS(14, 2)]
        [Abstract]
        [Export("canStartPictureInPictureAutomaticallyFromInline")]
        bool CanStartPictureInPictureAutomaticallyFromInline { get; set; }

        // @required @property (readonly, nonatomic) SJPictureInPictureStatus pictureInPictureStatus __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("pictureInPictureStatus")]
        SJPictureInPictureStatus PictureInPictureStatus();

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJVideoPlayerPlaybackController> _Nonnull, void (^ _Nonnull)(BOOL)) restoreUserInterfaceForPictureInPictureStop;
        [Abstract]
        [NullAllowed, Export("restoreUserInterfaceForPictureInPictureStop", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerPlaybackController, BoolArgumentAction> RestoreUserInterfaceForPictureInPictureStop { get; set; }

        // @required -(void)startPictureInPicture __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("startPictureInPicture")]
        void StartPictureInPicture();

        // @required -(void)stopPictureInPicture __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("stopPictureInPicture")]
        void StopPictureInPicture();

        // @required -(void)cancelPictureInPicture __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("cancelPictureInPicture")]
        void CancelPictureInPicture();
    }

    // @protocol SJMediaPlaybackScreenshotController
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface ISJMediaPlaybackScreenshotController
    {
        // @required -(void)screenshotWithTime:(NSTimeInterval)time size:(CGSize)size completion:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, UIImage * _Nullable, NSError * _Nullable))block;
        [Abstract]
        [Export("screenshotWithTime:size:completion:")]
        void Size(double time, CGSize size, Action<SJVideoPlayerPlaybackController, UIImage, NSError> block);
    }

    // @protocol SJMediaPlaybackExportController
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface ISJMediaPlaybackExportController
    {
        // @required -(void)exportWithBeginTime:(NSTimeInterval)beginTime duration:(NSTimeInterval)duration presetName:(NSString * _Nullable)presetName progress:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, float))progress completion:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, NSURL * _Nullable, UIImage * _Nullable))completion failure:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, NSError * _Nullable))failure;
        [Abstract]
        [Export("exportWithBeginTime:duration:presetName:progress:completion:failure:")]
        void ExportWithBeginTime(double beginTime, double duration, string presetName, Action<SJVideoPlayerPlaybackController, float> progress, Action<SJVideoPlayerPlaybackController, NSUrl, UIImage> completion, Action<SJVideoPlayerPlaybackController, NSError> failure);

        // @required -(void)generateGIFWithBeginTime:(NSTimeInterval)beginTime duration:(NSTimeInterval)duration maximumSize:(CGSize)maximumSize interval:(float)interval gifSavePath:(NSURL * _Nonnull)gifSavePath progress:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, float))progressBlock completion:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, UIImage * _Nonnull, UIImage * _Nonnull))completion failure:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, NSError * _Nonnull))failure;
        [Abstract]
        [Export("generateGIFWithBeginTime:duration:maximumSize:interval:gifSavePath:progress:completion:failure:")]
        void GenerateGIFWithBeginTime(double beginTime, double duration, CGSize maximumSize, float interval, NSUrl gifSavePath, Action<SJVideoPlayerPlaybackController, float> progressBlock, Action<SJVideoPlayerPlaybackController, UIImage, UIImage> completion, Action<SJVideoPlayerPlaybackController, NSError> failure);

        // @required -(void)cancelExportOperation;
        [Abstract]
        [Export("cancelExportOperation")]
        void CancelExportOperation();

        // @required -(void)cancelGenerateGIFOperation;
        [Abstract]
        [Export("cancelGenerateGIFOperation")]
        void CancelGenerateGIFOperation();
    }

    // @protocol SJVideoPlayerPlaybackControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerPlaybackControllerDelegate
    {
        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller assetStatusDidChange:(SJAssetStatus)status;
        [Export("playbackController:assetStatusDidChange:")]
        void PlaybackControllerAssetStatusDidChange(SJVideoPlayerPlaybackController controller, SJAssetStatus status);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller timeControlStatusDidChange:(SJPlaybackTimeControlStatus)status;
        [Export("playbackController:timeControlStatusDidChange:")]
        void PlaybackControllerTimeControlStatusDidChange(SJVideoPlayerPlaybackController controller, SJPlaybackTimeControlStatus status);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller volumeDidChange:(float)volume;
        [Export("playbackController:volumeDidChange:")]
        void PlaybackControllerVolumeDidChange(SJVideoPlayerPlaybackController controller, float volume);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller rateDidChange:(float)rate;
        [Export("playbackController:rateDidChange:")]
        void PlaybackControllerRateDidChange(SJVideoPlayerPlaybackController controller, float rate);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller mutedDidChange:(BOOL)isMuted;
        [Export("playbackController:mutedDidChange:")]
        void PlaybackControllerMutedDidChange(SJVideoPlayerPlaybackController controller, bool isMuted);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller playbackDidFinish:(SJFinishedReason _Nonnull)reason;
        [Export("playbackController:playbackDidFinish:")]
        void PlaybackControllerPlaybackDidFinish(SJVideoPlayerPlaybackController controller, string reason);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller durationDidChange:(NSTimeInterval)duration;
        [Export("playbackController:durationDidChange:")]
        void PlaybackControllerDurationDidChange(SJVideoPlayerPlaybackController controller, double duration);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller currentTimeDidChange:(NSTimeInterval)currentTime;
        [Export("playbackController:currentTimeDidChange:")]
        void PlaybackControllerCurrentTimeDidChange(SJVideoPlayerPlaybackController controller, double currentTime);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller presentationSizeDidChange:(CGSize)presentationSize;
        [Export("playbackController:presentationSizeDidChange:")]
        void PlaybackControllerPresentationSizeDidChange(SJVideoPlayerPlaybackController controller, CGSize presentationSize);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller playbackTypeDidChange:(SJPlaybackType)playbackType;
        [Export("playbackController:playbackTypeDidChange:")]
        void PlaybackControllerPlaybackTypeDidChange(SJVideoPlayerPlaybackController controller, SJPlaybackType playbackType);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller playableDurationDidChange:(NSTimeInterval)playableDuration;
        [Export("playbackController:playableDurationDidChange:")]
        void PlaybackControllerPlayableDurationDidChange(SJVideoPlayerPlaybackController controller, double playableDuration);

        // @optional -(void)playbackControllerIsReadyForDisplay:(id<SJVideoPlayerPlaybackController> _Nonnull)controller;
        [Export("playbackControllerIsReadyForDisplay:")]
        void PlaybackControllerIsReadyForDisplay(SJVideoPlayerPlaybackController controller);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller switchingDefinitionStatusDidChange:(SJDefinitionSwitchStatus)status media:(id<SJMediaModelProtocol> _Nonnull)media;
        [Export("playbackController:switchingDefinitionStatusDidChange:media:")]
        void PlaybackControllerSwitchingDefinitionStatusDidChange(SJVideoPlayerPlaybackController controller, SJDefinitionSwitchStatus status, SJMediaModelProtocol media);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller didReplay:(id<SJMediaModelProtocol> _Nonnull)media;
        [Export("playbackController:didReplay:")]
        void PlaybackControllerDidReplay(SJVideoPlayerPlaybackController controller, SJMediaModelProtocol media);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller pictureInPictureStatusDidChange:(SJPictureInPictureStatus)status __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Export("playbackController:pictureInPictureStatusDidChange:")]
        void PlaybackControllerPictureInPictureStatusDidChange(SJVideoPlayerPlaybackController controller, SJPictureInPictureStatus status);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller willSeekToTime:(CMTime)time;
        [Export("playbackController:willSeekToTime:")]
        void PlaybackControllerWillSeekToTime(SJVideoPlayerPlaybackController controller, CMTime time);

        // @optional -(void)playbackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller didSeekToTime:(CMTime)time;
        [Export("playbackController:didSeekToTime:")]
        void PlaybackControllerDidSeekToTime(SJVideoPlayerPlaybackController controller, CMTime time);

        // @optional -(void)applicationWillEnterForegroundWithPlaybackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller;
        [Export("applicationWillEnterForegroundWithPlaybackController:")]
        void ApplicationWillEnterForegroundWithPlaybackController(SJVideoPlayerPlaybackController controller);

        // @optional -(void)applicationDidBecomeActiveWithPlaybackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller;
        [Export("applicationDidBecomeActiveWithPlaybackController:")]
        void ApplicationDidBecomeActiveWithPlaybackController(SJVideoPlayerPlaybackController controller);

        // @optional -(void)applicationWillResignActiveWithPlaybackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller;
        [Export("applicationWillResignActiveWithPlaybackController:")]
        void ApplicationWillResignActiveWithPlaybackController(SJVideoPlayerPlaybackController controller);

        // @optional -(void)applicationDidEnterBackgroundWithPlaybackController:(id<SJVideoPlayerPlaybackController> _Nonnull)controller;
        [Export("applicationDidEnterBackgroundWithPlaybackController:")]
        void ApplicationDidEnterBackgroundWithPlaybackController(SJVideoPlayerPlaybackController controller);
    }

    // @protocol SJMediaModelProtocol
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJMediaModelProtocol
    {
        // @required @property (nonatomic, strong) NSURL * _Nullable mediaURL;
        [Abstract]
        [NullAllowed, Export("mediaURL", ArgumentSemantic.Strong)]
        NSUrl MediaURL { get; set; }

        // @required @property (nonatomic) NSTimeInterval startPosition;
        [Abstract]
        [Export("startPosition")]
        double StartPosition { get; set; }

        // @required @property (nonatomic) NSTimeInterval trialEndPosition;
        [Abstract]
        [Export("trialEndPosition")]
        double TrialEndPosition { get; set; }
    }

    // @protocol SJGestureController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJGestureController
    {
        // @required @property (nonatomic) SJPlayerGestureTypeMask supportedGestureTypes;
        [Abstract]
        [Export("supportedGestureTypes", ArgumentSemantic.Assign)]
        SJPlayerGestureTypeMask SupportedGestureTypes { get; set; }

        // @required @property (copy, nonatomic) BOOL (^ _Nullable)(id<SJGestureController> _Nonnull, SJPlayerGestureType, CGPoint) gestureRecognizerShouldTrigger;
        [Abstract]
        [NullAllowed, Export("gestureRecognizerShouldTrigger", ArgumentSemantic.Copy)]
        Func<SJGestureController, SJPlayerGestureType, CGPoint, bool> GestureRecognizerShouldTrigger { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJGestureController> _Nonnull, CGPoint) singleTapHandler;
        [Abstract]
        [NullAllowed, Export("singleTapHandler", ArgumentSemantic.Copy)]
        Action<SJGestureController, CGPoint> SingleTapHandler { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJGestureController> _Nonnull, CGPoint) doubleTapHandler;
        [Abstract]
        [NullAllowed, Export("doubleTapHandler", ArgumentSemantic.Copy)]
        Action<SJGestureController, CGPoint> DoubleTapHandler { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJGestureController> _Nonnull, SJPanGestureTriggeredPosition, SJPanGestureMovingDirection, SJPanGestureRecognizerState, CGPoint) panHandler;
        [Abstract]
        [NullAllowed, Export("panHandler", ArgumentSemantic.Copy)]
        Action<SJGestureController, SJPanGestureTriggeredPosition, SJPanGestureMovingDirection, SJPanGestureRecognizerState, CGPoint> PanHandler { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJGestureController> _Nonnull, CGFloat) pinchHandler;
        [Abstract]
        [NullAllowed, Export("pinchHandler", ArgumentSemantic.Copy)]
        Action<SJGestureController, nfloat> PinchHandler { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJGestureController> _Nonnull, SJLongPressGestureRecognizerState) longPressHandler;
        [Abstract]
        [NullAllowed, Export("longPressHandler", ArgumentSemantic.Copy)]
        Action<SJGestureController, SJLongPressGestureRecognizerState> LongPressHandler { get; set; }

        // @required -(void)cancelGesture:(SJPlayerGestureType)type;
        [Abstract]
        [Export("cancelGesture:")]
        void CancelGesture(SJPlayerGestureType type);

        // @required -(UIGestureRecognizerState)stateOfGesture:(SJPlayerGestureType)type;
        [Abstract]
        [Export("stateOfGesture:")]
        UIGestureRecognizerState StateOfGesture(SJPlayerGestureType type);

        // @required @property (readonly, nonatomic) SJPanGestureMovingDirection movingDirection;
        [Abstract]
        [Export("movingDirection")]
        SJPanGestureMovingDirection MovingDirection();

        // @required @property (readonly, nonatomic) SJPanGestureTriggeredPosition triggeredPosition;
        [Abstract]
        [Export("triggeredPosition")]
        SJPanGestureTriggeredPosition TriggeredPosition();
    }

    // @protocol SJVideoPlayerControlLayerDataSource <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerControlLayerDataSource
    {
        // @required -(UIView *)controlView;
        [Abstract]
        [Export("controlView")]
        //[Verify(MethodToProperty)]
        UIView ControlView();

        // @optional -(void)installedControlViewToVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("installedControlViewToVideoPlayer:")]
        void InstalledControlViewToVideoPlayer(SJBaseVideoPlayer videoPlayer);
    }

    // @protocol SJVideoPlayerControlLayerDelegate <SJPlaybackInfoDelegate, SJRotationControlDelegate, SJGestureControllerDelegate, SJNetworkStatusControlDelegate, SJVolumeBrightnessRateControlDelegate, SJLockScreenStateControlDelegate, SJAppActivityControlDelegate, SJFitOnScreenControlDelegate, SJSwitchVideoDefinitionControlDelegate, SJPlaybackControlDelegate>
    [Protocol, Model]
    interface SJVideoPlayerControlLayerDelegate : SJPlaybackInfoDelegate, SJRotationControlDelegate, SJGestureControllerDelegate, SJNetworkStatusControlDelegate, SJVolumeBrightnessRateControlDelegate, SJLockScreenStateControlDelegate, SJAppActivityControlDelegate, SJFitOnScreenControlDelegate, SJSwitchVideoDefinitionControlDelegate, SJPlaybackControlDelegate
    {
        // @optional -(void)controlLayerNeedAppear:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("controlLayerNeedAppear:")]
        void ControlLayerNeedAppear(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)controlLayerNeedDisappear:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("controlLayerNeedDisappear:")]
        void ControlLayerNeedDisappear(SJBaseVideoPlayer videoPlayer);

        // @optional -(BOOL)controlLayerOfVideoPlayerCanAutomaticallyDisappear:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("controlLayerOfVideoPlayerCanAutomaticallyDisappear:")]
        bool ControlLayerOfVideoPlayerCanAutomaticallyDisappear(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)videoPlayerWillAppearInScrollView:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("videoPlayerWillAppearInScrollView:")]
        void VideoPlayerWillAppearInScrollView(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)videoPlayerWillDisappearInScrollView:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("videoPlayerWillDisappearInScrollView:")]
        void VideoPlayerWillDisappearInScrollView(SJBaseVideoPlayer videoPlayer);
    }

    // @protocol SJPlaybackControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJPlaybackControlDelegate
    {
        // @optional -(BOOL)canPerformPlayForVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("canPerformPlayForVideoPlayer:")]
        bool CanPerformPlayForVideoPlayer(SJBaseVideoPlayer videoPlayer);

        // @optional -(BOOL)canPerformPauseForVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("canPerformPauseForVideoPlayer:")]
        bool CanPerformPauseForVideoPlayer(SJBaseVideoPlayer videoPlayer);

        // @optional -(BOOL)canPerformStopForVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("canPerformStopForVideoPlayer:")]
        bool CanPerformStopForVideoPlayer(SJBaseVideoPlayer videoPlayer);
    }

    // @protocol SJPlaybackInfoDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJPlaybackInfoDelegate
    {
        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer prepareToPlay:(SJVideoPlayerURLAsset *)asset;
        [Export("videoPlayer:prepareToPlay:")]
        void VideoPlayerPrepareToPlay(SJBaseVideoPlayer videoPlayer, SJVideoPlayerURLAsset asset);

        // @optional -(void)videoPlayerPlaybackStatusDidChange:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("videoPlayerPlaybackStatusDidChange:")]
        void VideoPlayerPlaybackStatusDidChange(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer pictureInPictureStatusDidChange:(SJPictureInPictureStatus)status __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Export("videoPlayer:pictureInPictureStatusDidChange:")]
        void VideoPlayerPictureInPictureStatusDidChange(SJBaseVideoPlayer videoPlayer, SJPictureInPictureStatus status);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer currentTimeDidChange:(NSTimeInterval)currentTime;
        [Export("videoPlayer:currentTimeDidChange:")]
        void VideoPlayerCurrentTimeDidChange(SJBaseVideoPlayer videoPlayer, double currentTime);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer durationDidChange:(NSTimeInterval)duration;
        [Export("videoPlayer:durationDidChange:")]
        void VideoPlayerDurationDidChange(SJBaseVideoPlayer videoPlayer, double duration);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer playableDurationDidChange:(NSTimeInterval)duration;
        [Export("videoPlayer:playableDurationDidChange:")]
        void VideoPlayerPlayableDurationDidChange(SJBaseVideoPlayer videoPlayer, double duration);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer playbackTypeDidChange:(SJPlaybackType)playbackType;
        [Export("videoPlayer:playbackTypeDidChange:")]
        void VideoPlayerPlaybackTypeDidChange(SJBaseVideoPlayer videoPlayer, SJPlaybackType playbackType);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer presentationSizeDidChange:(CGSize)size;
        [Export("videoPlayer:presentationSizeDidChange:")]
        void VideoPlayerPresentationSizeDidChange(SJBaseVideoPlayer videoPlayer, CGSize size);
    }

    // @protocol SJVolumeBrightnessRateControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJVolumeBrightnessRateControlDelegate
    {
        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer muteChanged:(BOOL)mute;
        [Export("videoPlayer:muteChanged:")]
        void MuteChanged(SJBaseVideoPlayer videoPlayer, bool mute);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer volumeChanged:(float)volume;
        [Export("videoPlayer:volumeChanged:")]
        void VolumeChanged(SJBaseVideoPlayer videoPlayer, float volume);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer brightnessChanged:(float)brightness;
        [Export("videoPlayer:brightnessChanged:")]
        void BrightnessChanged(SJBaseVideoPlayer videoPlayer, float brightness);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer rateChanged:(float)rate;
        [Export("videoPlayer:rateChanged:")]
        void RateChanged(SJBaseVideoPlayer videoPlayer, float rate);
    }

    // @protocol SJRotationControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJRotationControlDelegate
    {
        // @optional -(BOOL)canTriggerRotationOfVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("canTriggerRotationOfVideoPlayer:")]
        bool CanTriggerRotationOfVideoPlayer(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer willRotateView:(BOOL)isFull;
        [Export("videoPlayer:willRotateView:")]
        void VideoPlayerWillRotateView(SJBaseVideoPlayer videoPlayer, bool isFull);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer didEndRotation:(BOOL)isFull;
        [Export("videoPlayer:didEndRotation:")]
        void VideoPlayerDidEndRotation(SJBaseVideoPlayer videoPlayer, bool isFull);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer onRotationTransitioningChanged:(BOOL)isTransitioning;
        [Export("videoPlayer:onRotationTransitioningChanged:")]
        void VideoPlayer(SJBaseVideoPlayer videoPlayer, bool isTransitioning);
    }

    // @protocol SJFitOnScreenControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJFitOnScreenControlDelegate
    {
        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer willFitOnScreen:(BOOL)isFitOnScreen;
        [Export("videoPlayer:willFitOnScreen:")]
        void WillFitOnScreen(SJBaseVideoPlayer videoPlayer, bool isFitOnScreen);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer didCompleteFitOnScreen:(BOOL)isFitOnScreen;
        [Export("videoPlayer:didCompleteFitOnScreen:")]
        void DidCompleteFitOnScreen(SJBaseVideoPlayer videoPlayer, bool isFitOnScreen);
    }

    // @protocol SJGestureControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJGestureControllerDelegate
    {
        // @optional -(BOOL)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer gestureRecognizerShouldTrigger:(SJPlayerGestureType)type location:(CGPoint)location;
        [Export("videoPlayer:gestureRecognizerShouldTrigger:location:")]
        bool VideoPlayer(SJBaseVideoPlayer videoPlayer, SJPlayerGestureType type, CGPoint location);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer panGestureTriggeredInTheHorizontalDirection:(SJPanGestureRecognizerState)state progressTime:(NSTimeInterval)progressTime;
        [Export("videoPlayer:panGestureTriggeredInTheHorizontalDirection:progressTime:")]
        void VideoPlayer(SJBaseVideoPlayer videoPlayer, SJPanGestureRecognizerState state, double progressTime);

        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer longPressGestureStateDidChange:(SJLongPressGestureRecognizerState)state;
        [Export("videoPlayer:longPressGestureStateDidChange:")]
        void VideoPlayer(SJBaseVideoPlayer videoPlayer, SJLongPressGestureRecognizerState state);
    }

    // @protocol SJNetworkStatusControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJNetworkStatusControlDelegate
    {
        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer reachabilityChanged:(SJNetworkStatus)status;
        [Export("videoPlayer:reachabilityChanged:")]
        void ReachabilityChanged(SJBaseVideoPlayer videoPlayer, SJNetworkStatus status);
    }

    // @protocol SJLockScreenStateControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJLockScreenStateControlDelegate
    {
        // @optional -(void)tappedPlayerOnTheLockedState:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("tappedPlayerOnTheLockedState:")]
        void TappedPlayerOnTheLockedState(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)lockedVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("lockedVideoPlayer:")]
        void LockedVideoPlayer(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)unlockedVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("unlockedVideoPlayer:")]
        void UnlockedVideoPlayer(SJBaseVideoPlayer videoPlayer);
    }

    // @protocol SJSwitchVideoDefinitionControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJSwitchVideoDefinitionControlDelegate
    {
        // @optional -(void)videoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer switchingDefinitionStatusDidChange:(SJDefinitionSwitchStatus)status media:(id<SJMediaModelProtocol>)media;
        [Export("videoPlayer:switchingDefinitionStatusDidChange:media:")]
        void SwitchingDefinitionStatusDidChange(SJBaseVideoPlayer videoPlayer, SJDefinitionSwitchStatus status, SJMediaModelProtocol media);
    }

    // @protocol SJAppActivityControlDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJAppActivityControlDelegate
    {
        // @optional -(void)applicationWillEnterForegroundWithVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("applicationWillEnterForegroundWithVideoPlayer:")]
        void ApplicationWillEnterForegroundWithVideoPlayer(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)applicationDidBecomeActiveWithVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("applicationDidBecomeActiveWithVideoPlayer:")]
        void ApplicationDidBecomeActiveWithVideoPlayer(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)applicationWillResignActiveWithVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("applicationWillResignActiveWithVideoPlayer:")]
        void ApplicationWillResignActiveWithVideoPlayer(SJBaseVideoPlayer videoPlayer);

        // @optional -(void)applicationDidEnterBackgroundWithVideoPlayer:(__kindof SJBaseVideoPlayer *)videoPlayer;
        [Export("applicationDidEnterBackgroundWithVideoPlayer:")]
        void ApplicationDidEnterBackgroundWithVideoPlayer(SJBaseVideoPlayer videoPlayer);
    }

    // @protocol SJControlLayerAppearManager
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJControlLayerAppearManager
    {
        // @required -(id<SJControlLayerAppearManagerObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJControlLayerAppearManagerObserver Observer();

        // @required @property (getter = isDisabled, nonatomic) BOOL disabled;
        [Abstract]
        [Export("disabled")]
        bool Disabled { [Bind("isDisabled")] get; set; }

        // @required @property (nonatomic) NSTimeInterval interval;
        [Abstract]
        [Export("interval")]
        double Interval { get; set; }

        // @required @property (readonly, nonatomic) BOOL isAppeared;
        [Abstract]
        [Export("isAppeared")]
        bool IsAppeared();

        // @required -(void)switchAppearState;
        [Abstract]
        [Export("switchAppearState")]
        void SwitchAppearState();

        // @required -(void)needAppear;
        [Abstract]
        [Export("needAppear")]
        void NeedAppear();

        // @required -(void)needDisappear;
        [Abstract]
        [Export("needDisappear")]
        void NeedDisappear();

        // @required -(void)resume;
        [Abstract]
        [Export("resume")]
        void Resume();

        // @required -(void)keepAppearState;
        [Abstract]
        [Export("keepAppearState")]
        void KeepAppearState();

        // @required -(void)keepDisappearState;
        [Abstract]
        [Export("keepDisappearState")]
        void KeepDisappearState();

        // @required @property (copy, nonatomic) BOOL (^ _Nullable)(id<SJControlLayerAppearManager> _Nonnull) canAutomaticallyDisappear;
        [Abstract]
        [NullAllowed, Export("canAutomaticallyDisappear", ArgumentSemantic.Copy)]
        Func<SJControlLayerAppearManager, bool> CanAutomaticallyDisappear { get; set; }
    }

    // @protocol SJControlLayerAppearManagerObserver
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJControlLayerAppearManagerObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJControlLayerAppearManager> _Nonnull) onAppearChanged;
        [Abstract]
        [NullAllowed, Export("onAppearChanged", ArgumentSemantic.Copy)]
        Action<SJControlLayerAppearManager> OnAppearChanged { get; set; }
    }

    // @protocol SJFlipTransitionManager <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ISJFlipTransitionManager
    {
        // @required -(instancetype _Nonnull)initWithTarget:(UIView * _Nonnull)target;
        [Abstract]
        [Export("initWithTarget:")]
        NativeHandle Constructor(UIView target);

        // @required -(id<SJFlipTransitionManagerObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJFlipTransitionManagerObserver Observer();

        // @required @property (readonly, getter = isTransitioning, nonatomic) BOOL transitioning;
        [Abstract]
        [Export("transitioning")]
        bool Transitioning { [Bind("isTransitioning")] get; }

        // @required @property (nonatomic) NSTimeInterval duration;
        [Abstract]
        [Export("duration")]
        double Duration { get; set; }

        // @required @property (nonatomic) SJViewFlipTransition flipTransition;
        [Abstract]
        [Export("flipTransition", ArgumentSemantic.Assign)]
        SJViewFlipTransition FlipTransition { get; set; }

        // @required -(void)setFlipTransition:(SJViewFlipTransition)t animated:(BOOL)animated;
        [Abstract]
        [Export("setFlipTransition:animated:")]
        void SetFlipTransition(SJViewFlipTransition t, bool animated);

        // @required -(void)setFlipTransition:(SJViewFlipTransition)t animated:(BOOL)animated completionHandler:(void (^ _Nullable)(id<SJFlipTransitionManager> _Nonnull))completionHandler;
        [Abstract]
        [Export("setFlipTransition:animated:completionHandler:")]
        void SetFlipTransition(SJViewFlipTransition t, bool animated, SJFlipTransitionManagerArgumentAction completionHandler);

        // @required @property (nonatomic, strong) UIView * _Nullable target;
        [Abstract]
        [NullAllowed, Export("target", ArgumentSemantic.Strong)]
        UIView Target { get; set; }
    }

    // @protocol SJFlipTransitionManagerObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJFlipTransitionManagerObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJFlipTransitionManager> _Nonnull) flipTransitionDidStartExeBlock;
        [Abstract]
        [NullAllowed, Export("flipTransitionDidStartExeBlock", ArgumentSemantic.Copy)]
        Action<SJFlipTransitionManager> FlipTransitionDidStartExeBlock { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJFlipTransitionManager> _Nonnull) flipTransitionDidStopExeBlock;
        [Abstract]
        [NullAllowed, Export("flipTransitionDidStopExeBlock", ArgumentSemantic.Copy)]
        Action<SJFlipTransitionManager> FlipTransitionDidStopExeBlock { get; set; }
    }

    // @interface SJPlayModel : NSObject
    [BaseType(typeof(NSObject))]
    interface SJPlayModel
    {
        // @property (nonatomic) SEL _Nullable superviewSelector;
        [NullAllowed, Export("superviewSelector", ArgumentSemantic.Assign)]
        Selector SuperviewSelector { get; set; }

        // @property (nonatomic, strong) __kindof SJPlayModel * _Nullable nextPlayModel;
        [NullAllowed, Export("nextPlayModel", ArgumentSemantic.Strong)]
        SJPlayModel NextPlayModel { get; set; }

        // @property (nonatomic) SEL _Nullable scrollViewSelector;
        [NullAllowed, Export("scrollViewSelector", ArgumentSemantic.Assign)]
        Selector ScrollViewSelector { get; set; }

        // @property (nonatomic) UIEdgeInsets playableAreaInsets;
        [Export("playableAreaInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets PlayableAreaInsets { get; set; }

        // +(instancetype _Nonnull)playModelWithScrollView:(UIScrollView * _Nonnull)scrollView;
        [Static]
        [Export("playModelWithScrollView:")]
        SJPlayModel PlayModelWithScrollView(UIScrollView scrollView);

        // +(instancetype _Nonnull)playModelWithScrollView:(UIScrollView * _Nonnull)scrollView superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithScrollView:superviewSelector:")]
        SJPlayModel PlayModelWithScrollViewSuperviewSelector(UIScrollView scrollView, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView indexPath:(NSIndexPath * _Nonnull)indexPath;
        [Static]
        [Export("playModelWithTableView:indexPath:")]
        SJPlayModel PlayModelWithTableViewIndexPath(UITableView tableView, NSIndexPath indexPath);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView indexPath:(NSIndexPath * _Nonnull)indexPath superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithTableView:indexPath:superviewSelector:")]
        SJPlayModel PlayModelWithTableViewIndexPathSuperviewSelector(UITableView tableView, NSIndexPath indexPath, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView tableHeaderView:(UIView * _Nonnull)tableHeaderView;
        [Static]
        [Export("playModelWithTableView:tableHeaderView:")]
        SJPlayModel PlayModelWithTableViewTableHeaderView(UITableView tableView, UIView tableHeaderView);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView tableHeaderView:(UIView * _Nonnull)tableHeaderView superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithTableView:tableHeaderView:superviewSelector:")]
        SJPlayModel PlayModelWithTableViewTableHeaderViewSuperviewSelector(UITableView tableView, UIView tableHeaderView, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView tableFooterView:(UIView * _Nonnull)tableFooterView;
        [Static]
        [Export("playModelWithTableView:tableFooterView:")]
        SJPlayModel PlayModelWithTableViewTableFooterView(UITableView tableView, UIView tableFooterView);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView tableFooterView:(UIView * _Nonnull)tableFooterView superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithTableView:tableFooterView:superviewSelector:")]
        SJPlayModel PlayModelWithTableViewTableFooterViewSuperviewSelector(UITableView tableView, UIView tableFooterView, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView inHeaderForSection:(NSInteger)section;
        [Static]
        [Export("playModelWithTableView:inHeaderForSection:")]
        SJPlayModel PlayModelWithTableViewInHeaderForSection(UITableView tableView, nint section);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView inHeaderForSection:(NSInteger)section superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithTableView:inHeaderForSection:superviewSelector:")]
        SJPlayModel PlayModelWithTableViewInHeaderForSectionSuperviewSelector(UITableView tableView, nint section, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView inFooterForSection:(NSInteger)section;
        [Static]
        [Export("playModelWithTableView:inFooterForSection:")]
        SJPlayModel PlayModelWithTableViewInFooterForSection(UITableView tableView, nint section);

        // +(instancetype _Nonnull)playModelWithTableView:(UITableView * _Nonnull)tableView inFooterForSection:(NSInteger)section superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithTableView:inFooterForSection:superviewSelector:")]
        SJPlayModel PlayModelWithTableViewInFooterForSectionSuperviewSelector(UITableView tableView, nint section, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithCollectionView:(UICollectionView * _Nonnull)collectionView indexPath:(NSIndexPath * _Nonnull)indexPath;
        [Static]
        [Export("playModelWithCollectionView:indexPath:")]
        SJPlayModel PlayModelWithCollectionViewIndexPath(UICollectionView collectionView, NSIndexPath indexPath);

        // +(instancetype _Nonnull)playModelWithCollectionView:(UICollectionView * _Nonnull)collectionView indexPath:(NSIndexPath * _Nonnull)indexPath superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithCollectionView:indexPath:superviewSelector:")]
        SJPlayModel PlayModelWithCollectionViewIndexPathSuperviewSelector(UICollectionView collectionView, NSIndexPath indexPath, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithCollectionView:(UICollectionView * _Nonnull)collectionView inHeaderForSection:(NSInteger)section;
        [Static]
        [Export("playModelWithCollectionView:inHeaderForSection:")]
        SJPlayModel PlayModelWithCollectionViewInHeaderForSection(UICollectionView collectionView, nint section);

        // +(instancetype _Nonnull)playModelWithCollectionView:(UICollectionView * _Nonnull)collectionView inHeaderForSection:(NSInteger)section superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithCollectionView:inHeaderForSection:superviewSelector:")]
        SJPlayModel PlayModelWithCollectionViewInHeaderForSectionSuperviewSelector(UICollectionView collectionView, nint section, Selector superviewSelector);

        // +(instancetype _Nonnull)playModelWithCollectionView:(UICollectionView * _Nonnull)collectionView inFooterForSection:(NSInteger)section;
        [Static]
        [Export("playModelWithCollectionView:inFooterForSection:")]
        SJPlayModel PlayModelWithCollectionViewInFooterForSection(UICollectionView collectionView, nint section);

        // +(instancetype _Nonnull)playModelWithCollectionView:(UICollectionView * _Nonnull)collectionView inFooterForSection:(NSInteger)section superviewSelector:(SEL _Nonnull)superviewSelector;
        [Static]
        [Export("playModelWithCollectionView:inFooterForSection:superviewSelector:")]
        SJPlayModel PlayModelWithCollectionViewInFooterForSectionSuperviewSelector(UICollectionView collectionView, nint section, Selector superviewSelector);

        // -(BOOL)isPlayInScrollView;
        [Export("isPlayInScrollView")]
        //[Verify(MethodToProperty)]
        bool IsPlayInScrollView();

        // -(UIView<SJPlayModelPlayerSuperview> * _Nullable)playerSuperview;
        [NullAllowed, Export("playerSuperview")]
        //[Verify(MethodToProperty)]
        SJPlayModelPlayerSuperview PlayerSuperview();

        // -(__kindof UIScrollView * _Nullable)inScrollView;
        [NullAllowed, Export("inScrollView")]
        //[Verify(MethodToProperty)]
        UIScrollView InScrollView();

        // -(NSIndexPath * _Nullable)indexPath;
        [NullAllowed, Export("indexPath")]
        //[Verify(MethodToProperty)]
        NSIndexPath IndexPath();

        // -(NSInteger)section;
        [Export("section")]
        //[Verify(MethodToProperty)]
        nint Section();

        // @property (nonatomic) NSUInteger superviewTag;
        [Export("superviewTag")]
        nuint SuperviewTag { get; set; }
    }

    // @protocol SJPlayModelPlayerSuperview
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJPlayModelPlayerSuperview
    {
    }

    // @protocol SJPlayModelNestedView
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJPlayModelNestedView
    {
    }

    // @interface SJDeprecated (SJPlayModel)
    [Category]
    [BaseType(typeof(SJPlayModel))]
    interface SJPlayModel_SJDeprecated
    {
        // +(instancetype _Nonnull)UIViewPlayModel __attribute__((deprecated("use `SJPlayModel.alloc.init`!")));
        [Static]
        [Export("UIViewPlayModel")]
        SJPlayModel UIViewPlayModel();

        // +(instancetype _Nonnull)UITableViewCellPlayModelWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath tableView:(UITableView * _Nonnull)tableView __attribute__((deprecated("use `playModelWithTableView:indexPath`!")));
        [Static]
        [Export("UITableViewCellPlayModelWithPlayerSuperviewTag:atIndexPath:tableView:")]
        SJPlayModel UITableViewCellPlayModelWithPlayerSuperviewTag(nint playerSuperviewTag, NSIndexPath indexPath, UITableView tableView);

        // +(instancetype _Nonnull)UICollectionViewCellPlayModelWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionView:(UICollectionView * _Nonnull)collectionView __attribute__((deprecated("use `playModelWithCollectionView:indexPath`!")));
        [Static]
        [Export("UICollectionViewCellPlayModelWithPlayerSuperviewTag:atIndexPath:collectionView:")]
        SJPlayModel UICollectionViewCellPlayModelWithPlayerSuperviewTag(nint playerSuperviewTag, NSIndexPath indexPath, UICollectionView collectionView);

        // +(instancetype _Nonnull)UITableViewHeaderViewPlayModelWithPlayerSuperview:(UIView * _Nonnull)playerSuperview tableView:(UITableView * _Nonnull)tableView __attribute__((deprecated("use `playModelWithTableView:tableHeaderView`!")));
        [Static]
        [Export("UITableViewHeaderViewPlayModelWithPlayerSuperview:tableView:")]
        SJPlayModel UITableViewHeaderViewPlayModelWithPlayerSuperview(UIView playerSuperview, UITableView tableView);

        // +(instancetype _Nonnull)UITableViewHeaderFooterViewPlayModelWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag inSection:(NSInteger)section isHeader:(BOOL)isHeader tableView:(UITableView * _Nonnull)tableView __attribute__((deprecated("use `playModelWithTableView:tableFooterView`!")));
        [Static]
        [Export("UITableViewHeaderFooterViewPlayModelWithPlayerSuperviewTag:inSection:isHeader:tableView:")]
        SJPlayModel UITableViewHeaderFooterViewPlayModelWithPlayerSuperviewTag(nint playerSuperviewTag, nint section, bool isHeader, UITableView tableView);

        // +(instancetype _Nonnull)UICollectionViewNestedInUITableViewHeaderViewPlayModelWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionView:(UICollectionView * _Nonnull)collectionView tableView:(UITableView * _Nonnull)tableView __attribute__((deprecated("use `nextPlayModel`!")));
        [Static]
        [Export("UICollectionViewNestedInUITableViewHeaderViewPlayModelWithPlayerSuperviewTag:atIndexPath:collectionView:tableView:")]
        SJPlayModel UICollectionViewNestedInUITableViewHeaderViewPlayModelWithPlayerSuperviewTag(nint playerSuperviewTag, NSIndexPath indexPath, UICollectionView collectionView, UITableView tableView);

        // +(instancetype _Nonnull)UICollectionViewNestedInUITableViewCellPlayModelWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionViewTag:(NSInteger)collectionViewTag collectionViewAtIndexPath:(NSIndexPath * _Nonnull)collectionViewAtIndexPath tableView:(UITableView * _Nonnull)tableView __attribute__((deprecated("use `nextPlayModel`!")));
        [Static]
        [Export("UICollectionViewNestedInUITableViewCellPlayModelWithPlayerSuperviewTag:atIndexPath:collectionViewTag:collectionViewAtIndexPath:tableView:")]
        SJPlayModel UICollectionViewNestedInUITableViewCellPlayModelWithPlayerSuperviewTag(nint playerSuperviewTag, NSIndexPath indexPath, nint collectionViewTag, NSIndexPath collectionViewAtIndexPath, UITableView tableView);

        // +(instancetype _Nonnull)UICollectionViewNestedInUICollectionViewCellPlayModelWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionViewTag:(NSInteger)collectionViewTag collectionViewAtIndexPath:(NSIndexPath * _Nonnull)collectionViewAtIndexPath rootCollectionView:(UICollectionView * _Nonnull)rootCollectionView __attribute__((deprecated("use `nextPlayModel`!")));
        [Static]
        [Export("UICollectionViewNestedInUICollectionViewCellPlayModelWithPlayerSuperviewTag:atIndexPath:collectionViewTag:collectionViewAtIndexPath:rootCollectionView:")]
        SJPlayModel UICollectionViewNestedInUICollectionViewCellPlayModelWithPlayerSuperviewTag(nint playerSuperviewTag, NSIndexPath indexPath, nint collectionViewTag, NSIndexPath collectionViewAtIndexPath, UICollectionView rootCollectionView);
    }

    // @protocol SJPlayerDefaultSelectors <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJPlayerDefaultSelectors
    {
        // @required @property (readonly, nonatomic) id _Nonnull playerSuperview;
        [Abstract]
        [Export("playerSuperview")]
        NSObject PlayerSuperview();

        // @required @property (readonly, nonatomic) id _Nonnull collectionView;
        [Abstract]
        [Export("collectionView")]
        NSObject CollectionView();
    }

    // @interface SJVideoPlayerURLAsset : NSObject <SJMediaModelProtocol>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJVideoPlayerURLAsset : SJMediaModelProtocol
    {
        // -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)URL startPosition:(NSTimeInterval)startPosition playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithURL:startPosition:playModel:")]
        NativeHandle Constructor(NSUrl URL, double startPosition, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)URL startPosition:(NSTimeInterval)startPosition;
        [Export("initWithURL:startPosition:")]
        NativeHandle Constructor(NSUrl URL, double startPosition);

        // -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)URL playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithURL:playModel:")]
        NativeHandle Constructor(NSUrl URL, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithURL:(NSURL * _Nonnull)URL;
        [Export("initWithURL:")]
        NativeHandle Constructor(NSUrl URL);

        // @property (nonatomic) NSTimeInterval startPosition;
        [Export("startPosition")]
        double StartPosition { get; set; }

        // @property (nonatomic) NSTimeInterval trialEndPosition;
        [Export("trialEndPosition")]
        double TrialEndPosition { get; set; }

        // @property (nonatomic, strong, null_resettable) SJPlayModel * _Null_unspecified playModel;
        [NullAllowed, Export("playModel", ArgumentSemantic.Strong)]
        SJPlayModel PlayModel { get; set; }

        // -(id<SJVideoPlayerURLAssetObserver> _Nonnull)getObserver;
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJVideoPlayerURLAssetObserver Observer();

        // @property (nonatomic) BOOL isM3u8;
        [Export("isM3u8")]
        bool IsM3u8 { get; set; }
    }

    // @protocol SJVideoPlayerURLAssetObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerURLAssetObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerURLAsset * _Nonnull) playModelDidChangeExeBlock;
        [Abstract]
        [NullAllowed, Export("playModelDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerURLAsset> PlayModelDidChangeExeBlock { get; set; }
    }

    // @interface SJAVMediaPlaybackAdd (SJVideoPlayerURLAsset)
    [Category]
    [BaseType(typeof(SJVideoPlayerURLAsset))]
    interface SJVideoPlayerURLAsset_SJAVMediaPlaybackAdd
    {
        // -(instancetype _Nullable)initWithAVAsset:(__kindof AVAsset * _Nonnull)asset;
        [Export("initWithAVAsset:")]
        NativeHandle Constructor(AVAsset asset);

        // -(instancetype _Nullable)initWithAVAsset:(__kindof AVAsset * _Nonnull)asset playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAVAsset:playModel:")]
        NativeHandle Constructor(AVAsset asset, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithAVAsset:(__kindof AVAsset * _Nonnull)asset startPosition:(NSTimeInterval)startPosition playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAVAsset:startPosition:playModel:")]
        NativeHandle Constructor(AVAsset asset, double startPosition, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithAVPlayerItem:(AVPlayerItem * _Nonnull)playerItem;
        [Export("initWithAVPlayerItem:")]
        NativeHandle Constructor(AVPlayerItem playerItem);

        // -(instancetype _Nullable)initWithAVPlayerItem:(AVPlayerItem * _Nonnull)playerItem playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAVPlayerItem:playModel:")]
        NativeHandle Constructor(AVPlayerItem playerItem, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithAVPlayerItem:(AVPlayerItem * _Nonnull)playerItem startPosition:(NSTimeInterval)startPosition playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAVPlayerItem:startPosition:playModel:")]
        NativeHandle Constructor(AVPlayerItem playerItem, double startPosition, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithAVPlayer:(AVPlayer * _Nonnull)player;
        [Export("initWithAVPlayer:")]
        NativeHandle Constructor(AVPlayer player);

        // -(instancetype _Nullable)initWithAVPlayer:(AVPlayer * _Nonnull)player playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAVPlayer:playModel:")]
        NativeHandle Constructor(AVPlayer player, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithAVPlayer:(AVPlayer * _Nonnull)player startPosition:(NSTimeInterval)startPosition playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAVPlayer:startPosition:playModel:")]
        NativeHandle Constructor(AVPlayer player, double startPosition, SJPlayModel playModel);

        // @property (nonatomic, strong) __kindof AVAsset * _Nullable avAsset;
        [NullAllowed, Export("avAsset", ArgumentSemantic.Strong)]
        AVAsset AvAsset { get; set; }

        // @property (nonatomic, strong) AVPlayerItem * _Nullable avPlayerItem;
        [NullAllowed, Export("avPlayerItem", ArgumentSemantic.Strong)]
        AVPlayerItem AvPlayerItem { get; set; }

        // @property (nonatomic, strong) AVPlayer * _Nullable avPlayer;
        [NullAllowed, Export("avPlayer", ArgumentSemantic.Strong)]
        AVPlayer AvPlayer { get; set; }

        // -(instancetype _Nullable)initWithOtherAsset:(SJVideoPlayerURLAsset * _Nonnull)otherAsset playModel:(__kindof SJPlayModel * _Nullable)playModel;
        [Export("initWithOtherAsset:playModel:")]
        NativeHandle Constructor(SJVideoPlayerURLAsset otherAsset, SJPlayModel playModel);

        // @property (readonly, nonatomic, strong) SJVideoPlayerURLAsset * _Nullable original;
        [NullAllowed, Export("original", ArgumentSemantic.Strong)]
        SJVideoPlayerURLAsset Original();

        // -(SJVideoPlayerURLAsset * _Nullable)originAsset __attribute__((deprecated("ues `original`")));
        [NullAllowed, Export("originAsset")]
        //[Verify(MethodToProperty)]
        SJVideoPlayerURLAsset OriginAsset();
    }

    // @protocol SJDeviceVolumeAndBrightnessController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJDeviceVolumeAndBrightnessController
    {
        // @required -(id<SJDeviceVolumeAndBrightnessControllerObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJDeviceVolumeAndBrightnessControllerObserver Observer();

        // @required @property (nonatomic) float volume;
        [Abstract]
        [Export("volume")]
        float Volume { get; set; }

        // @required @property (nonatomic) float brightness;
        [Abstract]
        [Export("brightness")]
        float Brightness { get; set; }

        // @required @property (nonatomic, weak) UIView * _Nullable target;
        [Abstract]
        [NullAllowed, Export("target", ArgumentSemantic.Weak)]
        UIView Target { get; set; }

        // @required @property (nonatomic, strong) id<SJDeviceVolumeAndBrightnessTargetViewContext> _Nullable targetViewContext;
        [Abstract]
        [NullAllowed, Export("targetViewContext", ArgumentSemantic.Strong)]
        SJDeviceVolumeAndBrightnessTargetViewContext TargetViewContext { get; set; }

        // @required -(void)onTargetViewMoveToWindow;
        [Abstract]
        [Export("onTargetViewMoveToWindow")]
        void OnTargetViewMoveToWindow();

        // @required -(void)onTargetViewContextUpdated;
        [Abstract]
        [Export("onTargetViewContextUpdated")]
        void OnTargetViewContextUpdated();
    }

    // @protocol SJDeviceVolumeAndBrightnessTargetViewContext <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJDeviceVolumeAndBrightnessTargetViewContext
    {
        // @required @property (readonly, nonatomic) BOOL isFullscreen;
        [Abstract]
        [Export("isFullscreen")]
        bool IsFullscreen();

        // @required @property (readonly, nonatomic) BOOL isFitOnScreen;
        [Abstract]
        [Export("isFitOnScreen")]
        bool IsFitOnScreen();

        // @required @property (readonly, nonatomic) BOOL isPlayOnScrollView;
        [Abstract]
        [Export("isPlayOnScrollView")]
        bool IsPlayOnScrollView();

        // @required @property (readonly, nonatomic) BOOL isScrollAppeared;
        [Abstract]
        [Export("isScrollAppeared")]
        bool IsScrollAppeared();

        // @required @property (readonly, nonatomic) BOOL isFloatingMode;
        [Abstract]
        [Export("isFloatingMode")]
        bool IsFloatingMode();

        // @required @property (readonly, nonatomic) BOOL isPictureInPictureMode;
        [Abstract]
        [Export("isPictureInPictureMode")]
        bool IsPictureInPictureMode();
    }

    // @protocol SJDeviceVolumeAndBrightnessControllerObserver
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJDeviceVolumeAndBrightnessControllerObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJDeviceVolumeAndBrightnessController> _Nonnull, float) volumeDidChangeExeBlock;
        [Abstract]
        [NullAllowed, Export("volumeDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJDeviceVolumeAndBrightnessController, float> VolumeDidChangeExeBlock { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJDeviceVolumeAndBrightnessController> _Nonnull, float) brightnessDidChangeExeBlock;
        [Abstract]
        [NullAllowed, Export("brightnessDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJDeviceVolumeAndBrightnessController, float> BrightnessDidChangeExeBlock { get; set; }
    }

    // @protocol SJSmallViewFloatingController
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface ISJSmallViewFloatingController
    {
        // @required -(id<SJSmallViewFloatingControllerObserverProtocol> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJSmallViewFloatingControllerObserverProtocol Observer();

        // @required @property (getter = isEnabled, nonatomic) BOOL enabled;
        [Abstract]
        [Export("enabled")]
        bool Enabled { [Bind("isEnabled")] get; set; }

        // @required @property (readonly, nonatomic) BOOL isAppeared;
        [Abstract]
        [Export("isAppeared")]
        bool IsAppeared();

        // @required -(void)show;
        [Abstract]
        [Export("show")]
        void Show();

        // @required -(void)dismiss;
        [Abstract]
        [Export("dismiss")]
        void Dismiss();

        // @required @property (copy, nonatomic) BOOL (^ _Nullable)(id<SJSmallViewFloatingController> _Nonnull) floatingViewShouldAppear;
        [Abstract]
        [NullAllowed, Export("floatingViewShouldAppear", ArgumentSemantic.Copy)]
        Func<SJSmallViewFloatingController, bool> FloatingViewShouldAppear { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJSmallViewFloatingController> _Nonnull) onSingleTapped;
        [Abstract]
        [NullAllowed, Export("onSingleTapped", ArgumentSemantic.Copy)]
        Action<SJSmallViewFloatingController> OnSingleTapped { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJSmallViewFloatingController> _Nonnull) onDoubleTapped;
        [Abstract]
        [NullAllowed, Export("onDoubleTapped", ArgumentSemantic.Copy)]
        Action<SJSmallViewFloatingController> OnDoubleTapped { get; set; }

        // @required @property (getter = isSlidable, nonatomic) BOOL slidable;
        [Abstract]
        [Export("slidable")]
        bool Slidable { [Bind("isSlidable")] get; set; }

        // @required @property (readonly, nonatomic, strong) __kindof UIView * _Nonnull floatingView;
        [Abstract]
        [Export("floatingView", ArgumentSemantic.Strong)]
        UIView FloatingView();

        // @required @property (nonatomic, weak) UIView * _Nullable target;
        [Abstract]
        [NullAllowed, Export("target", ArgumentSemantic.Weak)]
        UIView Target { get; set; }

        // @required @property (nonatomic, weak) UIView * _Nullable targetSuperview;
        [Abstract]
        [NullAllowed, Export("targetSuperview", ArgumentSemantic.Weak)]
        UIView TargetSuperview { get; set; }
    }

    // @protocol SJSmallViewFloatingControllerObserverProtocol
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    interface SJSmallViewFloatingControllerObserverProtocol
    {
        // @required @property (readonly, nonatomic, weak) id<SJSmallViewFloatingController> _Nullable controller;
        [Abstract]
        [NullAllowed, Export("controller", ArgumentSemantic.Weak)]
        SJSmallViewFloatingController Controller();

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJSmallViewFloatingController> _Nonnull) onAppearChanged;
        [Abstract]
        [NullAllowed, Export("onAppearChanged", ArgumentSemantic.Copy)]
        Action<SJSmallViewFloatingController> OnAppearChanged { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJSmallViewFloatingController> _Nonnull) onEnabled;
        [Abstract]
        [NullAllowed, Export("onEnabled", ArgumentSemantic.Copy)]
        Action<SJSmallViewFloatingController> OnEnabled { get; set; }
    }

    // @interface SJVideoDefinitionSwitchingInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SJVideoDefinitionSwitchingInfo
    {
        // -(SJVideoDefinitionSwitchingInfoObserver * _Nonnull)getObserver;
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJVideoDefinitionSwitchingInfoObserver Observer();

        // @property (readonly, nonatomic, weak) SJVideoPlayerURLAsset * _Nullable currentPlayingAsset;
        [NullAllowed, Export("currentPlayingAsset", ArgumentSemantic.Weak)]
        SJVideoPlayerURLAsset CurrentPlayingAsset();

        // @property (readonly, nonatomic, weak) SJVideoPlayerURLAsset * _Nullable switchingAsset;
        [NullAllowed, Export("switchingAsset", ArgumentSemantic.Weak)]
        SJVideoPlayerURLAsset SwitchingAsset();

        // @property (readonly, nonatomic) SJDefinitionSwitchStatus status;
        [Export("status")]
        SJDefinitionSwitchStatus Status();
    }

    // @interface SJVideoDefinitionSwitchingInfoObserver : NSObject
    [BaseType(typeof(NSObject))]
    interface SJVideoDefinitionSwitchingInfoObserver
    {
        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoDefinitionSwitchingInfo * _Nonnull) statusDidChangeExeBlock;
        [NullAllowed, Export("statusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJVideoDefinitionSwitchingInfo> StatusDidChangeExeBlock { get; set; }
    }

    // @protocol SJPromptingPopupController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJPromptingPopupController
    {
        // @required @property (nonatomic) UIEdgeInsets contentInset;
        [Abstract]
        [Export("contentInset", ArgumentSemantic.Assign)]
        UIEdgeInsets ContentInset { get; set; }

        // @required -(void)show:(NSAttributedString * _Nonnull)title;
        [Abstract]
        [Export("show:")]
        void Show(NSAttributedString title);

        // @required -(void)show:(NSAttributedString * _Nonnull)title duration:(NSTimeInterval)duration;
        [Abstract]
        [Export("show:duration:")]
        void Show(NSAttributedString title, double duration);

        // @required -(void)showCustomView:(UIView * _Nonnull)view;
        [Abstract]
        [Export("showCustomView:")]
        void ShowCustomView(UIView view);

        // @required -(void)showCustomView:(UIView * _Nonnull)view duration:(NSTimeInterval)duration;
        [Abstract]
        [Export("showCustomView:duration:")]
        void ShowCustomView(UIView view, double duration);

        // @required -(BOOL)isShowingWithCustomView:(UIView * _Nonnull)view;
        [Abstract]
        [Export("isShowingWithCustomView:")]
        bool IsShowingWithCustomView(UIView view);

        // @required -(void)remove:(UIView * _Nonnull)view;
        [Abstract]
        [Export("remove:")]
        void Remove(UIView view);

        // @required -(void)clear;
        [Abstract]
        [Export("clear")]
        void Clear();

        // @required @property (nonatomic) CGFloat leftMargin;
        [Abstract]
        [Export("leftMargin")]
        nfloat LeftMargin { get; set; }

        // @required @property (nonatomic) CGFloat bottomMargin;
        [Abstract]
        [Export("bottomMargin")]
        nfloat BottomMargin { get; set; }

        // @required @property (nonatomic) CGFloat itemSpacing;
        [Abstract]
        [Export("itemSpacing")]
        nfloat ItemSpacing { get; set; }

        // @required @property (readonly, copy, nonatomic) __kindof NSArray<UIView *> * _Nullable displayingViews;
        [Abstract]
        [NullAllowed, Export("displayingViews", ArgumentSemantic.Copy)]
        UIView[] DisplayingViews();

        // @required @property (nonatomic) BOOL automaticallyAdjustsLeftInset;
        [Abstract]
        [Export("automaticallyAdjustsLeftInset")]
        bool AutomaticallyAdjustsLeftInset { get; set; }

        // @required @property (nonatomic) BOOL automaticallyAdjustsBottomInset;
        [Abstract]
        [Export("automaticallyAdjustsBottomInset")]
        bool AutomaticallyAdjustsBottomInset { get; set; }

        // @required @property (nonatomic, weak) UIView * _Nullable target;
        [Abstract]
        [NullAllowed, Export("target", ArgumentSemantic.Weak)]
        UIView Target { get; set; }
    }

    // @interface SJPlaybackObservation : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJPlaybackObservation
    {
        // -(instancetype _Nonnull)initWithPlayer:(__kindof SJBaseVideoPlayer * _Nonnull)player;
        [Export("initWithPlayer:")]
        NativeHandle Constructor(SJBaseVideoPlayer player);

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playbackStatusDidChangeExeBlock;
        [NullAllowed, Export("playbackStatusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PlaybackStatusDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playbackDidFinishExeBlock;
        [NullAllowed, Export("playbackDidFinishExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PlaybackDidFinishExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) assetStatusDidChangeExeBlock;
        [NullAllowed, Export("assetStatusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> AssetStatusDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) timeControlStatusDidChangeExeBlock;
        [NullAllowed, Export("timeControlStatusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> TimeControlStatusDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) API_AVAILABLE(ios(14.0)) void (^)(__kindof SJBaseVideoPlayer * _Nonnull) pictureInPictureStatusDidChangeExeBlock __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Export("pictureInPictureStatusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PictureInPictureStatusDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull, CMTime) willSeekToTimeExeBlock;
        [NullAllowed, Export("willSeekToTimeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer, CMTime> WillSeekToTimeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull, CMTime) didSeekToTimeExeBlock;
        [NullAllowed, Export("didSeekToTimeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer, CMTime> DidSeekToTimeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) didReplayExeBlock;
        [NullAllowed, Export("didReplayExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> DidReplayExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) definitionSwitchStatusDidChangeExeBlock;
        [NullAllowed, Export("definitionSwitchStatusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> DefinitionSwitchStatusDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) currentTimeDidChangeExeBlock;
        [NullAllowed, Export("currentTimeDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> CurrentTimeDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) durationDidChangeExeBlock;
        [NullAllowed, Export("durationDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> DurationDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playableDurationDidChangeExeBlock;
        [NullAllowed, Export("playableDurationDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PlayableDurationDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) presentationSizeDidChangeExeBlock;
        [NullAllowed, Export("presentationSizeDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PresentationSizeDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playbackTypeDidChangeExeBlock;
        [NullAllowed, Export("playbackTypeDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PlaybackTypeDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) screenLockStateDidChangeExeBlock;
        [NullAllowed, Export("screenLockStateDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> ScreenLockStateDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) mutedDidChangeExeBlock;
        [NullAllowed, Export("mutedDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> MutedDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playerVolumeDidChangeExeBlock;
        [NullAllowed, Export("playerVolumeDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PlayerVolumeDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) rateDidChangeExeBlock;
        [NullAllowed, Export("rateDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> RateDidChangeExeBlock { get; set; }

        // @property (readonly, nonatomic, weak) __kindof SJBaseVideoPlayer * _Nullable player;
        [NullAllowed, Export("player", ArgumentSemantic.Weak)]
        SJBaseVideoPlayer Player();

        // @property (copy, nonatomic) __deprecated_msg("use `playbackDidFinishExeBlock`") void (^)(__kindof SJBaseVideoPlayer * _Nonnull) didPlayToEndTimeExeBlock __attribute__((deprecated("use `playbackDidFinishExeBlock`")));
        [Export("didPlayToEndTimeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> DidPlayToEndTimeExeBlock { get; set; }
    }

    // @protocol SJVideoPlayerPresentView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJVideoPlayerPresentView
    {
        // @required @property (readonly, nonatomic, strong) UIImageView * _Nonnull placeholderImageView;
        [Abstract]
        [Export("placeholderImageView", ArgumentSemantic.Strong)]
        UIImageView PlaceholderImageView();

        // @required @property (readonly, getter = isPlaceholderImageViewHidden, nonatomic) BOOL placeholderImageViewHidden;
        [Abstract]
        [Export("placeholderImageViewHidden")]
        bool PlaceholderImageViewHidden { [Bind("isPlaceholderImageViewHidden")] get; }

        // @required @property (nonatomic) UIViewContentMode placeholderImageViewContentMode;
        [Abstract]
        [Export("placeholderImageViewContentMode", ArgumentSemantic.Assign)]
        UIViewContentMode PlaceholderImageViewContentMode { get; set; }

        // @required -(void)setPlaceholderImageViewHidden:(BOOL)isHidden animated:(BOOL)animated;
        [Abstract]
        [Export("setPlaceholderImageViewHidden:animated:")]
        void SetPlaceholderImageViewHidden(bool isHidden, bool animated);

        // @required -(void)hidePlaceholderImageViewAnimated:(BOOL)animated delay:(NSTimeInterval)secs;
        [Abstract]
        [Export("hidePlaceholderImageViewAnimated:delay:")]
        void HidePlaceholderImageViewAnimated(bool animated, double secs);
    }

    // @protocol SJSubtitlePopupController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJSubtitlePopupController
    {
        // @required @property (copy, nonatomic) NSArray<id<SJSubtitleItem>> * _Nullable subtitles;
        [Abstract]
        [NullAllowed, Export("subtitles", ArgumentSemantic.Copy)]
        SJSubtitleItem[] Subtitles { get; set; }

        // @required @property (nonatomic) NSInteger numberOfLines;
        [Abstract]
        [Export("numberOfLines")]
        nint NumberOfLines { get; set; }

        // @required @property (nonatomic) UIEdgeInsets contentInsets;
        [Abstract]
        [Export("contentInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets ContentInsets { get; set; }

        // @required @property (readonly, nonatomic, strong) UIView * _Nonnull view;
        [Abstract]
        [Export("view", ArgumentSemantic.Strong)]
        UIView View();

        // @required @property (nonatomic) NSTimeInterval currentTime;
        [Abstract]
        [Export("currentTime")]
        double CurrentTime { get; set; }
    }

    // @protocol SJSubtitleItem <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ISJSubtitleItem
    {
        // @required -(instancetype _Nonnull)initWithContent:(NSAttributedString * _Nonnull)content range:(SJTimeRange)range;
        [Abstract]
        [Export("initWithContent:range:")]
        NativeHandle Constructor(NSAttributedString content, SJTimeRange range);

        // @required -(instancetype _Nonnull)initWithContent:(NSAttributedString * _Nonnull)content start:(NSTimeInterval)start end:(NSTimeInterval)end;
        [Abstract]
        [Export("initWithContent:start:end:")]
        NativeHandle Constructor(NSAttributedString content, double start, double end);

        // @required @property (readonly, copy, nonatomic) NSAttributedString * _Nonnull content;
        [Abstract]
        [Export("content", ArgumentSemantic.Copy)]
        NSAttributedString Content();

        // @required @property (readonly, nonatomic) SJTimeRange range;
        [Abstract]
        [Export("range")]
        SJTimeRange Range();
    }

    // @protocol SJDanmakuPopupController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ISJDanmakuPopupController
    {
        // @required -(instancetype _Nonnull)initWithNumberOfTracks:(NSUInteger)numberOfTracks;
        [Abstract]
        [Export("initWithNumberOfTracks:")]
        NativeHandle Constructor(nuint numberOfTracks);

        // @required @property (getter = isDisabled, nonatomic) BOOL disabled;
        [Abstract]
        [Export("disabled")]
        bool Disabled { [Bind("isDisabled")] get; set; }

        // @required -(void)enqueue:(id<SJDanmakuItem> _Nonnull)danmaku;
        [Abstract]
        [Export("enqueue:")]
        void Enqueue(SJDanmakuItem danmaku);

        // @required -(void)emptyQueue;
        [Abstract]
        [Export("emptyQueue")]
        void EmptyQueue();

        // @required -(void)removeDisplayedItems;
        [Abstract]
        [Export("removeDisplayedItems")]
        void RemoveDisplayedItems();

        // @required -(void)removeAll;
        [Abstract]
        [Export("removeAll")]
        void RemoveAll();

        // @required @property (readonly, getter = isPaused, nonatomic) BOOL paused;
        [Abstract]
        [Export("paused")]
        bool Paused { [Bind("isPaused")] get; }

        // @required -(void)pause;
        [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)resume;
        [Abstract]
        [Export("resume")]
        void Resume();

        // @required @property (readonly, nonatomic, strong) __kindof UIView * _Nonnull view;
        [Abstract]
        [Export("view", ArgumentSemantic.Strong)]
        UIView View();

        // @required -(id<SJDanmakuPopupControllerObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJDanmakuPopupControllerObserver Observer();

        // @required @property (readonly, nonatomic) NSInteger queueSize;
        [Abstract]
        [Export("queueSize")]
        nint QueueSize();

        // @required @property (nonatomic) NSInteger numberOfTracks;
        [Abstract]
        [Export("numberOfTracks")]
        nint NumberOfTracks { get; set; }
    }

    // @protocol SJDanmakuItem <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ISJDanmakuItem
    {
        // @required -(instancetype _Nonnull)initWithContent:(NSAttributedString * _Nonnull)content;
        [Abstract]
        [Export("initWithContent:")]
        NativeHandle Constructor(NSAttributedString content);

        // @required -(instancetype _Nonnull)initWithCustomView:(__kindof UIView * _Nonnull)customView;
        [Abstract]
        [Export("initWithCustomView:")]
        NativeHandle Constructor(UIView customView);

        // @required @property (readonly, copy, nonatomic) NSAttributedString * _Nullable content;
        [Abstract]
        [NullAllowed, Export("content", ArgumentSemantic.Copy)]
        NSAttributedString Content();

        // @required @property (readonly, nonatomic, strong) __kindof UIView * _Nullable customView;
        [Abstract]
        [NullAllowed, Export("customView", ArgumentSemantic.Strong)]
        UIView CustomView();
    }

    // @protocol SJDanmakuPopupControllerObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJDanmakuPopupControllerObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJDanmakuPopupController> _Nonnull) onDisabledChanged;
        [Abstract]
        [NullAllowed, Export("onDisabledChanged", ArgumentSemantic.Copy)]
        Action<SJDanmakuPopupController> OnDisabledChanged { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJDanmakuPopupController> _Nonnull) onPausedChanged;
        [Abstract]
        [NullAllowed, Export("onPausedChanged", ArgumentSemantic.Copy)]
        Action<SJDanmakuPopupController> OnPausedChanged { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJDanmakuPopupController> _Nonnull, id<SJDanmakuItem> _Nonnull) willDisplayItem;
        [Abstract]
        [NullAllowed, Export("willDisplayItem", ArgumentSemantic.Copy)]
        Action<SJDanmakuPopupController, SJDanmakuItem> WillDisplayItem { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJDanmakuPopupController> _Nonnull, id<SJDanmakuItem> _Nonnull) didEndDisplayingItem;
        [Abstract]
        [NullAllowed, Export("didEndDisplayingItem", ArgumentSemantic.Copy)]
        Action<SJDanmakuPopupController, SJDanmakuItem> DidEndDisplayingItem { get; set; }
    }

    // @protocol SJTextPopupController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJTextPopupController
    {
        // @required -(void)show:(NSAttributedString * _Nonnull)title;
        [Abstract]
        [Export("show:")]
        void Show(NSAttributedString title);

        // @required -(void)show:(NSAttributedString * _Nonnull)title duration:(NSTimeInterval)duration;
        [Abstract]
        [Export("show:duration:")]
        void Show(NSAttributedString title, double duration);

        // @required -(void)show:(NSAttributedString * _Nonnull)title duration:(NSTimeInterval)duration completionHandler:(void (^ _Nullable)(void))completionHandler;
        [Abstract]
        [Export("show:duration:completionHandler:")]
        void Show(NSAttributedString title, double duration, Action? completionHandler);

        // @required -(void)hidden;
        [Abstract]
        [Export("hidden")]
        void Hidden();

        // @required @property (nonatomic) UIEdgeInsets contentInset;
        [Abstract]
        [Export("contentInset", ArgumentSemantic.Assign)]
        UIEdgeInsets ContentInset { get; set; }

        // @required @property (nonatomic) CGFloat cornerRadius;
        [Abstract]
        [Export("cornerRadius")]
        nfloat CornerRadius { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
        [Abstract]
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @required @property (nonatomic) CGFloat maxLayoutWidth;
        [Abstract]
        [Export("maxLayoutWidth")]
        nfloat MaxLayoutWidth { get; set; }

        // @required @property (nonatomic, weak) UIView * _Nullable target;
        [Abstract]
        [NullAllowed, Export("target", ArgumentSemantic.Weak)]
        UIView Target { get; set; }
    }

    // @protocol SJWatermarkView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJWatermarkView
    {
        // @required -(void)layoutWatermarkInRect:(CGRect)rect videoPresentationSize:(CGSize)vSize videoGravity:(SJVideoGravity)videoGravity;
        [Abstract]
        [Export("layoutWatermarkInRect:videoPresentationSize:videoGravity:")]
        void VideoPresentationSize(CGRect rect, CGSize vSize, string videoGravity);
    }

    // @interface SJBaseVideoPlayer : NSObject
    [BaseType(typeof(NSObject))]
    interface SJBaseVideoPlayer
    {
        // +(NSString * _Nonnull)version;
        [Static]
        [Export("version")]
        //[Verify(MethodToProperty)]
        string Version();

        // +(instancetype _Nonnull)player;
        [Static]
        [Export("player")]
        SJBaseVideoPlayer Player();

        // @property (nonatomic) SJVideoGravity _Nonnull videoGravity;
        [Export("videoGravity")]
        string VideoGravity { get; set; }

        // @property (readonly, nonatomic, strong) __kindof UIView * _Nonnull view;
        [Export("view", ArgumentSemantic.Strong)]
        UIView View();

        [Wrap("WeakControlLayerDataSource")]
        [NullAllowed]
        SJVideoPlayerControlLayerDataSource ControlLayerDataSource { get; set; }

        // @property (nonatomic, weak) id<SJVideoPlayerControlLayerDataSource> _Nullable controlLayerDataSource;
        [NullAllowed, Export("controlLayerDataSource", ArgumentSemantic.Weak)]
        NSObject WeakControlLayerDataSource { get; set; }

        [Wrap("WeakControlLayerDelegate")]
        [NullAllowed]
        SJVideoPlayerControlLayerDelegate ControlLayerDelegate { get; set; }

        // @property (nonatomic, weak) id<SJVideoPlayerControlLayerDelegate> _Nullable controlLayerDelegate;
        [NullAllowed, Export("controlLayerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakControlLayerDelegate { get; set; }
    }

    // @interface AudioSession (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_AudioSession
    {
        // @property (getter = isAudioSessionControlEnabled, nonatomic) BOOL audioSessionControlEnabled;
        [Export("audioSessionControlEnabled")]
        bool AudioSessionControlEnabled { [Bind("isAudioSessionControlEnabled")] get; set; }

        // -(void)setCategory:(AVAudioSessionCategory _Nonnull)category withOptions:(AVAudioSessionCategoryOptions)options;
        [Export("setCategory:withOptions:")]
        void SetCategory(string category, AVAudioSessionCategoryOptions options);

        // -(void)setActiveOptions:(AVAudioSessionSetActiveOptions)options;
        [Export("setActiveOptions:")]
        void SetActiveOptions(AVAudioSessionSetActiveOptions options);
    }

    // @interface Placeholder (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Placeholder
    {
        // @property (readonly, nonatomic, strong) UIView<SJVideoPlayerPresentView> * _Nonnull presentView;
        [Export("presentView", ArgumentSemantic.Strong)]
        SJVideoPlayerPresentView PresentView();

        // @property (nonatomic) BOOL automaticallyHidesPlaceholderImageView;
        [Export("automaticallyHidesPlaceholderImageView")]
        bool AutomaticallyHidesPlaceholderImageView { get; set; }

        // @property (nonatomic) NSTimeInterval delayInSecondsForHiddenPlaceholderImageView;
        [Export("delayInSecondsForHiddenPlaceholderImageView")]
        double DelayInSecondsForHiddenPlaceholderImageView { get; set; }
    }

    // @interface VideoFlipTransition (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_VideoFlipTransition
    {
        // @property (nonatomic, strong, null_resettable) id<SJFlipTransitionManager> _Null_unspecified flipTransitionManager;
        [NullAllowed, Export("flipTransitionManager", ArgumentSemantic.Strong)]
        SJFlipTransitionManager FlipTransitionManager { get; set; }

        // @property (readonly, nonatomic, strong) id<SJFlipTransitionManagerObserver> _Nonnull flipTransitionObserver;
        [Export("flipTransitionObserver", ArgumentSemantic.Strong)]
        SJFlipTransitionManagerObserver FlipTransitionObserver();
    }

    // @interface Playback (SJBaseVideoPlayer) <SJVideoPlayerPlaybackControllerDelegate>
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Playback : SJVideoPlayerPlaybackControllerDelegate
    {
        // @property (nonatomic, strong, null_resettable) __kindof id<SJVideoPlayerPlaybackController> _Null_unspecified playbackController;
        [NullAllowed, Export("playbackController", ArgumentSemantic.Strong)]
        SJVideoPlayerPlaybackController PlaybackController { get; set; }

        // @property (readonly, nonatomic, strong) SJPlaybackObservation * _Nonnull playbackObserver;
        [Export("playbackObserver", ArgumentSemantic.Strong)]
        SJPlaybackObservation PlaybackObserver();

        // @property (nonatomic, strong) SJVideoPlayerURLAsset * _Nullable URLAsset;
        [NullAllowed, Export("URLAsset", ArgumentSemantic.Strong)]
        SJVideoPlayerURLAsset URLAsset { get; set; }

        // @property (readonly, nonatomic) SJAssetStatus assetStatus;
        [Export("assetStatus")]
        SJAssetStatus AssetStatus();

        // @property (readonly, nonatomic) SJPlaybackTimeControlStatus timeControlStatus;
        [Export("timeControlStatus")]
        SJPlaybackTimeControlStatus TimeControlStatus();

        // @property (readonly, nonatomic) SJWaitingReason _Nullable reasonForWaitingToPlay;
        [NullAllowed, Export("reasonForWaitingToPlay")]
        string ReasonForWaitingToPlay();

        // @property (readonly, nonatomic) BOOL isPaused;
        [Export("isPaused")]
        bool IsPaused();

        // @property (readonly, nonatomic) BOOL isPlaying;
        [Export("isPlaying")]
        bool IsPlaying();

        // @property (readonly, nonatomic) BOOL isBuffering;
        [Export("isBuffering")]
        bool IsBuffering();

        // @property (readonly, nonatomic) BOOL isEvaluating;
        [Export("isEvaluating")]
        bool IsEvaluating();

        // @property (readonly, nonatomic) BOOL isNoAssetToPlay;
        [Export("isNoAssetToPlay")]
        bool IsNoAssetToPlay();

        // @property (readonly, nonatomic) BOOL isPlaybackFailed;
        [Export("isPlaybackFailed")]
        bool IsPlaybackFailed();

        // @property (readonly, nonatomic) BOOL isPlaybackFinished;
        [Export("isPlaybackFinished")]
        bool IsPlaybackFinished();

        // @property (readonly, nonatomic) SJFinishedReason _Nullable finishedReason;
        [NullAllowed, Export("finishedReason")]
        string FinishedReason();

        // -(void)play;
        [Export("play")]
        void Play();

        // -(void)pause;
        [Export("pause")]
        void Pause();

        // -(void)pauseForUser;
        [Export("pauseForUser")]
        void PauseForUser();

        // -(void)refresh;
        [Export("refresh")]
        void Refresh();

        // -(void)replay;
        [Export("replay")]
        void Replay();

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // @property (getter = isMuted, nonatomic) BOOL muted;
        [Export("muted")]
        bool Muted { [Bind("isMuted")] get; set; }

        // @property (nonatomic) float playerVolume;
        [Export("playerVolume")]
        float PlayerVolume { get; set; }

        // @property (nonatomic) float rate;
        [Export("rate")]
        float Rate { get; set; }

        // @property (readonly, nonatomic) NSTimeInterval currentTime;
        [Export("currentTime")]
        double CurrentTime();

        // @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration();

        // @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Export("playableDuration")]
        double PlayableDuration();

        // @property (readonly, nonatomic) NSTimeInterval durationWatched;
        [Export("durationWatched")]
        double DurationWatched();

        // @property (readonly, nonatomic) BOOL isUserPaused;
        [Export("isUserPaused")]
        bool IsUserPaused();

        // @property (readonly, nonatomic) BOOL isPlayed;
        [Export("isPlayed")]
        bool IsPlayed();

        // @property (readonly, nonatomic) BOOL isReplayed;
        [Export("isReplayed")]
        bool IsReplayed();

        // @property (readonly, nonatomic) SJPlaybackType playbackType;
        [Export("playbackType")]
        SJPlaybackType PlaybackType();

        // -(NSString * _Nonnull)stringForSeconds:(NSInteger)secs;
        [Export("stringForSeconds:")]
        string StringForSeconds(nint secs);

        // @property (getter = isPausedInBackground, nonatomic) BOOL pausedInBackground;
        [Export("pausedInBackground")]
        bool PausedInBackground { [Bind("isPausedInBackground")] get; set; }

        // @property (nonatomic) BOOL autoplayWhenSetNewAsset;
        [Export("autoplayWhenSetNewAsset")]
        bool AutoplayWhenSetNewAsset { get; set; }

        // @property (nonatomic) BOOL resumePlaybackWhenAppDidEnterForeground;
        [Export("resumePlaybackWhenAppDidEnterForeground")]
        bool ResumePlaybackWhenAppDidEnterForeground { get; set; }

        // @property (nonatomic) BOOL resumePlaybackWhenPlayerHasFinishedSeeking;
        [Export("resumePlaybackWhenPlayerHasFinishedSeeking")]
        bool ResumePlaybackWhenPlayerHasFinishedSeeking { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) canPlayAnAsset;
        [NullAllowed, Export("canPlayAnAsset", ArgumentSemantic.Copy)]
        Func<SJBaseVideoPlayer, bool> CanPlayAnAsset { get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) canSeekToTime;
        [NullAllowed, Export("canSeekToTime", ArgumentSemantic.Copy)]
        Func<SJBaseVideoPlayer, bool> CanSeekToTime { get; set; }

        // @property (nonatomic) BOOL accurateSeeking;
        [Export("accurateSeeking")]
        bool AccurateSeeking { get; set; }

        // -(void)seekToTime:(NSTimeInterval)secs completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Export("seekToTime:completionHandler:")]
        void SeekToTime(double secs, BoolArgumentAction completionHandler);

        // -(void)seekToTime:(CMTime)time toleranceBefore:(CMTime)toleranceBefore toleranceAfter:(CMTime)toleranceAfter completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Export("seekToTime:toleranceBefore:toleranceAfter:completionHandler:")]
        void SeekToTime(CMTime time, CMTime toleranceBefore, CMTime toleranceAfter, BoolArgumentAction completionHandler);

        // -(void)switchVideoDefinition:(SJVideoPlayerURLAsset * _Nonnull)URLAsset;
        [Export("switchVideoDefinition:")]
        void SwitchVideoDefinition(SJVideoPlayerURLAsset URLAsset);

        // @property (readonly, nonatomic, strong) SJVideoDefinitionSwitchingInfo * _Nonnull definitionSwitchingInfo;
        [Export("definitionSwitchingInfo", ArgumentSemantic.Strong)]
        SJVideoDefinitionSwitchingInfo DefinitionSwitchingInfo();

        // @property (readonly, nonatomic, strong) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error();
    }

    // @interface DeviceVolumeAndBrightness (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_DeviceVolumeAndBrightness
    {
        // @property (nonatomic, strong, null_resettable) id<SJDeviceVolumeAndBrightnessController> _Null_unspecified deviceVolumeAndBrightnessController;
        [NullAllowed, Export("deviceVolumeAndBrightnessController", ArgumentSemantic.Strong)]
        SJDeviceVolumeAndBrightnessController DeviceVolumeAndBrightnessController { get; set; }

        // @property (readonly, nonatomic, strong) id<SJDeviceVolumeAndBrightnessControllerObserver> _Nonnull deviceVolumeAndBrightnessObserver;
        [Export("deviceVolumeAndBrightnessObserver", ArgumentSemantic.Strong)]
        SJDeviceVolumeAndBrightnessControllerObserver DeviceVolumeAndBrightnessObserver();

        // @property (nonatomic) BOOL disableBrightnessSetting;
        [Export("disableBrightnessSetting")]
        bool DisableBrightnessSetting { get; set; }

        // @property (nonatomic) BOOL disableVolumeSetting;
        [Export("disableVolumeSetting")]
        bool DisableVolumeSetting { get; set; }
    }

    // @interface Life (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Life
    {
        // -(void)vc_viewDidAppear;
        [Export("vc_viewDidAppear")]
        void Vc_viewDidAppear();

        // -(void)vc_viewWillDisappear;
        [Export("vc_viewWillDisappear")]
        void Vc_viewWillDisappear();

        // -(void)vc_viewDidDisappear;
        [Export("vc_viewDidDisappear")]
        void Vc_viewDidDisappear();

        // -(BOOL)vc_prefersStatusBarHidden;
        [Export("vc_prefersStatusBarHidden")]
        //[Verify(MethodToProperty)]
        bool Vc_prefersStatusBarHidden();

        // -(UIStatusBarStyle)vc_preferredStatusBarStyle;
        [Export("vc_preferredStatusBarStyle")]
        //[Verify(MethodToProperty)]
        UIStatusBarStyle Vc_preferredStatusBarStyle();

        // @property (nonatomic) BOOL vc_isDisappeared;
        [Export("vc_isDisappeared")]
        bool Vc_isDisappeared { get; set; }

        // -(void)needShowStatusBar;
        [Export("needShowStatusBar")]
        void NeedShowStatusBar();

        // -(void)needHiddenStatusBar;
        [Export("needHiddenStatusBar")]
        void NeedHiddenStatusBar();
    }

    // @interface Network (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Network
    {
        // @property (nonatomic, strong, null_resettable) id<SJReachability> _Null_unspecified reachability;
        [NullAllowed, Export("reachability", ArgumentSemantic.Strong)]
        SJReachability Reachability { get; set; }

        // @property (readonly, nonatomic, strong) id<SJReachabilityObserver> _Nonnull reachabilityObserver;
        [Export("reachabilityObserver", ArgumentSemantic.Strong)]
        SJReachabilityObserver ReachabilityObserver();
    }

    // @interface Popup (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Popup
    {
        // @property (nonatomic, strong, null_resettable) id<SJTextPopupController> _Null_unspecified textPopupController;
        [NullAllowed, Export("textPopupController", ArgumentSemantic.Strong)]
        SJTextPopupController TextPopupController { get; set; }

        // @property (nonatomic, strong, null_resettable) id<SJPromptingPopupController> _Null_unspecified promptingPopupController;
        [NullAllowed, Export("promptingPopupController", ArgumentSemantic.Strong)]
        SJPromptingPopupController PromptingPopupController { get; set; }
    }

    // @interface Gesture (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Gesture
    {
        // @property (readonly, nonatomic, strong) id<SJGestureController> _Nonnull gestureController;
        [Export("gestureController", ArgumentSemantic.Strong)]
        SJGestureController GestureController();

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull, SJPlayerGestureType, CGPoint) gestureRecognizerShouldTrigger;
        [NullAllowed, Export("gestureRecognizerShouldTrigger", ArgumentSemantic.Copy)]
        Func<SJBaseVideoPlayer, SJPlayerGestureType, CGPoint, bool> GestureRecognizerShouldTrigger { get; set; }

        // @property (nonatomic) BOOL allowHorizontalTriggeringOfPanGesturesInCells;
        [Export("allowHorizontalTriggeringOfPanGesturesInCells")]
        bool AllowHorizontalTriggeringOfPanGesturesInCells { get; set; }

        // @property (nonatomic) CGFloat rateWhenLongPressGestureTriggered;
        [Export("rateWhenLongPressGestureTriggered")]
        nfloat RateWhenLongPressGestureTriggered { get; set; }

        // @property (nonatomic) CGFloat offsetFactorForHorizontalPanGesture;
        [Export("offsetFactorForHorizontalPanGesture")]
        nfloat OffsetFactorForHorizontalPanGesture { get; set; }
    }

    // @interface ControlLayer (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_ControlLayer
    {
        // @property (nonatomic, strong, null_resettable) id<SJControlLayerAppearManager> _Null_unspecified controlLayerAppearManager;
        [NullAllowed, Export("controlLayerAppearManager", ArgumentSemantic.Strong)]
        SJControlLayerAppearManager ControlLayerAppearManager { get; set; }

        // @property (readonly, nonatomic, strong) id<SJControlLayerAppearManagerObserver> _Nonnull controlLayerAppearObserver;
        [Export("controlLayerAppearObserver", ArgumentSemantic.Strong)]
        SJControlLayerAppearManagerObserver ControlLayerAppearObserver();

        // @property (getter = isControlLayerAppeared, nonatomic) BOOL controlLayerAppeared;
        [Export("controlLayerAppeared")]
        bool ControlLayerAppeared { [Bind("isControlLayerAppeared")] get; set; }

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) canAutomaticallyDisappear;
        [NullAllowed, Export("canAutomaticallyDisappear", ArgumentSemantic.Copy)]
        Func<SJBaseVideoPlayer, bool> CanAutomaticallyDisappear { get; set; }

        // -(void)controlLayerNeedAppear;
        [Export("controlLayerNeedAppear")]
        void ControlLayerNeedAppear();

        // -(void)controlLayerNeedDisappear;
        [Export("controlLayerNeedDisappear")]
        void ControlLayerNeedDisappear();

        // @property (nonatomic) BOOL pausedToKeepAppearState;
        [Export("pausedToKeepAppearState")]
        bool PausedToKeepAppearState { get; set; }
    }

    // @interface FitOnScreen (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_FitOnScreen
    {
        // @property (nonatomic, strong, null_resettable) id<SJFitOnScreenManager> _Null_unspecified fitOnScreenManager;
        [NullAllowed, Export("fitOnScreenManager", ArgumentSemantic.Strong)]
        SJFitOnScreenManager FitOnScreenManager { get; set; }

        // @property (readonly, nonatomic, strong) id<SJFitOnScreenManagerObserver> _Nonnull fitOnScreenObserver;
        [Export("fitOnScreenObserver", ArgumentSemantic.Strong)]
        SJFitOnScreenManagerObserver FitOnScreenObserver();

        // @property (getter = isFitOnScreen, nonatomic) BOOL fitOnScreen;
        [Export("fitOnScreen")]
        bool FitOnScreen { [Bind("isFitOnScreen")] get; set; }

        // @property (nonatomic) BOOL onlyFitOnScreen;
        [Export("onlyFitOnScreen")]
        bool OnlyFitOnScreen { get; set; }

        // -(void)setFitOnScreen:(BOOL)fitOnScreen animated:(BOOL)animated;
        [Export("setFitOnScreen:animated:")]
        void SetFitOnScreen(bool fitOnScreen, bool animated);

        // -(void)setFitOnScreen:(BOOL)fitOnScreen animated:(BOOL)animated completionHandler:(void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull))completionHandler;
        [Export("setFitOnScreen:animated:completionHandler:")]
        void SetFitOnScreen(bool fitOnScreen, bool animated, Action<SJBaseVideoPlayer> completionHandler);
    }

    // @interface Rotation (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Rotation
    {
        // @property (nonatomic, strong) id<SJRotationManager> _Nullable rotationManager;
        [NullAllowed, Export("rotationManager", ArgumentSemantic.Strong)]
        SJRotationManager RotationManager { get; set; }

        // @property (readonly, nonatomic, strong) id<SJRotationManagerObserver> _Nonnull rotationObserver;
        [Export("rotationObserver", ArgumentSemantic.Strong)]
        SJRotationManagerObserver RotationObserver();

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) shouldTriggerRotation;
        [NullAllowed, Export("shouldTriggerRotation", ArgumentSemantic.Copy)]
        Func<SJBaseVideoPlayer, bool> ShouldTriggerRotation { get; set; }

        // @property (nonatomic) BOOL allowsRotationInFitOnScreen;
        [Export("allowsRotationInFitOnScreen")]
        bool AllowsRotationInFitOnScreen { get; set; }

        // -(void)rotate;
        [Export("rotate")]
        void Rotate();

        // -(void)rotate:(SJOrientation)orientation animated:(BOOL)animated;
        [Export("rotate:animated:")]
        void Rotate(SJOrientation orientation, bool animated);

        // -(void)rotate:(SJOrientation)orientation animated:(BOOL)animated completion:(void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull))block;
        [Export("rotate:animated:completion:")]
        void Rotate(SJOrientation orientation, bool animated, Action<SJBaseVideoPlayer> block);

        // @property (readonly, nonatomic) BOOL isRotating;
        [Export("isRotating")]
        bool IsRotating();

        // @property (readonly, nonatomic) BOOL isFullscreen;
        [Export("isFullscreen")]
        bool IsFullscreen();

        // @property (getter = isLockedScreen, nonatomic) BOOL lockedScreen;
        [Export("lockedScreen")]
        bool LockedScreen { [Bind("isLockedScreen")] get; set; }

        // @property (readonly, nonatomic) UIInterfaceOrientation currentOrientation;
        [Export("currentOrientation")]
        UIInterfaceOrientation CurrentOrientation();
    }

    // @interface Screenshot (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Screenshot
    {
        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) presentationSizeDidChangeExeBlock;
        [NullAllowed, Export("presentationSizeDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PresentationSizeDidChangeExeBlock { get; set; }

        // @property (readonly, nonatomic) CGSize videoPresentationSize;
        [Export("videoPresentationSize")]
        CGSize VideoPresentationSize();

        // -(UIImage * _Nullable)screenshot;
        [NullAllowed, Export("screenshot")]
        //[Verify(MethodToProperty)]
        UIImage Screenshot();

        // -(void)screenshotWithTime:(NSTimeInterval)time completion:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, UIImage * _Nullable, NSError * _Nullable))block;
        [Export("screenshotWithTime:completion:")]
        void ScreenshotWithTime(double time, Action<SJBaseVideoPlayer, UIImage, NSError> block);

        // -(void)screenshotWithTime:(NSTimeInterval)time size:(CGSize)size completion:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, UIImage * _Nullable, NSError * _Nullable))block;
        [Export("screenshotWithTime:size:completion:")]
        void ScreenshotWithTime(double time, CGSize size, Action<SJBaseVideoPlayer, UIImage, NSError> block);
    }

    // @interface Export (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Export
    {
        // -(void)exportWithBeginTime:(NSTimeInterval)beginTime duration:(NSTimeInterval)duration presetName:(NSString * _Nullable)presetName progress:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, float))progressBlock completion:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, NSURL * _Nonnull, UIImage * _Nonnull))completion failure:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, NSError * _Nonnull))failure;
        [Export("exportWithBeginTime:duration:presetName:progress:completion:failure:")]
        void ExportWithBeginTime(double beginTime, double duration, string presetName, Action<SJBaseVideoPlayer, float> progressBlock, Action<SJBaseVideoPlayer, NSUrl, UIImage> completion, Action<SJBaseVideoPlayer, NSError> failure);

        // -(void)cancelExportOperation;
        [Export("cancelExportOperation")]
        void CancelExportOperation();

        // -(void)generateGIFWithBeginTime:(NSTimeInterval)beginTime duration:(NSTimeInterval)duration progress:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, float))progressBlock completion:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, UIImage * _Nonnull, UIImage * _Nonnull, NSURL * _Nonnull))completion failure:(void (^ _Nonnull)(__kindof SJBaseVideoPlayer * _Nonnull, NSError * _Nonnull))failure;
        [Export("generateGIFWithBeginTime:duration:progress:completion:failure:")]
        void GenerateGIFWithBeginTime(double beginTime, double duration, Action<SJBaseVideoPlayer, float> progressBlock, Action<SJBaseVideoPlayer, UIImage, UIImage, NSUrl> completion, Action<SJBaseVideoPlayer, NSError> failure);

        // -(void)cancelGenerateGIFOperation;
        [Export("cancelGenerateGIFOperation")]
        void CancelGenerateGIFOperation();
    }

    // @interface ScrollView (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_ScrollView
    {
        // -(void)refreshAppearStateForPlayerView;
        [Export("refreshAppearStateForPlayerView")]
        void RefreshAppearStateForPlayerView();

        // @property (nonatomic, strong, null_resettable) id<SJSmallViewFloatingController> _Null_unspecified smallViewFloatingController;
        [NullAllowed, Export("smallViewFloatingController", ArgumentSemantic.Strong)]
        SJSmallViewFloatingController SmallViewFloatingController { get; set; }

        // @property (getter = isHiddenFloatSmallViewWhenPlaybackFinished, nonatomic) BOOL hiddenFloatSmallViewWhenPlaybackFinished;
        [Export("hiddenFloatSmallViewWhenPlaybackFinished")]
        bool HiddenFloatSmallViewWhenPlaybackFinished { [Bind("isHiddenFloatSmallViewWhenPlaybackFinished")] get; set; }

        // @property (nonatomic) BOOL pausedWhenScrollDisappeared;
        [Export("pausedWhenScrollDisappeared")]
        bool PausedWhenScrollDisappeared { get; set; }

        // @property (nonatomic) BOOL resumePlaybackWhenScrollAppeared;
        [Export("resumePlaybackWhenScrollAppeared")]
        bool ResumePlaybackWhenScrollAppeared { get; set; }

        // @property (nonatomic) BOOL hiddenViewWhenScrollDisappeared;
        [Export("hiddenViewWhenScrollDisappeared")]
        bool HiddenViewWhenScrollDisappeared { get; set; }

        // @property (readonly, nonatomic) BOOL isPlayOnScrollView;
        [Export("isPlayOnScrollView")]
        bool IsPlayOnScrollView();

        // @property (readonly, nonatomic) BOOL isScrollAppeared;
        [Export("isScrollAppeared")]
        bool IsScrollAppeared();

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playerViewWillAppearExeBlock;
        [NullAllowed, Export("playerViewWillAppearExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PlayerViewWillAppearExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playerViewWillDisappearExeBlock;
        [NullAllowed, Export("playerViewWillDisappearExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer> PlayerViewWillDisappearExeBlock { get; set; }
    }

    // @interface Subtitle (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Subtitle
    {
        // @property (nonatomic, strong, null_resettable) id<SJSubtitlePopupController> _Null_unspecified subtitlePopupController;
        [NullAllowed, Export("subtitlePopupController", ArgumentSemantic.Strong)]
        SJSubtitlePopupController SubtitlePopupController { get; set; }

        // @property (nonatomic) CGFloat subtitleBottomMargin;
        [Export("subtitleBottomMargin")]
        nfloat SubtitleBottomMargin { get; set; }

        // @property (nonatomic) CGFloat subtitleHorizontalMinMargin;
        [Export("subtitleHorizontalMinMargin")]
        nfloat SubtitleHorizontalMinMargin { get; set; }
    }

    // @interface Danmaku (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Danmaku
    {
        // @property (nonatomic, strong, null_resettable) id<SJDanmakuPopupController> _Null_unspecified danmakuPopupController;
        [NullAllowed, Export("danmakuPopupController", ArgumentSemantic.Strong)]
        SJDanmakuPopupController DanmakuPopupController { get; set; }
    }

    // @interface Watermark (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Watermark
    {
        // @property (nonatomic, strong) UIView<SJWatermarkView> * _Nullable watermarkView;
        [NullAllowed, Export("watermarkView", ArgumentSemantic.Strong)]
        SJWatermarkView WatermarkView { get; set; }

        // -(void)updateWatermarkViewLayout;
        [Export("updateWatermarkViewLayout")]
        void UpdateWatermarkViewLayout();
    }

    // @interface Deprecated (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Deprecated
    {
        // -(void)playWithURL:(NSURL * _Nonnull)URL;
        [Export("playWithURL:")]
        void PlayWithURL(NSUrl URL);

        // @property (nonatomic, strong) NSURL * _Nullable assetURL;
        [NullAllowed, Export("assetURL", ArgumentSemantic.Strong)]
        NSUrl AssetURL { get; set; }

        // @property (readonly, nonatomic) BOOL isPlayedToEndTime __attribute__((deprecated("use `isPlaybackFinished`;")));
        [Export("isPlayedToEndTime")]
        bool IsPlayedToEndTime();
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJMediaType _Nonnull SJMediaTypeVideo;
        [Field("SJMediaTypeVideo", "__Internal")]
        NSString SJMediaTypeVideo { get; }

        // extern const SJMediaType _Nonnull SJMediaTypeAudio;
        [Field("SJMediaTypeAudio", "__Internal")]
        NSString SJMediaTypeAudio { get; }
    }

    // @protocol SJPlaybackHistoryController <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJPlaybackHistoryController
    {
        // @required -(void)save:(id<SJPlaybackRecord> _Nonnull)record;
        [Abstract]
        [Export("save:")]
        void Save(SJPlaybackRecord record);

        // @required -(id<SJPlaybackRecord> _Nullable)recordForMedia:(NSInteger)mediaId user:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Abstract]
        [Export("recordForMedia:user:mediaType:")]
        //[return: NullAllowed]
        SJPlaybackRecord RecordForMedia(nint mediaId, nint userId, string mediaType);

        // @required -(NSArray<id<SJPlaybackRecord>> * _Nullable)recordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType range:(NSRange)range;
        [Abstract]
        [Export("recordsForUser:mediaType:range:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForUser(nint userId, string mediaType, NSRange range);

        // @required -(NSArray<id<SJPlaybackRecord>> * _Nullable)recordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Abstract]
        [Export("recordsForUser:mediaType:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForUser(nint userId, string mediaType);

        // @required -(NSArray<id<SJPlaybackRecord>> * _Nullable)recordsForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders range:(NSRange)range;
        [Abstract]
        [Export("recordsForConditions:orderBy:range:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForConditions(SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, NSRange range);

        // @required -(NSArray<id<SJPlaybackRecord>> * _Nullable)recordsForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders;
        [Abstract]
        [Export("recordsForConditions:orderBy:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForConditions(SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders);

        // @required -(NSUInteger)countOfRecordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Abstract]
        [Export("countOfRecordsForUser:mediaType:")]
        nuint CountOfRecordsForUser(nint userId, string mediaType);

        // @required -(NSUInteger)countOfRecordsForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions;
        [Abstract]
        [Export("countOfRecordsForConditions:")]
        nuint CountOfRecordsForConditions(SJSQLite3Condition[] conditions);

        // @required -(void)remove:(NSInteger)media user:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Abstract]
        [Export("remove:user:mediaType:")]
        void Remove(nint media, nint userId, string mediaType);

        // @required -(void)removeAllRecordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Abstract]
        [Export("removeAllRecordsForUser:mediaType:")]
        void RemoveAllRecordsForUser(nint userId, string mediaType);

        // @required -(void)removeForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions;
        [Abstract]
        [Export("removeForConditions:")]
        void RemoveForConditions(SJSQLite3Condition[] conditions);
    }

    // @protocol SJPlaybackRecord <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJPlaybackRecord
    {
        // @required @property (readonly, nonatomic) NSInteger mediaId;
        [Abstract]
        [Export("mediaId")]
        nint MediaId();

        // @required @property (readonly, nonatomic) NSInteger userId;
        [Abstract]
        [Export("userId")]
        nint UserId();

        // @required @property (readonly, nonatomic) SJMediaType _Nonnull mediaType;
        [Abstract]
        [Export("mediaType")]
        string MediaType();

        // @required @property (readonly, nonatomic) NSTimeInterval position;
        [Abstract]
        [Export("position")]
        double Position();

        // @required @property (readonly, nonatomic) NSTimeInterval createdTime;
        [Abstract]
        [Export("createdTime")]
        double CreatedTime();

        // @required @property (readonly, nonatomic) NSTimeInterval updatedTime;
        [Abstract]
        [Export("updatedTime")]
        double UpdatedTime();
    }

    // @interface SJPlaybackRecord : NSObject <SJPlaybackRecord>
    [BaseType(typeof(NSObject))]
    interface SJPlaybackRecord : ISJPlaybackRecord
    {
        // -(instancetype _Nonnull)initWithMediaId:(NSInteger)mediaId mediaType:(SJMediaType _Nonnull)mediaType userId:(NSInteger)userId;
        [Export("initWithMediaId:mediaType:userId:")]
        NativeHandle Constructor(nint mediaId, string mediaType, nint userId);

        // @property (nonatomic) NSInteger mediaId;
        [Export("mediaId")]
        nint MediaId { get; set; }

        // @property (nonatomic) NSInteger userId;
        [Export("userId")]
        nint UserId { get; set; }

        // @property (nonatomic) NSTimeInterval position;
        [Export("position")]
        double Position { get; set; }

        // @property (nonatomic) SJMediaType _Nonnull mediaType;
        [Export("mediaType")]
        string MediaType { get; set; }
    }

    // @interface SJPrivate (SJPlaybackRecord)
    [Category]
    [BaseType(typeof(SJPlaybackRecord))]
    interface SJPlaybackRecord_SJPrivate
    {
        // @property (nonatomic) NSInteger id;
        [Export("id")]
        nint Id { get; set; }

        // @property (nonatomic) NSTimeInterval createdTime;
        [Export("createdTime")]
        double CreatedTime { get; set; }

        // @property (nonatomic) NSTimeInterval updatedTime;
        [Export("updatedTime")]
        double UpdatedTime { get; set; }
    }

    // @interface SJSQLite3Extended (SJPlaybackRecord) <SJSQLiteTableModelProtocol>
    [Category]
    [BaseType(typeof(SJPlaybackRecord))]
    interface SJPlaybackRecord_SJSQLite3Extended : SJSQLiteTableModelProtocol
    {
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJMediaType _Nonnull SJMediaTypeVideo;
        //[Field("SJMediaTypeVideo", "__Internal")]
        //NSString SJMediaTypeVideo { get; }

        // extern const SJMediaType _Nonnull SJMediaTypeAudio;
        //[Field("SJMediaTypeAudio", "__Internal")]
        //NSString SJMediaTypeAudio { get; }
    }

    // @interface SJPlaybackHistoryController : NSObject <SJPlaybackHistoryController>
    [BaseType(typeof(NSObject))]
    interface SJPlaybackHistoryController : ISJPlaybackHistoryController
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJPlaybackHistoryController Shared();

        // -(instancetype _Nonnull)initWithPath:(NSString * _Nonnull)path;
        [Export("initWithPath:")]
        NativeHandle Constructor(string path);

        // -(void)save:(SJPlaybackRecord * _Nonnull)record;
        [Export("save:")]
        void Save(SJPlaybackRecord record);

        // -(SJPlaybackRecord * _Nullable)recordForMedia:(NSInteger)mediaId user:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Export("recordForMedia:user:mediaType:")]
        //[return: NullAllowed]
        SJPlaybackRecord RecordForMedia(nint mediaId, nint userId, string mediaType);

        // -(NSArray<SJPlaybackRecord *> * _Nullable)recordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType range:(NSRange)range;
        [Export("recordsForUser:mediaType:range:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForUser(nint userId, string mediaType, NSRange range);

        // -(NSArray<SJPlaybackRecord *> * _Nullable)recordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Export("recordsForUser:mediaType:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForUser(nint userId, string mediaType);

        // -(NSArray<SJPlaybackRecord *> * _Nullable)recordsForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders range:(NSRange)range;
        [Export("recordsForConditions:orderBy:range:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForConditions(SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, NSRange range);

        // -(NSArray<SJPlaybackRecord *> * _Nullable)recordsForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders;
        [Export("recordsForConditions:orderBy:")]
        //[return: NullAllowed]
        SJPlaybackRecord[] RecordsForConditions(SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders);

        // -(NSUInteger)countOfRecordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Export("countOfRecordsForUser:mediaType:")]
        nuint CountOfRecordsForUser(nint userId, string mediaType);

        // -(NSUInteger)countOfRecordsForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions;
        [Export("countOfRecordsForConditions:")]
        nuint CountOfRecordsForConditions(SJSQLite3Condition[] conditions);

        // -(void)remove:(NSInteger)media user:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Export("remove:user:mediaType:")]
        void Remove(nint media, nint userId, string mediaType);

        // -(void)removeAllRecordsForUser:(NSInteger)userId mediaType:(SJMediaType _Nonnull)mediaType;
        [Export("removeAllRecordsForUser:mediaType:")]
        void RemoveAllRecordsForUser(nint userId, string mediaType);

        // -(void)removeForConditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions;
        [Export("removeForConditions:")]
        void RemoveForConditions(SJSQLite3Condition[] conditions);
    }

    // @interface SJPlaybackRecordSaveHandlerExtended (SJVideoPlayerURLAsset)
    [Category]
    [BaseType(typeof(SJVideoPlayerURLAsset))]
    interface SJVideoPlayerURLAsset_SJPlaybackRecordSaveHandlerExtended
    {
        // @property (nonatomic, strong) SJPlaybackRecord * _Nullable record;
        [NullAllowed, Export("record", ArgumentSemantic.Strong)]
        SJPlaybackRecord Record { get; set; }
    }

    // @interface SJPlaybackRecordSaveHandler : NSObject
    [BaseType(typeof(NSObject))]
    interface SJPlaybackRecordSaveHandler
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJPlaybackRecordSaveHandler Shared();

        // -(instancetype _Nonnull)initWithEvents:(SJPlayerEventMask)events playbackHistoryController:(id<SJPlaybackHistoryController> _Nonnull)controller;
        [Export("initWithEvents:playbackHistoryController:")]
        NativeHandle Constructor(SJPlayerEventMask events, SJPlaybackHistoryController controller);

        // @property (nonatomic) SJPlayerEventMask events;
        [Export("events", ArgumentSemantic.Assign)]
        SJPlayerEventMask Events { get; set; }
    }

    // @interface SJPlayerEventObserver : NSObject
    [BaseType(typeof(NSObject))]
    interface SJPlayerEventObserver
    {
        // -(instancetype _Nonnull)initWithEvents:(SJPlayerEventMask)events handler:(void (^ _Nonnull)(id _Nonnull, SJPlayerEvent))block;
        [Export("initWithEvents:handler:")]
        NativeHandle Constructor(SJPlayerEventMask events, Action<NSObject, SJPlayerEvent> block);

        // @property (nonatomic) SJPlayerEventMask events;
        [Export("events", ArgumentSemantic.Assign)]
        SJPlayerEventMask Events { get; set; }
    }

    // @interface SJPlayerAutoplayConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface SJPlayerAutoplayConfig
    {
        // +(instancetype _Nonnull)configWithPlayerSuperviewSelector:(SEL _Nullable)playerSuperviewSelector autoplayDelegate:(id<SJPlayerAutoplayDelegate> _Nonnull)delegate;
        [Static]
        [Export("configWithPlayerSuperviewSelector:autoplayDelegate:")]
        SJPlayerAutoplayConfig ConfigWithPlayerSuperviewSelector(Selector playerSuperviewSelector, SJPlayerAutoplayDelegate @delegate);

        // @property (nonatomic) SEL _Nullable playerSuperviewSelector;
        [NullAllowed, Export("playerSuperviewSelector", ArgumentSemantic.Assign)]
        Selector PlayerSuperviewSelector { get; set; }

        [Wrap("WeakAutoplayDelegate")]
        [NullAllowed]
        SJPlayerAutoplayDelegate AutoplayDelegate();

        // @property (readonly, nonatomic, weak) id<SJPlayerAutoplayDelegate> _Nullable autoplayDelegate;
        [NullAllowed, Export("autoplayDelegate", ArgumentSemantic.Weak)]
        NSObject WeakAutoplayDelegate();

        // @property (nonatomic) UICollectionViewScrollDirection scrollDirection;
        [Export("scrollDirection", ArgumentSemantic.Assign)]
        UICollectionViewScrollDirection ScrollDirection { get; set; }

        // @property (nonatomic) UIEdgeInsets playableAreaInsets;
        [Export("playableAreaInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets PlayableAreaInsets { get; set; }
    }

    // @protocol SJPlayerAutoplayDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJPlayerAutoplayDelegate
    {
        // @required -(void)sj_playerNeedPlayNewAssetAtIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Abstract]
        [Export("sj_playerNeedPlayNewAssetAtIndexPath:")]
        void Sj_playerNeedPlayNewAssetAtIndexPath(NSIndexPath indexPath);
    }

    // @interface SJDeprecated (SJPlayerAutoplayConfig)
    [Category]
    [BaseType(typeof(SJPlayerAutoplayConfig))]
    interface SJPlayerAutoplayConfig_SJDeprecated
    {
        // +(instancetype _Nonnull)configWithAutoplayDelegate:(id<SJPlayerAutoplayDelegate> _Nonnull)autoplayDelegate __attribute__((deprecated("use `configWithPlayerSuperviewSelector:autoplayDelegate:`;")));
        [Static]
        [Export("configWithAutoplayDelegate:")]
        SJPlayerAutoplayConfig ConfigWithAutoplayDelegate(SJPlayerAutoplayDelegate autoplayDelegate);

        // +(instancetype _Nonnull)configWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag autoplayDelegate:(id<SJPlayerAutoplayDelegate> _Nonnull)autoplayDelegate __attribute__((deprecated("use `configWithPlayerSuperviewSelector:autoplayDelegate:`;")));
        [Static]
        [Export("configWithPlayerSuperviewTag:autoplayDelegate:")]
        SJPlayerAutoplayConfig ConfigWithPlayerSuperviewTag(nint playerSuperviewTag, SJPlayerAutoplayDelegate autoplayDelegate);

        // @property (readonly, nonatomic) NSInteger playerSuperviewTag __attribute__((deprecated("use `config.scrollViewSelector`")));
        [Export("playerSuperviewTag")]
        nint PlayerSuperviewTag();
    }

    // @interface ListViewAutoplaySJAdd (UIScrollView)
    [Category]
    [BaseType(typeof(UIScrollView))]
    interface UIScrollView_ListViewAutoplaySJAdd
    {
        // @property (readonly, nonatomic) BOOL sj_enabledAutoplay;
        [Export("sj_enabledAutoplay")]
        bool Sj_enabledAutoplay();

        // -(void)sj_enableAutoplayWithConfig:(SJPlayerAutoplayConfig * _Nonnull)autoplayConfig;
        [Export("sj_enableAutoplayWithConfig:")]
        void Sj_enableAutoplayWithConfig(SJPlayerAutoplayConfig autoplayConfig);

        // -(void)sj_disableAutoplay;
        [Export("sj_disableAutoplay")]
        void Sj_disableAutoplay();

        // -(void)sj_removeCurrentPlayerView;
        [Export("sj_removeCurrentPlayerView")]
        void Sj_removeCurrentPlayerView();
    }

    // @interface SJAutoplayPlayerAssigns (UIScrollView)
    [Category]
    [BaseType(typeof(UIScrollView))]
    interface UIScrollView_SJAutoplayPlayerAssigns
    {
        // @property (readonly, nonatomic, strong) NSIndexPath * _Nullable sj_currentPlayingIndexPath;
        [NullAllowed, Export("sj_currentPlayingIndexPath", ArgumentSemantic.Strong)]
        NSIndexPath Sj_currentPlayingIndexPath();

        // -(void)setSj_currentPlayingIndexPath:(NSIndexPath * _Nullable)sj_currentPlayingIndexPath;
        [Export("setSj_currentPlayingIndexPath:")]
        void SetSj_currentPlayingIndexPath(NSIndexPath sj_currentPlayingIndexPath);
    }

    // @interface SJAVMediaExport (AVAsset)
    [Category]
    [BaseType(typeof(AVAsset))]
    interface AVAsset_SJAVMediaExport
    {
        // -(void)sj_generatePreviewImagesWithMaxItemSize:(CGSize)itemSize count:(NSUInteger)count completionHandler:(void (^ _Nonnull)(AVAsset * _Nonnull, NSArray<UIImage *> * _Nullable, NSError * _Nullable))block;
        [Export("sj_generatePreviewImagesWithMaxItemSize:count:completionHandler:")]
        void Sj_generatePreviewImagesWithMaxItemSize(CGSize itemSize, nuint count, Action<AVAsset, NSArray<UIImage>, NSError> block);

        // -(void)sj_cancelGeneratePreviewImages;
        [Export("sj_cancelGeneratePreviewImages")]
        void Sj_cancelGeneratePreviewImages();

        // -(void)sj_exportWithStartTime:(NSTimeInterval)secs0 duration:(NSTimeInterval)secs1 toFile:(NSURL * _Nonnull)fileURL presetName:(NSString * _Nullable)presetName progress:(void (^ _Nullable)(AVAsset * _Nonnull, float))progressBlock success:(void (^ _Nullable)(AVAsset * _Nonnull, AVAsset * _Nullable, NSURL * _Nullable, UIImage * _Nullable))successBlock failure:(void (^ _Nullable)(AVAsset * _Nonnull, NSError * _Nullable))failureBlock;
        [Export("sj_exportWithStartTime:duration:toFile:presetName:progress:success:failure:")]
        void Sj_exportWithStartTime(double secs0, double secs1, NSUrl fileURL, string presetName, Action<AVAsset, float> progressBlock, Action<AVAsset, AVAsset, NSUrl, UIImage> successBlock, Action<AVAsset, NSError> failureBlock);

        // -(void)sj_cancelExportOperation;
        [Export("sj_cancelExportOperation")]
        void Sj_cancelExportOperation();

        // -(UIImage * _Nullable)sj_screenshotWithTime:(CMTime)time;
        [Export("sj_screenshotWithTime:")]
        //[return: NullAllowed]
        UIImage Sj_screenshotWithTime(CMTime time);

        // -(void)sj_screenshotWithTime:(NSTimeInterval)time completionHandler:(void (^ _Nonnull)(AVAsset * _Nonnull, UIImage * _Nullable, NSError * _Nullable))block;
        [Export("sj_screenshotWithTime:completionHandler:")]
        void Sj_screenshotWithTime(double time, Action<AVAsset, UIImage, NSError> block);

        // -(void)sj_screenshotWithTime:(NSTimeInterval)time size:(CGSize)size completionHandler:(void (^ _Nonnull)(AVAsset * _Nonnull, UIImage * _Nullable, NSError * _Nullable))block;
        [Export("sj_screenshotWithTime:size:completionHandler:")]
        void Sj_screenshotWithTime(double time, CGSize size, Action<AVAsset, UIImage, NSError> block);

        // -(void)sj_cancelScreenshotOperation;
        [Export("sj_cancelScreenshotOperation")]
        void Sj_cancelScreenshotOperation();

        // -(void)sj_generateGIFWithBeginTime:(NSTimeInterval)beginTime duration:(NSTimeInterval)duration imageMaxSize:(CGSize)size interval:(float)interval toFile:(NSURL * _Nonnull)fileURL progress:(void (^ _Nonnull)(AVAsset * _Nonnull, float))progressBlock success:(void (^ _Nonnull)(AVAsset * _Nonnull, UIImage * _Nonnull, UIImage * _Nonnull))successBlock failure:(void (^ _Nonnull)(AVAsset * _Nonnull, NSError * _Nonnull))failureBlock;
        [Export("sj_generateGIFWithBeginTime:duration:imageMaxSize:interval:toFile:progress:success:failure:")]
        void Sj_generateGIFWithBeginTime(double beginTime, double duration, CGSize size, float interval, NSUrl fileURL, Action<AVAsset, float> progressBlock, Action<AVAsset, UIImage, UIImage> successBlock, Action<AVAsset, NSError> failureBlock);

        // -(void)sj_cancelGenerateGIFOperation;
        [Export("sj_cancelGenerateGIFOperation")]
        void Sj_cancelGenerateGIFOperation();
    }

    // @interface SJMediaPlaybackController : NSObject <SJVideoPlayerPlaybackController>
    [BaseType(typeof(NSObject))]
    interface SJMediaPlaybackController : SJVideoPlayerPlaybackController
    {
        // @property (nonatomic, strong) SJVideoPlayerURLAsset * _Nullable media;
        [NullAllowed, Export("media", ArgumentSemantic.Strong)]
        SJVideoPlayerURLAsset Media { get; set; }

        // @property (readonly, nonatomic, strong) id<SJMediaPlayer> _Nullable currentPlayer;
        [NullAllowed, Export("currentPlayer", ArgumentSemantic.Strong)]
        SJMediaPlayer CurrentPlayer();

        // @property (readonly, nonatomic, strong) __kindof UIView<SJMediaPlayerView> * _Nullable currentPlayerView;
        [NullAllowed, Export("currentPlayerView", ArgumentSemantic.Strong)]
        SJMediaPlayerView CurrentPlayerView();

        // -(void)playerWithMedia:(SJVideoPlayerURLAsset * _Nonnull)media completionHandler:(void (^ _Nonnull)(id<SJMediaPlayer> _Nullable))completionHandler;
        [Export("playerWithMedia:completionHandler:")]
        void PlayerWithMedia(SJVideoPlayerURLAsset media, Action<SJMediaPlayer> completionHandler);

        // -(UIView<SJMediaPlayerView> * _Nonnull)playerViewWithPlayer:(id<SJMediaPlayer> _Nonnull)player;
        [Export("playerViewWithPlayer:")]
        SJMediaPlayerView PlayerViewWithPlayer(SJMediaPlayer player);

        // -(void)receivedApplicationDidBecomeActiveNotification;
        [Export("receivedApplicationDidBecomeActiveNotification")]
        void ReceivedApplicationDidBecomeActiveNotification();

        // -(void)receivedApplicationWillResignActiveNotification;
        [Export("receivedApplicationWillResignActiveNotification")]
        void ReceivedApplicationWillResignActiveNotification();

        // -(void)receivedApplicationWillEnterForegroundNotification;
        [Export("receivedApplicationWillEnterForegroundNotification")]
        void ReceivedApplicationWillEnterForegroundNotification();

        // -(void)receivedApplicationDidEnterBackgroundNotification;
        [Export("receivedApplicationDidEnterBackgroundNotification")]
        void ReceivedApplicationDidEnterBackgroundNotification();

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJVideoPlayerPlaybackController> _Nonnull, void (^ _Nonnull)(BOOL)) restoreUserInterfaceForPictureInPictureStop;
        [NullAllowed, Export("restoreUserInterfaceForPictureInPictureStop", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerPlaybackController, BoolArgumentAction> RestoreUserInterfaceForPictureInPictureStop { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSNotificationName _Nonnull SJMediaPlayerAssetStatusDidChangeNotification;
        [Field("SJMediaPlayerAssetStatusDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerAssetStatusDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerTimeControlStatusDidChangeNotification;
        [Field("SJMediaPlayerTimeControlStatusDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerTimeControlStatusDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerPresentationSizeDidChangeNotification;
        [Field("SJMediaPlayerPresentationSizeDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerPresentationSizeDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerPlaybackDidFinishNotification;
        [Field("SJMediaPlayerPlaybackDidFinishNotification", "__Internal")]
        NSString SJMediaPlayerPlaybackDidFinishNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerDidReplayNotification;
        [Field("SJMediaPlayerDidReplayNotification", "__Internal")]
        NSString SJMediaPlayerDidReplayNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerDurationDidChangeNotification;
        [Field("SJMediaPlayerDurationDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerDurationDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerPlayableDurationDidChangeNotification;
        [Field("SJMediaPlayerPlayableDurationDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerPlayableDurationDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerRateDidChangeNotification;
        [Field("SJMediaPlayerRateDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerRateDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerVolumeDidChangeNotification;
        [Field("SJMediaPlayerVolumeDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerVolumeDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerMutedDidChangeNotification;
        [Field("SJMediaPlayerMutedDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerMutedDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJMediaPlayerViewReadyForDisplayNotification;
        [Field("SJMediaPlayerViewReadyForDisplayNotification", "__Internal")]
        NSString SJMediaPlayerViewReadyForDisplayNotification { get; }
    }

    // @protocol SJMediaPlayerView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJMediaPlayerView
    {
        // @required @property (nonatomic) SJVideoGravity _Nonnull videoGravity;
        [Abstract]
        [Export("videoGravity")]
        string VideoGravity { get; set; }

        // @required @property (readonly, getter = isReadyForDisplay, nonatomic) BOOL readyForDisplay;
        [Abstract]
        [Export("readyForDisplay")]
        bool ReadyForDisplay { [Bind("isReadyForDisplay")] get; }
    }

    // @protocol SJMediaPlayer <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJMediaPlayer
    {
        // @required @property (readonly, nonatomic, strong) NSError * _Nullable error;
        [Abstract]
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error();

        // @required @property (readonly, nonatomic) SJWaitingReason _Nullable reasonForWaitingToPlay;
        [Abstract]
        [NullAllowed, Export("reasonForWaitingToPlay")]
        string ReasonForWaitingToPlay();

        // @required @property (readonly, nonatomic) SJPlaybackTimeControlStatus timeControlStatus;
        [Abstract]
        [Export("timeControlStatus")]
        SJPlaybackTimeControlStatus TimeControlStatus();

        // @required @property (readonly, nonatomic) SJAssetStatus assetStatus;
        [Abstract]
        [Export("assetStatus")]
        SJAssetStatus AssetStatus();

        // @required @property (readonly, nonatomic) SJSeekingInfo seekingInfo;
        [Abstract]
        [Export("seekingInfo")]
        SJSeekingInfo SeekingInfo();

        // @required @property (readonly, nonatomic) CGSize presentationSize;
        [Abstract]
        [Export("presentationSize")]
        CGSize PresentationSize();

        // @required @property (readonly, nonatomic) BOOL isReplayed;
        [Abstract]
        [Export("isReplayed")]
        bool IsReplayed();

        // @required @property (readonly, nonatomic) BOOL isPlayed;
        [Abstract]
        [Export("isPlayed")]
        bool IsPlayed();

        // @required @property (readonly, nonatomic) BOOL isPlaybackFinished;
        [Abstract]
        [Export("isPlaybackFinished")]
        bool IsPlaybackFinished();

        // @required @property (readonly, nonatomic) SJFinishedReason _Nullable finishedReason;
        [Abstract]
        [NullAllowed, Export("finishedReason")]
        string FinishedReason();

        // @required @property (nonatomic) NSTimeInterval trialEndPosition;
        [Abstract]
        [Export("trialEndPosition")]
        double TrialEndPosition { get; set; }

        // @required @property (nonatomic) float rate;
        [Abstract]
        [Export("rate")]
        float Rate { get; set; }

        // @required @property (nonatomic) float volume;
        [Abstract]
        [Export("volume")]
        float Volume { get; set; }

        // @required @property (getter = isMuted, nonatomic) BOOL muted;
        [Abstract]
        [Export("muted")]
        bool Muted { [Bind("isMuted")] get; set; }

        // @required -(void)seekToTime:(CMTime)time completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Abstract]
        [Export("seekToTime:completionHandler:")]
        void SeekToTime(CMTime time, BoolArgumentAction completionHandler);

        // @required @property (readonly, nonatomic) NSTimeInterval currentTime;
        [Abstract]
        [Export("currentTime")]
        double CurrentTime();

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Abstract]
        [Export("duration")]
        double Duration();

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Abstract]
        [Export("playableDuration")]
        double PlayableDuration();

        // @required -(void)play;
        [Abstract]
        [Export("play")]
        void Play();

        // @required -(void)pause;
        [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)replay;
        [Abstract]
        [Export("replay")]
        void Replay();

        // @required -(void)report;
        [Abstract]
        [Export("report")]
        void Report();

        // @required -(UIImage * _Nullable)screenshot;
        [Abstract]
        [NullAllowed, Export("screenshot")]
        //[Verify(MethodToProperty)]
        UIImage Screenshot();
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSNotificationName _Nonnull SJMediaPlayerPlaybackTypeDidChangeNotification;
        [Field("SJMediaPlayerPlaybackTypeDidChangeNotification", "__Internal")]
        NSString SJMediaPlayerPlaybackTypeDidChangeNotification();
    }

    // @interface SJSwitchDefinitionExtended (SJMediaPlaybackController)
    [Category]
    [BaseType(typeof(SJMediaPlaybackController))]
    interface SJMediaPlaybackController_SJSwitchDefinitionExtended
    {
        // -(void)replaceMediaForDefinitionMedia:(SJVideoPlayerURLAsset * _Nonnull)definitionMedia __attribute__((objc_requires_super));
        [Export("replaceMediaForDefinitionMedia:")]
        [RequiresSuper]
        void ReplaceMediaForDefinitionMedia(SJVideoPlayerURLAsset definitionMedia);
    }

    // @interface SJAVMediaPlayer : NSObject <SJMediaPlayer>
    [BaseType(typeof(NSObject))]
    interface SJAVMediaPlayer : SJMediaPlayer
    {
        // -(instancetype _Nonnull)initWithAVPlayer:(AVPlayer * _Nonnull)player startPosition:(NSTimeInterval)time;
        [Export("initWithAVPlayer:startPosition:")]
        NativeHandle Constructor(AVPlayer player, double time);

        // @property (nonatomic) NSTimeInterval trialEndPosition;
        [Export("trialEndPosition")]
        double TrialEndPosition { get; set; }

        // @property (readonly, nonatomic, strong) AVPlayer * _Nonnull avPlayer;
        [Export("avPlayer", ArgumentSemantic.Strong)]
        AVPlayer AvPlayer();

        // @property (readonly, nonatomic) SJPlaybackType playbackType;
        [Export("playbackType")]
        SJPlaybackType PlaybackType();

        // @property (nonatomic) NSTimeInterval minBufferedDuration;
        [Export("minBufferedDuration")]
        double MinBufferedDuration { get; set; }

        // @property (nonatomic) BOOL accurateSeeking;
        [Export("accurateSeeking")]
        bool AccurateSeeking { get; set; }

        // -(void)seekToTime:(CMTime)time toleranceBefore:(CMTime)toleranceBefore toleranceAfter:(CMTime)toleranceAfter completionHandler:(void (^ _Nullable)(BOOL))completionHandler;
        [Export("seekToTime:toleranceBefore:toleranceAfter:completionHandler:")]
        void SeekToTime(CMTime time, CMTime toleranceBefore, CMTime toleranceAfter, BoolArgumentAction completionHandler);
    }

    // @interface SJAVMediaPlayerLayerView : UIView <SJMediaPlayerView>
    [BaseType(typeof(UIView))]
    interface SJAVMediaPlayerLayerView : SJMediaPlayerView
    {
        // @property (readonly, nonatomic, strong) AVPlayerLayer * _Nonnull layer;
        [Export("layer", ArgumentSemantic.Strong)]
        AVPlayerLayer Layer();

        // -(void)setScreenshot:(UIImage * _Nullable)image;
        [Export("setScreenshot:")]
        void SetScreenshot(UIImage image);
    }

    // @interface SJAVMediaPlayerLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface SJAVMediaPlayerLoader
    {
        // +(SJAVMediaPlayer * _Nullable)loadPlayerForMedia:(SJVideoPlayerURLAsset * _Nonnull)media;
        [Static]
        [Export("loadPlayerForMedia:")]
        //[return: NullAllowed]
        SJAVMediaPlayer LoadPlayerForMedia(SJVideoPlayerURLAsset media);

        // +(void)clearPlayerForMedia:(SJVideoPlayerURLAsset * _Nonnull)media;
        [Static]
        [Export("clearPlayerForMedia:")]
        void ClearPlayerForMedia(SJVideoPlayerURLAsset media);
    }

    // @interface SJAVPictureInPictureController : NSObject <SJPictureInPictureController>
    //[iOS(14, 0)]
    [BaseType(typeof(NSObject))]
    interface SJAVPictureInPictureController : SJPictureInPictureController
    {
        // +(BOOL)isPictureInPictureSupported;
        [Static]
        [Export("isPictureInPictureSupported")]
        //[Verify(MethodToProperty)]
        bool IsPictureInPictureSupported();

        // -(instancetype _Nullable)initWithLayer:(AVPlayerLayer * _Nonnull)layer delegate:(id<SJPictureInPictureControllerDelegate> _Nonnull)delegate;
        [Export("initWithLayer:delegate:")]
        NativeHandle Constructor(AVPlayerLayer layer, SJPictureInPictureControllerDelegate @delegate);

        // @property (nonatomic) BOOL requiresLinearPlayback;
        [Export("requiresLinearPlayback")]
        bool RequiresLinearPlayback { get; set; }

        // @property (nonatomic) BOOL canStartPictureInPictureAutomaticallyFromInline __attribute__((availability(ios, introduced=14.2)));
        //[iOS(14, 2)]
        [Export("canStartPictureInPictureAutomaticallyFromInline")]
        bool CanStartPictureInPictureAutomaticallyFromInline { get; set; }

        // @property (readonly, nonatomic) SJPictureInPictureStatus status;
        [Export("status")]
        SJPictureInPictureStatus Status();

        // @property (readonly, nonatomic) BOOL wantsPictureInPictureStart;
        [Export("wantsPictureInPictureStart")]
        bool WantsPictureInPictureStart();

        // @property (readonly, getter = isAvailable, nonatomic) BOOL available;
        [Export("available")]
        bool Available { [Bind("isAvailable")] get; }

        // @property (readonly, getter = isEnabled, nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { [Bind("isEnabled")] get; }

        // -(void)startPictureInPicture;
        [Export("startPictureInPicture")]
        void StartPictureInPicture();

        // -(void)stopPictureInPicture;
        [Export("stopPictureInPicture")]
        void StopPictureInPicture();
    }

    // @interface SJVideoPlayerURLAssetPrefetcher : NSObject
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerURLAssetPrefetcher
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJVideoPlayerURLAssetPrefetcher Shared();

        // @property (nonatomic) NSUInteger maxCount;
        [Export("maxCount")]
        nuint MaxCount { get; set; }

        // -(SJPrefetchIdentifier)prefetchAsset:(SJVideoPlayerURLAsset * _Nonnull)asset;
        [Export("prefetchAsset:")]
        nint PrefetchAsset(SJVideoPlayerURLAsset asset);

        // -(SJVideoPlayerURLAsset * _Nullable)assetForURL:(NSURL * _Nonnull)URL;
        [Export("assetForURL:")]
        //[return: NullAllowed]
        SJVideoPlayerURLAsset AssetForURL(NSUrl URL);

        // -(SJVideoPlayerURLAsset * _Nullable)assetForIdentifier:(SJPrefetchIdentifier)identifier;
        [Export("assetForIdentifier:")]
        //[return: NullAllowed]
        SJVideoPlayerURLAsset AssetForIdentifier(nint identifier);

        // -(void)removeAsset:(SJVideoPlayerURLAsset * _Nonnull)asset;
        [Export("removeAsset:")]
        void RemoveAsset(SJVideoPlayerURLAsset asset);
    }

    // @interface SJAVMediaPlaybackController : SJMediaPlaybackController
    [BaseType(typeof(SJMediaPlaybackController))]
    interface SJAVMediaPlaybackController
    {
        // @property (readonly, nonatomic, strong) SJAVMediaPlayer * _Nullable currentPlayer;
        [NullAllowed, Export("currentPlayer", ArgumentSemantic.Strong)]
        SJAVMediaPlayer CurrentPlayer();

        // @property (readonly, nonatomic, strong) SJAVMediaPlayerLayerView * _Nullable currentPlayerView;
        [NullAllowed, Export("currentPlayerView", ArgumentSemantic.Strong)]
        SJAVMediaPlayerLayerView CurrentPlayerView();

        // @property (nonatomic) BOOL accurateSeeking;
        [Export("accurateSeeking")]
        bool AccurateSeeking { get; set; }
    }

    // @interface SJAVMediaPlaybackAdd (SJAVMediaPlaybackController) <SJMediaPlaybackExportController, SJMediaPlaybackScreenshotController>
    [Category]
    [BaseType(typeof(SJAVMediaPlaybackController))]
    interface SJAVMediaPlaybackController_SJAVMediaPlaybackAdd : ISJMediaPlaybackExportController, ISJMediaPlaybackScreenshotController
    {
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSInteger SJPlayerViewTag;
        [Field("SJPlayerViewTag", "__Internal")]
        nint SJPlayerViewTag();

        // extern const NSInteger SJPresentViewTag;
        [Field("SJPresentViewTag", "__Internal")]
        nint SJPresentViewTag();
    }

    // @interface SJPlayerZIndexes : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJPlayerZIndexes
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJPlayerZIndexes Shared();

        // @property (nonatomic) NSInteger textPopupViewZIndex;
        [Export("textPopupViewZIndex")]
        nint TextPopupViewZIndex { get; set; }

        // @property (nonatomic) NSInteger promptingPopupViewZIndex;
        [Export("promptingPopupViewZIndex")]
        nint PromptingPopupViewZIndex { get; set; }

        // @property (nonatomic) NSInteger controlLayerViewZIndex;
        [Export("controlLayerViewZIndex")]
        nint ControlLayerViewZIndex { get; set; }

        // @property (nonatomic) NSInteger danmakuViewZIndex;
        [Export("danmakuViewZIndex")]
        nint DanmakuViewZIndex { get; set; }

        // @property (nonatomic) NSInteger placeholderImageViewZIndex;
        [Export("placeholderImageViewZIndex")]
        nint PlaceholderImageViewZIndex { get; set; }

        // @property (nonatomic) NSInteger watermarkViewZIndex;
        [Export("watermarkViewZIndex")]
        nint WatermarkViewZIndex { get; set; }

        // @property (nonatomic) NSInteger subtitleViewZIndex;
        [Export("subtitleViewZIndex")]
        nint SubtitleViewZIndex { get; set; }

        // @property (nonatomic) NSInteger playbackViewZIndex;
        [Export("playbackViewZIndex")]
        nint PlaybackViewZIndex { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSNotificationName _Nonnull SJVideoPlayerAssetStatusDidChangeNotification;
        [Field("SJVideoPlayerAssetStatusDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerAssetStatusDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerDefinitionSwitchStatusDidChangeNotification;
        [Field("SJVideoPlayerDefinitionSwitchStatusDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerDefinitionSwitchStatusDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerURLAssetWillChangeNotification;
        [Field("SJVideoPlayerURLAssetWillChangeNotification", "__Internal")]
        NSString SJVideoPlayerURLAssetWillChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerURLAssetDidChangeNotification;
        [Field("SJVideoPlayerURLAssetDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerURLAssetDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerApplicationDidEnterBackgroundNotification;
        [Field("SJVideoPlayerApplicationDidEnterBackgroundNotification", "__Internal")]
        NSString SJVideoPlayerApplicationDidEnterBackgroundNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerApplicationWillEnterForegroundNotification;
        [Field("SJVideoPlayerApplicationWillEnterForegroundNotification", "__Internal")]
        NSString SJVideoPlayerApplicationWillEnterForegroundNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerApplicationWillTerminateNotification;
        [Field("SJVideoPlayerApplicationWillTerminateNotification", "__Internal")]
        NSString SJVideoPlayerApplicationWillTerminateNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackControllerWillDeallocateNotification;
        [Field("SJVideoPlayerPlaybackControllerWillDeallocateNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackControllerWillDeallocateNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackTimeControlStatusDidChangeNotification;
        [Field("SJVideoPlayerPlaybackTimeControlStatusDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackTimeControlStatusDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPictureInPictureStatusDidChangeNotification;
        [Field("SJVideoPlayerPictureInPictureStatusDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPictureInPictureStatusDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidFinishNotification;
        [Field("SJVideoPlayerPlaybackDidFinishNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidFinishNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidReplayNotification;
        [Field("SJVideoPlayerPlaybackDidReplayNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidReplayNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackWillStopNotification;
        [Field("SJVideoPlayerPlaybackWillStopNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackWillStopNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidStopNotification;
        [Field("SJVideoPlayerPlaybackDidStopNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidStopNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackWillRefreshNotification;
        [Field("SJVideoPlayerPlaybackWillRefreshNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackWillRefreshNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidRefreshNotification;
        [Field("SJVideoPlayerPlaybackDidRefreshNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidRefreshNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackWillSeekNotification;
        [Field("SJVideoPlayerPlaybackWillSeekNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackWillSeekNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidSeekNotification;
        [Field("SJVideoPlayerPlaybackDidSeekNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidSeekNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerCurrentTimeDidChangeNotification;
        [Field("SJVideoPlayerCurrentTimeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerCurrentTimeDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerDurationDidChangeNotification;
        [Field("SJVideoPlayerDurationDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerDurationDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlayableDurationDidChangeNotification;
        [Field("SJVideoPlayerPlayableDurationDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPlayableDurationDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPresentationSizeDidChangeNotification;
        [Field("SJVideoPlayerPresentationSizeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPresentationSizeDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackTypeDidChangeNotification;
        [Field("SJVideoPlayerPlaybackTypeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackTypeDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerRateDidChangeNotification;
        [Field("SJVideoPlayerRateDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerRateDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerMutedDidChangeNotification;
        [Field("SJVideoPlayerMutedDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerMutedDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerVolumeDidChangeNotification;
        [Field("SJVideoPlayerVolumeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerVolumeDidChangeNotification();

        // extern const NSNotificationName _Nonnull SJVideoPlayerScreenLockStateDidChangeNotification;
        [Field("SJVideoPlayerScreenLockStateDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerScreenLockStateDidChangeNotification();

        // extern NSString *const _Nonnull SJVideoPlayerNotificationUserInfoKeySeekTime;
        [Field("SJVideoPlayerNotificationUserInfoKeySeekTime", "__Internal")]
        NSString SJVideoPlayerNotificationUserInfoKeySeekTime();
    }

    // @interface SJBaseVideoPlayerExtended (NSString)
    [Category]
    [BaseType(typeof(NSString))]
    interface NSString_SJBaseVideoPlayerExtended
    {
        // +(instancetype _Nonnull)stringWithCurrentTime:(NSTimeInterval)currentTime duration:(NSTimeInterval)duration;
        [Static]
        [Export("stringWithCurrentTime:duration:")]
        NSString StringWithCurrentTime(double currentTime, double duration);
    }

    // @interface SJAssetAdd (NSTimer)
    [Category]
    [BaseType(typeof(NSTimer))]
    interface NSTimer_SJAssetAdd
    {
        // +(NSTimer * _Nonnull)sj_timerWithTimeInterval:(NSTimeInterval)interval repeats:(BOOL)repeats;
        [Static]
        [Export("sj_timerWithTimeInterval:repeats:")]
        NSTimer Sj_timerWithTimeInterval(double interval, bool repeats);

        // +(NSTimer * _Nonnull)sj_timerWithTimeInterval:(NSTimeInterval)interval repeats:(BOOL)repeats usingBlock:(void (^ _Nullable)(NSTimer * _Nonnull))usingBlock;
        [Static]
        [Export("sj_timerWithTimeInterval:repeats:usingBlock:")]
        NSTimer Sj_timerWithTimeInterval(double interval, bool repeats, Action<NSTimer> usingBlock);

        // @property (copy, nonatomic) void (^ _Nullable)(NSTimer * _Nonnull) sj_usingBlock;
        [NullAllowed, Export("sj_usingBlock", ArgumentSemantic.Copy)]
        Action<NSTimer> Sj_usingBlock { get; set; }

        // -(void)sj_fire;
        [Export("sj_fire")]
        void Sj_fire();
    }

    // @interface SJDeprecated (NSTimer)
    [Category]
    [BaseType(typeof(NSTimer))]
    interface NSTimer_SJDeprecated
    {
        // +(NSTimer * _Nonnull)assetAdd_timerWithTimeInterval:(NSTimeInterval)ti block:(void (^ _Nonnull)(NSTimer * _Nonnull))block repeats:(BOOL)repeats;
        [Static]
        [Export("assetAdd_timerWithTimeInterval:block:repeats:")]
        NSTimer AssetAdd_timerWithTimeInterval(double ti, Action<NSTimer> block, bool repeats);

        // -(void)assetAdd_fire;
        [Export("assetAdd_fire")]
        void AssetAdd_fire();
    }

    // @interface SJControlLayerAppearStateManager : NSObject <SJControlLayerAppearManager>
    [BaseType(typeof(NSObject))]
    interface SJControlLayerAppearStateManager : SJControlLayerAppearManager
    {
    }

    // @interface SJDanmakuItem : NSObject <SJDanmakuItem>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJDanmakuItem : ISJDanmakuItem
    {
        // -(instancetype _Nonnull)initWithContent:(NSAttributedString * _Nonnull)content;
        [Export("initWithContent:")]
        NativeHandle Constructor(NSAttributedString content);

        // -(instancetype _Nonnull)initWithCustomView:(__kindof UIView * _Nonnull)customView;
        [Export("initWithCustomView:")]
        NativeHandle Constructor(UIView customView);

        // @property (readonly, copy, nonatomic) NSAttributedString * _Nullable content;
        [NullAllowed, Export("content", ArgumentSemantic.Copy)]
        NSAttributedString Content();

        // @property (readonly, nonatomic, strong) __kindof UIView * _Nullable customView;
        [NullAllowed, Export("customView", ArgumentSemantic.Strong)]
        UIView CustomView();
    }

    // @interface SJDanmakuPopupController : NSObject <SJDanmakuPopupController>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJDanmakuPopupController : ISJDanmakuPopupController
    {
        // -(instancetype _Nonnull)initWithNumberOfTracks:(NSUInteger)numberOfTracks;
        [Export("initWithNumberOfTracks:")]
        NativeHandle Constructor(nuint numberOfTracks);

        // @property (nonatomic) NSInteger numberOfTracks;
        [Export("numberOfTracks")]
        nint NumberOfTracks { get; set; }

        // @property (readonly, nonatomic, strong) SJDanmakuTrackConfiguration * _Nonnull trackConfiguration;
        [Export("trackConfiguration", ArgumentSemantic.Strong)]
        SJDanmakuTrackConfiguration TrackConfiguration();

        // -(void)reloadTrackConfiguration;
        [Export("reloadTrackConfiguration")]
        void ReloadTrackConfiguration();

        // @property (getter = isDisabled, nonatomic) BOOL disabled;
        [Export("disabled")]
        bool Disabled { [Bind("isDisabled")] get; set; }

        // -(void)enqueue:(id<SJDanmakuItem> _Nonnull)item;
        [Export("enqueue:")]
        void Enqueue(SJDanmakuItem item);

        // -(void)emptyQueue;
        [Export("emptyQueue")]
        void EmptyQueue();

        // -(void)removeDisplayedItems;
        [Export("removeDisplayedItems")]
        void RemoveDisplayedItems();

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();

        // @property (readonly, getter = isPaused, nonatomic) BOOL paused;
        [Export("paused")]
        bool Paused { [Bind("isPaused")] get; }

        // -(void)pause;
        [Export("pause")]
        void Pause();

        // -(void)resume;
        [Export("resume")]
        void Resume();

        // -(id<SJDanmakuPopupControllerObserver> _Nonnull)getObserver;
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJDanmakuPopupControllerObserver Observer();

        // @property (readonly, nonatomic, strong) __kindof UIView * _Nonnull view;
        [Export("view", ArgumentSemantic.Strong)]
        UIView View();

        // @property (readonly, nonatomic) NSInteger queueSize;
        [Export("queueSize")]
        nint QueueSize();
    }

    // @interface SJDanmakuTrackConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface SJDanmakuTrackConfiguration
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJDanmakuTrackConfigurationDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJDanmakuTrackConfigurationDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) CGFloat rate;
        [Export("rate")]
        nfloat Rate { get; set; }

        // @property (nonatomic) CGFloat itemSpacing;
        [Export("itemSpacing")]
        nfloat ItemSpacing { get; set; }

        // @property (nonatomic) CGFloat topMargin;
        [Export("topMargin")]
        nfloat TopMargin { get; set; }

        // @property (nonatomic) CGFloat height;
        [Export("height")]
        nfloat Height { get; set; }
    }

    // @protocol SJDanmakuTrackConfigurationDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJDanmakuTrackConfigurationDelegate
    {
        // @optional -(CGFloat)trackConfiguration:(SJDanmakuTrackConfiguration * _Nonnull)trackConfiguration rateForTrackAtIndex:(NSInteger)index;
        [Export("trackConfiguration:rateForTrackAtIndex:")]
        nfloat RateForTrackAtIndex(SJDanmakuTrackConfiguration trackConfiguration, nint index);

        // @optional -(CGFloat)trackConfiguration:(SJDanmakuTrackConfiguration * _Nonnull)trackConfiguration itemSpacingForTrackAtIndex:(NSInteger)index;
        [Export("trackConfiguration:itemSpacingForTrackAtIndex:")]
        nfloat ItemSpacingForTrackAtIndex(SJDanmakuTrackConfiguration trackConfiguration, nint index);

        // @optional -(CGFloat)trackConfiguration:(SJDanmakuTrackConfiguration * _Nonnull)trackConfiguration topMarginForTrackAtIndex:(NSInteger)index;
        [Export("trackConfiguration:topMarginForTrackAtIndex:")]
        nfloat TopMarginForTrackAtIndex(SJDanmakuTrackConfiguration trackConfiguration, nint index);

        // @optional -(CGFloat)trackConfiguration:(SJDanmakuTrackConfiguration * _Nonnull)trackConfiguration heightForTrackAtIndex:(NSInteger)index;
        [Export("trackConfiguration:heightForTrackAtIndex:")]
        nfloat HeightForTrackAtIndex(SJDanmakuTrackConfiguration trackConfiguration, nint index);
    }

    // @interface SJDeviceVolumeAndBrightness : NSObject
    [BaseType(typeof(NSObject))]
    interface SJDeviceVolumeAndBrightness
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJDeviceVolumeAndBrightness Shared();

        // @property (readonly, nonatomic, strong) UIView * _Nonnull sysVolumeView;
        [Export("sysVolumeView", ArgumentSemantic.Strong)]
        UIView SysVolumeView();

        // @property (nonatomic) float volume;
        [Export("volume")]
        float Volume { get; set; }

        // @property (nonatomic) float brightness;
        [Export("brightness")]
        float Brightness { get; set; }

        // -(void)addObserver:(id<SJDeviceVolumeAndBrightnessObserver> _Nonnull)observer;
        [Export("addObserver:")]
        void AddObserver(SJDeviceVolumeAndBrightnessObserver observer);

        // -(void)removeObserver:(id<SJDeviceVolumeAndBrightnessObserver> _Nonnull)observer;
        [Export("removeObserver:")]
        void RemoveObserver(SJDeviceVolumeAndBrightnessObserver observer);
    }

    // @protocol SJDeviceVolumeAndBrightnessObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJDeviceVolumeAndBrightnessObserver
    {
        // @optional -(void)device:(SJDeviceVolumeAndBrightness * _Nonnull)device onVolumeChanged:(float)volume;
        [Export("device:onVolumeChanged:")]
        void OnVolumeChanged(SJDeviceVolumeAndBrightness device, float volume);

        // @optional -(void)device:(SJDeviceVolumeAndBrightness * _Nonnull)device onBrightnessChanged:(float)brightness;
        [Export("device:onBrightnessChanged:")]
        void OnBrightnessChanged(SJDeviceVolumeAndBrightness device, float brightness);
    }

    // @interface SJDeviceVolumeAndBrightnessController : NSObject <SJDeviceVolumeAndBrightnessController>
    [BaseType(typeof(NSObject))]
    interface SJDeviceVolumeAndBrightnessController : ISJDeviceVolumeAndBrightnessController
    {
        // @property (nonatomic, strong) UIView<SJDeviceVolumeAndBrightnessPopupView> * _Nullable brightnessView;
        [NullAllowed, Export("brightnessView", ArgumentSemantic.Strong)]
        SJDeviceVolumeAndBrightnessPopupView BrightnessView { get; set; }

        // @property (nonatomic, strong) UIView<SJDeviceVolumeAndBrightnessPopupView> * _Nullable volumeView;
        [NullAllowed, Export("volumeView", ArgumentSemantic.Strong)]
        SJDeviceVolumeAndBrightnessPopupView VolumeView { get; set; }
    }

    // @protocol SJDeviceVolumeAndBrightnessPopupViewDataSource <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJDeviceVolumeAndBrightnessPopupViewDataSource
    {
        // @required @property (nonatomic, strong) UIImage * _Nullable startImage;
        [Abstract]
        [NullAllowed, Export("startImage", ArgumentSemantic.Strong)]
        UIImage StartImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable image;
        [Abstract]
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @required @property (nonatomic) float progress;
        [Abstract]
        [Export("progress")]
        float Progress { get; set; }

        // @required @property (nonatomic, strong, null_resettable) UIColor * _Null_unspecified traceColor;
        [Abstract]
        [NullAllowed, Export("traceColor", ArgumentSemantic.Strong)]
        UIColor TraceColor { get; set; }

        // @required @property (nonatomic, strong, null_resettable) UIColor * _Null_unspecified trackColor;
        [Abstract]
        [NullAllowed, Export("trackColor", ArgumentSemantic.Strong)]
        UIColor TrackColor { get; set; }
    }

    // @protocol SJDeviceVolumeAndBrightnessPopupView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJDeviceVolumeAndBrightnessPopupView
    {
        [Wrap("WeakDataSource"), Abstract]
        SJDeviceVolumeAndBrightnessPopupViewDataSource DataSource { get; set; }

        // @required @property (nonatomic, strong) id<SJDeviceVolumeAndBrightnessPopupViewDataSource> _Nonnull dataSource;
        [Abstract]
        [NullAllowed, Export("dataSource", ArgumentSemantic.Strong)]
        NSObject WeakDataSource { get; set; }

        // @required -(void)refreshData;
        [Abstract]
        [Export("refreshData")]
        void RefreshData();
    }

    // @interface SJDeviceSystemVolumeViewDisplayManager : NSObject
    [BaseType(typeof(NSObject))]
    interface SJDeviceSystemVolumeViewDisplayManager
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJDeviceSystemVolumeViewDisplayManager Shared();

        // @property (nonatomic) BOOL automaticallyDisplaySystemVolumeView;
        [Export("automaticallyDisplaySystemVolumeView")]
        bool AutomaticallyDisplaySystemVolumeView { get; set; }

        // -(void)update;
        [Export("update")]
        void Update();

        // -(void)addController:(id<SJDeviceVolumeAndBrightnessController> _Nullable)controller;
        [Export("addController:")]
        void AddController(SJDeviceVolumeAndBrightnessController controller);

        // -(void)removeController:(id<SJDeviceVolumeAndBrightnessController> _Nullable)controller;
        [Export("removeController:")]
        void RemoveController(SJDeviceVolumeAndBrightnessController controller);
    }

    // @interface SJDeviceVolumeAndBrightnessTargetViewContext : NSObject <SJDeviceVolumeAndBrightnessTargetViewContext>
    [BaseType(typeof(NSObject))]
    interface SJDeviceVolumeAndBrightnessTargetViewContext : ISJDeviceVolumeAndBrightnessTargetViewContext
    {
        // @property (nonatomic) BOOL isFullscreen;
        [Export("isFullscreen")]
        bool IsFullscreen { get; set; }

        // @property (nonatomic) BOOL isFitOnScreen;
        [Export("isFitOnScreen")]
        bool IsFitOnScreen { get; set; }

        // @property (nonatomic) BOOL isPlayOnScrollView;
        [Export("isPlayOnScrollView")]
        bool IsPlayOnScrollView { get; set; }

        // @property (nonatomic) BOOL isScrollAppeared;
        [Export("isScrollAppeared")]
        bool IsScrollAppeared { get; set; }

        // @property (nonatomic) BOOL isFloatingMode;
        [Export("isFloatingMode")]
        bool IsFloatingMode { get; set; }

        // @property (nonatomic) BOOL isPictureInPictureMode;
        [Export("isPictureInPictureMode")]
        bool IsPictureInPictureMode { get; set; }
    }

    // @protocol SJViewControllerManager <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJViewControllerManager
    {
        // @required @property (readonly, getter = isViewDisappeared, nonatomic) BOOL viewDisappeared;
        [Abstract]
        [Export("viewDisappeared")]
        bool ViewDisappeared { [Bind("isViewDisappeared")] get; }

        // @required @property (readonly, nonatomic) UIStatusBarStyle preferredStatusBarStyle;
        [Abstract]
        [Export("preferredStatusBarStyle")]
        UIStatusBarStyle PreferredStatusBarStyle();

        // @required @property (readonly, nonatomic) BOOL prefersStatusBarHidden;
        [Abstract]
        [Export("prefersStatusBarHidden")]
        bool PrefersStatusBarHidden();

        // @required -(void)viewDidAppear;
        [Abstract]
        [Export("viewDidAppear")]
        void ViewDidAppear();

        // @required -(void)viewWillDisappear;
        [Abstract]
        [Export("viewWillDisappear")]
        void ViewWillDisappear();

        // @required -(void)viewDidDisappear;
        [Abstract]
        [Export("viewDidDisappear")]
        void ViewDidDisappear();

        // @required -(void)pushViewController:(UIViewController * _Nonnull)viewController animated:(BOOL)animated;
        [Abstract]
        [Export("pushViewController:animated:")]
        void PushViewController(UIViewController viewController, bool animated);

        // @required -(void)showStatusBar;
        [Abstract]
        [Export("showStatusBar")]
        void ShowStatusBar();

        // @required -(void)hiddenStatusBar;
        [Abstract]
        [Export("hiddenStatusBar")]
        void HiddenStatusBar();

        // @required -(void)setNeedsStatusBarAppearanceUpdate;
        [Abstract]
        [Export("setNeedsStatusBarAppearanceUpdate")]
        void SetNeedsStatusBarAppearanceUpdate();
    }

    // @interface SJFitOnScreenManager : NSObject <SJFitOnScreenManager>
    [BaseType(typeof(NSObject))]
    interface SJFitOnScreenManager : ISJFitOnScreenManager
    {
        // @property (nonatomic, weak) id<SJViewControllerManager> _Nullable viewControllerManager;
        [NullAllowed, Export("viewControllerManager", ArgumentSemantic.Weak)]
        SJViewControllerManager ViewControllerManager { get; set; }
    }

    // @interface SJFlipTransitionManager : NSObject <SJFlipTransitionManager>
    [BaseType(typeof(NSObject))]
    interface SJFlipTransitionManager : ISJFlipTransitionManager
    {
    }

    // @interface SJPlayerView : UIView
    [BaseType(typeof(UIView))]
    interface SJPlayerView
    {
        // @property (readonly, nonatomic, strong) UIView * _Nullable presentView;
        [NullAllowed, Export("presentView", ArgumentSemantic.Strong)]
        UIView PresentView();

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJPlayerViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJPlayerViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol SJPlayerViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJPlayerViewDelegate
    {
        // @required -(void)playerViewWillMoveToWindow:(SJPlayerView * _Nonnull)playerView;
        [Abstract]
        [Export("playerViewWillMoveToWindow:")]
        void PlayerViewWillMoveToWindow(SJPlayerView playerView);

        // @required -(UIView * _Nullable)playerView:(SJPlayerView * _Nonnull)playerView hitTestForView:(__kindof UIView * _Nullable)view;
        [Abstract]
        [Export("playerView:hitTestForView:")]
        //[return: NullAllowed]
        UIView PlayerView(SJPlayerView playerView, UIView view);
    }

    // @interface Internal (SJPlayerView)
    [Category]
    [BaseType(typeof(SJPlayerView))]
    interface SJPlayerView_Internal
    {
        // @property (nonatomic, strong) UIView * _Nullable presentView;
        [NullAllowed, Export("presentView", ArgumentSemantic.Strong)]
        UIView PresentView { get; set; }
    }

    // @interface SJScrollViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJScrollViewPlayModel
    {
        // -(instancetype _Nonnull)initWithScrollView:(UIScrollView * _Nonnull)scrollView;
        [Export("initWithScrollView:")]
        NativeHandle Constructor(UIScrollView scrollView);

        // @property (readonly, nonatomic, weak) UIScrollView * _Nullable scrollView;
        [NullAllowed, Export("scrollView", ArgumentSemantic.Weak)]
        UIScrollView ScrollView();
    }

    // @interface SJTableViewCellPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJTableViewCellPlayModel
    {
        // -(instancetype _Nonnull)initWithTableView:(UITableView * _Nonnull)tableView indexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("initWithTableView:indexPath:")]
        NativeHandle Constructor(UITableView tableView, NSIndexPath indexPath);

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        NSIndexPath IndexPath();
    }

    // @interface SJTableViewTableHeaderViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJTableViewTableHeaderViewPlayModel
    {
        // -(instancetype _Nonnull)initWithTableView:(UITableView * _Nonnull)tableView tableHeaderView:(UIView * _Nonnull)tableHeaderView;
        [Export("initWithTableView:tableHeaderView:")]
        NativeHandle Constructor(UITableView tableView, UIView tableHeaderView);

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // @property (readonly, nonatomic, weak) UIView * _Nullable tableHeaderView;
        [NullAllowed, Export("tableHeaderView", ArgumentSemantic.Weak)]
        UIView TableHeaderView();
    }

    // @interface SJTableViewTableFooterViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJTableViewTableFooterViewPlayModel
    {
        // -(instancetype _Nonnull)initWithTableView:(UITableView * _Nonnull)tableView tableFooterView:(UIView * _Nonnull)tableFooterView;
        [Export("initWithTableView:tableFooterView:")]
        NativeHandle Constructor(UITableView tableView, UIView tableFooterView);

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // @property (readonly, nonatomic, weak) UIView * _Nullable tableFooterView;
        [NullAllowed, Export("tableFooterView", ArgumentSemantic.Weak)]
        UIView TableFooterView();
    }

    // @interface SJTableViewSectionHeaderViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJTableViewSectionHeaderViewPlayModel
    {
        // -(instancetype _Nonnull)initWithTableView:(UITableView * _Nonnull)tableView inHeaderForSection:(NSInteger)section;
        [Export("initWithTableView:inHeaderForSection:")]
        NativeHandle Constructor(UITableView tableView, nint section);

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // @property (readonly, nonatomic) NSInteger section;
        [Export("section")]
        nint Section();
    }

    // @interface SJTableViewSectionFooterViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJTableViewSectionFooterViewPlayModel
    {
        // -(instancetype _Nonnull)initWithTableView:(UITableView * _Nonnull)tableView inFooterForSection:(NSInteger)section;
        [Export("initWithTableView:inFooterForSection:")]
        NativeHandle Constructor(UITableView tableView, nint section);

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // @property (readonly, nonatomic) NSInteger section;
        [Export("section")]
        nint Section();
    }

    // @interface SJCollectionViewCellPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJCollectionViewCellPlayModel
    {
        // -(instancetype _Nonnull)initWithCollectionView:(UICollectionView * _Nonnull)collectionView indexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("initWithCollectionView:indexPath:")]
        NativeHandle Constructor(UICollectionView collectionView, NSIndexPath indexPath);

        // @property (readonly, nonatomic, weak) UICollectionView * _Nullable collectionView;
        [NullAllowed, Export("collectionView", ArgumentSemantic.Weak)]
        UICollectionView CollectionView();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        NSIndexPath IndexPath();
    }

    // @interface SJCollectionViewSectionHeaderViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJCollectionViewSectionHeaderViewPlayModel
    {
        // -(instancetype _Nonnull)initWithCollectionView:(UICollectionView * _Nonnull)collectionView inHeaderForSection:(NSInteger)section;
        [Export("initWithCollectionView:inHeaderForSection:")]
        NativeHandle Constructor(UICollectionView collectionView, nint section);

        // @property (readonly, nonatomic, weak) UICollectionView * _Nullable collectionView;
        [NullAllowed, Export("collectionView", ArgumentSemantic.Weak)]
        UICollectionView CollectionView();

        // @property (readonly, nonatomic) NSInteger section;
        [Export("section")]
        nint Section();
    }

    // @interface SJCollectionViewSectionFooterViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJCollectionViewSectionFooterViewPlayModel
    {
        // -(instancetype _Nonnull)initWithCollectionView:(UICollectionView * _Nonnull)collectionView inFooterForSection:(NSInteger)section;
        [Export("initWithCollectionView:inFooterForSection:")]
        NativeHandle Constructor(UICollectionView collectionView, nint section);

        // @property (readonly, nonatomic, weak) UICollectionView * _Nullable collectionView;
        [NullAllowed, Export("collectionView", ArgumentSemantic.Weak)]
        UICollectionView CollectionView();

        // @property (readonly, nonatomic) NSInteger section;
        [Export("section")]
        nint Section();
    }

    // @interface SJUITableViewCellPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJUITableViewCellPlayModel
    {
        // -(instancetype _Nonnull)initWithPlayerSuperview:(UIView * _Nonnull)playerSuperview atIndexPath:(NSIndexPath * _Nonnull)indexPath tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperview:atIndexPath:tableView:")]
        NativeHandle Constructor(UIView playerSuperview, NSIndexPath indexPath, UITableView tableView);

        // @property (readonly, nonatomic) NSInteger playerSuperviewTag;
        [Export("playerSuperviewTag")]
        nint PlayerSuperviewTag();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        NSIndexPath IndexPath();

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // -(instancetype _Nonnull)initWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperviewTag:atIndexPath:tableView:")]
        NativeHandle Constructor(nint playerSuperviewTag, NSIndexPath indexPath, UITableView tableView);
    }

    // @interface SJUICollectionViewCellPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJUICollectionViewCellPlayModel
    {
        // -(instancetype _Nonnull)initWithPlayerSuperview:(UIView * _Nonnull)playerSuperview atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionView:(UICollectionView * _Nonnull)collectionView;
        [Export("initWithPlayerSuperview:atIndexPath:collectionView:")]
        NativeHandle Constructor(UIView playerSuperview, NSIndexPath indexPath, UICollectionView collectionView);

        // @property (readonly, nonatomic) NSInteger playerSuperviewTag;
        [Export("playerSuperviewTag")]
        nint PlayerSuperviewTag();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        NSIndexPath IndexPath();

        // @property (readonly, nonatomic, weak) UICollectionView * _Nullable collectionView;
        [NullAllowed, Export("collectionView", ArgumentSemantic.Weak)]
        UICollectionView CollectionView();

        // -(instancetype _Nonnull)initWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionView:(UICollectionView * _Nonnull)collectionView;
        [Export("initWithPlayerSuperviewTag:atIndexPath:collectionView:")]
        NativeHandle Constructor(nint playerSuperviewTag, NSIndexPath indexPath, UICollectionView collectionView);
    }

    // @interface SJUITableViewHeaderViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJUITableViewHeaderViewPlayModel
    {
        // -(instancetype _Nonnull)initWithPlayerSuperview:(UIView * _Nonnull)playerSuperview tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperview:tableView:")]
        NativeHandle Constructor(UIView playerSuperview, UITableView tableView);

        // @property (readonly, nonatomic, weak) UIView * _Nullable playerSuperview;
        [NullAllowed, Export("playerSuperview", ArgumentSemantic.Weak)]
        UIView PlayerSuperview();

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();
    }

    // @interface SJUICollectionViewNestedInUITableViewHeaderViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJUICollectionViewNestedInUITableViewHeaderViewPlayModel
    {
        // -(instancetype _Nonnull)initWithPlayerSuperview:(UIView * _Nonnull)playerSuperview atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionView:(UICollectionView * _Nonnull)collectionView tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperview:atIndexPath:collectionView:tableView:")]
        NativeHandle Constructor(UIView playerSuperview, NSIndexPath indexPath, UICollectionView collectionView, UITableView tableView);

        // @property (readonly, nonatomic) NSInteger playerSuperviewTag;
        [Export("playerSuperviewTag")]
        nint PlayerSuperviewTag();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        NSIndexPath IndexPath();

        // @property (readonly, nonatomic, weak) UICollectionView * _Nullable collectionView;
        [NullAllowed, Export("collectionView", ArgumentSemantic.Weak)]
        UICollectionView CollectionView();

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // -(instancetype _Nonnull)initWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionView:(UICollectionView * _Nonnull)collectionView tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperviewTag:atIndexPath:collectionView:tableView:")]
        NativeHandle Constructor(nint playerSuperviewTag, NSIndexPath indexPath, UICollectionView collectionView, UITableView tableView);
    }

    // @interface SJUICollectionViewNestedInUITableViewCellPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJUICollectionViewNestedInUITableViewCellPlayModel
    {
        // -(instancetype _Nonnull)initWithPlayerSuperview:(UIView * _Nonnull)playerSuperview atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionView:(UICollectionView * _Nonnull)collectionView collectionViewAtIndexPath:(NSIndexPath * _Nonnull)collectionViewAtIndexPath tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperview:atIndexPath:collectionView:collectionViewAtIndexPath:tableView:")]
        NativeHandle Constructor(UIView playerSuperview, NSIndexPath indexPath, UICollectionView collectionView, NSIndexPath collectionViewAtIndexPath, UITableView tableView);

        // @property (readonly, nonatomic) NSInteger playerSuperviewTag;
        [Export("playerSuperviewTag")]
        nint PlayerSuperviewTag();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        NSIndexPath IndexPath();

        // @property (readonly, nonatomic) NSInteger collectionViewTag;
        [Export("collectionViewTag")]
        nint CollectionViewTag();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull collectionViewAtIndexPath;
        [Export("collectionViewAtIndexPath", ArgumentSemantic.Strong)]
        NSIndexPath CollectionViewAtIndexPath();

        // @property (readonly, nonatomic, weak) UITableView * _Nullable tableView;
        [NullAllowed, Export("tableView", ArgumentSemantic.Weak)]
        UITableView TableView();

        // -(instancetype _Nonnull)initWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionViewTag:(NSInteger)collectionViewTag collectionViewAtIndexPath:(NSIndexPath * _Nonnull)collectionViewAtIndexPath tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperviewTag:atIndexPath:collectionViewTag:collectionViewAtIndexPath:tableView:")]
        NativeHandle Constructor(nint playerSuperviewTag, NSIndexPath indexPath, nint collectionViewTag, NSIndexPath collectionViewAtIndexPath, UITableView tableView);

        // -(UICollectionView * _Nonnull)collectionView;
        [Export("collectionView")]
        //[Verify(MethodToProperty)]
        UICollectionView CollectionView();
    }

    // @interface SJUICollectionViewNestedInUICollectionViewCellPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJUICollectionViewNestedInUICollectionViewCellPlayModel
    {
        // -(instancetype _Nonnull)initWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag atIndexPath:(NSIndexPath * _Nonnull)indexPath collectionViewTag:(NSInteger)collectionViewTag collectionViewAtIndexPath:(NSIndexPath * _Nonnull)collectionViewAtIndexPath rootCollectionView:(UICollectionView * _Nonnull)rootCollectionView;
        [Export("initWithPlayerSuperviewTag:atIndexPath:collectionViewTag:collectionViewAtIndexPath:rootCollectionView:")]
        NativeHandle Constructor(nint playerSuperviewTag, NSIndexPath indexPath, nint collectionViewTag, NSIndexPath collectionViewAtIndexPath, UICollectionView rootCollectionView);

        // @property (readonly, nonatomic) NSInteger playerSuperviewTag;
        [Export("playerSuperviewTag")]
        nint PlayerSuperviewTag();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull indexPath;
        [Export("indexPath", ArgumentSemantic.Strong)]
        NSIndexPath IndexPath();

        // @property (readonly, nonatomic) NSInteger collectionViewTag;
        [Export("collectionViewTag")]
        nint CollectionViewTag();

        // @property (readonly, nonatomic, strong) NSIndexPath * _Nonnull collectionViewAtIndexPath;
        [Export("collectionViewAtIndexPath", ArgumentSemantic.Strong)]
        NSIndexPath CollectionViewAtIndexPath();

        // @property (readonly, nonatomic, weak) UICollectionView * _Nullable rootCollectionView;
        [NullAllowed, Export("rootCollectionView", ArgumentSemantic.Weak)]
        UICollectionView RootCollectionView();

        // -(UICollectionView * _Nonnull)collectionView;
        [Export("collectionView")]
        //[Verify(MethodToProperty)]
        UICollectionView CollectionView();
    }

    // @interface SJUITableViewHeaderFooterViewPlayModel : SJPlayModel
    [BaseType(typeof(SJPlayModel))]
    interface SJUITableViewHeaderFooterViewPlayModel
    {
        // -(instancetype _Nonnull)initWithPlayerSuperviewTag:(NSInteger)playerSuperviewTag inSection:(NSInteger)inSection isHeader:(BOOL)isHeader tableView:(UITableView * _Nonnull)tableView;
        [Export("initWithPlayerSuperviewTag:inSection:isHeader:tableView:")]
        NativeHandle Constructor(nint playerSuperviewTag, nint inSection, bool isHeader, UITableView tableView);

        // @property (readonly, nonatomic) NSInteger playerSuperviewTag;
        [Export("playerSuperviewTag")]
        nint PlayerSuperviewTag();

        // @property (readonly, nonatomic) NSInteger inSection;
        [Export("inSection")]
        nint InSection();

        // @property (readonly, nonatomic) BOOL isHeader;
        [Export("isHeader")]
        bool IsHeader();

        // @property (readonly, nonatomic, strong) UITableView * _Nonnull tableView;
        [Export("tableView", ArgumentSemantic.Strong)]
        UITableView TableView();
    }

    // @protocol SJPlayModelPropertiesObserverDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJPlayModelPropertiesObserverDelegate
    {
        // @optional -(void)observer:(SJPlayModelPropertiesObserver * _Nonnull)observer userTouchedTableView:(BOOL)touched;
        [Export("observer:userTouchedTableView:")]
        void ObserverUserTouchedTableView(SJPlayModelPropertiesObserver observer, bool touched);

        // @optional -(void)observer:(SJPlayModelPropertiesObserver * _Nonnull)observer userTouchedCollectionView:(BOOL)touched;
        [Export("observer:userTouchedCollectionView:")]
        void ObserverUserTouchedCollectionView(SJPlayModelPropertiesObserver observer, bool touched);

        // @optional -(void)playerWillAppearForObserver:(SJPlayModelPropertiesObserver * _Nonnull)observer superview:(UIView * _Nonnull)superview;
        [Export("playerWillAppearForObserver:superview:")]
        void PlayerWillAppearForObserver(SJPlayModelPropertiesObserver observer, UIView superview);

        // @optional -(void)playerWillDisappearForObserver:(SJPlayModelPropertiesObserver * _Nonnull)observer;
        [Export("playerWillDisappearForObserver:")]
        void PlayerWillDisappearForObserver(SJPlayModelPropertiesObserver observer);
    }

    // @interface SJPlayModelPropertiesObserver : NSObject
    [BaseType(typeof(NSObject))]
    interface SJPlayModelPropertiesObserver
    {
        // -(instancetype _Nonnull)initWithPlayModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithPlayModel:")]
        NativeHandle Constructor(SJPlayModel playModel);

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJPlayModelPropertiesObserverDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJPlayModelPropertiesObserverDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic) BOOL isAppeared;
        [Export("isAppeared")]
        bool IsAppeared();

        // @property (readonly, nonatomic) BOOL isTouched;
        [Export("isTouched")]
        bool IsTouched();

        // @property (readonly, nonatomic) BOOL isPlayInScrollView;
        [Export("isPlayInScrollView")]
        bool IsPlayInScrollView();

        // @property (readonly, nonatomic) BOOL isScrolling;
        [Export("isScrolling")]
        bool IsScrolling();

        // -(void)refreshAppearState;
        [Export("refreshAppearState")]
        void RefreshAppearState();
    }

    // @interface SJPromptingPopupController : NSObject <SJPromptingPopupController>
    [BaseType(typeof(NSObject))]
    interface SJPromptingPopupController : ISJPromptingPopupController
    {
    }

    // @interface SJReachability : NSObject <SJReachability>
    [BaseType(typeof(NSObject))]
    interface SJReachability : ISJReachability
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJReachability Shared();
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSNotificationName _Nonnull SJRotationManagerRotationNotification;
        [Field("SJRotationManagerRotationNotification", "__Internal")]
        NSString SJRotationManagerRotationNotification();

        // extern const NSNotificationName _Nonnull SJRotationManagerTransitionNotification;
        [Field("SJRotationManagerTransitionNotification", "__Internal")]
        NSString SJRotationManagerTransitionNotification();
    }

    // @interface SJRotationFullscreenNavigationController : UINavigationController
    [BaseType(typeof(UINavigationController))]
    interface SJRotationFullscreenNavigationController
    {
        // -(instancetype _Nonnull)initWithRootViewController:(UIViewController * _Nonnull)rootViewController delegate:(id<SJRotationFullscreenNavigationControllerDelegate> _Nullable)delegate;
        [Export("initWithRootViewController:delegate:")]
        NativeHandle Constructor(UIViewController rootViewController, SJRotationFullscreenNavigationControllerDelegate @delegate);
    }

    // @protocol SJRotationFullscreenNavigationControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJRotationFullscreenNavigationControllerDelegate
    {
        // @required -(void)pushViewController:(UIViewController * _Nonnull)viewController animated:(BOOL)animated;
        [Abstract]
        [Export("pushViewController:animated:")]
        void Animated(UIViewController viewController, bool animated);
    }

    // @interface SJRotationFullscreenViewController : UIViewController
    [BaseType(typeof(UIViewController))]
    interface SJRotationFullscreenViewController
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJRotationFullscreenViewControllerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJRotationFullscreenViewControllerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol SJRotationFullscreenViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJRotationFullscreenViewControllerDelegate
    {
        // @required -(UIStatusBarStyle)preferredStatusBarStyleForRotationFullscreenViewController:(SJRotationFullscreenViewController * _Nonnull)viewController;
        [Abstract]
        [Export("preferredStatusBarStyleForRotationFullscreenViewController:")]
        UIStatusBarStyle PreferredStatusBarStyleForRotationFullscreenViewController(SJRotationFullscreenViewController viewController);

        // @required -(BOOL)prefersStatusBarHiddenForRotationFullscreenViewController:(SJRotationFullscreenViewController * _Nonnull)viewController;
        [Abstract]
        [Export("prefersStatusBarHiddenForRotationFullscreenViewController:")]
        bool PrefersStatusBarHiddenForRotationFullscreenViewController(SJRotationFullscreenViewController viewController);
    }

    // @interface SJRotationManager : NSObject <SJRotationManager>
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJRotationManager : ISJRotationManager
    {
        // +(UIInterfaceOrientationMask)supportedInterfaceOrientationsForWindow:(UIWindow * _Nullable)window;
        [Static]
        [Export("supportedInterfaceOrientationsForWindow:")]
        UIInterfaceOrientationMask SupportedInterfaceOrientationsForWindow(UIWindow window);

        // +(instancetype _Nonnull)rotationManager;
        [Static]
        [Export("rotationManager")]
        SJRotationManager RotationManager();

        // -(id<SJRotationManagerObserver> _Nonnull)getObserver;
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJRotationManagerObserver Observer();

        // @property (copy, nonatomic) BOOL (^ _Nullable)(id<SJRotationManager> _Nonnull) shouldTriggerRotation;
        [NullAllowed, Export("shouldTriggerRotation", ArgumentSemantic.Copy)]
        Func<SJRotationManager, bool> ShouldTriggerRotation { get; set; }

        // @property (getter = isDisabledAutorotation, nonatomic) BOOL disabledAutorotation;
        [Export("disabledAutorotation")]
        bool DisabledAutorotation { [Bind("isDisabledAutorotation")] get; set; }

        // @property (nonatomic) SJOrientationMask autorotationSupportedOrientations;
        [Export("autorotationSupportedOrientations", ArgumentSemantic.Assign)]
        SJOrientationMask AutorotationSupportedOrientations { get; set; }

        // -(void)rotate;
        [Export("rotate")]
        void Rotate();

        // -(void)rotate:(SJOrientation)orientation animated:(BOOL)animated;
        [Export("rotate:animated:")]
        void Rotate(SJOrientation orientation, bool animated);

        // -(void)rotate:(SJOrientation)orientation animated:(BOOL)animated completionHandler:(void (^ _Nullable)(id<SJRotationManager> _Nonnull))completionHandler;
        [Export("rotate:animated:completionHandler:")]
        void Rotate(SJOrientation orientation, bool animated, SJRotationManagerArgumentAction completionHandler);

        // @property (readonly, nonatomic) SJOrientation currentOrientation;
        [Export("currentOrientation")]
        SJOrientation CurrentOrientation();

        // @property (readonly, nonatomic) BOOL isFullscreen;
        [Export("isFullscreen")]
        bool IsFullscreen();

        // @property (readonly, getter = isRotating, nonatomic) BOOL rotating;
        [Export("rotating")]
        bool Rotating { [Bind("isRotating")] get; }

        // @property (readonly, getter = isTransitioning, nonatomic) BOOL transitioning;
        [Export("transitioning")]
        bool Transitioning { [Bind("isTransitioning")] get; }

        // @property (nonatomic, weak) UIView * _Nullable superview;
        [NullAllowed, Export("superview", ArgumentSemantic.Weak)]
        UIView Superview { get; set; }

        // @property (nonatomic, weak) UIView * _Nullable target;
        [NullAllowed, Export("target", ArgumentSemantic.Weak)]
        UIView Target { get; set; }

        // @property (nonatomic, weak) id<SJRotationActionForwarder> _Nullable actionForwarder;
        [NullAllowed, Export("actionForwarder", ArgumentSemantic.Weak)]
        SJRotationActionForwarder ActionForwarder { get; set; }
    }

    // @protocol SJRotationActionForwarder <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJRotationActionForwarder
    {
        // @required -(void)pushViewController:(UIViewController * _Nonnull)viewController animated:(BOOL)animated;
        [Abstract]
        [Export("pushViewController:animated:")]
        void Animated(UIViewController viewController, bool animated);

        // @required -(UIStatusBarStyle)preferredStatusBarStyle;
        [Abstract]
        [Export("preferredStatusBarStyle")]
        //[Verify(MethodToProperty)]
        UIStatusBarStyle PreferredStatusBarStyle();

        // @required -(BOOL)prefersStatusBarHidden;
        [Abstract]
        [Export("prefersStatusBarHidden")]
        //[Verify(MethodToProperty)]
        bool PrefersStatusBarHidden();
    }

    // @interface SJRotationSafeAreaFixing (UIViewController)
    //[Introduced(PlatformName.iOS, 13, 0, message: "deprecated!")]
    //[Deprecated(PlatformName.iOS, 16, 0, message: "deprecated!")]
    [Category]
    [BaseType(typeof(UIViewController))]
    interface UIViewController_SJRotationSafeAreaFixing
    {
        // @property (nonatomic) SJSafeAreaInsetsMask disabledAdjustSafeAreaInsetsMask;
        [Export("disabledAdjustSafeAreaInsetsMask", ArgumentSemantic.Assign)]
        SJSafeAreaInsetsMask DisabledAdjustSafeAreaInsetsMask { get; set; }
    }

    // @interface SJRotationFullscreenWindow : UIWindow
    [BaseType(typeof(UIWindow))]
    interface SJRotationFullscreenWindow
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame delegate:(id<SJRotationFullscreenWindowDelegate> _Nullable)delegate;
        [Export("initWithFrame:delegate:")]
        NativeHandle Constructor(CGRect frame, SJRotationFullscreenWindowDelegate @delegate);

        // -(instancetype _Nonnull)initWithWindowScene:(UIWindowScene * _Nonnull)windowScene delegate:(id<SJRotationFullscreenWindowDelegate> _Nullable)delegate __attribute__((availability(ios, introduced=13.0)));
        //[iOS(13, 0)]
        [Export("initWithWindowScene:delegate:")]
        NativeHandle Constructor(UIWindowScene windowScene, SJRotationFullscreenWindowDelegate @delegate);

        // @property (nonatomic, weak) SJRotationManager * _Nullable rotationManager;
        [NullAllowed, Export("rotationManager", ArgumentSemantic.Weak)]
        SJRotationManager RotationManager { get; set; }
    }

    // @protocol SJRotationFullscreenWindowDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJRotationFullscreenWindowDelegate
    {
        // @required -(BOOL)window:(SJRotationFullscreenWindow * _Nonnull)window pointInside:(CGPoint)point withEvent:(UIEvent * _Nullable)event;
        [Abstract]
        [Export("window:pointInside:withEvent:")]
        bool PointInside(SJRotationFullscreenWindow window, CGPoint point, UIEvent @event);
    }

    // @interface Internal (SJRotationManager) <SJRotationFullscreenViewControllerDelegate>
    [Category]
    [BaseType(typeof(SJRotationManager))]
    interface SJRotationManager_Internal : SJRotationFullscreenViewControllerDelegate
    {
        // -(UIInterfaceOrientationMask)supportedInterfaceOrientationsForWindow:(UIWindow * _Nullable)window;
        [Export("supportedInterfaceOrientationsForWindow:")]
        UIInterfaceOrientationMask SupportedInterfaceOrientationsForWindow(UIWindow window);

        // -(__kindof SJRotationFullscreenViewController * _Nonnull)rotationFullscreenViewController;
        [Export("rotationFullscreenViewController")]
        //[Verify(MethodToProperty)]
        SJRotationFullscreenViewController RotationFullscreenViewController();

        // -(BOOL)pointInside:(CGPoint)point withEvent:(UIEvent * _Nonnull)event;
        [Export("pointInside:withEvent:")]
        bool PointInside(CGPoint point, UIEvent @event);

        // -(BOOL)allowsRotation __attribute__((objc_requires_super));
        [Export("allowsRotation")]
        //[RequiresSuper]
        //[Verify(MethodToProperty)]
        bool AllowsRotation();

        // -(void)onDeviceOrientationChanged:(SJOrientation)deviceOrientation;
        [Export("onDeviceOrientationChanged:")]
        void OnDeviceOrientationChanged(SJOrientation deviceOrientation);

        // -(void)rotateToOrientation:(SJOrientation)orientation animated:(BOOL)animated complete:(void (^ _Nullable)(SJRotationManager * _Nonnull))completionHandler;
        [Export("rotateToOrientation:animated:complete:")]
        void RotateToOrientation(SJOrientation orientation, bool animated, Action<SJRotationManager> completionHandler);

        // @property (readonly, nonatomic, strong) UIWindow * _Nonnull window;
        [Export("window", ArgumentSemantic.Strong)]
        UIWindow Window();

        // @property (readonly, getter = isForcedRotation, nonatomic) BOOL forcedRotation;
        [Export("forcedRotation")]
        bool ForcedRotation { [Bind("isForcedRotation")] get; }

        // @property (readonly, nonatomic) SJOrientation deviceOrientation;
        [Export("deviceOrientation")]
        SJOrientation DeviceOrientation();

        // @property (nonatomic) SJOrientation currentOrientation;
        [Export("currentOrientation", ArgumentSemantic.Assign)]
        SJOrientation CurrentOrientation { get; set; }

        // -(void)rotationBegin __attribute__((objc_requires_super));
        [Export("rotationBegin")]
        [RequiresSuper]
        void RotationBegin();

        // -(void)rotationEnd __attribute__((objc_requires_super));
        [Export("rotationEnd")]
        [RequiresSuper]
        void RotationEnd();

        // -(void)transitionBegin __attribute__((objc_requires_super));
        [Export("transitionBegin")]
        [RequiresSuper]
        void TransitionBegin();

        // -(void)transitionEnd __attribute__((objc_requires_super));
        [Export("transitionEnd")]
        [RequiresSuper]
        void TransitionEnd();
    }

    // @interface SJRotationManager_iOS_16_Later : SJRotationManager
    //[iOS(16, 0)]
    [BaseType(typeof(SJRotationManager))]
    interface SJRotationManager_iOS_16_Later
    {
    }

    // @interface SJRotationManager_iOS_9_15 : SJRotationManager
    //[Introduced(PlatformName.iOS, 9, 0, message: "deprecated!")]
    //[Deprecated(PlatformName.iOS, 16, 0, message: "deprecated!")]
    [BaseType(typeof(SJRotationManager))]
    interface SJRotationManager_iOS_9_15
    {
    }

    // @interface SJRotationObserver : NSObject <SJRotationManagerObserver>
    [BaseType(typeof(NSObject))]
    interface SJRotationObserver : SJRotationManagerObserver
    {
        // -(instancetype _Nonnull)initWithManager:(SJRotationManager * _Nonnull)manager;
        [Export("initWithManager:")]
        NativeHandle Constructor(SJRotationManager manager);

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJRotationManager> _Nonnull, BOOL) onRotatingChanged;
        [NullAllowed, Export("onRotatingChanged", ArgumentSemantic.Copy)]
        Action<SJRotationManager, bool> OnRotatingChanged { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJRotationManager> _Nonnull, BOOL) onTransitioningChanged;
        [NullAllowed, Export("onTransitioningChanged", ArgumentSemantic.Copy)]
        Action<SJRotationManager, bool> OnTransitioningChanged { get; set; }
    }

    // @interface SJSmallViewFloatingController : NSObject <SJSmallViewFloatingController>
    [BaseType(typeof(NSObject))]
    interface SJSmallViewFloatingController : ISJSmallViewFloatingController
    {
        // @property (nonatomic) SJSmallViewLayoutPosition layoutPosition;
        [Export("layoutPosition", ArgumentSemantic.Assign)]
        SJSmallViewLayoutPosition LayoutPosition { get; set; }

        // @property (nonatomic) UIEdgeInsets layoutInsets;
        [Export("layoutInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets LayoutInsets { get; set; }

        // @property (nonatomic) CGSize layoutSize;
        [Export("layoutSize", ArgumentSemantic.Assign)]
        CGSize LayoutSize { get; set; }

        // @property (nonatomic) BOOL ignoreSafeAreaInsets __attribute__((availability(ios, introduced=11.0)));
        //[iOS(11, 0)]
        [Export("ignoreSafeAreaInsets")]
        bool IgnoreSafeAreaInsets { get; set; }

        // @property (nonatomic) BOOL addFloatViewToKeyWindow;
        [Export("addFloatViewToKeyWindow")]
        bool AddFloatViewToKeyWindow { get; set; }
    }

    // @interface SJSubtitleItem : NSObject <SJSubtitleItem>
    [BaseType(typeof(NSObject))]
    interface SJSubtitleItem : ISJSubtitleItem
    {
        // -(instancetype _Nonnull)initWithContent:(NSAttributedString * _Nonnull)content range:(SJTimeRange)range;
        [Export("initWithContent:range:")]
        NativeHandle Constructor(NSAttributedString content, SJTimeRange range);

        // -(instancetype _Nonnull)initWithContent:(NSAttributedString * _Nonnull)content start:(NSTimeInterval)start end:(NSTimeInterval)end;
        [Export("initWithContent:start:end:")]
        NativeHandle Constructor(NSAttributedString content, double start, double end);

        // @property (readonly, copy, nonatomic) NSAttributedString * _Nonnull content;
        [Export("content", ArgumentSemantic.Copy)]
        NSAttributedString Content();

        // @property (readonly, nonatomic) SJTimeRange range;
        [Export("range")]
        SJTimeRange Range();
    }

    // @interface SJSubtitlePopupController : NSObject <SJSubtitlePopupController>
    [BaseType(typeof(NSObject))]
    interface SJSubtitlePopupController : ISJSubtitlePopupController
    {
        // @property (copy, nonatomic) NSArray<SJSubtitleItem *> * _Nullable subtitles;
        [NullAllowed, Export("subtitles", ArgumentSemantic.Copy)]
        SJSubtitleItem[] Subtitles { get; set; }

        // @property (nonatomic) NSInteger numberOfLines;
        [Export("numberOfLines")]
        nint NumberOfLines { get; set; }

        // @property (nonatomic) UIEdgeInsets contentInsets;
        [Export("contentInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets ContentInsets { get; set; }
    }

    // @interface SJTextPopupController : NSObject <SJTextPopupController>
    [BaseType(typeof(NSObject))]
    interface SJTextPopupController : ISJTextPopupController
    {
    }

    // @interface Private (SJVideoDefinitionSwitchingInfo)
    [Category]
    [BaseType(typeof(SJVideoDefinitionSwitchingInfo))]
    interface SJVideoDefinitionSwitchingInfo_Private
    {
        // @property (nonatomic, weak) SJVideoPlayerURLAsset * _Nullable currentPlayingAsset;
        [NullAllowed, Export("currentPlayingAsset", ArgumentSemantic.Weak)]
        SJVideoPlayerURLAsset CurrentPlayingAsset { get; set; }

        // @property (nonatomic, weak) SJVideoPlayerURLAsset * _Nullable switchingAsset;
        [NullAllowed, Export("switchingAsset", ArgumentSemantic.Weak)]
        SJVideoPlayerURLAsset SwitchingAsset { get; set; }

        // @property (nonatomic) SJDefinitionSwitchStatus status;
        [Export("status", ArgumentSemantic.Assign)]
        SJDefinitionSwitchStatus Status { get; set; }
    }

    // @interface SJVideoPlayerPresentView : UIView <SJVideoPlayerPresentView, SJGestureController>
    [BaseType(typeof(UIView))]
    interface SJVideoPlayerPresentView : ISJVideoPlayerPresentView, SJGestureController
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJVideoPlayerPresentViewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJVideoPlayerPresentViewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol SJVideoPlayerPresentViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerPresentViewDelegate
    {
        // @optional -(void)presentViewDidLayoutSubviews:(SJVideoPlayerPresentView * _Nonnull)presentView;
        [Export("presentViewDidLayoutSubviews:")]
        void PresentViewDidLayoutSubviews(SJVideoPlayerPresentView presentView);

        // @optional -(void)presentViewDidMoveToWindow:(SJVideoPlayerPresentView * _Nonnull)presentView;
        [Export("presentViewDidMoveToWindow:")]
        void PresentViewDidMoveToWindow(SJVideoPlayerPresentView presentView);
    }

    // @interface SJSubtitlesAdd (SJVideoPlayerURLAsset)
    [Category]
    [BaseType(typeof(SJVideoPlayerURLAsset))]
    interface SJVideoPlayerURLAsset_SJSubtitlesAdd
    {
        // @property (copy, nonatomic) NSArray<SJSubtitleItem *> * _Nullable subtitles;
        [NullAllowed, Export("subtitles", ArgumentSemantic.Copy)]
        SJSubtitleItem[] Subtitles { get; set; }
    }

    // @interface SJViewControllerManager : NSObject <SJViewControllerManager, SJRotationActionForwarder>
    [BaseType(typeof(NSObject))]
    interface SJViewControllerManager : ISJViewControllerManager, SJRotationActionForwarder
    {
        // @property (nonatomic, weak) id<SJFitOnScreenManager> _Nullable fitOnScreenManager;
        [NullAllowed, Export("fitOnScreenManager", ArgumentSemantic.Weak)]
        SJFitOnScreenManager FitOnScreenManager { get; set; }

        // @property (nonatomic, weak) id<SJRotationManager> _Nullable rotationManager;
        [NullAllowed, Export("rotationManager", ArgumentSemantic.Weak)]
        SJRotationManager RotationManager { get; set; }

        // @property (nonatomic, weak) id<SJControlLayerAppearManager> _Nullable controlLayerAppearManager;
        [NullAllowed, Export("controlLayerAppearManager", ArgumentSemantic.Weak)]
        SJControlLayerAppearManager ControlLayerAppearManager { get; set; }

        // @property (nonatomic, weak) UIView<SJVideoPlayerPresentView> * _Nullable presentView;
        [NullAllowed, Export("presentView", ArgumentSemantic.Weak)]
        SJVideoPlayerPresentView PresentView { get; set; }

        // @property (getter = isLockedScreen, nonatomic) BOOL lockedScreen;
        [Export("lockedScreen")]
        bool LockedScreen { [Bind("isLockedScreen")] get; set; }
    }

    // @interface SJWatermarkView : UIImageView <SJWatermarkView>
    [BaseType(typeof(UIImageView))]
    interface SJWatermarkView : ISJWatermarkView
    {
        // @property (nonatomic) SJWatermarkLayoutPosition layoutPosition;
        [Export("layoutPosition", ArgumentSemantic.Assign)]
        SJWatermarkLayoutPosition LayoutPosition { get; set; }

        // @property (nonatomic) UIEdgeInsets layoutInsets;
        [Export("layoutInsets", ArgumentSemantic.Assign)]
        UIEdgeInsets LayoutInsets { get; set; }

        // @property (nonatomic) CGFloat layoutHeight;
        [Export("layoutHeight")]
        nfloat LayoutHeight { get; set; }

        // -(void)layoutWatermarkInRect:(CGRect)rect videoPresentationSize:(CGSize)vSize videoGravity:(SJVideoGravity _Nonnull)videoGravity;
        [Export("layoutWatermarkInRect:videoPresentationSize:videoGravity:")]
        void LayoutWatermarkInRect(CGRect rect, CGSize vSize, string videoGravity);
    }

    // typedef void (^SJAnimationDidStartHandler)(__kindof CAAnimation * _Nonnull);
    delegate void SJAnimationDidStartHandler(CAAnimation arg0);

    // typedef void (^SJAnimationDidStopHandler)(__kindof CAAnimation * _Nonnull, BOOL);
    delegate void SJAnimationDidStopHandler(CAAnimation arg0, bool arg1);

    // @interface SJBaseVideoPlayerExtended (CALayer)
    [Category]
    [BaseType(typeof(CALayer))]
    interface CALayer_SJBaseVideoPlayerExtended
    {
        // -(void)pauseAnimation;
        [Export("pauseAnimation")]
        void PauseAnimation();

        // -(void)resumeAnimation;
        [Export("resumeAnimation")]
        void ResumeAnimation();

        // -(void)addAnimation:(CAAnimation * _Nonnull)anim startHandler:(SJAnimationDidStartHandler _Nonnull)startHandler;
        [Export("addAnimation:startHandler:")]
        void AddAnimation(CAAnimation anim, SJAnimationDidStartHandler startHandler);

        // -(void)addAnimation:(CAAnimation * _Nonnull)anim stopHandler:(SJAnimationDidStopHandler _Nonnull)stopHandler;
        [Export("addAnimation:stopHandler:")]
        void AddAnimation(CAAnimation anim, SJAnimationDidStopHandler stopHandler);

        // -(void)addAnimation:(CAAnimation * _Nonnull)anim startHandler:(SJAnimationDidStartHandler _Nullable)startHandler stopHandler:(SJAnimationDidStopHandler _Nullable)stopHandler;
        [Export("addAnimation:startHandler:stopHandler:")]
        void AddAnimation(CAAnimation anim, SJAnimationDidStartHandler startHandler, SJAnimationDidStopHandler stopHandler);
    }

    // @interface SJBaseVideoPlayerExtended (UIScrollView)
    [Category]
    [BaseType(typeof(UIScrollView))]
    interface UIScrollView_SJBaseVideoPlayerExtended
    {
        // -(__kindof UIView * _Nullable)viewWithTag:(NSInteger)tag atIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("viewWithTag:atIndexPath:")]
        //[return: NullAllowed]
        UIView ViewWithTag(nint tag, NSIndexPath indexPath);

        // -(BOOL)isViewAppearedWithTag:(NSInteger)tag insets:(UIEdgeInsets)insets atIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("isViewAppearedWithTag:insets:atIndexPath:")]
        bool IsViewAppearedWithTag(nint tag, UIEdgeInsets insets, NSIndexPath indexPath);

        // -(__kindof UIView * _Nullable)viewWithProtocol:(Protocol * _Nonnull)protocol tag:(NSInteger)tag atIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("viewWithProtocol:tag:atIndexPath:")]
        //[return: NullAllowed]
        UIView ViewWithProtocolTagAtIndexPath(Protocol protocol, nint tag, NSIndexPath indexPath);

        // -(__kindof UIView * _Nullable)viewWithProtocol:(Protocol * _Nonnull)protocol tag:(NSInteger)tag inHeaderForSection:(NSInteger)section;
        [Export("viewWithProtocol:tag:inHeaderForSection:")]
        //[return: NullAllowed]
        UIView ViewWithProtocolTagInHeaderForSection(Protocol protocol, nint tag, nint section);

        // -(__kindof UIView * _Nullable)viewWithProtocol:(Protocol * _Nonnull)protocol tag:(NSInteger)tag inFooterForSection:(NSInteger)section;
        [Export("viewWithProtocol:tag:inFooterForSection:")]
        //[return: NullAllowed]
        UIView ViewWithProtocolTagInFooterForSection(Protocol protocol, nint tag, nint section);

        // -(BOOL)isViewAppearedWithProtocol:(Protocol * _Nonnull)protocol tag:(NSInteger)tag insets:(UIEdgeInsets)insets atIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("isViewAppearedWithProtocol:tag:insets:atIndexPath:")]
        bool IsViewAppearedWithProtocol(Protocol protocol, nint tag, UIEdgeInsets insets, NSIndexPath indexPath);

        // -(__kindof UIView * _Nullable)viewForSelector:(SEL _Nonnull)selector atIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("viewForSelector:atIndexPath:")]
        //[return: NullAllowed]
        UIView ViewForSelectorAtIndexPath(Selector selector, NSIndexPath indexPath);

        // -(__kindof UIView * _Nullable)viewForSelector:(SEL _Nonnull)selector inHeaderForSection:(NSInteger)section;
        [Export("viewForSelector:inHeaderForSection:")]
        //[return: NullAllowed]
        UIView ViewForSelectorInHeaderForSection(Selector selector, nint section);

        // -(__kindof UIView * _Nullable)viewForSelector:(SEL _Nonnull)selector inFooterForSection:(NSInteger)section;
        [Export("viewForSelector:inFooterForSection:")]
        //[return: NullAllowed]
        UIView ViewForSelectorInFooterForSection(Selector selector, nint section);

        // -(BOOL)isViewAppearedForSelector:(SEL _Nonnull)selector insets:(UIEdgeInsets)insets atIndexPath:(NSIndexPath * _Nonnull)indexPath;
        [Export("isViewAppearedForSelector:insets:atIndexPath:")]
        bool IsViewAppearedForSelector(Selector selector, UIEdgeInsets insets, NSIndexPath indexPath);
    }

    // @interface SJBaseVideoPlayerExtended (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_SJBaseVideoPlayerExtended
    {
        // -(BOOL)isViewAppeared:(UIView * _Nullable)childView insets:(UIEdgeInsets)insets;
        [Export("isViewAppeared:insets:")]
        bool IsViewAppeared(UIView childView, UIEdgeInsets insets);

        // -(CGRect)intersectionWithView:(UIView * _Nonnull)view insets:(UIEdgeInsets)insets;
        [Export("intersectionWithView:insets:")]
        CGRect IntersectionWithView(UIView view, UIEdgeInsets insets);

        // -(__kindof UIResponder * _Nullable)lookupResponderForClass:(Class _Nonnull)cls;
        [Export("lookupResponderForClass:")]
        //[return: NullAllowed]
        UIResponder LookupResponderForClass(Class cls);

        // -(__kindof UIView * _Nullable)viewWithProtocol:(Protocol * _Nonnull)protocol tag:(NSInteger)tag;
        [Export("viewWithProtocol:tag:")]
        //[return: NullAllowed]
        UIView ViewWithProtocol(Protocol protocol, nint tag);

        // -(BOOL)isViewAppearedWithProtocol:(Protocol * _Nonnull)protocol tag:(NSInteger)tag insets:(UIEdgeInsets)insets;
        [Export("isViewAppearedWithProtocol:tag:insets:")]
        bool IsViewAppearedWithProtocol(Protocol protocol, nint tag, UIEdgeInsets insets);

        // @property (nonatomic) CGFloat sj_x;
        [Export("sj_x")]
        nfloat Sj_x { get; set; }

        // @property (nonatomic) CGFloat sj_y;
        [Export("sj_y")]
        nfloat Sj_y { get; set; }

        // @property (nonatomic) CGFloat sj_w;
        [Export("sj_w")]
        nfloat Sj_w { get; set; }

        // @property (nonatomic) CGFloat sj_h;
        [Export("sj_h")]
        nfloat Sj_h { get; set; }

        // @property (nonatomic) CGSize sj_size;
        [Export("sj_size", ArgumentSemantic.Assign)]
        CGSize Sj_size { get; set; }
    }

    // @interface SJBaseVideoPlayerExtended (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_SJBaseVideoPlayerExtended
    {
        // -(__kindof UIView * _Nullable)subviewForSelector:(SEL _Nonnull)selector;
        [Export("subviewForSelector:")]
        //[return: NullAllowed]
        UIView SubviewForSelector(Selector selector);
    }

    // typedef void (^SJAnimationCompletionHandler)();
    delegate void SJAnimationCompletionHandler();

    // typedef void (^SJPresentedAnimationHandler)(__kindof UIViewController * _Nonnull, SJAnimationCompletionHandler _Nonnull);
    delegate void SJPresentedAnimationHandler(UIViewController arg0, SJAnimationCompletionHandler arg1);

    // typedef void (^SJDismissedAnimationHandler)(__kindof UIViewController * _Nonnull, SJAnimationCompletionHandler _Nonnull);
    delegate void SJDismissedAnimationHandler(UIViewController arg0, SJAnimationCompletionHandler arg1);

    // @interface SJBaseVideoPlayerExtended (UIViewController)
    [Category]
    [BaseType(typeof(UIViewController))]
    interface UIViewController_SJBaseVideoPlayerExtended
    {
        // -(void)setTransitionDuration:(NSTimeInterval)dutaion presentedAnimation:(SJPresentedAnimationHandler _Nonnull)presentedAnimation dismissedAnimation:(SJDismissedAnimationHandler _Nonnull)dismissedAnimation;
        [Export("setTransitionDuration:presentedAnimation:dismissedAnimation:")]
        void SetTransitionDuration(double dutaion, SJPresentedAnimationHandler presentedAnimation, SJDismissedAnimationHandler dismissedAnimation);
    }

    // @interface SJTimerControl : NSObject
    [BaseType(typeof(NSObject))]
    interface SJTimerControl
    {
        // @property (nonatomic) NSTimeInterval interval;
        [Export("interval")]
        double Interval { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJTimerControl * _Nonnull) exeBlock;
        [NullAllowed, Export("exeBlock", ArgumentSemantic.Copy)]
        Action<SJTimerControl> ExeBlock { get; set; }

        // -(void)resume;
        [Export("resume")]
        void Resume();

        // -(void)interrupt;
        [Export("interrupt")]
        void Interrupt();
    }

    // @interface SJVideoPlayerRegistrar : NSObject
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerRegistrar
    {
        // @property (readonly, nonatomic) SJVideoPlayerAppState state;
        [Export("state")]
        SJVideoPlayerAppState State();

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) willResignActive;
        [NullAllowed, Export("willResignActive", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> WillResignActive { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) didBecomeActive;
        [NullAllowed, Export("didBecomeActive", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> DidBecomeActive { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) willEnterForeground;
        [NullAllowed, Export("willEnterForeground", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> WillEnterForeground { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) didEnterBackground;
        [NullAllowed, Export("didEnterBackground", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> DidEnterBackground { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) willTerminate;
        [NullAllowed, Export("willTerminate", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> WillTerminate { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) newDeviceAvailable;
        [NullAllowed, Export("newDeviceAvailable", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> NewDeviceAvailable { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) oldDeviceUnavailable;
        [NullAllowed, Export("oldDeviceUnavailable", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> OldDeviceUnavailable { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) categoryChange;
        [NullAllowed, Export("categoryChange", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> CategoryChange { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerRegistrar * _Nonnull) audioSessionInterruption;
        [NullAllowed, Export("audioSessionInterruption", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerRegistrar> AudioSessionInterruption { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSErrorDomain _Nonnull SJIJKMediaPlayerErrorDomain;
        [Field("SJIJKMediaPlayerErrorDomain", "__Internal")]
        NSString SJIJKMediaPlayerErrorDomain();
    }

    // @interface SJIJKMediaPlayer : NSObject <SJMediaPlayer>
    [BaseType(typeof(NSObject))]
    interface SJIJKMediaPlayer : SJMediaPlayer
    {
        // -(instancetype _Nonnull)initWithURL:(NSURL * _Nonnull)URL startPosition:(NSTimeInterval)startPosition options:(IJKFFOptions * _Nonnull)ops;
        [Export("initWithURL:startPosition:options:")]
        NativeHandle Constructor(NSUrl URL, double startPosition, IJKFFOptions ops);

        // @property (readonly, nonatomic, strong) NSURL * _Nonnull URL;
        [Export("URL", ArgumentSemantic.Strong)]
        NSUrl URL();

        // @property (nonatomic) NSTimeInterval trialEndPosition;
        [Export("trialEndPosition")]
        double TrialEndPosition { get; set; }

        // @property (nonatomic) BOOL pauseWhenAppDidEnterBackground;
        [Export("pauseWhenAppDidEnterBackground")]
        bool PauseWhenAppDidEnterBackground { get; set; }

        // @property (readonly, nonatomic) BOOL firstVideoFrameRendered;
        [Export("firstVideoFrameRendered")]
        bool FirstVideoFrameRendered();

        // @property (readonly, nonatomic) UIView * _Nonnull view;
        [Export("view")]
        UIView View();

        // @property (nonatomic) SJVideoGravity _Nonnull videoGravity;
        [Export("videoGravity")]
        string VideoGravity { get; set; }
    }

    // @interface SJIJKMediaPlayerLayerView : UIView <SJMediaPlayerView>
    [BaseType(typeof(UIView))]
    interface SJIJKMediaPlayerLayerView : SJMediaPlayerView
    {
        // -(instancetype _Nonnull)initWithPlayer:(SJIJKMediaPlayer * _Nonnull)player;
        [Export("initWithPlayer:")]
        NativeHandle Constructor(SJIJKMediaPlayer player);

        // @property (readonly, nonatomic, strong) SJIJKMediaPlayer * _Nonnull player;
        [Export("player", ArgumentSemantic.Strong)]
        SJIJKMediaPlayer Player();

        // @property (nonatomic) SJVideoGravity _Nonnull videoGravity;
        [Export("videoGravity")]
        string VideoGravity { get; set; }

        // @property (readonly, getter = isReadyForDisplay, nonatomic) BOOL readyForDisplay;
        [Export("readyForDisplay")]
        bool ReadyForDisplay { [Bind("isReadyForDisplay")] get; }
    }

    // @interface SJIJKMediaPlaybackController : SJMediaPlaybackController
    [BaseType(typeof(SJMediaPlaybackController))]
    interface SJIJKMediaPlaybackController
    {
        // @property (nonatomic, strong, null_resettable) IJKFFOptions * _Null_unspecified options;
        [NullAllowed, Export("options", ArgumentSemantic.Strong)]
        IJKFFOptions Options { get; set; }

        // @property (readonly, nonatomic, strong) SJIJKMediaPlayer * _Nullable currentPlayer;
        [NullAllowed, Export("currentPlayer", ArgumentSemantic.Strong)]
        SJIJKMediaPlayer CurrentPlayer();
    }

    // @interface SJBaseVideoPlayerResourceLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface SJBaseVideoPlayerResourceLoader
    {
        // +(UIImage * _Nullable)imageNamed:(NSString * _Nonnull)name;
        [Static]
        [Export("imageNamed:")]
        //[return: NullAllowed]
        UIImage ImageNamed(string name);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double SJBaseVideoPlayerVersionNumber;
        [Field("SJBaseVideoPlayerVersionNumber", "__Internal")]
        double SJBaseVideoPlayerVersionNumber();

        // extern const unsigned char[] SJBaseVideoPlayerVersionString;
        [Field("SJBaseVideoPlayerVersionString", "__Internal")]
        NSString SJBaseVideoPlayerVersionString();
    }
}
