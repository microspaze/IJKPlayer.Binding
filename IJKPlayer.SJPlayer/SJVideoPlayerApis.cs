using System;
using System.Runtime.InteropServices;
using CoreAnimation;
using CoreGraphics;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace IJKPlayer.SJPlayer
{
    /*// common argument actions
    delegate void SJVideoPlayerConfigurationsArgumentAction(SJVideoPlayerConfigurations arg0);
    delegate void SJVideoPlayerLocalizedStringsArgumentAction(SJVideoPlayerLocalizedStrings arg0);
    delegate void SJVideoPlayerControlLayerResourcesArgumentAction(SJVideoPlayerControlLayerResources arg0);
    delegate void SJEdgeControlButtonItemActionArgumentAction(SJEdgeControlButtonItemAction arg0);
    
    // @protocol SJControlLayer <SJVideoPlayerControlLayerDataSource, SJVideoPlayerControlLayerDelegate, SJControlLayerRestartProtocol, SJControlLayerExitProtocol>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    interface SJControlLayer : SJVideoPlayerControlLayerDataSource, SJVideoPlayerControlLayerDelegate, SJControlLayerRestartProtocol, SJControlLayerExitProtocol
    {
    }

    // @protocol SJControlLayerRestartProtocol <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJControlLayerRestartProtocol
    {
        // @required @property (readonly, nonatomic) BOOL restarted;
        [Abstract]
        [Export("restarted")]
        bool Restarted();

        // @required -(void)restartControlLayer;
        [Abstract]
        [Export("restartControlLayer")]
        void RestartControlLayer();
    }

    // @protocol SJControlLayerExitProtocol <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJControlLayerExitProtocol
    {
        // @required -(void)exitControlLayer;
        [Abstract]
        [Export("exitControlLayer")]
        void ExitControlLayer();
    }

    [Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJControlLayerIdentifier SJControlLayer_Edge;
        [Field("SJControlLayer_Edge", "__Internal")]
        nint SJControlLayer_Edge { get; }

        // extern const SJControlLayerIdentifier SJControlLayer_Clips;
        [Field("SJControlLayer_Clips", "__Internal")]
        nint SJControlLayer_Clips { get; }

        // extern const SJControlLayerIdentifier SJControlLayer_More;
        [Field("SJControlLayer_More", "__Internal")]
        nint SJControlLayer_More { get; }

        // extern const SJControlLayerIdentifier SJControlLayer_LoadFailed;
        [Field("SJControlLayer_LoadFailed", "__Internal")]
        nint SJControlLayer_LoadFailed { get; }

        // extern const SJControlLayerIdentifier SJControlLayer_NotReachableAndPlaybackStalled;
        [Field("SJControlLayer_NotReachableAndPlaybackStalled", "__Internal")]
        nint SJControlLayer_NotReachableAndPlaybackStalled { get; }

        // extern const SJControlLayerIdentifier SJControlLayer_FloatSmallView;
        [Field("SJControlLayer_FloatSmallView", "__Internal")]
        nint SJControlLayer_FloatSmallView { get; }

        // extern const SJControlLayerIdentifier SJControlLayer_SwitchVideoDefinition;
        [Field("SJControlLayer_SwitchVideoDefinition", "__Internal")]
        nint SJControlLayer_SwitchVideoDefinition { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyLongPressSpeedupPlayback __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyLongPressSpeedupPlayback", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyLongPressSpeedupPlayback { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyNoNetwork __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyNoNetwork", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyNoNetwork { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyWiFiNetWork __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyWiFiNetWork", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyWiFiNetWork { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyCellularNetwork __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyCellularNetwork", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyCellularNetwork { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyReplay __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyReplay", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyReplay { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyRetry __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyRetry", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyRetry { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyReload __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyReload", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyReload { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyLiveBroadcast __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyLiveBroadcast", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyLiveBroadcast { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyCancel __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyCancel", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyCancel { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyDone __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyDone", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyDone { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyUnstableNetworkPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyUnstableNetworkPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyUnstableNetworkPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyCellularNetworkPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyCellularNetworkPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyCellularNetworkPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyNoNetworkPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyNoNetworkPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyNoNetworkPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyPlaybackFailedPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyPlaybackFailedPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyPlaybackFailedPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyRecordsPreparingPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyRecordsPreparingPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyRecordsPreparingPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyRecordsToFinishRecordingPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyRecordsToFinishRecordingPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyRecordsToFinishRecordingPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyExportsExportingPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyExportsExportingPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyExportsExportingPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyExportsExportFailedPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyExportsExportFailedPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyExportsExportFailedPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyExportsExportSuccessfullyPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyExportsExportSuccessfullyPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyExportsExportSuccessfullyPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyUploadsUploadingPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyUploadsUploadingPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyUploadsUploadingPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyUploadsUploadFailedPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyUploadsUploadFailedPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyUploadsUploadFailedPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyUploadsUploadSuccessfullyPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyUploadsUploadSuccessfullyPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyUploadsUploadSuccessfullyPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyScreenshotSuccessfullyPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyScreenshotSuccessfullyPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyScreenshotSuccessfullyPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyAlbumAuthDeniedPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyAlbumAuthDeniedPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyAlbumAuthDeniedPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyAlbumSavingScreenshotToAlbumPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyAlbumSavingScreenshotToAlbumPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyAlbumSavingScreenshotToAlbumPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyAlbumSavedToAlbumPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyAlbumSavedToAlbumPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyAlbumSavedToAlbumPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyOperationFailedPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyOperationFailedPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyOperationFailedPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyDefinitionSwitchingPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyDefinitionSwitchingPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyDefinitionSwitchingPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyDefinitionSwitchSuccessfullyPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyDefinitionSwitchSuccessfullyPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyDefinitionSwitchSuccessfullyPrompt { get; }

        // extern const SJVideoPlayerLocalizedStringKey _Nonnull SJVideoPlayerLocalizedStringKeyDefinitionSwitchFailedPrompt __attribute__((visibility("default")));
        [Field("SJVideoPlayerLocalizedStringKeyDefinitionSwitchFailedPrompt", "__Internal")]
        NSString SJVideoPlayerLocalizedStringKeyDefinitionSwitchFailedPrompt { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerConfigurationsDidUpdateNotification __attribute__((visibility("default")));
        [Field("SJVideoPlayerConfigurationsDidUpdateNotification", "__Internal")]
        NSString SJVideoPlayerConfigurationsDidUpdateNotification { get; }
    }

    // @interface SJVideoPlayerConfigurations : NSObject
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerConfigurations
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJVideoPlayerConfigurations Shared();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(void (^ _Nonnull)(SJVideoPlayerConfigurations * _Nonnull)) update;
        [Static]
        [Export("update", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerConfigurationsArgumentAction> Update();

        // @property (nonatomic, strong, null_resettable) id<SJVideoPlayerLocalizedStrings> _Null_unspecified localizedStrings;
        [NullAllowed, Export("localizedStrings", ArgumentSemantic.Strong)]
        SJVideoPlayerLocalizedStrings LocalizedStrings { get; set; }

        // @property (nonatomic, strong, null_resettable) id<SJVideoPlayerControlLayerResources> _Null_unspecified resources;
        [NullAllowed, Export("resources", ArgumentSemantic.Strong)]
        SJVideoPlayerControlLayerResources Resources { get; set; }

        // @property (nonatomic) NSTimeInterval animationDuration;
        [Export("animationDuration")]
        double AnimationDuration { get; set; }
    }

    // @protocol SJVideoPlayerControlLayerResources <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerControlLayerResources
    {
        // @required @property (nonatomic, strong) UIImage * _Nullable placeholder;
        [Abstract]
        [NullAllowed, Export("placeholder", ArgumentSemantic.Strong)]
        UIImage Placeholder { get; set; }

        // @required @property (nonatomic, strong) API_AVAILABLE(ios(14.0)) UIImage * pictureInPictureItemStartImage __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("pictureInPictureItemStartImage", ArgumentSemantic.Strong)]
        UIImage PictureInPictureItemStartImage { get; set; }

        // @required @property (nonatomic, strong) API_AVAILABLE(ios(14.0)) UIImage * pictureInPictureItemStopImage __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Abstract]
        [Export("pictureInPictureItemStopImage", ArgumentSemantic.Strong)]
        UIImage PictureInPictureItemStopImage { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable speedupPlaybackTriangleColor;
        [Abstract]
        [NullAllowed, Export("speedupPlaybackTriangleColor", ArgumentSemantic.Strong)]
        UIColor SpeedupPlaybackTriangleColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable speedupPlaybackRateTextColor;
        [Abstract]
        [NullAllowed, Export("speedupPlaybackRateTextColor", ArgumentSemantic.Strong)]
        UIColor SpeedupPlaybackRateTextColor { get; set; }

        // @required @property (nonatomic, strong) UIFont * _Nullable speedupPlaybackRateTextFont;
        [Abstract]
        [NullAllowed, Export("speedupPlaybackRateTextFont", ArgumentSemantic.Strong)]
        UIFont SpeedupPlaybackRateTextFont { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable speedupPlaybackTextColor;
        [Abstract]
        [NullAllowed, Export("speedupPlaybackTextColor", ArgumentSemantic.Strong)]
        UIColor SpeedupPlaybackTextColor { get; set; }

        // @required @property (nonatomic, strong) UIFont * _Nullable speedupPlaybackTextFont;
        [Abstract]
        [NullAllowed, Export("speedupPlaybackTextFont", ArgumentSemantic.Strong)]
        UIFont SpeedupPlaybackTextFont { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable loadingNetworkSpeedTextColor;
        [Abstract]
        [NullAllowed, Export("loadingNetworkSpeedTextColor", ArgumentSemantic.Strong)]
        UIColor LoadingNetworkSpeedTextColor { get; set; }

        // @required @property (nonatomic, strong) UIFont * _Nullable loadingNetworkSpeedTextFont;
        [Abstract]
        [NullAllowed, Export("loadingNetworkSpeedTextFont", ArgumentSemantic.Strong)]
        UIFont LoadingNetworkSpeedTextFont { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable loadingLineColor;
        [Abstract]
        [NullAllowed, Export("loadingLineColor", ArgumentSemantic.Strong)]
        UIColor LoadingLineColor { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable fastImage;
        [Abstract]
        [NullAllowed, Export("fastImage", ArgumentSemantic.Strong)]
        UIImage FastImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable forwardImage;
        [Abstract]
        [NullAllowed, Export("forwardImage", ArgumentSemantic.Strong)]
        UIImage ForwardImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable batteryBorderImage;
        [Abstract]
        [NullAllowed, Export("batteryBorderImage", ArgumentSemantic.Strong)]
        UIImage BatteryBorderImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable batteryNubImage;
        [Abstract]
        [NullAllowed, Export("batteryNubImage", ArgumentSemantic.Strong)]
        UIImage BatteryNubImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable batteryLightningImage;
        [Abstract]
        [NullAllowed, Export("batteryLightningImage", ArgumentSemantic.Strong)]
        UIImage BatteryLightningImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable backImage;
        [Abstract]
        [NullAllowed, Export("backImage", ArgumentSemantic.Strong)]
        UIImage BackImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreImage;
        [Abstract]
        [NullAllowed, Export("moreImage", ArgumentSemantic.Strong)]
        UIImage MoreImage { get; set; }

        // @required @property (nonatomic, strong) UIFont * _Nullable titleLabelFont;
        [Abstract]
        [NullAllowed, Export("titleLabelFont", ArgumentSemantic.Strong)]
        UIFont TitleLabelFont { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable titleLabelColor;
        [Abstract]
        [NullAllowed, Export("titleLabelColor", ArgumentSemantic.Strong)]
        UIColor TitleLabelColor { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable lockImage;
        [Abstract]
        [NullAllowed, Export("lockImage", ArgumentSemantic.Strong)]
        UIImage LockImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable unlockImage;
        [Abstract]
        [NullAllowed, Export("unlockImage", ArgumentSemantic.Strong)]
        UIImage UnlockImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable pauseImage;
        [Abstract]
        [NullAllowed, Export("pauseImage", ArgumentSemantic.Strong)]
        UIImage PauseImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable playImage;
        [Abstract]
        [NullAllowed, Export("playImage", ArgumentSemantic.Strong)]
        UIImage PlayImage { get; set; }

        // @required @property (nonatomic, strong) UIFont * _Nullable timeLabelFont;
        [Abstract]
        [NullAllowed, Export("timeLabelFont", ArgumentSemantic.Strong)]
        UIFont TimeLabelFont { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable timeLabelColor;
        [Abstract]
        [NullAllowed, Export("timeLabelColor", ArgumentSemantic.Strong)]
        UIColor TimeLabelColor { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable smallScreenImage;
        [Abstract]
        [NullAllowed, Export("smallScreenImage", ArgumentSemantic.Strong)]
        UIImage SmallScreenImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable fullscreenImage;
        [Abstract]
        [NullAllowed, Export("fullscreenImage", ArgumentSemantic.Strong)]
        UIImage FullscreenImage { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable progressTrackColor;
        [Abstract]
        [NullAllowed, Export("progressTrackColor", ArgumentSemantic.Strong)]
        UIColor ProgressTrackColor { get; set; }

        // @required @property (nonatomic) float progressTrackHeight;
        [Abstract]
        [Export("progressTrackHeight")]
        float ProgressTrackHeight { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable progressTraceColor;
        [Abstract]
        [NullAllowed, Export("progressTraceColor", ArgumentSemantic.Strong)]
        UIColor ProgressTraceColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable progressBufferColor;
        [Abstract]
        [NullAllowed, Export("progressBufferColor", ArgumentSemantic.Strong)]
        UIColor ProgressBufferColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable progressThumbColor;
        [Abstract]
        [NullAllowed, Export("progressThumbColor", ArgumentSemantic.Strong)]
        UIColor ProgressThumbColor { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable progressThumbImage;
        [Abstract]
        [NullAllowed, Export("progressThumbImage", ArgumentSemantic.Strong)]
        UIImage ProgressThumbImage { get; set; }

        // @required @property (nonatomic) float progressThumbSize;
        [Abstract]
        [Export("progressThumbSize")]
        float ProgressThumbSize { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable bottomIndicatorTrackColor;
        [Abstract]
        [NullAllowed, Export("bottomIndicatorTrackColor", ArgumentSemantic.Strong)]
        UIColor BottomIndicatorTrackColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable bottomIndicatorTraceColor;
        [Abstract]
        [NullAllowed, Export("bottomIndicatorTraceColor", ArgumentSemantic.Strong)]
        UIColor BottomIndicatorTraceColor { get; set; }

        // @required @property (nonatomic) float bottomIndicatorHeight;
        [Abstract]
        [Export("bottomIndicatorHeight")]
        float BottomIndicatorHeight { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable clipsImage;
        [Abstract]
        [NullAllowed, Export("clipsImage", ArgumentSemantic.Strong)]
        UIImage ClipsImage { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable replayTitleColor;
        [Abstract]
        [NullAllowed, Export("replayTitleColor", ArgumentSemantic.Strong)]
        UIColor ReplayTitleColor { get; set; }

        // @required @property (nonatomic, strong) UIFont * _Nullable replayTitleFont;
        [Abstract]
        [NullAllowed, Export("replayTitleFont", ArgumentSemantic.Strong)]
        UIFont ReplayTitleFont { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable replayImage;
        [Abstract]
        [NullAllowed, Export("replayImage", ArgumentSemantic.Strong)]
        UIImage ReplayImage { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable moreControlLayerBackgroundColor;
        [Abstract]
        [NullAllowed, Export("moreControlLayerBackgroundColor", ArgumentSemantic.Strong)]
        UIColor MoreControlLayerBackgroundColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable moreSliderTraceColor;
        [Abstract]
        [NullAllowed, Export("moreSliderTraceColor", ArgumentSemantic.Strong)]
        UIColor MoreSliderTraceColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable moreSliderTrackColor;
        [Abstract]
        [NullAllowed, Export("moreSliderTrackColor", ArgumentSemantic.Strong)]
        UIColor MoreSliderTrackColor { get; set; }

        // @required @property (nonatomic) float moreSliderTrackHeight;
        [Abstract]
        [Export("moreSliderTrackHeight")]
        float MoreSliderTrackHeight { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreSliderThumbImage;
        [Abstract]
        [NullAllowed, Export("moreSliderThumbImage", ArgumentSemantic.Strong)]
        UIImage MoreSliderThumbImage { get; set; }

        // @required @property (nonatomic) float moreSliderThumbSize;
        [Abstract]
        [Export("moreSliderThumbSize")]
        float MoreSliderThumbSize { get; set; }

        // @required @property (nonatomic) float moreSliderMinRateValue;
        [Abstract]
        [Export("moreSliderMinRateValue")]
        float MoreSliderMinRateValue { get; set; }

        // @required @property (nonatomic) float moreSliderMaxRateValue;
        [Abstract]
        [Export("moreSliderMaxRateValue")]
        float MoreSliderMaxRateValue { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreSliderMinRateImage;
        [Abstract]
        [NullAllowed, Export("moreSliderMinRateImage", ArgumentSemantic.Strong)]
        UIImage MoreSliderMinRateImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreSliderMaxRateImage;
        [Abstract]
        [NullAllowed, Export("moreSliderMaxRateImage", ArgumentSemantic.Strong)]
        UIImage MoreSliderMaxRateImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreSliderMinVolumeImage;
        [Abstract]
        [NullAllowed, Export("moreSliderMinVolumeImage", ArgumentSemantic.Strong)]
        UIImage MoreSliderMinVolumeImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreSliderMaxVolumeImage;
        [Abstract]
        [NullAllowed, Export("moreSliderMaxVolumeImage", ArgumentSemantic.Strong)]
        UIImage MoreSliderMaxVolumeImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreSliderMinBrightnessImage;
        [Abstract]
        [NullAllowed, Export("moreSliderMinBrightnessImage", ArgumentSemantic.Strong)]
        UIImage MoreSliderMinBrightnessImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable moreSliderMaxBrightnessImage;
        [Abstract]
        [NullAllowed, Export("moreSliderMaxBrightnessImage", ArgumentSemantic.Strong)]
        UIImage MoreSliderMaxBrightnessImage { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable playFailedButtonBackgroundColor;
        [Abstract]
        [NullAllowed, Export("playFailedButtonBackgroundColor", ArgumentSemantic.Strong)]
        UIColor PlayFailedButtonBackgroundColor { get; set; }

        // @required @property (nonatomic, strong) UIColor * _Nullable noNetworkButtonBackgroundColor;
        [Abstract]
        [NullAllowed, Export("noNetworkButtonBackgroundColor", ArgumentSemantic.Strong)]
        UIColor NoNetworkButtonBackgroundColor { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable floatSmallViewCloseImage;
        [Abstract]
        [NullAllowed, Export("floatSmallViewCloseImage", ArgumentSemantic.Strong)]
        UIImage FloatSmallViewCloseImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable screenshotImage;
        [Abstract]
        [NullAllowed, Export("screenshotImage", ArgumentSemantic.Strong)]
        UIImage ScreenshotImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable videoClipImage;
        [Abstract]
        [NullAllowed, Export("videoClipImage", ArgumentSemantic.Strong)]
        UIImage VideoClipImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable GIFClipImage;
        [Abstract]
        [NullAllowed, Export("GIFClipImage", ArgumentSemantic.Strong)]
        UIImage GIFClipImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable recordsPreparingImage;
        [Abstract]
        [NullAllowed, Export("recordsPreparingImage", ArgumentSemantic.Strong)]
        UIImage RecordsPreparingImage { get; set; }

        // @required @property (nonatomic, strong) UIImage * _Nullable recordsToFinishRecordingImage;
        [Abstract]
        [NullAllowed, Export("recordsToFinishRecordingImage", ArgumentSemantic.Strong)]
        UIImage RecordsToFinishRecordingImage { get; set; }
    }

    // @protocol SJVideoPlayerLocalizedStrings <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerLocalizedStrings
    {
        // @required -(void)setFromBundle:(NSBundle * _Nonnull)bundle;
        [Abstract]
        [Export("setFromBundle:")]
        void SetFromBundle(NSBundle bundle);

        // @required @property (copy, nonatomic) NSString * _Nullable longPressSpeedupPlayback;
        [Abstract]
        [NullAllowed, Export("longPressSpeedupPlayback")]
        string LongPressSpeedupPlayback { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable noNetWork;
        [Abstract]
        [NullAllowed, Export("noNetWork")]
        string NoNetWork { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable WiFiNetwork;
        [Abstract]
        [NullAllowed, Export("WiFiNetwork")]
        string WiFiNetwork { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable cellularNetwork;
        [Abstract]
        [NullAllowed, Export("cellularNetwork")]
        string CellularNetwork { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable replay;
        [Abstract]
        [NullAllowed, Export("replay")]
        string Replay { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable retry;
        [Abstract]
        [NullAllowed, Export("retry")]
        string Retry { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable reload;
        [Abstract]
        [NullAllowed, Export("reload")]
        string Reload { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable liveBroadcast;
        [Abstract]
        [NullAllowed, Export("liveBroadcast")]
        string LiveBroadcast { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable cancel;
        [Abstract]
        [NullAllowed, Export("cancel")]
        string Cancel { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable done;
        [Abstract]
        [NullAllowed, Export("done")]
        string Done { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable unstableNetworkPrompt;
        [Abstract]
        [NullAllowed, Export("unstableNetworkPrompt")]
        string UnstableNetworkPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable cellularNetworkPrompt;
        [Abstract]
        [NullAllowed, Export("cellularNetworkPrompt")]
        string CellularNetworkPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable noNetworkPrompt;
        [Abstract]
        [NullAllowed, Export("noNetworkPrompt")]
        string NoNetworkPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable playbackFailedPrompt;
        [Abstract]
        [NullAllowed, Export("playbackFailedPrompt")]
        string PlaybackFailedPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable recordsPreparingPrompt;
        [Abstract]
        [NullAllowed, Export("recordsPreparingPrompt")]
        string RecordsPreparingPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable recordsToFinishRecordingPrompt;
        [Abstract]
        [NullAllowed, Export("recordsToFinishRecordingPrompt")]
        string RecordsToFinishRecordingPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable exportsExportingPrompt;
        [Abstract]
        [NullAllowed, Export("exportsExportingPrompt")]
        string ExportsExportingPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable exportsExportFailedPrompt;
        [Abstract]
        [NullAllowed, Export("exportsExportFailedPrompt")]
        string ExportsExportFailedPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable exportsExportSuccessfullyPrompt;
        [Abstract]
        [NullAllowed, Export("exportsExportSuccessfullyPrompt")]
        string ExportsExportSuccessfullyPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable uploadsUploadingPrompt;
        [Abstract]
        [NullAllowed, Export("uploadsUploadingPrompt")]
        string UploadsUploadingPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable uploadsUploadFailedPrompt;
        [Abstract]
        [NullAllowed, Export("uploadsUploadFailedPrompt")]
        string UploadsUploadFailedPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable uploadsUploadSuccessfullyPrompt;
        [Abstract]
        [NullAllowed, Export("uploadsUploadSuccessfullyPrompt")]
        string UploadsUploadSuccessfullyPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable screenshotSuccessfullyPrompt;
        [Abstract]
        [NullAllowed, Export("screenshotSuccessfullyPrompt")]
        string ScreenshotSuccessfullyPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable albumAuthDeniedPrompt;
        [Abstract]
        [NullAllowed, Export("albumAuthDeniedPrompt")]
        string AlbumAuthDeniedPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable albumSavingScreenshotToAlbumPrompt;
        [Abstract]
        [NullAllowed, Export("albumSavingScreenshotToAlbumPrompt")]
        string AlbumSavingScreenshotToAlbumPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable albumSavedToAlbumPrompt;
        [Abstract]
        [NullAllowed, Export("albumSavedToAlbumPrompt")]
        string AlbumSavedToAlbumPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable operationFailedPrompt;
        [Abstract]
        [NullAllowed, Export("operationFailedPrompt")]
        string OperationFailedPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable definitionSwitchingPrompt;
        [Abstract]
        [NullAllowed, Export("definitionSwitchingPrompt")]
        string DefinitionSwitchingPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable definitionSwitchSuccessfullyPrompt;
        [Abstract]
        [NullAllowed, Export("definitionSwitchSuccessfullyPrompt")]
        string DefinitionSwitchSuccessfullyPrompt { get; set; }

        // @required @property (copy, nonatomic) NSString * _Nullable definitionSwitchFailedPrompt;
        [Abstract]
        [NullAllowed, Export("definitionSwitchFailedPrompt")]
        string DefinitionSwitchFailedPrompt { get; set; }
    }

    // @interface SJControlAdd (SJVideoPlayerURLAsset)
    [Category]
    [BaseType(typeof(SJVideoPlayerURLAsset))]
    interface SJVideoPlayerURLAsset_SJControlAdd
    {
        // @property (copy, nonatomic) NSString * _Nullable title;
        [Export("title")]
        string? GetTitle();
        
        [Export("settitle:")]
        void SetTitle(string? title);

        // @property (copy, nonatomic) NSAttributedString * _Nullable attributedTitle;
        [Export("attributedTitle")]
        NSAttributedString? GetAttributedTitle();
        
        [Export("setattributedTitle:")]
        void SetAttributedTitle(NSAttributedString? attributedString);
    }

    // @protocol SJVideoPlayerClipsParameters <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJVideoPlayerClipsParameters
    {
        // @required @property (readonly, nonatomic) SJVideoPlayerClipsOperation operation;
        [Abstract]
        [Export("operation")]
        SJVideoPlayerClipsOperation Operation();

        // @required @property (readonly, nonatomic) CMTimeRange range;
        [Abstract]
        [Export("range")]
        CMTimeRange Range();

        // @required @property (nonatomic) BOOL resultNeedUpload;
        [Abstract]
        [Export("resultNeedUpload")]
        bool ResultNeedUpload { get; set; }

        // @required @property (nonatomic, weak) id<SJVideoPlayerClipsResultUpload> _Nullable resultUploader;
        [Abstract]
        [NullAllowed, Export("resultUploader", ArgumentSemantic.Weak)]
        SJVideoPlayerClipsResultUpload ResultUploader { get; set; }

        // @required @property (nonatomic) BOOL saveResultToAlbum;
        [Abstract]
        [Export("saveResultToAlbum")]
        bool SaveResultToAlbum { get; set; }
    }

    // @protocol SJVideoPlayerClipsResult <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerClipsResult
    {
        // @required @property (readonly, nonatomic) SJVideoPlayerClipsOperation operation;
        [Abstract]
        [Export("operation")]
        SJVideoPlayerClipsOperation Operation();

        // @required @property (readonly, nonatomic) SJClipsExportState exportState;
        [Abstract]
        [Export("exportState")]
        SJClipsExportState ExportState();

        // @required @property (readonly, nonatomic) SJClipsResultUploadState uploadState;
        [Abstract]
        [Export("uploadState")]
        SJClipsResultUploadState UploadState();

        // @required @property (readonly, nonatomic, strong) UIImage * _Nullable thumbnailImage;
        [Abstract]
        [NullAllowed, Export("thumbnailImage", ArgumentSemantic.Strong)]
        UIImage ThumbnailImage();

        // @required @property (readonly, nonatomic, strong) UIImage * _Nullable image;
        [Abstract]
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image();

        // @required @property (readonly, nonatomic, strong) NSURL * _Nullable fileURL;
        [Abstract]
        [NullAllowed, Export("fileURL", ArgumentSemantic.Strong)]
        NSUrl FileURL();

        // @required @property (readonly, nonatomic, strong) SJVideoPlayerURLAsset * _Nullable currentPlayAsset;
        [Abstract]
        [NullAllowed, Export("currentPlayAsset", ArgumentSemantic.Strong)]
        SJVideoPlayerURLAsset CurrentPlayAsset();

        // @required -(NSData * _Nullable)data;
        [Abstract]
        [NullAllowed, Export("data")]
        //[Verify(MethodToProperty)]
        NSData Data();
    }

    // @protocol SJVideoPlayerClipsResultUpload <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerClipsResultUpload
    {
        // @required -(void)upload:(id<SJVideoPlayerClipsResult> _Nonnull)result progress:(void (^ _Nullable)(float))progressBlock success:(void (^ _Nullable)(void))success failure:(void (^ _Nullable)(NSError * _Nonnull))failure;
        [Abstract]
        [Export("upload:progress:success:failure:")]
        void Upload(SJVideoPlayerClipsResult result, Action<float> progressBlock, Action? success, Action<NSError> failure);

        // @required -(void)cancelUpload:(id<SJVideoPlayerClipsResult> _Nonnull)result;
        [Abstract]
        [Export("cancelUpload:")]
        void CancelUpload(SJVideoPlayerClipsResult result);
    }

    // @interface SJClipsResultShareItem : NSObject
    [BaseType(typeof(NSObject))]
    interface SJClipsResultShareItem
    {
        // -(instancetype)initWithTitle:(NSString *)title image:(UIImage *)image;
        [Export("initWithTitle:image:")]
        NativeHandle Constructor(string title, UIImage image);

        // @property (nonatomic, strong) NSString * title;
        [Export("title", ArgumentSemantic.Strong)]
        string Title { get; set; }

        // @property (nonatomic, strong) UIImage * image;
        [Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (nonatomic) BOOL canAlsoClickedWhenUploading;
        [Export("canAlsoClickedWhenUploading")]
        bool CanAlsoClickedWhenUploading { get; set; }
    }

    // @interface SJVideoPlayerClipsConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerClipsConfig
    {
        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull, SJVideoPlayerClipsOperation) shouldStart;
        [NullAllowed, Export("shouldStart", ArgumentSemantic.Copy)]
        Func<SJBaseVideoPlayer, SJVideoPlayerClipsOperation, bool> ShouldStart { get; set; }

        // @property (nonatomic, strong) NSArray<SJClipsResultShareItem *> * _Nullable resultShareItems;
        [NullAllowed, Export("resultShareItems", ArgumentSemantic.Strong)]
        SJClipsResultShareItem[] ResultShareItems { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull, SJClipsResultShareItem * _Nonnull, id<SJVideoPlayerClipsResult> _Nonnull) clickedResultShareItemExeBlock;
        [NullAllowed, Export("clickedResultShareItemExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer, SJClipsResultShareItem, SJVideoPlayerClipsResult> ClickedResultShareItemExeBlock { get; set; }

        // @property (nonatomic) BOOL resultNeedUpload;
        [Export("resultNeedUpload")]
        bool ResultNeedUpload { get; set; }

        // @property (nonatomic, weak) id<SJVideoPlayerClipsResultUpload> _Nullable resultUploader;
        [NullAllowed, Export("resultUploader", ArgumentSemantic.Weak)]
        SJVideoPlayerClipsResultUpload ResultUploader { get; set; }

        // @property (nonatomic) BOOL disableScreenshot;
        [Export("disableScreenshot")]
        bool DisableScreenshot { get; set; }

        // @property (nonatomic) BOOL disableRecord;
        [Export("disableRecord")]
        bool DisableRecord { get; set; }

        // @property (nonatomic) BOOL disableGIF;
        [Export("disableGIF")]
        bool DisableGIF { get; set; }

        // @property (nonatomic) BOOL saveResultToAlbum;
        [Export("saveResultToAlbum")]
        bool SaveResultToAlbum { get; set; }

        // -(void)config:(SJVideoPlayerClipsConfig * _Nonnull)otherConfig;
        [Export("config:")]
        void Config(SJVideoPlayerClipsConfig otherConfig);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern SJControlLayerIdentifier SJControlLayer_Uninitialized;
        [Field("SJControlLayer_Uninitialized", "__Internal")]
        nint SJControlLayer_Uninitialized { get; }
    }

    // @protocol SJControlLayerSwitcher <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ISJControlLayerSwitcher
    {
        // @required -(instancetype _Nonnull)initWithPlayer:(SJBaseVideoPlayer * _Nonnull)player;
        //[Abstract]
        [Export("initWithPlayer:")]
        NativeHandle Constructor(SJBaseVideoPlayer player);

        // @required -(void)switchControlLayerForIdentifier:(SJControlLayerIdentifier)identifier;
        [Abstract]
        [Export("switchControlLayerForIdentifier:")]
        void SwitchControlLayerForIdentifier(nint identifier);

        // @required -(BOOL)switchToPreviousControlLayer;
        [Abstract]
        [Export("switchToPreviousControlLayer")]
        //[Verify(MethodToProperty)]
        bool SwitchToPreviousControlLayer();

        // @required -(void)addControlLayerForIdentifier:(SJControlLayerIdentifier)identifier lazyLoading:(id<SJControlLayer>  _Nonnull (^ _Nullable)(SJControlLayerIdentifier))loading;
        [Abstract]
        [Export("addControlLayerForIdentifier:lazyLoading:")]
        void AddControlLayerForIdentifier(nint identifier, Func<nint, SJControlLayer> loading);

        // @required -(void)deleteControlLayerForIdentifier:(SJControlLayerIdentifier)identifier;
        [Abstract]
        [Export("deleteControlLayerForIdentifier:")]
        void DeleteControlLayerForIdentifier(nint identifier);

        // @required -(BOOL)containsControlLayer:(SJControlLayerIdentifier)identifier;
        [Abstract]
        [Export("containsControlLayer:")]
        bool ContainsControlLayer(nint identifier);

        // @required -(id<SJControlLayer> _Nullable)controlLayerForIdentifier:(SJControlLayerIdentifier)identifier;
        [Abstract]
        [Export("controlLayerForIdentifier:")]
        //[return: NullAllowed]
        SJControlLayer ControlLayerForIdentifier(nint identifier);

        // @required -(id<SJControlLayerSwitcherObserver> _Nonnull)getObserver;
        [Abstract]
        [Export("getObserver")]
        //[Verify(MethodToProperty)]
        SJControlLayerSwitcherObserver Observer();

        // @required @property (copy, nonatomic) id<SJControlLayer>  _Nullable (^ _Nullable)(SJControlLayerIdentifier) resolveControlLayer;
        [Abstract]
        [NullAllowed, Export("resolveControlLayer", ArgumentSemantic.Copy)]
        Func<nint, SJControlLayer> ResolveControlLayer { get; set; }

        [Wrap("WeakDelegate"), Abstract]
        [NullAllowed]
        SJControlLayerSwitcherDelegate Delegate { get; set; }

        // @required @property (nonatomic, weak) id<SJControlLayerSwitcherDelegate> _Nullable delegate;
        [Abstract]
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @required @property (readonly, nonatomic) SJControlLayerIdentifier previousIdentifier;
        [Abstract]
        [Export("previousIdentifier")]
        nint PreviousIdentifier();

        // @required @property (readonly, nonatomic) SJControlLayerIdentifier currentIdentifier;
        [Abstract]
        [Export("currentIdentifier")]
        nint CurrentIdentifier();
    }

    // @interface SJControlLayerSwitcher : NSObject <SJControlLayerSwitcher>
    [BaseType(typeof(NSObject))]
    interface SJControlLayerSwitcher : ISJControlLayerSwitcher
    {
    }

    // @protocol SJControlLayerSwitcherDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJControlLayerSwitcherDelegate
    {
        // @optional -(BOOL)switcher:(id<SJControlLayerSwitcher> _Nonnull)switcher shouldSwitchToControlLayer:(SJControlLayerIdentifier)identifier;
        [Export("switcher:shouldSwitchToControlLayer:")]
        bool SwitcherShouldSwitchToControlLayer(SJControlLayerSwitcher switcher, nint identifier);

        // @optional -(id<SJControlLayer> _Nullable)switcher:(id<SJControlLayerSwitcher> _Nonnull)switcher controlLayerForIdentifier:(SJControlLayerIdentifier)identifier;
        [Export("switcher:controlLayerForIdentifier:")]
        //[return: NullAllowed]
        SJControlLayer SwitcherControlLayerForIdentifier(SJControlLayerSwitcher switcher, nint identifier);
    }

    // @protocol SJControlLayerSwitcherObserver <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJControlLayerSwitcherObserver
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJControlLayerSwitcher> _Nonnull, id<SJControlLayer> _Nonnull) playerWillBeginSwitchControlLayer;
        [Abstract]
        [NullAllowed, Export("playerWillBeginSwitchControlLayer", ArgumentSemantic.Copy)]
        Action<SJControlLayerSwitcher, SJControlLayer> PlayerWillBeginSwitchControlLayer { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(id<SJControlLayerSwitcher> _Nonnull, id<SJControlLayer> _Nonnull) playerDidEndSwitchControlLayer;
        [Abstract]
        [NullAllowed, Export("playerDidEndSwitchControlLayer", ArgumentSemantic.Copy)]
        Action<SJControlLayerSwitcher, SJControlLayer> PlayerDidEndSwitchControlLayer { get; set; }
    }

    // @interface SJVideoPlayerControlMaskView : UIView
    [BaseType(typeof(UIView))]
    interface SJVideoPlayerControlMaskView
    {
        // -(instancetype _Nonnull)initWithStyle:(SJMaskStyle)style;
        [Export("initWithStyle:")]
        NativeHandle Constructor(SJMaskStyle style);

        // -(void)cleanColors;
        [Export("cleanColors")]
        void CleanColors();
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSNotificationName _Nonnull SJEdgeControlButtonItemPerformedActionNotification __attribute__((visibility("default")));
        [Field("SJEdgeControlButtonItemPerformedActionNotification", "__Internal")]
        NSString SJEdgeControlButtonItemPerformedActionNotification { get; }
    }

    // @interface SJEdgeControlButtonItem : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJEdgeControlButtonItem
    {
        // -(instancetype _Nonnull)initWithImage:(UIImage * _Nullable)image target:(id _Nullable)target action:(SEL _Nullable)action tag:(SJEdgeControlButtonItemTag)tag;
        [Export("initWithImage:target:action:tag:")]
        NativeHandle Constructor(UIImage image, NSObject target, Selector action, nint tag);

        // -(instancetype _Nonnull)initWithTitle:(NSAttributedString * _Nullable)title target:(id _Nullable)target action:(SEL _Nullable)action tag:(SJEdgeControlButtonItemTag)tag;
        [Export("initWithTitle:target:action:tag:")]
        NativeHandle Constructor(NSAttributedString title, NSObject target, Selector action, nint tag);

        // -(instancetype _Nonnull)initWithCustomView:(__kindof UIView * _Nullable)customView tag:(SJEdgeControlButtonItemTag)tag;
        [Export("initWithCustomView:tag:")]
        NativeHandle Constructor(UIView customView, nint tag);

        // -(instancetype _Nonnull)initWithTag:(SJEdgeControlButtonItemTag)tag;
        [Export("initWithTag:")]
        NativeHandle Constructor(nint tag);

        // @property (nonatomic) SJEdgeInsets insets;
        [Export("insets", ArgumentSemantic.Assign)]
        SJEdgeInsets Insets { get; set; }

        // @property (nonatomic) SJEdgeControlButtonItemTag tag;
        [Export("tag")]
        nint Tag { get; set; }

        // @property (nonatomic, strong) __kindof UIView * _Nullable customView;
        [NullAllowed, Export("customView", ArgumentSemantic.Strong)]
        UIView CustomView { get; set; }

        // @property (nonatomic, strong) NSAttributedString * _Nullable title;
        [NullAllowed, Export("title", ArgumentSemantic.Strong)]
        NSAttributedString Title { get; set; }

        // @property (nonatomic) NSInteger numberOfLines;
        [Export("numberOfLines")]
        nint NumberOfLines { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (getter = isHidden, nonatomic) BOOL hidden;
        [Export("hidden")]
        bool Hidden { [Bind("isHidden")] get; set; }

        // @property (nonatomic) CGFloat alpha;
        [Export("alpha")]
        nfloat Alpha { get; set; }

        // @property (nonatomic) BOOL fill;
        [Export("fill")]
        bool Fill { get; set; }

        // @property (readonly, nonatomic) NSArray<SJEdgeControlButtonItemAction *> * _Nullable actions;
        [NullAllowed, Export("actions")]
        SJEdgeControlButtonItemAction[] Actions();

        // -(void)addAction:(SJEdgeControlButtonItemAction * _Nonnull)action;
        [Export("addAction:")]
        void AddAction(SJEdgeControlButtonItemAction action);

        // -(void)removeAction:(SJEdgeControlButtonItemAction * _Nonnull)action;
        [Export("removeAction:")]
        void RemoveAction(SJEdgeControlButtonItemAction action);

        // -(void)removeAllActions;
        [Export("removeAllActions")]
        void RemoveAllActions();

        // -(void)performActions;
        [Export("performActions")]
        void PerformActions();
    }

    // @interface Placeholder (SJEdgeControlButtonItem)
    [Category]
    [BaseType(typeof(SJEdgeControlButtonItem))]
    interface SJEdgeControlButtonItem_Placeholder
    {
        // +(instancetype _Nonnull)placeholderWithType:(SJButtonItemPlaceholderType)placeholderType tag:(SJEdgeControlButtonItemTag)tag;
        [Static]
        [Export("placeholderWithType:tag:")]
        SJEdgeControlButtonItem PlaceholderWithType(SJButtonItemPlaceholderType placeholderType, nint tag);

        // +(instancetype _Nonnull)placeholderWithSize:(CGFloat)size tag:(SJEdgeControlButtonItemTag)tag;
        [Static]
        [Export("placeholderWithSize:tag:")]
        SJEdgeControlButtonItem PlaceholderWithSize(nfloat size, nint tag);

        // @property (readonly, nonatomic) SJButtonItemPlaceholderType placeholderType;
        [Export("placeholderType")]
        SJButtonItemPlaceholderType PlaceholderType();

        // @property (nonatomic) CGFloat size;
        [Export("size")]
        nfloat GetSize();
        
        [Export("setsize:")]
        void SetSize(nfloat size);
    }

    // @interface FrameLayout (SJEdgeControlButtonItem)
    [Category]
    [BaseType(typeof(SJEdgeControlButtonItem))]
    interface SJEdgeControlButtonItem_FrameLayout
    {
        // +(instancetype _Nonnull)frameLayoutWithCustomView:(__kindof UIView * _Nonnull)customView tag:(SJEdgeControlButtonItemTag)tag;
        [Static]
        [Export("frameLayoutWithCustomView:tag:")]
        SJEdgeControlButtonItem FrameLayoutWithCustomView(UIView customView, nint tag);

        // @property (readonly, nonatomic) BOOL isFrameLayout;
        [Export("isFrameLayout")]
        bool IsFrameLayout();
    }

    // @interface SJDeprecated (SJEdgeControlButtonItem)
    [Category]
    [BaseType(typeof(SJEdgeControlButtonItem))]
    interface SJEdgeControlButtonItem_SJDeprecated
    {
        // -(void)addTarget:(id _Nonnull)target action:(SEL _Nonnull)action __attribute__((deprecated("use `addAction:`;")));
        [Export("addTarget:action:")]
        void AddTarget(NSObject target, Selector action);

        // -(void)performAction __attribute__((deprecated("use `performActions`;")));
        [Export("performAction")]
        void PerformAction();
    }

    // @interface SJEdgeControlButtonItemAction : NSObject
    [BaseType(typeof(NSObject))]
    interface SJEdgeControlButtonItemAction
    {
        // +(instancetype _Nonnull)actionWithTarget:(id _Nonnull)target action:(SEL _Nonnull)action;
        [Static]
        [Export("actionWithTarget:action:")]
        SJEdgeControlButtonItemAction ActionWithTarget(NSObject target, Selector action);

        // -(instancetype _Nonnull)initWithTarget:(id _Nonnull)target action:(SEL _Nonnull)action;
        [Export("initWithTarget:action:")]
        NativeHandle Constructor(NSObject target, Selector action);

        // +(instancetype _Nonnull)actionWithHandler:(void (^ _Nonnull)(SJEdgeControlButtonItemAction * _Nonnull))handler;
        [Static]
        [Export("actionWithHandler:")]
        SJEdgeControlButtonItemAction ActionWithHandler(SJEdgeControlButtonItemActionArgumentAction handler);

        // -(instancetype _Nonnull)initWithHandler:(void (^ _Nonnull)(SJEdgeControlButtonItemAction * _Nonnull))handler;
        [Export("initWithHandler:")]
        NativeHandle Constructor(SJEdgeControlButtonItemActionArgumentAction handler);

        // @property (readonly, nonatomic, weak) id _Nullable target;
        [NullAllowed, Export("target", ArgumentSemantic.Weak)]
        NSObject Target();

        // @property (readonly, nonatomic) SEL _Nullable action;
        [NullAllowed, Export("action")]
        Selector Action();

        // @property (readonly, copy, nonatomic) void (^ _Nullable)(SJEdgeControlButtonItemAction * _Nonnull) handler;
        [NullAllowed, Export("handler", ArgumentSemantic.Copy)]
        Action<SJEdgeControlButtonItemAction> Handler();
    }

    // @interface SJEdgeControlButtonItemAdapterLayout : NSObject
    [BaseType(typeof(NSObject))]
    interface SJEdgeControlButtonItemAdapterLayout
    {
        // -(instancetype _Nonnull)initWithLayoutType:(SJAdapterLayoutType)type;
        [Export("initWithLayoutType:")]
        NativeHandle Constructor(SJAdapterLayoutType type);

        // @property (readonly, nonatomic) CGSize intrinsicContentSize;
        [Export("intrinsicContentSize")]
        CGSize IntrinsicContentSize();

        // @property (nonatomic) SJAdapterLayoutType layoutType;
        [Export("layoutType", ArgumentSemantic.Assign)]
        SJAdapterLayoutType LayoutType { get; set; }

        // @property (copy, nonatomic) NSArray<SJEdgeControlButtonItem *> * _Nullable items;
        [NullAllowed, Export("items", ArgumentSemantic.Copy)]
        SJEdgeControlButtonItem[] Items { get; set; }

        // @property (nonatomic) CGSize preferredMaxLayoutSize;
        [Export("preferredMaxLayoutSize", ArgumentSemantic.Assign)]
        CGSize PreferredMaxLayoutSize { get; set; }

        // @property (nonatomic) CGSize itemFillSizeForFrameLayout;
        [Export("itemFillSizeForFrameLayout", ArgumentSemantic.Assign)]
        CGSize ItemFillSizeForFrameLayout { get; set; }

        // -(void)prepareLayout;
        [Export("prepareLayout")]
        void PrepareLayout();

        // -(NSArray<SJEdgeControlButtonItemLayoutAttributes *> * _Nullable)layoutAttributesForItems;
        [NullAllowed, Export("layoutAttributesForItems")]
        //[Verify(MethodToProperty)]
        SJEdgeControlButtonItemLayoutAttributes[] LayoutAttributesForItems();

        // -(SJEdgeControlButtonItemLayoutAttributes * _Nullable)layoutAttributesForItemAtIndex:(NSInteger)index;
        [Export("layoutAttributesForItemAtIndex:")]
        //[return: NullAllowed]
        SJEdgeControlButtonItemLayoutAttributes LayoutAttributesForItemAtIndex(nint index);
    }

    // @interface SJEdgeControlButtonItemLayoutAttributes : NSObject
    [BaseType(typeof(NSObject))]
    interface SJEdgeControlButtonItemLayoutAttributes
    {
        // +(instancetype _Nonnull)layoutAttributesForItemWithIndex:(NSInteger)index;
        [Static]
        [Export("layoutAttributesForItemWithIndex:")]
        SJEdgeControlButtonItemLayoutAttributes LayoutAttributesForItemWithIndex(nint index);

        // @property (nonatomic) NSInteger index;
        [Export("index")]
        nint Index { get; set; }

        // @property (nonatomic) CGRect frame;
        [Export("frame", ArgumentSemantic.Assign)]
        CGRect Frame { get; set; }

        // @property (nonatomic) CGSize size;
        [Export("size", ArgumentSemantic.Assign)]
        CGSize Size { get; set; }

        // @property (nonatomic) CGPoint center;
        [Export("center", ArgumentSemantic.Assign)]
        CGPoint Center { get; set; }
    }

    // @interface SJEdgeControlButtonItemAdapter : UIView
    [BaseType(typeof(UIView))]
    [DisableDefaultCtor]
    interface SJEdgeControlButtonItemAdapter
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame layoutType:(SJAdapterLayoutType)type;
        [Export("initWithFrame:layoutType:")]
        NativeHandle Constructor(CGRect frame, SJAdapterLayoutType type);

        // -(void)reload;
        [Export("reload")]
        void Reload();

        // -(void)updateContentForItemWithTag:(SJEdgeControlButtonItemTag)tag;
        [Export("updateContentForItemWithTag:")]
        void UpdateContentForItemWithTag(nint tag);

        // @property (nonatomic) SJAdapterLayoutType layoutType;
        [Export("layoutType", ArgumentSemantic.Assign)]
        SJAdapterLayoutType LayoutType { get; set; }

        // @property (nonatomic) CGSize itemFillSizeForFrameLayout;
        [Export("itemFillSizeForFrameLayout", ArgumentSemantic.Assign)]
        CGSize ItemFillSizeForFrameLayout { get; set; }

        // -(SJEdgeControlButtonItem * _Nullable)itemAtIndex:(NSInteger)index;
        [Export("itemAtIndex:")]
        //[return: NullAllowed]
        SJEdgeControlButtonItem ItemAtIndex(nint index);

        // -(SJEdgeControlButtonItem * _Nullable)itemForTag:(SJEdgeControlButtonItemTag)tag;
        [Export("itemForTag:")]
        //[return: NullAllowed]
        SJEdgeControlButtonItem ItemForTag(nint tag);

        // -(NSInteger)indexOfItemForTag:(SJEdgeControlButtonItemTag)tag;
        [Export("indexOfItemForTag:")]
        nint IndexOfItemForTag(nint tag);

        // -(NSInteger)indexOfItem:(SJEdgeControlButtonItem * _Nonnull)item;
        [Export("indexOfItem:")]
        nint IndexOfItem(SJEdgeControlButtonItem item);

        // -(NSArray<SJEdgeControlButtonItem *> * _Nullable)itemsWithRange:(NSRange)range;
        [Export("itemsWithRange:")]
        //[return: NullAllowed]
        SJEdgeControlButtonItem[] ItemsWithRange(NSRange range);

        // -(BOOL)isHiddenWithRange:(NSRange)range;
        [Export("isHiddenWithRange:")]
        bool IsHiddenWithRange(NSRange range);

        // -(BOOL)itemContainsPoint:(CGPoint)point;
        [Export("itemContainsPoint:")]
        bool ItemContainsPoint(CGPoint point);

        // -(SJEdgeControlButtonItem * _Nullable)itemAtPoint:(CGPoint)point;
        [Export("itemAtPoint:")]
        //[return: NullAllowed]
        SJEdgeControlButtonItem ItemAtPoint(CGPoint point);

        // -(BOOL)containsItem:(SJEdgeControlButtonItem * _Nonnull)item;
        [Export("containsItem:")]
        bool ContainsItem(SJEdgeControlButtonItem item);

        // -(void)addItem:(SJEdgeControlButtonItem * _Nonnull)item;
        [Export("addItem:")]
        void AddItem(SJEdgeControlButtonItem item);

        // -(void)addItemsFromArray:(NSArray<SJEdgeControlButtonItem *> * _Nonnull)items;
        [Export("addItemsFromArray:")]
        void AddItemsFromArray(SJEdgeControlButtonItem[] items);

        // -(void)insertItem:(SJEdgeControlButtonItem * _Nonnull)item atIndex:(NSInteger)index;
        [Export("insertItem:atIndex:")]
        void InsertItemAtIndex(SJEdgeControlButtonItem item, nint index);

        // -(void)insertItem:(SJEdgeControlButtonItem * _Nonnull)item frontItem:(SJEdgeControlButtonItemTag)tag;
        [Export("insertItem:frontItem:")]
        void InsertItemFrontItem(SJEdgeControlButtonItem item, nint tag);

        // -(void)insertItem:(SJEdgeControlButtonItem * _Nonnull)item rearItem:(SJEdgeControlButtonItemTag)tag;
        [Export("insertItem:rearItem:")]
        void InsertItemRearItem(SJEdgeControlButtonItem item, nint tag);

        // -(void)removeItemAtIndex:(NSInteger)index;
        [Export("removeItemAtIndex:")]
        void RemoveItemAtIndex(nint index);

        // -(void)removeItemForTag:(SJEdgeControlButtonItemTag)tag;
        [Export("removeItemForTag:")]
        void RemoveItemForTag(nint tag);

        // -(void)removeAllItems;
        [Export("removeAllItems")]
        void RemoveAllItems();

        // -(void)exchangeItemAtIndex:(NSInteger)idx1 withItemAtIndex:(NSInteger)idx2;
        [Export("exchangeItemAtIndex:withItemAtIndex:")]
        void ExchangeItemAtIndex(nint idx1, nint idx2);

        // -(void)exchangeItemForTag:(SJEdgeControlButtonItemTag)tag1 withItemForTag:(SJEdgeControlButtonItemTag)tag2;
        [Export("exchangeItemForTag:withItemForTag:")]
        void ExchangeItemForTag(nint tag1, nint tag2);

        // -(UIView * _Nullable)viewForItemAtIndex:(NSInteger)idx;
        [Export("viewForItemAtIndex:")]
        //[return: NullAllowed]
        UIView ViewForItemAtIndex(nint idx);

        // -(UIView * _Nullable)viewForItemForTag:(SJEdgeControlButtonItemTag)tag;
        [Export("viewForItemForTag:")]
        //[return: NullAllowed]
        UIView ViewForItemForTag(nint tag);

        // @property (readonly, nonatomic) NSInteger numberOfItems;
        [Export("numberOfItems")]
        nint NumberOfItems();

        // @property (readonly, nonatomic, strong) SJEdgeControlButtonItemAdapter * _Nonnull view;
        [Export("view", ArgumentSemantic.Strong)]
        SJEdgeControlButtonItemAdapter View();

        // @property (readonly, nonatomic) NSInteger itemCount;
        [Export("itemCount")]
        nint ItemCount();
    }

    // @interface SJEdgeControlLayerAdapters : UIView
    [BaseType(typeof(UIView))]
    interface SJEdgeControlLayerAdapters
    {
        // @property (readonly, nonatomic, strong) SJEdgeControlButtonItemAdapter * _Nonnull topAdapter;
        [Export("topAdapter", ArgumentSemantic.Strong)]
        SJEdgeControlButtonItemAdapter TopAdapter();

        // @property (readonly, nonatomic, strong) SJEdgeControlButtonItemAdapter * _Nonnull leftAdapter;
        [Export("leftAdapter", ArgumentSemantic.Strong)]
        SJEdgeControlButtonItemAdapter LeftAdapter();

        // @property (readonly, nonatomic, strong) SJEdgeControlButtonItemAdapter * _Nonnull bottomAdapter;
        [Export("bottomAdapter", ArgumentSemantic.Strong)]
        SJEdgeControlButtonItemAdapter BottomAdapter();

        // @property (readonly, nonatomic, strong) SJEdgeControlButtonItemAdapter * _Nonnull rightAdapter;
        [Export("rightAdapter", ArgumentSemantic.Strong)]
        SJEdgeControlButtonItemAdapter RightAdapter();

        // @property (readonly, nonatomic, strong) SJEdgeControlButtonItemAdapter * _Nonnull centerAdapter;
        [Export("centerAdapter", ArgumentSemantic.Strong)]
        SJEdgeControlButtonItemAdapter CenterAdapter();

        // @property (readonly, nonatomic, strong) SJVideoPlayerControlMaskView * _Nonnull topContainerView;
        [Export("topContainerView", ArgumentSemantic.Strong)]
        SJVideoPlayerControlMaskView TopContainerView();

        // @property (readonly, nonatomic, strong) SJVideoPlayerControlMaskView * _Nonnull bottomContainerView;
        [Export("bottomContainerView", ArgumentSemantic.Strong)]
        SJVideoPlayerControlMaskView BottomContainerView();

        // @property (readonly, nonatomic, strong) UIView * _Nonnull leftContainerView;
        [Export("leftContainerView", ArgumentSemantic.Strong)]
        UIView LeftContainerView();

        // @property (readonly, nonatomic, strong) UIView * _Nonnull rightContainerView;
        [Export("rightContainerView", ArgumentSemantic.Strong)]
        UIView RightContainerView();

        // @property (readonly, nonatomic, strong) UIView * _Nonnull centerContainerView;
        [Export("centerContainerView", ArgumentSemantic.Strong)]
        UIView CenterContainerView();

        // @property (nonatomic) BOOL autoAdjustTopSpacing;
        [Export("autoAdjustTopSpacing")]
        bool AutoAdjustTopSpacing { get; set; }

        // @property (nonatomic) BOOL autoAdjustLayoutWhenDeviceIsIPhoneXSeries;
        [Export("autoAdjustLayoutWhenDeviceIsIPhoneXSeries")]
        bool AutoAdjustLayoutWhenDeviceIsIPhoneXSeries { get; set; }

        // @property (nonatomic) CGFloat topHeight;
        [Export("topHeight")]
        nfloat TopHeight { get; set; }

        // @property (nonatomic) CGFloat leftWidth;
        [Export("leftWidth")]
        nfloat LeftWidth { get; set; }

        // @property (nonatomic) CGFloat bottomHeight;
        [Export("bottomHeight")]
        nfloat BottomHeight { get; set; }

        // @property (nonatomic) CGFloat rightWidth;
        [Export("rightWidth")]
        nfloat RightWidth { get; set; }

        // @property (nonatomic) CGFloat topMargin;
        [Export("topMargin")]
        nfloat TopMargin { get; set; }

        // @property (nonatomic) CGFloat leftMargin;
        [Export("leftMargin")]
        nfloat LeftMargin { get; set; }

        // @property (nonatomic) CGFloat bottomMargin;
        [Export("bottomMargin")]
        nfloat BottomMargin { get; set; }

        // @property (nonatomic) CGFloat rightMargin;
        [Export("rightMargin")]
        nfloat RightMargin { get; set; }
    }

    // @protocol SJDraggingProgressPopupView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJDraggingProgressPopupView
    {
        // @required @property (nonatomic) SJDraggingProgressPopupViewStyle style;
        [Abstract]
        [Export("style", ArgumentSemantic.Assign)]
        SJDraggingProgressPopupViewStyle Style { get; set; }

        // @required @property (nonatomic) NSTimeInterval dragTime;
        [Abstract]
        [Export("dragTime")]
        double DragTime { get; set; }

        // @required @property (nonatomic) NSTimeInterval currentTime;
        [Abstract]
        [Export("currentTime")]
        double CurrentTime { get; set; }

        // @required @property (nonatomic) NSTimeInterval duration;
        [Abstract]
        [Export("duration")]
        double Duration { get; set; }

        // @required @property (readonly, getter = isPreviewImageHidden, nonatomic) BOOL previewImageHidden;
        [Abstract]
        [Export("previewImageHidden")]
        bool PreviewImageHidden { [Bind("isPreviewImageHidden")] get; }

        // @required @property (nonatomic, strong) UIImage * _Nullable previewImage;
        [Abstract]
        [NullAllowed, Export("previewImage", ArgumentSemantic.Strong)]
        UIImage PreviewImage { get; set; }
    }

    // @protocol SJDraggingObservation <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJDraggingObservation
    {
        // @required @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) willBeginDraggingExeBlock;
        [Abstract]
        [NullAllowed, Export("willBeginDraggingExeBlock", ArgumentSemantic.Copy)]
        Action<double> WillBeginDraggingExeBlock { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) didMoveExeBlock;
        [Abstract]
        [NullAllowed, Export("didMoveExeBlock", ArgumentSemantic.Copy)]
        Action<double> DidMoveExeBlock { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) willEndDraggingExeBlock;
        [Abstract]
        [NullAllowed, Export("willEndDraggingExeBlock", ArgumentSemantic.Copy)]
        Action<double> WillEndDraggingExeBlock { get; set; }

        // @required @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) didEndDraggingExeBlock;
        [Abstract]
        [NullAllowed, Export("didEndDraggingExeBlock", ArgumentSemantic.Copy)]
        Action<double> DidEndDraggingExeBlock { get; set; }
    }

    // @protocol SJLoadingView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJLoadingView
    {
        // @required @property (readonly, getter = isAnimating, nonatomic) BOOL animating;
        [Abstract]
        [Export("animating")]
        bool Animating { [Bind("isAnimating")] get; }

        // @required @property (nonatomic) BOOL showsNetworkSpeed;
        [Abstract]
        [Export("showsNetworkSpeed")]
        bool ShowsNetworkSpeed { get; set; }

        // @required @property (nonatomic, strong) NSAttributedString * _Nullable networkSpeedStr;
        [Abstract]
        [NullAllowed, Export("networkSpeedStr", ArgumentSemantic.Strong)]
        NSAttributedString NetworkSpeedStr { get; set; }

        // @required -(void)start;
        [Abstract]
        [Export("start")]
        void Start();

        // @required -(void)stop;
        [Abstract]
        [Export("stop")]
        void Stop();
    }

    // @protocol SJScrollingTextMarqueeView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJScrollingTextMarqueeView
    {
        // @required @property (copy, nonatomic) NSAttributedString * _Nullable attributedText;
        [Abstract]
        [NullAllowed, Export("attributedText", ArgumentSemantic.Copy)]
        NSAttributedString AttributedText { get; set; }

        // @required @property (nonatomic) CGFloat margin;
        [Abstract]
        [Export("margin")]
        nfloat Margin { get; set; }

        // @required @property (readonly, getter = isScrolling, nonatomic) BOOL scrolling;
        [Abstract]
        [Export("scrolling")]
        bool Scrolling { [Bind("isScrolling")] get; }

        // @required @property (getter = isScrollEnabled, nonatomic) BOOL scrollEnabled;
        [Abstract]
        [Export("scrollEnabled")]
        bool ScrollEnabled { [Bind("isScrollEnabled")] get; set; }

        // @required @property (getter = isCentered, nonatomic) BOOL centered;
        [Abstract]
        [Export("centered")]
        bool Centered { [Bind("isCentered")] get; set; }
    }

    // @protocol SJFullscreenModeStatusBar <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    //[iOS(11, 0)]
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJFullscreenModeStatusBar
    {
        // @required @property (nonatomic) SJNetworkStatus networkStatus;
        [Abstract]
        [Export("networkStatus", ArgumentSemantic.Assign)]
        SJNetworkStatus NetworkStatus { get; set; }

        // @required @property (nonatomic, strong) NSDate * _Nullable date;
        [Abstract]
        [NullAllowed, Export("date", ArgumentSemantic.Strong)]
        NSDate Date { get; set; }

        // @required @property (nonatomic) UIDeviceBatteryState batteryState;
        [Abstract]
        [Export("batteryState", ArgumentSemantic.Assign)]
        UIDeviceBatteryState BatteryState { get; set; }

        // @required @property (nonatomic) float batteryLevel;
        [Abstract]
        [Export("batteryLevel")]
        float BatteryLevel { get; set; }
    }

    // @protocol SJSpeedupPlaybackPopupView <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJSpeedupPlaybackPopupView
    {
        // @required @property (nonatomic) CGFloat rate;
        [Abstract]
        [Export("rate")]
        nfloat Rate { get; set; }

        // @required @property (readonly, getter = isAnimating, nonatomic) BOOL animating;
        [Abstract]
        [Export("animating")]
        bool Animating { [Bind("isAnimating")] get; }

        // @required -(void)show;
        [Abstract]
        [Export("show")]
        void Show();

        // @required -(void)hidden;
        [Abstract]
        [Export("hidden")]
        void Hidden();

        // @optional -(void)layoutInRect:(CGRect)rect gestureState:(SJLongPressGestureRecognizerState)state playbackRate:(CGFloat)rate;
        [Export("layoutInRect:gestureState:playbackRate:")]
        void LayoutInRect(CGRect rect, SJLongPressGestureRecognizerState state, nfloat rate);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerTopItem_Back;
        [Field("SJEdgeControlLayerTopItem_Back", "__Internal")]
        nint SJEdgeControlLayerTopItem_Back { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerTopItem_Title;
        [Field("SJEdgeControlLayerTopItem_Title", "__Internal")]
        nint SJEdgeControlLayerTopItem_Title { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerTopItem_PictureInPicture __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Field("SJEdgeControlLayerTopItem_PictureInPicture", "__Internal")]
        nint SJEdgeControlLayerTopItem_PictureInPicture { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerTopItem_More;
        [Field("SJEdgeControlLayerTopItem_More", "__Internal")]
        nint SJEdgeControlLayerTopItem_More { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerLeftItem_Lock;
        [Field("SJEdgeControlLayerLeftItem_Lock", "__Internal")]
        nint SJEdgeControlLayerLeftItem_Lock { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerRightItem_Clips;
        [Field("SJEdgeControlLayerRightItem_Clips", "__Internal")]
        nint SJEdgeControlLayerRightItem_Clips { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_Play;
        [Field("SJEdgeControlLayerBottomItem_Play", "__Internal")]
        nint SJEdgeControlLayerBottomItem_Play { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_CurrentTime;
        [Field("SJEdgeControlLayerBottomItem_CurrentTime", "__Internal")]
        nint SJEdgeControlLayerBottomItem_CurrentTime { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_DurationTime;
        [Field("SJEdgeControlLayerBottomItem_DurationTime", "__Internal")]
        nint SJEdgeControlLayerBottomItem_DurationTime { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_Separator;
        [Field("SJEdgeControlLayerBottomItem_Separator", "__Internal")]
        nint SJEdgeControlLayerBottomItem_Separator { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_Progress;
        [Field("SJEdgeControlLayerBottomItem_Progress", "__Internal")]
        nint SJEdgeControlLayerBottomItem_Progress { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_Full;
        [Field("SJEdgeControlLayerBottomItem_Full", "__Internal")]
        nint SJEdgeControlLayerBottomItem_Full { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_LIVEText;
        [Field("SJEdgeControlLayerBottomItem_LIVEText", "__Internal")]
        nint SJEdgeControlLayerBottomItem_LIVEText { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerBottomItem_Definition;
        [Field("SJEdgeControlLayerBottomItem_Definition", "__Internal")]
        nint SJEdgeControlLayerBottomItem_Definition { get; }

        // extern const SJEdgeControlButtonItemTag SJEdgeControlLayerCenterItem_Replay;
        [Field("SJEdgeControlLayerCenterItem_Replay", "__Internal")]
        nint SJEdgeControlLayerCenterItem_Replay { get; }
    }

    // @interface SJEdgeControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJEdgeControlLayer : SJControlLayer
    {
        // @property (nonatomic, strong, null_resettable) __kindof UIView<SJLoadingView> * _Null_unspecified loadingView;
        [NullAllowed, Export("loadingView", ArgumentSemantic.Strong)]
        SJLoadingView LoadingView { get; set; }

        // @property (nonatomic, strong, null_resettable) __kindof UIView<SJDraggingProgressPopupView> * _Null_unspecified draggingProgressPopupView;
        [NullAllowed, Export("draggingProgressPopupView", ArgumentSemantic.Strong)]
        SJDraggingProgressPopupView DraggingProgressPopupView { get; set; }

        // @property (readonly, nonatomic, strong) id<SJDraggingObservation> _Nonnull draggingObserver;
        [Export("draggingObserver", ArgumentSemantic.Strong)]
        SJDraggingObservation DraggingObserver();

        // @property (nonatomic, strong, null_resettable) __kindof UIView<SJScrollingTextMarqueeView> * _Null_unspecified titleView;
        [NullAllowed, Export("titleView", ArgumentSemantic.Strong)]
        SJScrollingTextMarqueeView TitleView { get; set; }

        // @property (nonatomic, strong, null_resettable) UIView<SJSpeedupPlaybackPopupView> * _Null_unspecified speedupPlaybackPopupView;
        [NullAllowed, Export("speedupPlaybackPopupView", ArgumentSemantic.Strong)]
        SJSpeedupPlaybackPopupView SpeedupPlaybackPopupView { get; set; }

        // @property (nonatomic) BOOL automaticallyShowsPictureInPictureItem __attribute__((availability(ios, introduced=14.0)));
        //[iOS(14, 0)]
        [Export("automaticallyShowsPictureInPictureItem")]
        bool AutomaticallyShowsPictureInPictureItem { get; set; }

        // @property (getter = isHiddenTitleItemWhenOrientationIsPortrait, nonatomic) BOOL hiddenTitleItemWhenOrientationIsPortrait;
        [Export("hiddenTitleItemWhenOrientationIsPortrait")]
        bool HiddenTitleItemWhenOrientationIsPortrait { [Bind("isHiddenTitleItemWhenOrientationIsPortrait")] get; set; }

        // @property (getter = isHiddenBackButtonWhenOrientationIsPortrait, nonatomic) BOOL hiddenBackButtonWhenOrientationIsPortrait;
        [Export("hiddenBackButtonWhenOrientationIsPortrait")]
        bool HiddenBackButtonWhenOrientationIsPortrait { [Bind("isHiddenBackButtonWhenOrientationIsPortrait")] get; set; }

        // @property (nonatomic) BOOL fixesBackItem;
        [Export("fixesBackItem")]
        bool FixesBackItem { get; set; }

        // @property (getter = isDisabledPromptingWhenNetworkStatusChanges, nonatomic) BOOL disabledPromptingWhenNetworkStatusChanges;
        [Export("disabledPromptingWhenNetworkStatusChanges")]
        bool DisabledPromptingWhenNetworkStatusChanges { [Bind("isDisabledPromptingWhenNetworkStatusChanges")] get; set; }

        // @property (getter = isHiddenBottomProgressIndicator, nonatomic) BOOL hiddenBottomProgressIndicator;
        [Export("hiddenBottomProgressIndicator")]
        bool HiddenBottomProgressIndicator { [Bind("isHiddenBottomProgressIndicator")] get; set; }

        // @property (nonatomic) CGFloat bottomProgressIndicatorHeight;
        [Export("bottomProgressIndicatorHeight")]
        nfloat BottomProgressIndicatorHeight { get; set; }

        // @property (nonatomic, strong, null_resettable) NS_AVAILABLE_IOS(11.0) UIView<SJFullscreenModeStatusBar> * customStatusBar __attribute__((availability(ios, introduced=11.0)));
        //[iOS(11, 0)]
        [NullAllowed, Export("customStatusBar", ArgumentSemantic.Strong)]
        SJFullscreenModeStatusBar CustomStatusBar { get; set; }

        // @property (copy, nonatomic, null_resettable) NS_AVAILABLE_IOS(11.0) BOOL (^)(SJEdgeControlLayer * _Nonnull) shouldShowsCustomStatusBar __attribute__((availability(ios, introduced=11.0)));
        //[iOS(11, 0)]
        [NullAllowed, Export("shouldShowsCustomStatusBar", ArgumentSemantic.Copy)]
        Func<SJEdgeControlLayer, bool> ShouldShowsCustomStatusBar { get; set; }

        // @property (nonatomic) BOOL automaticallyPerformRotationOrFitOnScreen;
        [Export("automaticallyPerformRotationOrFitOnScreen")]
        bool AutomaticallyPerformRotationOrFitOnScreen { get; set; }

        // @property (nonatomic) BOOL needsFitOnScreenFirst;
        [Export("needsFitOnScreenFirst")]
        bool NeedsFitOnScreenFirst { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJEdgeControlLayerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJEdgeControlLayerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol SJEdgeControlLayerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJEdgeControlLayerDelegate
    {
        // @required -(void)backItemWasTappedForControlLayer:(id<SJControlLayer> _Nonnull)controlLayer;
        [Abstract]
        [Export("backItemWasTappedForControlLayer:")]
        void BackItemWasTappedForControlLayer(SJControlLayer controlLayer);
    }

    // @interface SJControlLayerExtended (SJEdgeControlButtonItem)
    [Category]
    [BaseType(typeof(SJEdgeControlButtonItem))]
    interface SJEdgeControlButtonItem_SJControlLayerExtended
    {
        // @property (nonatomic) BOOL resetsAppearIntervalWhenPerformingItemAction;
        [Export("resetsAppearIntervalWhenPerformingItemAction")]
        bool GetResetsAppearIntervalWhenPerformingItemAction();
        
        [Export("setresetsAppearIntervalWhenPerformingItemAction:")]
        void SetResetsAppearIntervalWhenPerformingItemAction(bool resetsAppearIntervalWhenPerformingItemAction);
    }

    // @interface SJClipsControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJClipsControlLayer : SJControlLayer
    {
        // @property (copy, nonatomic) void (^ _Nullable)(SJClipsControlLayer * _Nonnull) cancelledOperationExeBlock;
        [NullAllowed, Export("cancelledOperationExeBlock", ArgumentSemantic.Copy)]
        Action<SJClipsControlLayer> CancelledOperationExeBlock { get; set; }

        // @property (nonatomic, strong) SJVideoPlayerClipsConfig * _Nullable config;
        [NullAllowed, Export("config", ArgumentSemantic.Strong)]
        SJVideoPlayerClipsConfig Config { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJEdgeControlButtonItemTag SJMoreSettingControlLayerItem_Volume;
        [Field("SJMoreSettingControlLayerItem_Volume", "__Internal")]
        nint SJMoreSettingControlLayerItem_Volume { get; }

        // extern const SJEdgeControlButtonItemTag SJMoreSettingControlLayerItem_Brightness;
        [Field("SJMoreSettingControlLayerItem_Brightness", "__Internal")]
        nint SJMoreSettingControlLayerItem_Brightness { get; }

        // extern const SJEdgeControlButtonItemTag SJMoreSettingControlLayerItem_Rate;
        [Field("SJMoreSettingControlLayerItem_Rate", "__Internal")]
        nint SJMoreSettingControlLayerItem_Rate { get; }
    }

    // @interface SJMoreSettingControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJMoreSettingControlLayer : SJControlLayer
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJMoreSettingControlLayerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJMoreSettingControlLayerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol SJMoreSettingControlLayerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJMoreSettingControlLayerDelegate
    {
        // @required -(void)tappedBlankAreaOnTheControlLayer:(id<SJControlLayer> _Nonnull)controlLayer;
        [Abstract]
        [Export("tappedBlankAreaOnTheControlLayer:")]
        void TappedBlankAreaOnTheControlLayer(SJControlLayer controlLayer);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJEdgeControlButtonItemTag SJNotReachableControlLayerTopItem_Back;
        [Field("SJNotReachableControlLayerTopItem_Back", "__Internal")]
        nint SJNotReachableControlLayerTopItem_Back { get; }
    }

    // @interface SJNotReachableControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJNotReachableControlLayer : SJControlLayer
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJNotReachableControlLayerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJNotReachableControlLayerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) UILabel * _Nonnull promptLabel;
        [Export("promptLabel", ArgumentSemantic.Strong)]
        UILabel PromptLabel();

        // @property (readonly, nonatomic, strong) SJButtonContainerView * _Nonnull reloadView;
        [Export("reloadView", ArgumentSemantic.Strong)]
        SJButtonContainerView ReloadView();

        // @property (nonatomic) BOOL hiddenBackButtonWhenOrientationIsPortrait;
        [Export("hiddenBackButtonWhenOrientationIsPortrait")]
        bool HiddenBackButtonWhenOrientationIsPortrait { get; set; }
    }

    // @interface SJButtonContainerView : UIView
    [BaseType(typeof(UIView))]
    interface SJButtonContainerView
    {
        // -(instancetype _Nonnull)initWithEdgeInsets:(UIEdgeInsets)insets;
        [Export("initWithEdgeInsets:")]
        NativeHandle Constructor(UIEdgeInsets insets);

        // @property (nonatomic) UIEdgeInsets insets;
        [Export("insets", ArgumentSemantic.Assign)]
        UIEdgeInsets Insets { get; set; }

        // @property (getter = isRoundedRect, nonatomic) BOOL roundedRect;
        [Export("roundedRect")]
        bool RoundedRect { [Bind("isRoundedRect")] get; set; }

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull button;
        [Export("button", ArgumentSemantic.Strong)]
        UIButton Button();
    }

    // @protocol SJNotReachableControlLayerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJNotReachableControlLayerDelegate
    {
        // @required -(void)backItemWasTappedForControlLayer:(id<SJControlLayer> _Nonnull)controlLayer;
        [Abstract]
        [Export("backItemWasTappedForControlLayer:")]
        void BackItemWasTappedForControlLayer(SJControlLayer controlLayer);

        // @required -(void)reloadItemWasTappedForControlLayer:(id<SJControlLayer> _Nonnull)controlLayer;
        [Abstract]
        [Export("reloadItemWasTappedForControlLayer:")]
        void ReloadItemWasTappedForControlLayer(SJControlLayer controlLayer);
    }

    // @interface SJLoadFailedControlLayer : SJNotReachableControlLayer
    [BaseType(typeof(SJNotReachableControlLayer))]
    interface SJLoadFailedControlLayer
    {
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const SJEdgeControlButtonItemTag SJSmallViewControlLayerTopItem_Close;
        [Field("SJSmallViewControlLayerTopItem_Close", "__Internal")]
        nint SJSmallViewControlLayerTopItem_Close { get; }
    }

    // @interface SJSmallViewControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJSmallViewControlLayer : SJControlLayer
    {
    }

    // @interface SJExtendedDefinition (SJVideoPlayerURLAsset)
    [Category]
    [BaseType(typeof(SJVideoPlayerURLAsset))]
    interface SJVideoPlayerURLAsset_SJExtendedDefinition
    {
        // @property (copy, nonatomic) NSString * _Nullable definition_fullName;
        [Export("definition_fullName")]
        string? GetDefinitionFullName();
        
        [Export("setdefinition_fullName:")]
        void SetDefinitionFullName(string? fullName);

        // @property (copy, nonatomic) NSString * _Nullable definition_lastName;
        [Export("definition_lastName")]
        string? GetDefinitionLastName();

        [Export("setdefinition_lastName:")]
        void SetDefinitionLastName(string? lastName);
    }

    // @interface SJVideoDefinitionSwitchingControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJVideoDefinitionSwitchingControlLayer : SJControlLayer
    {
        // @property (copy, nonatomic) NSArray<SJVideoPlayerURLAsset *> * _Nullable assets;
        [NullAllowed, Export("assets", ArgumentSemantic.Copy)]
        SJVideoPlayerURLAsset[] Assets { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJVideoDefinitionSwitchingControlLayerDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJVideoDefinitionSwitchingControlLayerDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic, strong, null_resettable) UIColor * _Null_unspecified selectedTextColor;
        [NullAllowed, Export("selectedTextColor", ArgumentSemantic.Strong)]
        UIColor SelectedTextColor { get; set; }
    }

    // @protocol SJVideoDefinitionSwitchingControlLayerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJVideoDefinitionSwitchingControlLayerDelegate
    {
        // @required -(void)controlLayer:(SJVideoDefinitionSwitchingControlLayer * _Nonnull)controlLayer didSelectAsset:(SJVideoPlayerURLAsset * _Nonnull)asset;
        [Abstract]
        [Export("controlLayer:didSelectAsset:")]
        void ControlLayer(SJVideoDefinitionSwitchingControlLayer controlLayer, SJVideoPlayerURLAsset asset);

        // @required -(void)tappedBlankAreaOnTheControlLayer:(id<SJControlLayer> _Nonnull)controlLayer;
        [Abstract]
        [Export("tappedBlankAreaOnTheControlLayer:")]
        void TappedBlankAreaOnTheControlLayer(SJControlLayer controlLayer);
    }

    // @interface SJVideoPlayerResourceLoader : NSObject
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerResourceLoader
    {
        // +(UIImage * _Nullable)imageNamed:(NSString * _Nonnull)name;
        [Static]
        [Export("imageNamed:")]
        //[return: NullAllowed]
        UIImage ImageNamed(string name);

        // @property (readonly, nonatomic, class) NSBundle * _Nonnull preferredLanguageBundle;
        [Static]
        [Export("preferredLanguageBundle")]
        NSBundle PreferredLanguageBundle();

        // @property (readonly, nonatomic, class) NSBundle * _Nonnull enBundle;
        [Static]
        [Export("enBundle")]
        NSBundle EnBundle();

        // @property (readonly, nonatomic, class) NSBundle * _Nonnull zhHansBundle;
        [Static]
        [Export("zhHansBundle")]
        NSBundle ZhHansBundle();

        // @property (readonly, nonatomic, class) NSBundle * _Nonnull zhHantBundle;
        [Static]
        [Export("zhHantBundle")]
        NSBundle ZhHantBundle();
    }

    // @interface SJVideoPlayer : SJBaseVideoPlayer
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJVideoPlayer
    {
        // +(instancetype _Nonnull)player;
        [Static]
        [Export("player")]
        SJVideoPlayer Player();

        // +(instancetype _Nonnull)lightweightPlayer;
        [Static]
        [Export("lightweightPlayer")]
        SJVideoPlayer LightweightPlayer();

        // @property (readonly, nonatomic, strong) SJControlLayerSwitcher * _Nonnull switcher;
        [Export("switcher", ArgumentSemantic.Strong)]
        SJControlLayerSwitcher Switcher();

        // @property (readonly, nonatomic, strong) SJEdgeControlLayer * _Nonnull defaultEdgeControlLayer;
        [Export("defaultEdgeControlLayer", ArgumentSemantic.Strong)]
        SJEdgeControlLayer DefaultEdgeControlLayer();

        // @property (readonly, nonatomic, strong) SJNotReachableControlLayer * _Nonnull defaultNotReachableControlLayer;
        [Export("defaultNotReachableControlLayer", ArgumentSemantic.Strong)]
        SJNotReachableControlLayer DefaultNotReachableControlLayer();

        // @property (readonly, nonatomic, strong) SJClipsControlLayer * _Nonnull defaultClipsControlLayer;
        [Export("defaultClipsControlLayer", ArgumentSemantic.Strong)]
        SJClipsControlLayer DefaultClipsControlLayer();

        // @property (readonly, nonatomic, strong) SJMoreSettingControlLayer * _Nonnull defaultMoreSettingControlLayer;
        [Export("defaultMoreSettingControlLayer", ArgumentSemantic.Strong)]
        SJMoreSettingControlLayer DefaultMoreSettingControlLayer();

        // @property (readonly, nonatomic, strong) SJLoadFailedControlLayer * _Nonnull defaultLoadFailedControlLayer;
        [Export("defaultLoadFailedControlLayer", ArgumentSemantic.Strong)]
        SJLoadFailedControlLayer DefaultLoadFailedControlLayer();

        // @property (readonly, nonatomic, strong) SJSmallViewControlLayer * _Nonnull defaultSmallViewControlLayer;
        [Export("defaultSmallViewControlLayer", ArgumentSemantic.Strong)]
        SJSmallViewControlLayer DefaultSmallViewControlLayer();

        // @property (readonly, nonatomic, strong) SJVideoDefinitionSwitchingControlLayer * _Nonnull defaultVideoDefinitionSwitchingControlLayer;
        [Export("defaultVideoDefinitionSwitchingControlLayer", ArgumentSemantic.Strong)]
        SJVideoDefinitionSwitchingControlLayer DefaultVideoDefinitionSwitchingControlLayer();

        // +(NSString * _Nonnull)version;
        [Static]
        [Export("version")]
        //[Verify(MethodToProperty)]
        string Version();
    }

    // @interface CommonSettings (SJVideoPlayer)
    [Category]
    [BaseType(typeof(SJVideoPlayer))]
    interface SJVideoPlayer_CommonSettings
    {
        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(void (^ _Nonnull)(id<SJVideoPlayerControlLayerResources> _Nonnull)) updateResources;
        [Static]
        [Export("updateResources", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerControlLayerResourcesArgumentAction> UpdateResources();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(void (^ _Nonnull)(id<SJVideoPlayerLocalizedStrings> _Nonnull)) updateLocalizedStrings;
        [Static]
        [Export("updateLocalizedStrings", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerLocalizedStringsArgumentAction> UpdateLocalizedStrings();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(NSBundle * _Nonnull) setLocalizedStrings;
        [Static]
        [Export("setLocalizedStrings", ArgumentSemantic.Copy)]
        Action<NSBundle> SetLocalizedStrings();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(void (^ _Nonnull)(SJVideoPlayerConfigurations * _Nonnull)) update;
        [Static]
        [Export("update", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerConfigurationsArgumentAction> Update();
    }

    // @interface SJExtendedVideoDefinitionSwitchingControlLayer (SJVideoPlayer)
    [Category]
    [BaseType(typeof(SJVideoPlayer))]
    interface SJVideoPlayer_SJExtendedVideoDefinitionSwitchingControlLayer
    {
        // @property (copy, nonatomic) NSArray<SJVideoPlayerURLAsset *> * _Nullable definitionURLAssets;
        [Export("definitionURLAssets")]
        SJVideoPlayerURLAsset[]? GetDefinitionURLAssets();
        
        [Export("setdefinitionURLAssets:")]
        void SetDefinitionURLAssets(SJVideoPlayerURLAsset[]? playerUrlAssets);

        // @property (getter = isDisabledDefinitionSwitchingPrompt, nonatomic) BOOL disabledDefinitionSwitchingPrompt;
        [Export("disabledDefinitionSwitchingPrompt")]
        bool GetDisabledDefinitionSwitchingPrompt();
        
        [Export("setdisabledDefinitionSwitchingPrompt:")]
        void SetDisabledDefinitionSwitchingPrompt(bool disabledDefinitionSwitchingPrompt);
    }

    // @interface RotationOrFitOnScreen (SJVideoPlayer)
    [Category]
    [BaseType(typeof(SJVideoPlayer))]
    interface SJVideoPlayer_RotationOrFitOnScreen
    {
        // @property (nonatomic) BOOL automaticallyPerformRotationOrFitOnScreen;
        [Export("automaticallyPerformRotationOrFitOnScreen")]
        bool GetAutomaticallyPerformRotationOrFitOnScreen();
        
        [Export("setautomaticallyPerformRotationOrFitOnScreen:")]
        void SetAutomaticallyPerformRotationOrFitOnScreen(bool automaticallyPerformRotationOrFitOnScreen);

        // @property (nonatomic) BOOL needsFitOnScreenFirst;
        [Export("needsFitOnScreenFirst")]
        bool GetNeedsFitOnScreenFirst();
        
        [Export("setneedsFitOnScreenFirst:")]
        void SetNeedsFitOnScreenFirst(bool needsFitOnScreenFirst);
    }

    // @interface SJVideoPlayerExtended (SJEdgeControlLayer)
    [Category]
    [BaseType(typeof(SJEdgeControlLayer))]
    interface SJEdgeControlLayer_SJVideoPlayerExtended
    {
        // @property (nonatomic) BOOL showsMoreItem;
        [Export("showsMoreItem")]
        bool GetShowsMoreItem();

        [Export("showsMoreItem")]
        void SetShowsMoreItem(bool showsMoreItem);

        // @property (getter = isEnabledClips, nonatomic) BOOL enabledClips;
        [Export("enabledClips")]
        bool GetEnabledClips();

        [Export("setenabledClips:")]
        void SetEnabledClips(bool enableClips);

        // @property (nonatomic, strong, null_resettable) SJVideoPlayerClipsConfig * _Null_unspecified clipsConfig;
        [Export("clipsConfig")]
        SJVideoPlayerClipsConfig? GetClipsConfig();

        [Export("setclipsConfig:")]
        void SetClipsConfig(SJVideoPlayerClipsConfig? clipsConfig);
    }

    // @interface SJExtendedControlLayerSwitcher (SJVideoPlayer)
    [Category]
    [BaseType(typeof(SJVideoPlayer))]
    interface SJVideoPlayer_SJExtendedControlLayerSwitcher
    {
        // -(void)switchControlLayerForIdentifier:(SJControlLayerIdentifier)identifier;
        [Export("switchControlLayerForIdentifier:")]
        void SwitchControlLayerForIdentifier(nint identifier);
    }

    // @interface SJDraggingObservation : NSObject <SJDraggingObservation>
    [BaseType(typeof(NSObject))]
    interface SJDraggingObservation : ISJDraggingObservation
    {
        // @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) willBeginDraggingExeBlock;
        [NullAllowed, Export("willBeginDraggingExeBlock", ArgumentSemantic.Copy)]
        Action<double> WillBeginDraggingExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) didMoveExeBlock;
        [NullAllowed, Export("didMoveExeBlock", ArgumentSemantic.Copy)]
        Action<double> DidMoveExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) willEndDraggingExeBlock;
        [NullAllowed, Export("willEndDraggingExeBlock", ArgumentSemantic.Copy)]
        Action<double> WillEndDraggingExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSTimeInterval) didEndDraggingExeBlock;
        [NullAllowed, Export("didEndDraggingExeBlock", ArgumentSemantic.Copy)]
        Action<double> DidEndDraggingExeBlock { get; set; }
    }

    // @interface SJDraggingProgressPopupView : UIView <SJDraggingProgressPopupView>
    [BaseType(typeof(UIView))]
    interface SJDraggingProgressPopupView : ISJDraggingProgressPopupView
    {
        // @property (readonly, getter = isPreviewImageHidden, nonatomic) BOOL previewImageHidden;
        [Export("previewImageHidden")]
        bool PreviewImageHidden { [Bind("isPreviewImageHidden")] get; }

        // @property (nonatomic, strong) UIImage * _Nullable previewImage;
        [NullAllowed, Export("previewImage", ArgumentSemantic.Strong)]
        UIImage PreviewImage { get; set; }

        // @property (nonatomic) SJDraggingProgressPopupViewStyle style;
        [Export("style", ArgumentSemantic.Assign)]
        SJDraggingProgressPopupViewStyle Style { get; set; }

        // @property (nonatomic) NSTimeInterval dragTime;
        [Export("dragTime")]
        double DragTime { get; set; }

        // @property (nonatomic) NSTimeInterval currentTime;
        [Export("currentTime")]
        double CurrentTime { get; set; }

        // @property (nonatomic) NSTimeInterval duration;
        [Export("duration")]
        double Duration { get; set; }
    }

    // @interface SJFullscreenModeStatusBar : UIView <SJFullscreenModeStatusBar>
    [BaseType(typeof(UIView))]
    interface SJFullscreenModeStatusBar : ISJFullscreenModeStatusBar
    {
        // @property (nonatomic) SJNetworkStatus networkStatus;
        [Export("networkStatus", ArgumentSemantic.Assign)]
        SJNetworkStatus NetworkStatus { get; set; }

        // @property (nonatomic, strong) NSDate * _Nullable date;
        [NullAllowed, Export("date", ArgumentSemantic.Strong)]
        NSDate Date { get; set; }

        // @property (nonatomic) UIDeviceBatteryState batteryState;
        [Export("batteryState", ArgumentSemantic.Assign)]
        UIDeviceBatteryState BatteryState { get; set; }

        // @property (nonatomic) float batteryLevel;
        [Export("batteryLevel")]
        float BatteryLevel { get; set; }
    }

    // @interface SJLoadingView : UIView <SJLoadingView>
    [BaseType(typeof(UIView))]
    interface SJLoadingView : ISJLoadingView
    {
        // @property (readonly, getter = isAnimating, nonatomic) BOOL animating;
        [Export("animating")]
        bool Animating { [Bind("isAnimating")] get; }

        // @property (nonatomic) BOOL showsNetworkSpeed;
        [Export("showsNetworkSpeed")]
        bool ShowsNetworkSpeed { get; set; }

        // @property (nonatomic, strong) NSAttributedString * _Nullable networkSpeedStr;
        [NullAllowed, Export("networkSpeedStr", ArgumentSemantic.Strong)]
        NSAttributedString NetworkSpeedStr { get; set; }

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)stop;
        [Export("stop")]
        void Stop();
    }

    // @interface SJScrollingTextMarqueeView : UIView <SJScrollingTextMarqueeView>
    [BaseType(typeof(UIView))]
    interface SJScrollingTextMarqueeView : ISJScrollingTextMarqueeView
    {
        // @property (copy, nonatomic) NSAttributedString * _Nullable attributedText;
        [NullAllowed, Export("attributedText", ArgumentSemantic.Copy)]
        NSAttributedString AttributedText { get; set; }

        // @property (nonatomic) CGFloat margin;
        [Export("margin")]
        nfloat Margin { get; set; }

        // @property (readonly, getter = isScrolling, nonatomic) BOOL scrolling;
        [Export("scrolling")]
        bool Scrolling { [Bind("isScrolling")] get; }

        // @property (getter = isScrollEnabled, nonatomic) BOOL scrollEnabled;
        [Export("scrollEnabled")]
        bool ScrollEnabled { [Bind("isScrollEnabled")] get; set; }

        // @property (getter = isCentered, nonatomic) BOOL centered;
        [Export("centered")]
        bool Centered { [Bind("isCentered")] get; set; }
    }

    // @interface SJSpeedupPlaybackPopupView : UIView <SJSpeedupPlaybackPopupView>
    [BaseType(typeof(UIView))]
    interface SJSpeedupPlaybackPopupView : ISJSpeedupPlaybackPopupView
    {
        // @property (nonatomic) CGFloat rate;
        [Export("rate")]
        nfloat Rate { get; set; }
    }

    // @interface SJAnimationAdded (UIView)
    [Category]
    [BaseType(typeof(UIView))]
    interface UIView_SJAnimationAdded
    {
        // @property (nonatomic) SJViewDisappearAnimation sjv_disappearDirection;
        [Export("sjv_disappearDirection")]
        SJViewDisappearAnimation GetSjv_disappearDirection();
        
        [Export("setsjv_disappearDirection:")]
        void SetSjv_disappearDirection(SJViewDisappearAnimation disappearAnimation);

        // @property (readonly, nonatomic) BOOL sjv_disappeared;
        [Export("sjv_disappeared")]
        bool Sjv_disappeared();

        // -(void)sjv_disapear;
        [Export("sjv_disapear")]
        void Sjv_disapear();

        // -(void)sjv_appear;
        [Export("sjv_appear")]
        void Sjv_appear();
    }

    // @interface SJInternal (SJEdgeControlButtonItem)
    [Category]
    [BaseType(typeof(SJEdgeControlButtonItem))]
    interface SJEdgeControlButtonItem_SJInternal
    {
        // @property (getter = isInnerHidden, nonatomic) BOOL innerHidden;
        [Export("innerHidden")]
        bool GetInnerHidden();
        
        [Export("setinnerHidden:")]
        void SetInnerHidden(bool innerHidden);
    }

    // @interface SJEdgeControlButtonItemView : UIControl
    [BaseType(typeof(UIControl))]
    interface SJEdgeControlButtonItemView
    {
        // @property (nonatomic, strong) SJEdgeControlButtonItem * _Nullable item;
        [NullAllowed, Export("item", ArgumentSemantic.Strong)]
        SJEdgeControlButtonItem Item { get; set; }

        // -(void)reloadItemIfNeeded;
        [Export("reloadItemIfNeeded")]
        void ReloadItemIfNeeded();
    }

    // @interface SJProgressSlider : UIView
    [BaseType(typeof(UIView))]
    interface SJProgressSlider
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        SJProgressSliderDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<SJProgressSliderDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (getter = isRound, nonatomic) BOOL round;
        [Export("round")]
        bool Round { [Bind("isRound")] get; set; }

        // @property (nonatomic) CGFloat trackHeight;
        [Export("trackHeight")]
        nfloat TrackHeight { get; set; }

        // @property (readonly, nonatomic, strong) UIImageView * _Nonnull trackImageView;
        [Export("trackImageView", ArgumentSemantic.Strong)]
        UIImageView TrackImageView();

        // @property (readonly, nonatomic, strong) UIImageView * _Nonnull traceImageView;
        [Export("traceImageView", ArgumentSemantic.Strong)]
        UIImageView TraceImageView();

        // @property (readonly, nonatomic, strong) UIImageView * _Nonnull thumbImageView;
        [Export("thumbImageView", ArgumentSemantic.Strong)]
        UIImageView ThumbImageView();

        // -(void)setThumbCornerRadius:(CGFloat)thumbCornerRadius size:(CGSize)size;
        [Export("setThumbCornerRadius:size:")]
        void SetThumbCornerRadius(nfloat thumbCornerRadius, CGSize size);

        // -(void)setThumbCornerRadius:(CGFloat)thumbCornerRadius size:(CGSize)size thumbBackgroundColor:(UIColor * _Nonnull)thumbBackgroundColor;
        [Export("setThumbCornerRadius:size:thumbBackgroundColor:")]
        void SetThumbCornerRadius(nfloat thumbCornerRadius, CGSize size, UIColor thumbBackgroundColor);

        // @property (nonatomic) CGFloat value;
        [Export("value")]
        nfloat Value { get; set; }

        // -(void)setValue:(CGFloat)value animated:(BOOL)animated;
        [Export("setValue:animated:")]
        void SetValue(nfloat value, bool animated);

        // @property (nonatomic) CGFloat animaMaxDuration;
        [Export("animaMaxDuration")]
        nfloat AnimaMaxDuration { get; set; }

        // @property (nonatomic) CGFloat minValue;
        [Export("minValue")]
        nfloat MinValue { get; set; }

        // @property (nonatomic) CGFloat maxValue;
        [Export("maxValue")]
        nfloat MaxValue { get; set; }

        // @property (nonatomic) CGFloat expand;
        [Export("expand")]
        nfloat Expand { get; set; }

        // @property (nonatomic) float thumbOutsideSpace;
        [Export("thumbOutsideSpace")]
        float ThumbOutsideSpace { get; set; }

        // @property (readonly, nonatomic, strong) UIPanGestureRecognizer * _Nonnull pan;
        [Export("pan", ArgumentSemantic.Strong)]
        UIPanGestureRecognizer Pan();

        // @property (readonly, nonatomic, strong) UITapGestureRecognizer * _Nonnull tap;
        [Export("tap", ArgumentSemantic.Strong)]
        UITapGestureRecognizer Tap();

        // @property (copy, nonatomic) void (^ _Nullable)(SJProgressSlider * _Nonnull, CGFloat) tappedExeBlock;
        [NullAllowed, Export("tappedExeBlock", ArgumentSemantic.Copy)]
        Action<SJProgressSlider, nfloat> TappedExeBlock { get; set; }

        // @property (readonly, assign, nonatomic) BOOL isDragging;
        [Export("isDragging")]
        bool IsDragging();

        // -(void)cancelDragging;
        [Export("cancelDragging")]
        void CancelDragging();

        // @property (nonatomic) BOOL isLoading;
        [Export("isLoading")]
        bool IsLoading { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull loadingColor;
        [Export("loadingColor", ArgumentSemantic.Strong)]
        UIColor LoadingColor { get; set; }
    }

    // @interface Prompt (SJProgressSlider)
    [Category]
    [BaseType(typeof(SJProgressSlider))]
    interface SJProgressSlider_Prompt
    {
        // @property (readonly, nonatomic, strong) UILabel * _Nonnull promptLabel;
        [Export("promptLabel", ArgumentSemantic.Strong)]
        UILabel PromptLabel();

        // @property (nonatomic) CGFloat promptSpacing;
        [Export("promptSpacing")]
        nfloat GetPromptSpacing();
        
        [Export("setpromptSpacing:")]
        void SetPromptSpacing(nfloat promptSpacing);
    }

    // @interface Border (SJProgressSlider)
    [Category]
    [BaseType(typeof(SJProgressSlider))]
    interface SJProgressSlider_Border
    {
        // @property (nonatomic) BOOL showsBorder;
        [Export("showsBorder")]
        bool GetShowsBorder();

        [Export("setshowsBorder:")]
        void SetShowsBorder(bool showsBorder);

        // @property (nonatomic, strong, null_resettable) UIColor * _Null_unspecified borderColor;
        [Export("borderColor")]
        UIColor? GetBorderColor();

        [Export("setborderColor:")]
        void SetBorderColor(UIColor? color);

        // @property (nonatomic) CGFloat borderWidth;
        [Export("borderWidth")]
        nfloat GetBorderWidth();

        [Export("setborderWidth:")]
        void SetBorderWidth(nfloat borderWidth);
    }

    // @interface Buffer (SJProgressSlider)
    [Category]
    [BaseType(typeof(SJProgressSlider))]
    interface SJProgressSlider_Buffer
    {
        // @property (nonatomic) BOOL showsBufferProgress;
        [Export("showsBufferProgress")]
        bool GetShowsBufferProgress();
        
        [Export("setshowsBufferProgress:")]
        void SetShowsBufferProgress(bool showsBufferProgress);

        // @property (nonatomic, strong, null_resettable) UIColor * _Null_unspecified bufferProgressColor;
        [Export("bufferProgressColor")]
        UIColor? GetBufferProgressColor();
        
        [Export("setbufferProgressColor:")]
        void SetBufferProgressColor(UIColor? color);

        // @property (nonatomic) CGFloat bufferProgress;
        [Export("bufferProgress")]
        nfloat GetBufferProgress();

        [Export("setbufferProgress:")]
        void SetBufferProgress(nfloat bufferProgress);
    }

    // @interface StopNode (SJProgressSlider)
    [Category]
    [BaseType(typeof(SJProgressSlider))]
    interface SJProgressSlider_StopNode
    {
        // @property (nonatomic) BOOL showsStopNode;
        [Export("showsStopNode")]
        bool GetShowsStopNode();

        [Export("setshowsStopNode:")]
        void SetShowsStopNode(bool showsStopNode);

        // @property (nonatomic, strong, null_resettable) UIView * _Null_unspecified stopNodeView;
        [Export("stopNodeView")]
        UIView? GetStopNodeView();
        
        [Export("setstopNodeView:")]
        void SetStopNodeView(UIView? stopNodeView);

        // @property (nonatomic) CGFloat stopNodeLocation;
        [Export("stopNodeLocation")]
        nfloat GetStopNodeLocation();
        
        [Export("setstopNodeLocation:")]
        void SetStopNodeLocation(nfloat stopNodeLocation);

        // -(void)setStopNodeViewCornerRadius:(CGFloat)cornerRadius size:(CGSize)size;
        [Export("setStopNodeViewCornerRadius:size:")]
        void SetStopNodeViewCornerRadius(nfloat cornerRadius, CGSize size);

        // -(void)setStopNodeViewCornerRadius:(CGFloat)cornerRadius size:(CGSize)size backgroundColor:(UIColor * _Nonnull)backgroundColor;
        [Export("setStopNodeViewCornerRadius:size:backgroundColor:")]
        void SetStopNodeViewCornerRadius(nfloat cornerRadius, CGSize size, UIColor backgroundColor);
    }

    // @protocol SJProgressSliderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface SJProgressSliderDelegate
    {
        // @optional -(void)sliderWillBeginDragging:(SJProgressSlider * _Nonnull)slider;
        [Export("sliderWillBeginDragging:")]
        void SliderWillBeginDragging(SJProgressSlider slider);

        // @optional -(void)slider:(SJProgressSlider * _Nonnull)slider valueDidChange:(CGFloat)value;
        [Export("slider:valueDidChange:")]
        void Slider(SJProgressSlider slider, nfloat value);

        // @optional -(void)sliderDidEndDragging:(SJProgressSlider * _Nonnull)slider;
        [Export("sliderDidEndDragging:")]
        void SliderDidEndDragging(SJProgressSlider slider);

        // @optional -(void)sliderDidDrag:(SJProgressSlider * _Nonnull)slider __attribute__((deprecated("use `slider:valueDidChange:`")));
        [Export("sliderDidDrag:")]
        void SliderDidDrag(SJProgressSlider slider);
    }

    // @interface SJCommonProgressSlider : UIView
    [BaseType(typeof(UIView))]
    interface SJCommonProgressSlider
    {
        // @property (assign, readwrite, nonatomic) float spacing;
        [Export("spacing")]
        float Spacing { get; set; }

        // @property (readonly, nonatomic, strong) UIView * leftContainerView;
        [Export("leftContainerView", ArgumentSemantic.Strong)]
        UIView LeftContainerView();

        // @property (readonly, nonatomic, strong) SJProgressSlider * slider;
        [Export("slider", ArgumentSemantic.Strong)]
        SJProgressSlider Slider();

        // @property (readonly, nonatomic, strong) UIView * rightContainerView;
        [Export("rightContainerView", ArgumentSemantic.Strong)]
        UIView RightContainerView();
    }

    // @interface SJButtonProgressSlider : SJCommonProgressSlider
    [BaseType(typeof(SJCommonProgressSlider))]
    interface SJButtonProgressSlider
    {
        // @property (readonly, nonatomic, strong) UIButton * _Nonnull leftBtn;
        [Export("leftBtn", ArgumentSemantic.Strong)]
        UIButton LeftBtn();

        // @property (readonly, nonatomic, strong) UIButton * _Nonnull rightBtn;
        [Export("rightBtn", ArgumentSemantic.Strong)]
        UIButton RightBtn();

        // @property (nonatomic, strong) NSString * _Nullable leftText;
        [NullAllowed, Export("leftText", ArgumentSemantic.Strong)]
        string LeftText { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable rightText;
        [NullAllowed, Export("rightText", ArgumentSemantic.Strong)]
        string RightText { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable titleColor;
        [NullAllowed, Export("titleColor", ArgumentSemantic.Strong)]
        UIColor TitleColor { get; set; }

        // @property (nonatomic, strong) UIFont * _Nullable font;
        [NullAllowed, Export("font", ArgumentSemantic.Strong)]
        UIFont Font { get; set; }
    }

    // @interface SJClipsGIFRecordsControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJClipsGIFRecordsControlLayer : SJControlLayer
    {
        // @property (readonly, nonatomic) SJClipsStatus status;
        [Export("status")]
        SJClipsStatus Status();

        // @property (copy, nonatomic) void (^ _Nullable)(SJClipsGIFRecordsControlLayer * _Nonnull) statusDidChangeExeBlock;
        [NullAllowed, Export("statusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJClipsGIFRecordsControlLayer> StatusDidChangeExeBlock { get; set; }

        // @property (readonly, nonatomic) CMTimeRange range;
        [Export("range")]
        CMTimeRange Range();
    }

    // @interface SJClipsResultsControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJClipsResultsControlLayer : SJControlLayer
    {
        // @property (nonatomic, strong) NSArray<SJClipsResultShareItem *> * _Nullable shareItems;
        [NullAllowed, Export("shareItems", ArgumentSemantic.Strong)]
        SJClipsResultShareItem[] ShareItems { get; set; }

        // @property (nonatomic, strong) id<SJVideoPlayerClipsParameters> _Nullable parameters;
        [NullAllowed, Export("parameters", ArgumentSemantic.Strong)]
        SJVideoPlayerClipsParameters Parameters { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJClipsResultsControlLayer * _Nonnull) cancelledOperationExeBlock;
        [NullAllowed, Export("cancelledOperationExeBlock", ArgumentSemantic.Copy)]
        Action<SJClipsResultsControlLayer> CancelledOperationExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull, SJClipsResultShareItem * _Nonnull, id<SJVideoPlayerClipsResult> _Nonnull) clickedResultShareItemExeBlock;
        [NullAllowed, Export("clickedResultShareItemExeBlock", ArgumentSemantic.Copy)]
        Action<SJBaseVideoPlayer, SJClipsResultShareItem, SJVideoPlayerClipsResult> ClickedResultShareItemExeBlock { get; set; }
    }

    // @interface SJClipsVideoRecordsControlLayer : SJEdgeControlLayerAdapters <SJControlLayer>
    [BaseType(typeof(SJEdgeControlLayerAdapters))]
    interface SJClipsVideoRecordsControlLayer : SJControlLayer
    {
        // @property (readonly, nonatomic) SJClipsStatus status;
        [Export("status")]
        SJClipsStatus Status();

        // @property (copy, nonatomic) void (^ _Nullable)(SJClipsVideoRecordsControlLayer * _Nonnull) statusDidChangeExeBlock;
        [NullAllowed, Export("statusDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJClipsVideoRecordsControlLayer> StatusDidChangeExeBlock { get; set; }

        // @property (readonly, nonatomic) CMTimeRange range;
        [Export("range")]
        CMTimeRange Range();
    }

    // @protocol SJClipsSaveResultFailed <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface SJClipsSaveResultFailed
    {
        // @required @property (readonly, nonatomic) SJClipsSaveResultToAlbumFailedReason reason;
        [Abstract]
        [Export("reason")]
        SJClipsSaveResultToAlbumFailedReason Reason();

        // @required -(NSString * _Nonnull)toString;
        [Abstract]
        [Export("toString")]
        //[Verify(MethodToProperty)]
        string ToString();
    }

    // @protocol SJClipsSaveResultToAlbumHandler <NSObject>
    /*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
#1#
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ISJClipsSaveResultToAlbumHandler
    {
        // @required -(void)saveResult:(id<SJVideoPlayerClipsResult> _Nonnull)result completionHandler:(void (^ _Nonnull)(BOOL, id<SJClipsSaveResultFailed> _Nonnull))completionHandler;
        [Abstract]
        [Export("saveResult:completionHandler:")]
        void CompletionHandler(SJVideoPlayerClipsResult result, Action<bool, SJClipsSaveResultFailed> completionHandler);
    }

    // @interface SJClipsSaveResultToAlbumHandler : NSObject <SJClipsSaveResultToAlbumHandler>
    [BaseType(typeof(NSObject))]
    interface SJClipsSaveResultToAlbumHandler : ISJClipsSaveResultToAlbumHandler
    {
    }

    // @interface SJVideoPlayerClipsGeneratedResult : NSObject <SJVideoPlayerClipsResult>
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerClipsGeneratedResult : SJVideoPlayerClipsResult
    {
        // @property (nonatomic) SJVideoPlayerClipsOperation operation;
        //[Export("operation", ArgumentSemantic.Assign)]
        //SJVideoPlayerClipsOperation Operation { get; set; }

        // @property (nonatomic) SJClipsExportState exportState;
        //[Export("exportState", ArgumentSemantic.Assign)]
        //SJClipsExportState ExportState { get; set; }

        // @property (nonatomic) float exportProgress;
        [Export("exportProgress")]
        float ExportProgress { get; set; }

        // @property (nonatomic) SJClipsResultUploadState uploadState;
        //[Export("uploadState", ArgumentSemantic.Assign)]
        //SJClipsResultUploadState UploadState { get; set; }

        // @property (nonatomic) float uploadProgress;
        [Export("uploadProgress")]
        float UploadProgress { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable thumbnailImage;
        //[NullAllowed, Export("thumbnailImage", ArgumentSemantic.Strong)]
        //UIImage ThumbnailImage { get; set; }

        // @property (nonatomic, strong) UIImage * _Nullable image;
        //[NullAllowed, Export("image", ArgumentSemantic.Strong)]
        //UIImage Image { get; set; }

        // @property (nonatomic, strong) NSURL * _Nullable fileURL;
        //[NullAllowed, Export("fileURL", ArgumentSemantic.Strong)]
        //NSUrl FileURL { get; set; }

        // @property (nonatomic, strong) SJVideoPlayerURLAsset * _Nullable currentPlayAsset;
        //[NullAllowed, Export("currentPlayAsset", ArgumentSemantic.Strong)]
        //SJVideoPlayerURLAsset CurrentPlayAsset { get; set; }

        // -(NSData * _Nullable)data;
        [NullAllowed, Export("data")]
        //[Verify(MethodToProperty)]
        NSData Data();

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerClipsGeneratedResult * _Nonnull) exportProgressDidChangeExeBlock;
        [NullAllowed, Export("exportProgressDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerClipsGeneratedResult> ExportProgressDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerClipsGeneratedResult * _Nonnull) uploadProgressDidChangeExeBlock;
        [NullAllowed, Export("uploadProgressDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerClipsGeneratedResult> UploadProgressDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerClipsGeneratedResult * _Nonnull) exportStateDidChangeExeBlock;
        [NullAllowed, Export("exportStateDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerClipsGeneratedResult> ExportStateDidChangeExeBlock { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJVideoPlayerClipsGeneratedResult * _Nonnull) uploadStateDidChangeExeBlock;
        [NullAllowed, Export("uploadStateDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJVideoPlayerClipsGeneratedResult> UploadStateDidChangeExeBlock { get; set; }
    }

    // @interface SJVideoPlayerClipsParameters : NSObject <SJVideoPlayerClipsParameters>
    [BaseType(typeof(NSObject))]
    interface SJVideoPlayerClipsParameters : ISJVideoPlayerClipsParameters
    {
        // -(instancetype _Nonnull)initWithOperation:(SJVideoPlayerClipsOperation)operation range:(CMTimeRange)range;
        [Export("initWithOperation:range:")]
        NativeHandle Constructor(SJVideoPlayerClipsOperation operation, CMTimeRange range);
    }

    // @interface SJClipsBackButton : UIButton
    [BaseType(typeof(UIButton))]
    interface SJClipsBackButton
    {
    }

    // @interface SJClipsButtonContainerView : UIView
    [BaseType(typeof(UIView))]
    interface SJClipsButtonContainerView
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame buttonSize:(CGSize)size;
        [Export("initWithFrame:buttonSize:")]
        NativeHandle Constructor(CGRect frame, CGSize size);

        // @property (readonly, nonatomic, strong) SJClipsBackButton * _Nonnull button;
        [Export("button", ArgumentSemantic.Strong)]
        SJClipsBackButton Button();

        // @property (copy, nonatomic) void (^ _Nullable)(SJClipsButtonContainerView * _Nonnull) clickedBackButtonExeBlock;
        [NullAllowed, Export("clickedBackButtonExeBlock", ArgumentSemantic.Copy)]
        Action<SJClipsButtonContainerView> ClickedBackButtonExeBlock { get; set; }
    }

    // @interface SJClipsCommonViewLayer : CALayer
    [BaseType(typeof(CALayer))]
    interface SJClipsCommonViewLayer
    {
    }

    // @interface SJClipsGIFCountDownView : UIView
    [BaseType(typeof(UIView))]
    interface SJClipsGIFCountDownView
    {
        // @property (readonly, nonatomic, strong) UILabel * _Nonnull timeLabel;
        [Export("timeLabel", ArgumentSemantic.Strong)]
        UILabel TimeLabel();

        // @property (readonly, nonatomic, strong) UILabel * _Nonnull promptLabel;
        [Export("promptLabel", ArgumentSemantic.Strong)]
        UILabel PromptLabel();
    }

    // @interface SJClipsResultShareItemsContainerView : UIView
    [BaseType(typeof(UIView))]
    interface SJClipsResultShareItemsContainerView
    {
        // @property (nonatomic, strong) NSArray<SJClipsResultShareItem *> * _Nullable shareItems;
        [NullAllowed, Export("shareItems", ArgumentSemantic.Strong)]
        SJClipsResultShareItem[] ShareItems { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJClipsResultShareItemsContainerView * _Nonnull, SJClipsResultShareItem * _Nonnull) clickedShareItemExeBlock;
        [NullAllowed, Export("clickedShareItemExeBlock", ArgumentSemantic.Copy)]
        Action<SJClipsResultShareItemsContainerView, SJClipsResultShareItem> ClickedShareItemExeBlock { get; set; }
    }

    // @interface SJClipsVideoCountDownView : UIView
    [BaseType(typeof(UIView))]
    interface SJClipsVideoCountDownView
    {
        // @property (readonly, nonatomic, strong) UILabel * _Nonnull timeLabel;
        [Export("timeLabel", ArgumentSemantic.Strong)]
        UILabel TimeLabel();

        // @property (readonly, nonatomic, strong) UILabel * _Nonnull promptLabel;
        [Export("promptLabel", ArgumentSemantic.Strong)]
        UILabel PromptLabel();

        // @property (readonly, nonatomic, strong) SJProgressSlider * _Nonnull progressSlider;
        [Export("progressSlider", ArgumentSemantic.Strong)]
        SJProgressSlider ProgressSlider();
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double SJVideoPlayerVersionNumber;
        [Field("SJVideoPlayerVersionNumber", "__Internal")]
        double SJVideoPlayerVersionNumber { get; }

        // extern const unsigned char[] SJVideoPlayerVersionString;
        [Field("SJVideoPlayerVersionString", "__Internal")]
        NSString SJVideoPlayerVersionString { get; }
    }
    */
}
