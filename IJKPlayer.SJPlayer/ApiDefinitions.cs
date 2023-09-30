using System;
using Foundation;
using MediaPlayer;
using ObjCRuntime;
using UIKit;
using AVFoundation;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using CoreMedia;
using System.Runtime.InteropServices;

namespace IJKPlayer.SJPlayer;

#region IJKMediaApis

    // @protocol IJKMediaPlayback <NSObject>
    partial interface IIJKMediaPlayback { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKMediaPlayback
    {
        // @required -(void)prepareToPlay;
        [Abstract]
        [Export("prepareToPlay")]
        void PrepareToPlay();

        // @required -(void)play;
        [Abstract]
        [Export("play")]
        void Play();

        // @required -(void)pause;
        [Abstract]
        [Export("pause")]
        void Pause();

        // @required -(void)stop;
        [Abstract]
        [Export("stop")]
        void Stop();

        // @required -(BOOL)isPlaying;
        [Abstract]
        [Export("isPlaying")]
        bool IsPlaying();

        // @required -(void)shutdown;
        [Abstract]
        [Export("shutdown")]
        void Shutdown();

        // @required -(void)setPauseInBackground:(BOOL)pause;
        [Abstract]
        [Export("setPauseInBackground:")]
        void SetPauseInBackground(bool pause);

        // @required @property (readonly, nonatomic) UIView * view;
        [Abstract]
        [Export("view")]
        UIView View();

        // @required @property (nonatomic) NSTimeInterval currentPlaybackTime;
        [Abstract]
        [Export("currentPlaybackTime")]
        double CurrentPlaybackTime { get; set; }

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Abstract]
        [Export("duration")]
        double Duration();

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Abstract]
        [Export("playableDuration")]
        double PlayableDuration();

        // @required @property (readonly, nonatomic) NSInteger bufferingProgress;
        [Abstract]
        [Export("bufferingProgress")]
        nint BufferingProgress();

        // @required @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Abstract]
        [Export("isPreparedToPlay")]
        bool IsPreparedToPlay();

        // @required @property (readonly, nonatomic) IJKMPMoviePlaybackState playbackState;
        [Abstract]
        [Export("playbackState")]
        IJKMPMoviePlaybackState PlaybackState();

        // @required @property (readonly, nonatomic) IJKMPMovieLoadState loadState;
        [Abstract]
        [Export("loadState")]
        IJKMPMovieLoadState LoadState();

        // @required @property (readonly, nonatomic) int isSeekBuffering;
        [Abstract]
        [Export("isSeekBuffering")]
        int IsSeekBuffering();

        // @required @property (readonly, nonatomic) int isAudioSync;
        [Abstract]
        [Export("isAudioSync")]
        int IsAudioSync();

        // @required @property (readonly, nonatomic) int isVideoSync;
        [Abstract]
        [Export("isVideoSync")]
        int IsVideoSync();

        // @required @property (readonly, nonatomic) int64_t numberOfBytesTransferred;
        [Abstract]
        [Export("numberOfBytesTransferred")]
        long NumberOfBytesTransferred();

        // @required @property (readonly, nonatomic) CGSize naturalSize;
        [Abstract]
        [Export("naturalSize")]
        CGSize NaturalSize();

        // @required @property (nonatomic) IJKMPMovieScalingMode scalingMode;
        [Abstract]
        [Export("scalingMode", ArgumentSemantic.Assign)]
        IJKMPMovieScalingMode ScalingMode { get; set; }

        // @required @property (nonatomic) BOOL shouldAutoplay;
        [Abstract]
        [Export("shouldAutoplay")]
        bool ShouldAutoplay { get; set; }

        // @required @property (nonatomic) BOOL allowsMediaAirPlay;
        [Abstract]
        [Export("allowsMediaAirPlay")]
        bool AllowsMediaAirPlay { get; set; }

        // @required @property (nonatomic) BOOL isDanmakuMediaAirPlay;
        [Abstract]
        [Export("isDanmakuMediaAirPlay")]
        bool IsDanmakuMediaAirPlay { get; set; }

        // @required @property (readonly, nonatomic) BOOL airPlayMediaActive;
        [Abstract]
        [Export("airPlayMediaActive")]
        bool AirPlayMediaActive();

        // @required @property (nonatomic) float playbackRate;
        [Abstract]
        [Export("playbackRate")]
        float PlaybackRate { get; set; }

        // @required @property (nonatomic) float playbackVolume;
        [Abstract]
        [Export("playbackVolume")]
        float PlaybackVolume { get; set; }

        // @required -(UIImage *)thumbnailImageAtCurrentTime;
        [Abstract]
        [Export("thumbnailImageAtCurrentTime")]
        UIImage ThumbnailImageAtCurrentTime();
    }

    [Static]
    partial interface IJKMPMoviePlayer
    {
        // extern NSString *const IJKMPMediaPlaybackIsPreparedToPlayDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMediaPlaybackIsPreparedToPlayDidChangeNotification", "__Internal")]
        NSString PlaybackIsPreparedToPlayDidChangeNotification { get; }

        //todo 
        // extern NSString *const IJKMPMoviePlayerScalingModeDidChangeNotification __attribute__((visibility("default")));
        //[Field("IJKMPMoviePlayerScalingModeDidChangeNotification", "__Internal")]
        //NSString ScalingModeDidChangeNotification { get; }

        // extern NSString *const IJKMPMoviePlayerPlaybackDidFinishNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerPlaybackDidFinishNotification", "__Internal")]
        NSString PlaybackDidFinishNotification { get; }

        // extern NSString *const IJKMPMoviePlayerPlaybackDidFinishReasonUserInfoKey __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerPlaybackDidFinishReasonUserInfoKey", "__Internal")]
        NSString PlaybackDidFinishReasonUserInfoKey { get; }

        // extern NSString *const IJKMPMoviePlayerPlaybackStateDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerPlaybackStateDidChangeNotification", "__Internal")]
        NSString PlaybackStateDidChangeNotification { get; }

        // extern NSString *const IJKMPMoviePlayerLoadStateDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerLoadStateDidChangeNotification", "__Internal")]
        NSString LoadStateDidChangeNotification { get; }

        // extern NSString *const IJKMPMoviePlayerIsAirPlayVideoActiveDidChangeNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerIsAirPlayVideoActiveDidChangeNotification", "__Internal")]
        NSString IsAirPlayVideoActiveDidChangeNotification { get; }

        // extern NSString *const IJKMPMovieNaturalSizeAvailableNotification __attribute__((visibility("default")));
        [Field("IJKMPMovieNaturalSizeAvailableNotification", "__Internal")]
        NSString NaturalSizeAvailableNotification { get; }

        // extern NSString *const IJKMPMoviePlayerVideoDecoderOpenNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerVideoDecoderOpenNotification", "__Internal")]
        NSString VideoDecoderOpenNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstVideoFrameRenderedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstVideoFrameRenderedNotification", "__Internal")]
        NSString FirstVideoFrameRenderedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstAudioFrameRenderedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstAudioFrameRenderedNotification", "__Internal")]
        NSString FirstAudioFrameRenderedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstAudioFrameDecodedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstAudioFrameDecodedNotification", "__Internal")]
        NSString FirstAudioFrameDecodedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFirstVideoFrameDecodedNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFirstVideoFrameDecodedNotification", "__Internal")]
        NSString FirstVideoFrameDecodedNotification { get; }

        // extern NSString *const IJKMPMoviePlayerOpenInputNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerOpenInputNotification", "__Internal")]
        NSString OpenInputNotification { get; }

        // extern NSString *const IJKMPMoviePlayerFindStreamInfoNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerFindStreamInfoNotification", "__Internal")]
        NSString FindStreamInfoNotification { get; }

        // extern NSString *const IJKMPMoviePlayerComponentOpenNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerComponentOpenNotification", "__Internal")]
        NSString ComponentOpenNotification { get; }

        // extern NSString *const IJKMPMoviePlayerDidSeekCompleteNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidSeekCompleteNotification", "__Internal")]
        NSString DidSeekCompleteNotification { get; }

        // extern NSString *const IJKMPMoviePlayerDidSeekCompleteTargetKey __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidSeekCompleteTargetKey", "__Internal")]
        NSString DidSeekCompleteTargetKey { get; }

        // extern NSString *const IJKMPMoviePlayerDidSeekCompleteErrorKey __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidSeekCompleteErrorKey", "__Internal")]
        NSString DidSeekCompleteErrorKey { get; }

        // extern NSString *const IJKMPMoviePlayerDidAccurateSeekCompleteCurPos __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerDidAccurateSeekCompleteCurPos", "__Internal")]
        NSString DidAccurateSeekCompleteCurPos { get; }

        // extern NSString *const IJKMPMoviePlayerAccurateSeekCompleteNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerAccurateSeekCompleteNotification", "__Internal")]
        NSString AccurateSeekCompleteNotification { get; }

        // extern NSString *const IJKMPMoviePlayerSeekAudioStartNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerSeekAudioStartNotification", "__Internal")]
        NSString SeekAudioStartNotification { get; }

        // extern NSString *const IJKMPMoviePlayerSeekVideoStartNotification __attribute__((visibility("default")));
        [Field("IJKMPMoviePlayerSeekVideoStartNotification", "__Internal")]
        NSString SeekVideoStartNotification { get; }
    }

    // @interface IJKMediaUrlOpenData : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKMediaUrlOpenData
    {
        // -(id)initWithUrl:(NSString *)url event:(IJKMediaEvent)event segmentIndex:(int)segmentIndex retryCounter:(int)retryCounter;
        [Export("initWithUrl:event:segmentIndex:retryCounter:")]
        IntPtr Constructor(string url, IJKMediaEvent @event, int segmentIndex, int retryCounter);

        // @property (readonly, nonatomic) IJKMediaEvent event;
        [Export("event")]
        IJKMediaEvent Event();

        // @property (readonly, nonatomic) int segmentIndex;
        [Export("segmentIndex")]
        int SegmentIndex();

        // @property (readonly, nonatomic) int retryCounter;
        [Export("retryCounter")]
        int RetryCounter();

        // @property (retain, nonatomic) NSString * url;
        [Export("url", ArgumentSemantic.Retain)]
        string Url { get; set; }

        // @property (assign, nonatomic) int fd;
        [Export("fd")]
        int Fd { get; set; }

        // @property (nonatomic, strong) NSString * msg;
        [Export("msg", ArgumentSemantic.Strong)]
        string Msg { get; set; }

        // @property (nonatomic) int error;
        [Export("error")]
        int Error { get; set; }

        // @property (getter = isHandled, nonatomic) BOOL handled;
        [Export("handled")]
        bool Handled { [Bind("isHandled")] get; set; }

        // @property (getter = isUrlChanged, nonatomic) BOOL urlChanged;
        [Export("urlChanged")]
        bool UrlChanged { [Bind("isUrlChanged")] get; set; }
    }

    // @protocol IJKMediaUrlOpenDelegate <NSObject>
    partial interface IIJKMediaUrlOpenDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKMediaUrlOpenDelegate
    {
        // @required -(void)willOpenUrl:(IJKMediaUrlOpenData *)urlOpenData;
        [Abstract]
        [Export("willOpenUrl:")]
        void WillOpenUrl(IJKMediaUrlOpenData urlOpenData);
    }

    // @protocol IJKMediaNativeInvokeDelegate <NSObject>
    partial interface IIJKMediaNativeInvokeDelegate { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKMediaNativeInvokeDelegate
    {
        // @required -(int)invoke:(IJKMediaEvent)event attributes:(NSDictionary *)attributes;
        [Abstract]
        [Export("invoke:attributes:")]
        int Attributes(IJKMediaEvent @event, NSDictionary attributes);
    }

    // @interface IJKMPMoviePlayerController : MPMoviePlayerController <IJKMediaPlayback>
    [BaseType(typeof(MPMoviePlayerController))]
    interface IJKMPMoviePlayerController : IIJKMediaPlayback
    {
        // -(id)initWithContentURL:(NSURL *)aUrl;
        [Export("initWithContentURL:")]
        IntPtr Constructor(NSUrl aUrl);

        // -(id)initWithContentURLString:(NSString *)aUrl;
        [Export("initWithContentURLString:")]
        IntPtr Constructor(string aUrl);
    }

    // @interface IJKFFOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKFFOptions
    {
        // +(IJKFFOptions *)optionsByDefault;
        [Static]
        [Export("optionsByDefault")]
        IJKFFOptions OptionsByDefault();

        // -(void)applyTo:(struct IjkMediaPlayer *)mediaPlayer;
        //todo
        [Export("applyTo:")]
        unsafe void ApplyTo(NSObject mediaPlayer);

        // -(void)setOptionValue:(NSString *)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionValue:forKey:ofCategory:")]
        void SetOptionValue(string value, string key, IJKFFOptionCategory category);

        // -(void)setOptionIntValue:(int64_t)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionIntValue:forKey:ofCategory:")]
        void SetOptionIntValue(long value, string key, IJKFFOptionCategory category);

        // -(void)setFormatOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setFormatOptionValue:forKey:")]
        void SetFormatOptionValue(string value, string key);

        // -(void)setCodecOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setCodecOptionValue:forKey:")]
        void SetCodecOptionValue(string value, string key);

        // -(void)setSwsOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setSwsOptionValue:forKey:")]
        void SetSwsOptionValue(string value, string key);

        // -(void)setPlayerOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setPlayerOptionValue:forKey:")]
        void SetPlayerOptionValue(string value, string key);

        // -(void)setFormatOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setFormatOptionIntValue:forKey:")]
        void SetFormatOptionIntValue(long value, string key);

        // -(void)setCodecOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setCodecOptionIntValue:forKey:")]
        void SetCodecOptionIntValue(long value, string key);

        // -(void)setSwsOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setSwsOptionIntValue:forKey:")]
        void SetSwsOptionIntValue(long value, string key);

        // -(void)setPlayerOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setPlayerOptionIntValue:forKey:")]
        void SetPlayerOptionIntValue(long value, string key);

        // @property (nonatomic) BOOL showHudView;
        [Export("showHudView")]
        bool ShowHudView { get; set; }
    }

    // @interface IJKFFMonitor : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKFFMonitor
    {
        // @property (nonatomic) NSDictionary * mediaMeta;
        [Export("mediaMeta", ArgumentSemantic.Assign)]
        NSDictionary MediaMeta { get; set; }

        // @property (nonatomic) NSDictionary * videoMeta;
        [Export("videoMeta", ArgumentSemantic.Assign)]
        NSDictionary VideoMeta { get; set; }

        // @property (nonatomic) NSDictionary * audioMeta;
        [Export("audioMeta", ArgumentSemantic.Assign)]
        NSDictionary AudioMeta { get; set; }

        // @property (readonly, nonatomic) int64_t duration;
        [Export("duration")]
        long Duration();

        // @property (readonly, nonatomic) int64_t bitrate;
        [Export("bitrate")]
        long Bitrate();

        // @property (readonly, nonatomic) float fps;
        [Export("fps")]
        float Fps();

        // @property (readonly, nonatomic) int width;
        [Export("width")]
        int Width();

        // @property (readonly, nonatomic) int height;
        [Export("height")]
        int Height();

        // @property (readonly, nonatomic) NSString * vcodec;
        [Export("vcodec")]
        string Vcodec();

        // @property (readonly, nonatomic) NSString * acodec;
        [Export("acodec")]
        string Acodec();

        // @property (readonly, nonatomic) int sampleRate;
        [Export("sampleRate")]
        int SampleRate();

        // @property (readonly, nonatomic) int64_t channelLayout;
        [Export("channelLayout")]
        long ChannelLayout();

        // @property (nonatomic) NSString * vdecoder;
        [Export("vdecoder")]
        string Vdecoder { get; set; }

        // @property (nonatomic) int tcpError;
        [Export("tcpError")]
        int TcpError { get; set; }

        // @property (nonatomic) NSString * remoteIp;
        [Export("remoteIp")]
        string RemoteIp { get; set; }

        // @property (nonatomic) int httpError;
        [Export("httpError")]
        int HttpError { get; set; }

        // @property (nonatomic) NSString * httpUrl;
        [Export("httpUrl")]
        string HttpUrl { get; set; }

        // @property (nonatomic) NSString * httpHost;
        [Export("httpHost")]
        string HttpHost { get; set; }

        // @property (nonatomic) int httpCode;
        [Export("httpCode")]
        int HttpCode { get; set; }

        // @property (nonatomic) int64_t httpOpenTick;
        [Export("httpOpenTick")]
        long HttpOpenTick { get; set; }

        // @property (nonatomic) int64_t httpSeekTick;
        [Export("httpSeekTick")]
        long HttpSeekTick { get; set; }

        // @property (nonatomic) int httpOpenCount;
        [Export("httpOpenCount")]
        int HttpOpenCount { get; set; }

        // @property (nonatomic) int httpSeekCount;
        [Export("httpSeekCount")]
        int HttpSeekCount { get; set; }

        // @property (nonatomic) int64_t lastHttpOpenDuration;
        [Export("lastHttpOpenDuration")]
        long LastHttpOpenDuration { get; set; }

        // @property (nonatomic) int64_t lastHttpSeekDuration;
        [Export("lastHttpSeekDuration")]
        long LastHttpSeekDuration { get; set; }

        // @property (nonatomic) int64_t filesize;
        [Export("filesize")]
        long Filesize { get; set; }

        // @property (nonatomic) int64_t prepareStartTick;
        [Export("prepareStartTick")]
        long PrepareStartTick { get; set; }

        // @property (nonatomic) int64_t prepareDuration;
        [Export("prepareDuration")]
        long PrepareDuration { get; set; }

        // @property (nonatomic) int64_t firstVideoFrameLatency;
        [Export("firstVideoFrameLatency")]
        long FirstVideoFrameLatency { get; set; }

        // @property (nonatomic) int64_t lastPrerollStartTick;
        [Export("lastPrerollStartTick")]
        long LastPrerollStartTick { get; set; }

        // @property (nonatomic) int64_t lastPrerollDuration;
        [Export("lastPrerollDuration")]
        long LastPrerollDuration { get; set; }
    }

    // @protocol IJKSDLGLViewProtocol <NSObject>
    partial interface IIJKSDLGLViewProtocol { }

    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IJKSDLGLViewProtocol
    {
        // @required -(UIImage *)snapshot;
        [Abstract]
        [Export("snapshot")]
        UIImage Snapshot();

        // @required @property (readonly, nonatomic) CGFloat fps;
        [Abstract]
        [Export("fps")]
        nfloat Fps();

        // @required @property (nonatomic) CGFloat scaleFactor;
        [Abstract]
        [Export("scaleFactor")]
        nfloat ScaleFactor { get; set; }

        // @required @property (nonatomic) BOOL isThirdGLView;
        [Abstract]
        [Export("isThirdGLView")]
        bool IsThirdGLView { get; set; }

        // @required -(void)display_pixels:(IJKOverlay *)overlay;
        [Abstract]
        [Export("display_pixels:")]
        unsafe void Display_pixels(IJKOverlay overlay);
    }

    // @interface IJKFFMoviePlayerController : NSObject <IJKMediaPlayback>
    [BaseType(typeof(NSObject))]
    interface IJKFFMoviePlayerController : IJKMediaPlayback
    {
        // -(id)initWithContentURL:(NSURL *)aUrl withOptions:(IJKFFOptions *)options;
        [Export("initWithContentURL:withOptions:")]
        IntPtr Constructor(NSUrl aUrl, IJKFFOptions options);

        // -(id)initWithContentURLString:(NSString *)aUrlString withOptions:(IJKFFOptions *)options;
        [Export("initWithContentURLString:withOptions:")]
        IntPtr Constructor(string aUrlString, IJKFFOptions options);

        // -(id)initWithMoreContent:(NSURL *)aUrl withOptions:(IJKFFOptions *)options withGLView:(UIView<IJKSDLGLViewProtocol> *)glView;
        [Export("initWithMoreContent:withOptions:withGLView:")]
        IntPtr Constructor(NSUrl aUrl, IJKFFOptions options, IJKSDLGLViewProtocol glView);

        // -(id)initWithMoreContentString:(NSString *)aUrlString withOptions:(IJKFFOptions *)options withGLView:(UIView<IJKSDLGLViewProtocol> *)glView;
        [Export("initWithMoreContentString:withOptions:withGLView:")]
        IntPtr Constructor(string aUrlString, IJKFFOptions options, IJKSDLGLViewProtocol glView);

        // -(void)prepareToPlay;
        [Export("prepareToPlay")]
        new void PrepareToPlay();

        // -(void)play;
        [Export("play")]
        new void Play();

        // -(void)pause;
        [Export("pause")]
        new void Pause();

        // -(void)stop;
        [Export("stop")]
        new void Stop();

        // -(BOOL)isPlaying;
        [Export("isPlaying")]
        new bool IsPlaying();

        // -(void)shutdown;
        [Export("shutdown")]
        new void Shutdown();

        // -(void)setPauseInBackground:(BOOL)pause;
        [Export("setPauseInBackground:")]
        new void SetPauseInBackground(bool pause);

        // @property (readonly, nonatomic) UIView * view;
        [Export("view")]
        new UIView View();

        // @required @property (nonatomic) NSTimeInterval currentPlaybackTime;
        [Export("currentPlaybackTime")]
        new double CurrentPlaybackTime { get; set; }

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        new double Duration();

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Export("playableDuration")]
        new double PlayableDuration();

        // @required @property (readonly, nonatomic) NSInteger bufferingProgress;
        [Export("bufferingProgress")]
        new nint BufferingProgress();

        // @required @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Export("isPreparedToPlay")]
        new bool IsPreparedToPlay();

        // @required @property (readonly, nonatomic) IJKMPMoviePlaybackState playbackState;
        [Export("playbackState")]
        new IJKMPMoviePlaybackState PlaybackState();

        // @required @property (readonly, nonatomic) IJKMPMovieLoadState loadState;
        [Export("loadState")]
        new IJKMPMovieLoadState LoadState();

        // @required @property (readonly, nonatomic) int isSeekBuffering;
        [Export("isSeekBuffering")]
        new int IsSeekBuffering();

        // @required @property (readonly, nonatomic) int isAudioSync;
        [Export("isAudioSync")]
        new int IsAudioSync();

        // @required @property (readonly, nonatomic) int isVideoSync;
        [Export("isVideoSync")]
        new int IsVideoSync();

        // @required @property (readonly, nonatomic) int64_t numberOfBytesTransferred;
        [Export("numberOfBytesTransferred")]
        new long NumberOfBytesTransferred();

        // @required @property (readonly, nonatomic) CGSize naturalSize;
        [Export("naturalSize")]
        new CGSize NaturalSize();

        // @required @property (nonatomic) IJKMPMovieScalingMode scalingMode;
        [Export("scalingMode", ArgumentSemantic.Assign)]
        new IJKMPMovieScalingMode ScalingMode { get; set; }

        // @required @property (nonatomic) BOOL shouldAutoplay;
        [Export("shouldAutoplay")]
        new bool ShouldAutoplay { get; set; }

        // @required @property (nonatomic) BOOL allowsMediaAirPlay;
        [Export("allowsMediaAirPlay")]
        new bool AllowsMediaAirPlay { get; set; }

        // @required @property (nonatomic) BOOL isDanmakuMediaAirPlay;
        [Export("isDanmakuMediaAirPlay")]
        new bool IsDanmakuMediaAirPlay { get; set; }

        // @required @property (readonly, nonatomic) BOOL airPlayMediaActive;
        [Export("airPlayMediaActive")]
        new bool AirPlayMediaActive();

        // @required @property (nonatomic) float playbackRate;
        [Export("playbackRate")]
        new float PlaybackRate { get; set; }

        // @required @property (nonatomic) float playbackVolume;
        [Export("playbackVolume")]
        new float PlaybackVolume { get; set; }

        // @required -(UIImage *)thumbnailImageAtCurrentTime;
        [Export("thumbnailImageAtCurrentTime")]
        new UIImage ThumbnailImageAtCurrentTime();

        // -(int64_t)trafficStatistic;
        [Export("trafficStatistic")]
        long TrafficStatistic();

        // -(float)dropFrameRate;
        [Export("dropFrameRate")]
        float DropFrameRate();

        // -(BOOL)isVideoToolboxOpen;
        [Export("isVideoToolboxOpen")]
        bool IsVideoToolboxOpen();

        // -(void)setHudValue:(NSString *)value forKey:(NSString *)key;
        [Export("setHudValue:forKey:")]
        void SetHudValue(string value, string key);

        // +(void)setLogReport:(BOOL)preferLogReport;
        [Static]
        [Export("setLogReport:")]
        void SetLogReport(bool preferLogReport);

        // +(void)setLogLevel:(IJKLogLevel)logLevel;
        [Static]
        [Export("setLogLevel:")]
        void SetLogLevel(IJKLogLevel logLevel);

        // +(BOOL)checkIfFFmpegVersionMatch:(BOOL)showAlert;
        [Static]
        [Export("checkIfFFmpegVersionMatch:")]
        bool CheckIfFFmpegVersionMatch(bool showAlert);

        // +(BOOL)checkIfPlayerVersionMatch:(BOOL)showAlert version:(NSString *)version;
        [Static]
        [Export("checkIfPlayerVersionMatch:version:")]
        bool CheckIfPlayerVersionMatch(bool showAlert, string version);

        // @property (readonly, nonatomic) CGFloat fpsInMeta;
        [Export("fpsInMeta")]
        nfloat FpsInMeta();

        // @property (readonly, nonatomic) CGFloat fpsAtOutput;
        [Export("fpsAtOutput")]
        nfloat FpsAtOutput();

        // @property (nonatomic) BOOL shouldShowHudView;
        [Export("shouldShowHudView")]
        bool ShouldShowHudView { get; set; }

        // -(void)setOptionValue:(NSString *)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionValue:forKey:ofCategory:")]
        void SetOptionValue(string value, string key, IJKFFOptionCategory category);

        // -(void)setOptionIntValue:(int64_t)value forKey:(NSString *)key ofCategory:(IJKFFOptionCategory)category;
        [Export("setOptionIntValue:forKey:ofCategory:")]
        void SetOptionIntValue(long value, string key, IJKFFOptionCategory category);

        // -(void)setFormatOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setFormatOptionValue:forKey:")]
        void SetFormatOptionValue(string value, string key);

        // -(void)setCodecOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setCodecOptionValue:forKey:")]
        void SetCodecOptionValue(string value, string key);

        // -(void)setSwsOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setSwsOptionValue:forKey:")]
        void SetSwsOptionValue(string value, string key);

        // -(void)setPlayerOptionValue:(NSString *)value forKey:(NSString *)key;
        [Export("setPlayerOptionValue:forKey:")]
        void SetPlayerOptionValue(string value, string key);

        // -(void)setFormatOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setFormatOptionIntValue:forKey:")]
        void SetFormatOptionIntValue(long value, string key);

        // -(void)setCodecOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setCodecOptionIntValue:forKey:")]
        void SetCodecOptionIntValue(long value, string key);

        // -(void)setSwsOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setSwsOptionIntValue:forKey:")]
        void SetSwsOptionIntValue(long value, string key);

        // -(void)setPlayerOptionIntValue:(int64_t)value forKey:(NSString *)key;
        [Export("setPlayerOptionIntValue:forKey:")]
        void SetPlayerOptionIntValue(long value, string key);

        [Wrap("WeakSegmentOpenDelegate")]
        IIJKMediaUrlOpenDelegate SegmentOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> segmentOpenDelegate;
        [NullAllowed, Export("segmentOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakSegmentOpenDelegate { get; set; }

        [Wrap("WeakTcpOpenDelegate")]
        IJKMediaUrlOpenDelegate TcpOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> tcpOpenDelegate;
        [NullAllowed, Export("tcpOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakTcpOpenDelegate { get; set; }

        [Wrap("WeakHttpOpenDelegate")]
        IIJKMediaUrlOpenDelegate HttpOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> httpOpenDelegate;
        [NullAllowed, Export("httpOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakHttpOpenDelegate { get; set; }

        [Wrap("WeakLiveOpenDelegate")]
        IIJKMediaUrlOpenDelegate LiveOpenDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaUrlOpenDelegate> liveOpenDelegate;
        [NullAllowed, Export("liveOpenDelegate", ArgumentSemantic.Retain)]
        NSObject WeakLiveOpenDelegate { get; set; }

        [Wrap("WeakNativeInvokeDelegate")]
        IIJKMediaNativeInvokeDelegate NativeInvokeDelegate { get; set; }

        // @property (retain, nonatomic) id<IJKMediaNativeInvokeDelegate> nativeInvokeDelegate;
        [NullAllowed, Export("nativeInvokeDelegate", ArgumentSemantic.Retain)]
        NSObject WeakNativeInvokeDelegate { get; set; }

        // -(void)didShutdown;
        [Export("didShutdown")]
        void DidShutdown();

        // @property (readonly, nonatomic) IJKFFMonitor * monitor;
        [Export("monitor")]
        IJKFFMonitor Monitor();
    }

    // @interface IJKAVMoviePlayerController : NSObject <IJKMediaPlayback>
    [BaseType(typeof(NSObject))]
    interface IJKAVMoviePlayerController : IJKMediaPlayback
    {
        // -(id)initWithContentURL:(NSURL *)aUrl;
        [Export("initWithContentURL:")]
        IntPtr Constructor(NSUrl aUrl);

        // -(id)initWithContentURLString:(NSString *)aUrl;
        [Export("initWithContentURLString:")]
        IntPtr Constructor(string aUrl);

        // -(void)prepareToPlay;
        [Export("prepareToPlay")]
        new void PrepareToPlay();

        // -(void)play;
        [Export("play")]
        new void Play();

        // -(void)pause;
        [Export("pause")]
        new void Pause();

        // -(void)stop;
        [Export("stop")]
        new void Stop();

        // -(BOOL)isPlaying;
        [Export("isPlaying")]
        new bool IsPlaying();

        // -(void)shutdown;
        [Export("shutdown")]
        new void Shutdown();

        // -(void)setPauseInBackground:(BOOL)pause;
        [Export("setPauseInBackground:")]
        new void SetPauseInBackground(bool pause);

        // @property (readonly, nonatomic) UIView * view;
        [Export("view")]
        new UIView View();

        // @required @property (nonatomic) NSTimeInterval currentPlaybackTime;
        [Export("currentPlaybackTime")]
        new double CurrentPlaybackTime { get; set; }

        // @required @property (readonly, nonatomic) NSTimeInterval duration;
        [Export("duration")]
        new double Duration();

        // @required @property (readonly, nonatomic) NSTimeInterval playableDuration;
        [Export("playableDuration")]
        new double PlayableDuration();

        // @required @property (readonly, nonatomic) NSInteger bufferingProgress;
        [Export("bufferingProgress")]
        new nint BufferingProgress();

        // @required @property (readonly, nonatomic) BOOL isPreparedToPlay;
        [Export("isPreparedToPlay")]
        new bool IsPreparedToPlay();

        // @required @property (readonly, nonatomic) IJKMPMoviePlaybackState playbackState;
        [Export("playbackState")]
        new IJKMPMoviePlaybackState PlaybackState();

        // @required @property (readonly, nonatomic) IJKMPMovieLoadState loadState;
        [Export("loadState")]
        new IJKMPMovieLoadState LoadState();

        // @required @property (readonly, nonatomic) int isSeekBuffering;
        [Export("isSeekBuffering")]
        new int IsSeekBuffering();

        // @required @property (readonly, nonatomic) int isAudioSync;
        [Export("isAudioSync")]
        new int IsAudioSync();

        // @required @property (readonly, nonatomic) int isVideoSync;
        [Export("isVideoSync")]
        new int IsVideoSync();

        // @required @property (readonly, nonatomic) int64_t numberOfBytesTransferred;
        [Export("numberOfBytesTransferred")]
        new long NumberOfBytesTransferred();

        // @required @property (readonly, nonatomic) CGSize naturalSize;
        [Export("naturalSize")]
        new CGSize NaturalSize();

        // @required @property (nonatomic) IJKMPMovieScalingMode scalingMode;
        [Export("scalingMode", ArgumentSemantic.Assign)]
        new IJKMPMovieScalingMode ScalingMode { get; set; }

        // @required @property (nonatomic) BOOL shouldAutoplay;
        [Export("shouldAutoplay")]
        new bool ShouldAutoplay { get; set; }

        // @required @property (nonatomic) BOOL allowsMediaAirPlay;
        [Export("allowsMediaAirPlay")]
        new bool AllowsMediaAirPlay { get; set; }

        // @required @property (nonatomic) BOOL isDanmakuMediaAirPlay;
        [Export("isDanmakuMediaAirPlay")]
        new bool IsDanmakuMediaAirPlay { get; set; }

        // @required @property (readonly, nonatomic) BOOL airPlayMediaActive;
        [Export("airPlayMediaActive")]
        new bool AirPlayMediaActive();

        // @required @property (nonatomic) float playbackRate;
        [Export("playbackRate")]
        new float PlaybackRate { get; set; }

        // @required @property (nonatomic) float playbackVolume;
        [Export("playbackVolume")]
        new float PlaybackVolume { get; set; }

        // @required -(UIImage *)thumbnailImageAtCurrentTime;
        [Export("thumbnailImageAtCurrentTime")]
        new UIImage ThumbnailImageAtCurrentTime();

        // +(id)getInstance:(NSString *)aUrl;
        [Static]
        [Export("getInstance:")]
        NSObject GetInstance(string aUrl);
    }

    // @interface IJKMediaModule : NSObject
    [BaseType(typeof(NSObject))]
    interface IJKMediaModule
    {
        // +(IJKMediaModule *)sharedModule;
        [Static]
        [Export("sharedModule")]
        IJKMediaModule SharedModule();

        // @property (getter = isAppIdleTimerDisabled, atomic) BOOL appIdleTimerDisabled;
        [Export("appIdleTimerDisabled")]
        bool AppIdleTimerDisabled { [Bind("isAppIdleTimerDisabled")] get; set; }

        // @property (getter = isMediaModuleIdleTimerDisabled, atomic) BOOL mediaModuleIdleTimerDisabled;
        [Export("mediaModuleIdleTimerDisabled")]
        bool MediaModuleIdleTimerDisabled { [Bind("isMediaModuleIdleTimerDisabled")] get; set; }
    }

#endregion

#region SJUIKitApis

    // @protocol SJUIKitTextMakerProtocol <SJUTAttributesProtocol>
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
    interface SJUIKitTextMakerProtocol : SJUTAttributesProtocol
    {
        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSString * _Nonnull) append;
        [Abstract]
        [Export("append", ArgumentSemantic.Copy)]
        Func<NSString, SJUTAttributesProtocol> Append();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(__attribute__((noescape)) SJUTAppendImageHandler _Nonnull) appendImage;
        [Abstract]
        [Export("appendImage", ArgumentSemantic.Copy)]
        Func<SJUTAppendImageHandler, SJUTAttributesProtocol> AppendImage();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSAttributedString * _Nonnull) appendText;
        [Abstract]
        [Export("appendText", ArgumentSemantic.Copy)]
        Func<NSAttributedString, SJUTAttributesProtocol> AppendText();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSRange) update;
        [Abstract]
        [Export("update", ArgumentSemantic.Copy)]
        Func<NSRange, SJUTAttributesProtocol> Update();

        // @required @property (readonly, copy, nonatomic) id<SJUTRegexHandlerProtocol>  _Nonnull (^ _Nonnull)(NSString * _Nonnull) regex;
        [Abstract]
        [Export("regex", ArgumentSemantic.Copy)]
        Func<NSString, SJUTRegexHandlerProtocol> Regex();

        // @required @property (readonly, copy, nonatomic) id<SJUTRangeHandlerProtocol>  _Nonnull (^ _Nonnull)(NSRange) range;
        [Abstract]
        [Export("range", ArgumentSemantic.Copy)]
        Func<NSRange, SJUTRangeHandlerProtocol> Range();
    }
    
    // common argument actions
    delegate void BoolArgumentAction(bool arg0);
    delegate void NSArrayNSValueArgumentAction(NSArray<NSValue> arg0);
    delegate void NSShaowArgumentAction(NSShadow arg0);
    delegate void SJUTStrokeArgumentAction(SJUTStroke arg0);
    delegate void SJUTDecorationArgumentAction(SJUTDecoration arg0);
    delegate void SJUIKitTextMakerProtocolArgumentAction(SJUIKitTextMakerProtocol arg0);
    delegate void SJUTAttributesProtocolArgumentAction(SJUTAttributesProtocol arg0);
    delegate void NSMutableAttributedStringNSTextCheckingResultArgumentsAction(NSMutableAttributedString arg0, NSTextCheckingResult arg1);
    delegate void SJAttributesRangeOperatorArgumentAction(SJAttributesRangeOperator arg0);
    delegate void SJAttributeWorkerArgumentAction(SJAttributeWorker arg0);

    // typedef void (^SJUTAppendImageHandler)(id<SJUTImageAttachment> _Nonnull);
    delegate void SJUTAppendImageHandler(SJUTImageAttachment arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTFontAttribute)(UIFont * _Nonnull);
    delegate SJUTAttributesProtocol SJUTFontAttribute(UIFont arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTColorAttribute)(UIColor * _Nonnull);
    delegate SJUTAttributesProtocol SJUTColorAttribute(UIColor arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTKernAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTKernAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTShadowAttribute)(void (^ _Nonnull)(NSShadow * _Nonnull));
    delegate SJUTAttributesProtocol SJUTShadowAttribute(NSShaowArgumentAction arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTStrokeAttribute)(void (^ _Nonnull)(id<SJUTStroke> _Nonnull));
    delegate SJUTAttributesProtocol SJUTStrokeAttribute(SJUTStrokeArgumentAction arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTDecorationAttribute)(void (^ _Nonnull)(id<SJUTDecoration> _Nonnull));
    delegate SJUTAttributesProtocol SJUTDecorationAttribute(SJUTDecorationArgumentAction arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTBaseLineOffsetAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTBaseLineOffsetAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineSpacingAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTLineSpacingAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTParagraphSpacingAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTParagraphSpacingAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTAlignmentAttribute)(NSTextAlignment);
    delegate SJUTAttributesProtocol SJUTAlignmentAttribute(UITextAlignment arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTFirstLineHeadIndentAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTFirstLineHeadIndentAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTHeadIndentAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTHeadIndentAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTTailIndentAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTTailIndentAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineBreakModeAttribute)(NSLineBreakMode);
    delegate SJUTAttributesProtocol SJUTLineBreakModeAttribute(UILineBreakMode arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTMinimumLineHeightAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTMinimumLineHeightAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTMaximumLineHeightAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTMaximumLineHeightAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTBaseWritingDirectionAttribute)(NSWritingDirection);
    delegate SJUTAttributesProtocol SJUTBaseWritingDirectionAttribute(NSWritingDirection arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineHeightMultipleAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTLineHeightMultipleAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTParagraphSpacingBeforeAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTParagraphSpacingBeforeAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTHyphenationFactorAttribute)(float);
    delegate SJUTAttributesProtocol SJUTHyphenationFactorAttribute(float arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTTabStopsAttribute)(NSArray<NSTextTab *> * _Nonnull);
    delegate SJUTAttributesProtocol SJUTTabStopsAttribute(NSTextTab[] arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTDefaultTabIntervalAttribute)(CGFloat);
    delegate SJUTAttributesProtocol SJUTDefaultTabIntervalAttribute(nfloat arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTAllowsDefaultTighteningForTruncationAttribute)(BOOL);
    delegate SJUTAttributesProtocol SJUTAllowsDefaultTighteningForTruncationAttribute(bool arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTLineBreakStrategyAttribute)(NSLineBreakStrategy);
    delegate SJUTAttributesProtocol SJUTLineBreakStrategyAttribute(NSLineBreakStrategy arg0);

    // typedef id<SJUTAttributesProtocol> _Nonnull (^SJUTSetAttribute)(id _Nullable, NSString * _Nonnull);
    delegate SJUTAttributesProtocol SJUTSetAttribute(NSObject arg0, string arg1);

    // @protocol SJUTAttributesProtocol
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
    interface SJUTAttributesProtocol
    {
        // @required @property (readonly, copy, nonatomic) SJUTFontAttribute _Nonnull font;
        [Abstract]
        [Export("font", ArgumentSemantic.Copy)]
        SJUTFontAttribute Font();

        // @required @property (readonly, copy, nonatomic) SJUTColorAttribute _Nonnull textColor;
        [Abstract]
        [Export("textColor", ArgumentSemantic.Copy)]
        SJUTColorAttribute TextColor();

        // @required @property (readonly, copy, nonatomic) SJUTColorAttribute _Nonnull backgroundColor;
        [Abstract]
        [Export("backgroundColor", ArgumentSemantic.Copy)]
        SJUTColorAttribute BackgroundColor();

        // @required @property (readonly, copy, nonatomic) SJUTKernAttribute _Nonnull kern;
        [Abstract]
        [Export("kern", ArgumentSemantic.Copy)]
        SJUTKernAttribute Kern();

        // @required @property (readonly, copy, nonatomic) SJUTShadowAttribute _Nonnull shadow;
        [Abstract]
        [Export("shadow", ArgumentSemantic.Copy)]
        SJUTShadowAttribute Shadow();

        // @required @property (readonly, copy, nonatomic) SJUTStrokeAttribute _Nonnull stroke;
        [Abstract]
        [Export("stroke", ArgumentSemantic.Copy)]
        SJUTStrokeAttribute Stroke();

        // @required @property (readonly, copy, nonatomic) SJUTDecorationAttribute _Nonnull underLine;
        [Abstract]
        [Export("underLine", ArgumentSemantic.Copy)]
        SJUTDecorationAttribute UnderLine();

        // @required @property (readonly, copy, nonatomic) SJUTDecorationAttribute _Nonnull strikethrough;
        [Abstract]
        [Export("strikethrough", ArgumentSemantic.Copy)]
        SJUTDecorationAttribute Strikethrough();

        // @required @property (readonly, copy, nonatomic) SJUTBaseLineOffsetAttribute _Nonnull baseLineOffset;
        [Abstract]
        [Export("baseLineOffset", ArgumentSemantic.Copy)]
        SJUTBaseLineOffsetAttribute BaseLineOffset();

        // @required @property (readonly, copy, nonatomic) SJUTLineSpacingAttribute _Nonnull lineSpacing;
        [Abstract]
        [Export("lineSpacing", ArgumentSemantic.Copy)]
        SJUTLineSpacingAttribute LineSpacing();

        // @required @property (readonly, copy, nonatomic) SJUTParagraphSpacingAttribute _Nonnull paragraphSpacing;
        [Abstract]
        [Export("paragraphSpacing", ArgumentSemantic.Copy)]
        SJUTParagraphSpacingAttribute ParagraphSpacing();

        // @required @property (readonly, copy, nonatomic) SJUTAlignmentAttribute _Nonnull alignment;
        [Abstract]
        [Export("alignment", ArgumentSemantic.Copy)]
        SJUTAlignmentAttribute Alignment();

        // @required @property (readonly, copy, nonatomic) SJUTFirstLineHeadIndentAttribute _Nonnull firstLineHeadIndent;
        [Abstract]
        [Export("firstLineHeadIndent", ArgumentSemantic.Copy)]
        SJUTFirstLineHeadIndentAttribute FirstLineHeadIndent();

        // @required @property (readonly, copy, nonatomic) SJUTHeadIndentAttribute _Nonnull headIndent;
        [Abstract]
        [Export("headIndent", ArgumentSemantic.Copy)]
        SJUTHeadIndentAttribute HeadIndent();

        // @required @property (readonly, copy, nonatomic) SJUTTailIndentAttribute _Nonnull tailIndent;
        [Abstract]
        [Export("tailIndent", ArgumentSemantic.Copy)]
        SJUTTailIndentAttribute TailIndent();

        // @required @property (readonly, copy, nonatomic) SJUTLineBreakModeAttribute _Nonnull lineBreakMode;
        [Abstract]
        [Export("lineBreakMode", ArgumentSemantic.Copy)]
        SJUTLineBreakModeAttribute LineBreakMode();

        // @required @property (readonly, copy, nonatomic) SJUTMinimumLineHeightAttribute _Nonnull minimumLineHeight;
        [Abstract]
        [Export("minimumLineHeight", ArgumentSemantic.Copy)]
        SJUTMinimumLineHeightAttribute MinimumLineHeight();

        // @required @property (readonly, copy, nonatomic) SJUTMaximumLineHeightAttribute _Nonnull maximumLineHeight;
        [Abstract]
        [Export("maximumLineHeight", ArgumentSemantic.Copy)]
        SJUTMaximumLineHeightAttribute MaximumLineHeight();

        // @required @property (readonly, copy, nonatomic) SJUTBaseWritingDirectionAttribute _Nonnull baseWritingDirection;
        [Abstract]
        [Export("baseWritingDirection", ArgumentSemantic.Copy)]
        SJUTBaseWritingDirectionAttribute BaseWritingDirection();

        // @required @property (readonly, copy, nonatomic) SJUTLineHeightMultipleAttribute _Nonnull lineHeightMultiple;
        [Abstract]
        [Export("lineHeightMultiple", ArgumentSemantic.Copy)]
        SJUTLineHeightMultipleAttribute LineHeightMultiple();

        // @required @property (readonly, copy, nonatomic) SJUTParagraphSpacingBeforeAttribute _Nonnull paragraphSpacingBefore;
        [Abstract]
        [Export("paragraphSpacingBefore", ArgumentSemantic.Copy)]
        SJUTParagraphSpacingBeforeAttribute ParagraphSpacingBefore();

        // @required @property (readonly, copy, nonatomic) SJUTHyphenationFactorAttribute _Nonnull hyphenationFactor;
        [Abstract]
        [Export("hyphenationFactor", ArgumentSemantic.Copy)]
        SJUTHyphenationFactorAttribute HyphenationFactor();

        // @required @property (readonly, copy, nonatomic) SJUTTabStopsAttribute _Nonnull tabStops;
        [Abstract]
        [Export("tabStops", ArgumentSemantic.Copy)]
        SJUTTabStopsAttribute TabStops();

        // @required @property (readonly, copy, nonatomic) SJUTDefaultTabIntervalAttribute _Nonnull defaultTabInterval;
        [Abstract]
        [Export("defaultTabInterval", ArgumentSemantic.Copy)]
        SJUTDefaultTabIntervalAttribute DefaultTabInterval();

        // @required @property (readonly, copy, nonatomic) API_AVAILABLE(ios(9.0)) SJUTAllowsDefaultTighteningForTruncationAttribute allowsDefaultTighteningForTruncation __attribute__((availability(ios, introduced=9.0)));
        //[iOS(9, 0)]
        [Abstract]
        [Export("allowsDefaultTighteningForTruncation", ArgumentSemantic.Copy)]
        SJUTAllowsDefaultTighteningForTruncationAttribute AllowsDefaultTighteningForTruncation();

        // @required @property (readonly, copy, nonatomic) API_AVAILABLE(ios(9.0)) SJUTLineBreakStrategyAttribute lineBreakStrategy __attribute__((availability(ios, introduced=9.0)));
        //[iOS(9, 0)]
        [Abstract]
        [Export("lineBreakStrategy", ArgumentSemantic.Copy)]
        SJUTLineBreakStrategyAttribute LineBreakStrategy();

        // @required @property (readonly, copy, nonatomic) SJUTSetAttribute _Nonnull set;
        [Abstract]
        [Export("set", ArgumentSemantic.Copy)]
        SJUTSetAttribute Set();
    }

    // @protocol SJUTRangeHandlerProtocol
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
    interface SJUTRangeHandlerProtocol
    {
        // @required @property (readonly, copy, nonatomic) void (^ _Nonnull)(void (^ _Nonnull)(id<SJUTAttributesProtocol> _Nonnull)) update;
        [Abstract]
        [Export("update", ArgumentSemantic.Copy)]
        Action<SJUTAttributesProtocolArgumentAction> Update();

        // @required @property (readonly, copy, nonatomic) void (^ _Nonnull)(void (^ _Nonnull)(id<SJUIKitTextMakerProtocol> _Nonnull)) replaceWithText;
        [Abstract]
        [Export("replaceWithText", ArgumentSemantic.Copy)]
        Action<SJUIKitTextMakerProtocolArgumentAction> ReplaceWithText();

        // @required @property (readonly, copy, nonatomic) id<SJUTAttributesProtocol>  _Nonnull (^ _Nonnull)(NSString * _Nonnull) replaceWithString;
        [Abstract]
        [Export("replaceWithString", ArgumentSemantic.Copy)]
        Func<NSString, SJUTAttributesProtocol> ReplaceWithString();
    }

    // @protocol SJUTRegexHandlerProtocol <SJUTRangeHandlerProtocol>
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
    interface SJUTRegexHandlerProtocol : SJUTRangeHandlerProtocol
    {
        // @required @property (readonly, copy, nonatomic) void (^ _Nonnull)(void (^ _Nonnull)(NSMutableAttributedString * _Nonnull, NSTextCheckingResult * _Nonnull)) handler;
        [Abstract]
        [Export("handler", ArgumentSemantic.Copy)]
        Action<NSMutableAttributedStringNSTextCheckingResultArgumentsAction> Handler();

        // @required @property (readonly, copy, nonatomic) id<SJUTRegexHandlerProtocol>  _Nonnull (^ _Nonnull)(NSRegularExpressionOptions) regularExpressionOptions;
        [Abstract]
        [Export("regularExpressionOptions", ArgumentSemantic.Copy)]
        Func<NSRegularExpressionOptions, SJUTRegexHandlerProtocol> RegularExpressionOptions();

        // @required @property (readonly, copy, nonatomic) id<SJUTRegexHandlerProtocol>  _Nonnull (^ _Nonnull)(NSMatchingOptions) matchingOptions;
        [Abstract]
        [Export("matchingOptions", ArgumentSemantic.Copy)]
        Func<NSMatchingOptions, SJUTRegexHandlerProtocol> MatchingOptions();
    }

    // @protocol SJUTStroke
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
    interface ISJUTStroke
    {
        // @required @property (nonatomic, strong) UIColor * _Nullable color;
        [Abstract]
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @required @property (nonatomic) float width;
        [Abstract]
        [Export("width")]
        float Width { get; set; }
    }

    // @protocol SJUTDecoration
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
    interface ISJUTDecoration
    {
        // @required @property (nonatomic, strong) UIColor * _Nullable color;
        [Abstract]
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @required @property (nonatomic) NSUnderlineStyle style;
        [Abstract]
        [Export("style", ArgumentSemantic.Assign)]
        NSUnderlineStyle Style { get; set; }
    }

    // @protocol SJUTImageAttachment <NSObject>
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
    interface ISJUTImageAttachment
    {
        // @required @property (nonatomic, strong) UIImage * _Nullable image;
        [Abstract]
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @required @property (nonatomic) SJUTVerticalAlignment alignment;
        [Abstract]
        [Export("alignment", ArgumentSemantic.Assign)]
        SJUTVerticalAlignment Alignment { get; set; }

        // @required @property (nonatomic) CGRect bounds;
        [Abstract]
        [Export("bounds", ArgumentSemantic.Assign)]
        CGRect Bounds { get; set; }
    }

    // @interface SJMake (NSAttributedString)
    [Category]
    [BaseType(typeof(NSAttributedString))]
    interface NSAttributedString_SJMake
    {
        // +(instancetype _Nonnull)sj_UIKitText:(void (^ _Nonnull)(id<SJUIKitTextMakerProtocol> _Nonnull))block;
        [Static]
        [Export("sj_UIKitText:")]
        NSAttributedString Sj_UIKitText(SJUIKitTextMakerProtocolArgumentAction block);

        // -(CGSize)sj_textSize;
        [Export("sj_textSize")]
        //[Verify(MethodToProperty)]
        CGSize Sj_textSize();

        // -(CGSize)sj_textSizeForRange:(NSRange)range;
        [Export("sj_textSizeForRange:")]
        CGSize Sj_textSizeForRange(NSRange range);

        // -(CGSize)sj_textSizeForPreferredMaxLayoutWidth:(CGFloat)width;
        [Export("sj_textSizeForPreferredMaxLayoutWidth:")]
        CGSize Sj_textSizeForPreferredMaxLayoutWidth(nfloat width);

        // -(CGSize)sj_textSizeForPreferredMaxLayoutHeight:(CGFloat)height;
        [Export("sj_textSizeForPreferredMaxLayoutHeight:")]
        CGSize Sj_textSizeForPreferredMaxLayoutHeight(nfloat height);
    }

    // @interface SJStrokeAttribute : NSObject <NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface SJStrokeAttribute : INSMutableCopying
    {
        // @property (nonatomic) double value;
        [Export("value")]
        double Value { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull color;
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // +(instancetype _Nonnull)strokeWithValue:(double)value color:(UIColor * _Nonnull)color;
        [Static]
        [Export("strokeWithValue:color:")]
        SJStrokeAttribute StrokeWithValue(double value, UIColor color);

        // -(instancetype _Nonnull)initWithValue:(double)value color:(UIColor * _Nonnull)color;
        [Export("initWithValue:color:")]
        NativeHandle Constructor(double value, UIColor color);
    }

    // @interface SJUnderlineAttribute : NSObject <NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface SJUnderlineAttribute : INSMutableCopying
    {
        // @property (nonatomic) NSUnderlineStyle value;
        [Export("value", ArgumentSemantic.Assign)]
        NSUnderlineStyle Value { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull color;
        [Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // +(instancetype _Nonnull)underLineWithStyle:(NSUnderlineStyle)value color:(UIColor * _Nonnull)color;
        [Static]
        [Export("underLineWithStyle:color:")]
        SJUnderlineAttribute UnderLineWithStyle(NSUnderlineStyle value, UIColor color);

        // -(instancetype _Nonnull)initWithStyle:(NSUnderlineStyle)value color:(UIColor * _Nonnull)color;
        [Export("initWithStyle:color:")]
        NativeHandle Constructor(NSUnderlineStyle value, UIColor color);
    }

    // @interface SJAttributesRecorder : NSObject <NSMutableCopying>
    [BaseType(typeof(NSObject))]
    interface SJAttributesRecorder : INSMutableCopying
    {
        // @property (nonatomic) NSRange range;
        [Export("range", ArgumentSemantic.Assign)]
        NSRange Range { get; set; }

        // @property (nonatomic, strong) UIFont * _Nullable font;
        [NullAllowed, Export("font", ArgumentSemantic.Strong)]
        UIFont Font { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable textColor;
        [NullAllowed, Export("textColor", ArgumentSemantic.Strong)]
        UIColor TextColor { get; set; }

        // @property (nonatomic) double expansion;
        [Export("expansion")]
        double Expansion { get; set; }

        // @property (nonatomic, strong) NSShadow * _Nullable shadow;
        [NullAllowed, Export("shadow", ArgumentSemantic.Strong)]
        NSShadow Shadow { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable backgroundColor;
        [NullAllowed, Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) SJUnderlineAttribute * _Nullable underLine;
        [NullAllowed, Export("underLine", ArgumentSemantic.Strong)]
        SJUnderlineAttribute UnderLine { get; set; }

        // @property (nonatomic, strong) SJUnderlineAttribute * _Nullable strikethrough;
        [NullAllowed, Export("strikethrough", ArgumentSemantic.Strong)]
        SJUnderlineAttribute Strikethrough { get; set; }

        // @property (nonatomic, strong) SJStrokeAttribute * _Nullable stroke;
        [NullAllowed, Export("stroke", ArgumentSemantic.Strong)]
        SJStrokeAttribute Stroke { get; set; }

        // @property (nonatomic) double obliqueness;
        [Export("obliqueness")]
        double Obliqueness { get; set; }

        // @property (nonatomic) double letterSpacing;
        [Export("letterSpacing")]
        double LetterSpacing { get; set; }

        // @property (nonatomic) double offset;
        [Export("offset")]
        double Offset { get; set; }

        // @property (nonatomic) BOOL link;
        [Export("link")]
        bool Link { get; set; }

        // @property (nonatomic, strong, null_resettable) NSMutableParagraphStyle * _Null_unspecified paragraphStyleM;
        [NullAllowed, Export("paragraphStyleM", ArgumentSemantic.Strong)]
        NSMutableParagraphStyle ParagraphStyleM { get; set; }

        // @property (nonatomic) double lineSpacing;
        [Export("lineSpacing")]
        double LineSpacing { get; set; }

        // @property (nonatomic) double paragraphSpacing;
        [Export("paragraphSpacing")]
        double ParagraphSpacing { get; set; }

        // @property (nonatomic) double paragraphSpacingBefore;
        [Export("paragraphSpacingBefore")]
        double ParagraphSpacingBefore { get; set; }

        // @property (nonatomic) double firstLineHeadIndent;
        [Export("firstLineHeadIndent")]
        double FirstLineHeadIndent { get; set; }

        // @property (nonatomic) double headIndent;
        [Export("headIndent")]
        double HeadIndent { get; set; }

        // @property (nonatomic) double tailIndent;
        [Export("tailIndent")]
        double TailIndent { get; set; }

        // @property (nonatomic, strong) NSNumber * _Nullable alignment;
        [NullAllowed, Export("alignment", ArgumentSemantic.Strong)]
        NSNumber Alignment { get; set; }

        // @property (nonatomic) NSLineBreakMode lineBreakMode;
        [Export("lineBreakMode", ArgumentSemantic.Assign)]
        UILineBreakMode LineBreakMode { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(SJAttributesRecorder * _Nonnull) propertyDidChangeExeBlock;
        [NullAllowed, Export("propertyDidChangeExeBlock", ArgumentSemantic.Copy)]
        Action<SJAttributesRecorder> PropertyDidChangeExeBlock { get; set; }
    }

    // @interface SJAttributesRangeOperator : NSObject
    [BaseType(typeof(NSObject))]
    interface SJAttributesRangeOperator
    {
        // -(instancetype _Nonnull)initWithRange:(NSRange)range target:(NSMutableAttributedString * _Nonnull)attrStr;
        [Export("initWithRange:target:")]
        NativeHandle Constructor(NSRange range, NSMutableAttributedString attrStr);

        // -(instancetype _Nonnull)initWithRecorder:(SJAttributesRecorder * _Nonnull)recorder target:(NSMutableAttributedString * _Nonnull)attrStr;
        [Export("initWithRecorder:target:")]
        NativeHandle Constructor(SJAttributesRecorder recorder, NSMutableAttributedString attrStr);
    }

    // @interface SJAttributeWorker : SJAttributesRangeOperator
    [BaseType(typeof(SJAttributesRangeOperator))]
    interface SJAttributeWorker
    {
        // @property (readonly, nonatomic) NSRange range;
        [Export("range")]
        NSRange Range();

        // @property (readonly, nonatomic) NSMutableAttributedString * _Nonnull workInProcess;
        [Export("workInProcess")]
        NSMutableAttributedString WorkInProcess();

        // -(NSMutableAttributedString * _Nonnull)endTask;
        [Export("endTask")]
        //[Verify(MethodToProperty)]
        NSMutableAttributedString EndTask();

        // -(NSMutableAttributedString * _Nonnull)endTaskAndComplete:(void (^ _Nonnull)(SJAttributeWorker * _Nonnull))block;
        [Export("endTaskAndComplete:")]
        NSMutableAttributedString EndTaskAndComplete(SJAttributeWorkerArgumentAction block);

        // @property (nonatomic, strong, null_resettable) UIFont * _Null_unspecified defaultFont;
        [NullAllowed, Export("defaultFont", ArgumentSemantic.Strong)]
        UIFont DefaultFont { get; set; }

        // @property (nonatomic, strong, null_resettable) UIColor * _Null_unspecified defaultTextColor;
        [NullAllowed, Export("defaultTextColor", ArgumentSemantic.Strong)]
        UIColor DefaultTextColor { get; set; }

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSRange, void (^ _Nonnull)(SJAttributesRangeOperator * _Nonnull)) rangeEdit;
        [Export("rangeEdit", ArgumentSemantic.Copy)]
        Func<NSRange, SJAttributesRangeOperatorArgumentAction, SJAttributeWorker> RangeEdit();

        // @property (readonly, copy, nonatomic) NSAttributedString * _Nonnull (^ _Nonnull)(NSRange) subAttrStr;
        [Export("subAttrStr", ArgumentSemantic.Copy)]
        Func<NSRange, NSAttributedString> SubAttrStr();

        // @property (readonly, nonatomic) NSInteger length;
        [Export("length")]
        nint Length();
    }

    // @interface Regexp (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Regexp
    {
        // @property (readwrite, nonatomic) NSRegularExpressionOptions regexpOptions;
        [Export("regexpOptions")]
        NSRegularExpressionOptions GetRegexpOptions();

        [Export("setregexpOptions:")]
        void SetRegexpOptions(NSRegularExpressionOptions options);

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSString * _Nonnull, void (^ _Nonnull)(SJAttributesRangeOperator * _Nonnull)) regexp;
        [Export("regexp", ArgumentSemantic.Copy)]
        Func<NSString, SJAttributesRangeOperatorArgumentAction, SJAttributeWorker> Regexp();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSString * _Nonnull, void (^ _Nonnull)(NSArray<NSValue *> * _Nonnull), BOOL) regexp_r;
        [Export("regexp_r", ArgumentSemantic.Copy)]
        Func<NSString, NSArrayNSValueArgumentAction, bool, SJAttributeWorker> Regexp_r();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSString * _Nonnull, id _Nonnull, ...) regexp_replace;
        [Export("regexp_replace", ArgumentSemantic.Copy)]
        Action<NSString, NSObject, IntPtr> Regexp_replace();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSString * _Nonnull, SJAttributeRegexpInsertPosition, id _Nonnull, ...) regexp_insert;
        [Export("regexp_insert", ArgumentSemantic.Copy)]
        Action<NSString, SJAttributeRegexpInsertPosition, NSObject, IntPtr> Regexp_insert();
    }

    // @interface Size (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Size
    {
        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(void) size;
        [Export("size", ArgumentSemantic.Copy)]
        Func<CGSize> Size();

        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(NSRange) sizeByRange;
        [Export("sizeByRange", ArgumentSemantic.Copy)]
        Func<NSRange, CGSize> SizeByRange();

        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(double) sizeByWidth;
        [Export("sizeByWidth", ArgumentSemantic.Copy)]
        Func<double, CGSize> SizeByWidth();

        // @property (readonly, copy, nonatomic) CGSize (^ _Nonnull)(double) sizeByHeight;
        [Export("sizeByHeight", ArgumentSemantic.Copy)]
        Func<double, CGSize> SizeByHeight();
    }

    // @interface Insert (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Insert
    {
        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(id _Nonnull, ...) append;
        [Export("append", ArgumentSemantic.Copy)]
        Func<NSObject, IntPtr, SJAttributesRangeOperator> Append();

        // @property (readonly, nonatomic) NSRange lastInsertedRange;
        [Export("lastInsertedRange")]
        NSRange LastInsertedRange();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(void (^ _Nonnull)(SJAttributesRangeOperator * _Nonnull)) lastInserted;
        [Export("lastInserted", ArgumentSemantic.Copy)]
        Func<SJAttributesRangeOperatorArgumentAction, SJAttributeWorker> LastInserted();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSAttributedStringKey _Nonnull, id _Nonnull, NSRange) add;
        [Export("add", ArgumentSemantic.Copy)]
        Func<NSString, NSObject, NSRange, SJAttributeWorker> Add();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSString * _Nonnull, NSInteger) insertText;
        [Export("insertText", ArgumentSemantic.Copy)]
        Func<NSString, nint, SJAttributeWorker> InsertText();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(UIImage * _Nonnull, NSInteger, CGPoint, CGSize) insertImage;
        [Export("insertImage", ArgumentSemantic.Copy)]
        Func<UIImage, nint, CGPoint, CGSize, SJAttributeWorker> InsertImage();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(NSAttributedString * _Nonnull, NSInteger) insertAttrStr;
        [Export("insertAttrStr", ArgumentSemantic.Copy)]
        Func<NSAttributedString, nint, SJAttributeWorker> InsertAttrStr();

        // @property (readonly, copy, nonatomic) SJAttributeWorker * _Nonnull (^ _Nonnull)(id _Nonnull, NSInteger, ...) insert;
        [Export("insert", ArgumentSemantic.Copy)]
        Func<NSObject, nint, IntPtr, SJAttributeWorker> Insert();
    }

    // @interface Replace (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Replace
    {
        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSRange, id _Nonnull, ...) replace;
        [Export("replace", ArgumentSemantic.Copy)]
        Action<NSRange, NSObject, IntPtr> Replace();
    }

    // @interface Delete (SJAttributeWorker)
    [Category]
    [BaseType(typeof(SJAttributeWorker))]
    interface SJAttributeWorker_Delete
    {
        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSRange) removeText;
        [Export("removeText", ArgumentSemantic.Copy)]
        Action<NSRange> RemoveText();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSAttributedStringKey _Nonnull, NSRange) removeAttribute;
        [Export("removeAttribute", ArgumentSemantic.Copy)]
        Action<NSString, NSRange> RemoveAttribute();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(NSRange) removeAttributes;
        [Export("removeAttributes", ArgumentSemantic.Copy)]
        Action<NSRange> RemoveAttributes();
    }

    // @interface Property (SJAttributesRangeOperator)
    [Category]
    [BaseType(typeof(SJAttributesRangeOperator))]
    interface SJAttributesRangeOperator_Property
    {
        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIFont * _Nonnull) font;
        [Export("font", ArgumentSemantic.Copy)]
        Func<UIFont, SJAttributesRangeOperator> Font();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIColor * _Nonnull) textColor;
        [Export("textColor", ArgumentSemantic.Copy)]
        Func<UIColor, SJAttributesRangeOperator> TextColor();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) expansion;
        [Export("expansion", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> Expansion();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(CGSize, CGFloat, UIColor * _Nonnull) shadow;
        [Export("shadow", ArgumentSemantic.Copy)]
        Func<CGSize, nfloat, UIColor, SJAttributesRangeOperator> Shadow();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIColor * _Nonnull) backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Copy)]
        Func<UIColor, SJAttributesRangeOperator> BackgroundColor();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSUnderlineStyle, UIColor * _Nonnull) underLine;
        [Export("underLine", ArgumentSemantic.Copy)]
        Func<NSUnderlineStyle, UIColor, SJAttributesRangeOperator> UnderLine();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSUnderlineStyle, UIColor * _Nonnull) strikethrough;
        [Export("strikethrough", ArgumentSemantic.Copy)]
        Func<NSUnderlineStyle, UIColor, SJAttributesRangeOperator> Strikethrough();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(UIColor * _Nonnull, double) stroke;
        [Export("stroke", ArgumentSemantic.Copy)]
        Func<UIColor, double, SJAttributesRangeOperator> Stroke();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) obliqueness;
        [Export("obliqueness", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> Obliqueness();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) letterSpacing;
        [Export("letterSpacing", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> LetterSpacing();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) offset;
        [Export("offset", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> Offset();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(void) isLink;
        [Export("isLink", ArgumentSemantic.Copy)]
        Func<SJAttributesRangeOperator> IsLink();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSParagraphStyle * _Nonnull) paragraphStyle;
        [Export("paragraphStyle", ArgumentSemantic.Copy)]
        Func<NSParagraphStyle, SJAttributesRangeOperator> ParagraphStyle();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) lineSpacing;
        [Export("lineSpacing", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> LineSpacing();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) paragraphSpacing;
        [Export("paragraphSpacing", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> ParagraphSpacing();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) paragraphSpacingBefore;
        [Export("paragraphSpacingBefore", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> ParagraphSpacingBefore();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) firstLineHeadIndent;
        [Export("firstLineHeadIndent", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> FirstLineHeadIndent();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) headIndent;
        [Export("headIndent", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> HeadIndent();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(double) tailIndent;
        [Export("tailIndent", ArgumentSemantic.Copy)]
        Func<double, SJAttributesRangeOperator> TailIndent();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSTextAlignment) alignment;
        [Export("alignment", ArgumentSemantic.Copy)]
        Func<UITextAlignment, SJAttributesRangeOperator> Alignment();

        // @property (readonly, copy, nonatomic) SJAttributesRangeOperator * _Nonnull (^ _Nonnull)(NSLineBreakMode) lineBreakMode;
        [Export("lineBreakMode", ArgumentSemantic.Copy)]
        Func<UILineBreakMode, SJAttributesRangeOperator> LineBreakMode();
    }

    // @interface SJUTStroke : NSObject <SJUTStroke>
    [BaseType(typeof(NSObject))]
    interface SJUTStroke : ISJUTStroke
    {
        // @property (nonatomic, strong) UIColor * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @property (nonatomic) float width;
        [Export("width")]
        float Width { get; set; }
    }

    // @interface SJUTDecoration : NSObject <SJUTDecoration>
    [BaseType(typeof(NSObject))]
    interface SJUTDecoration : ISJUTDecoration
    {
        // @property (nonatomic, strong) UIColor * _Nullable color;
        [NullAllowed, Export("color", ArgumentSemantic.Strong)]
        UIColor Color { get; set; }

        // @property (nonatomic) NSUnderlineStyle style;
        [Export("style", ArgumentSemantic.Assign)]
        NSUnderlineStyle Style { get; set; }
    }

    // @interface SJUTImageAttachment : NSObject <SJUTImageAttachment>
    [BaseType(typeof(NSObject))]
    interface SJUTImageAttachment : ISJUTImageAttachment
    {
        // @property (nonatomic, strong) UIImage * _Nullable image;
        [NullAllowed, Export("image", ArgumentSemantic.Strong)]
        UIImage Image { get; set; }

        // @property (nonatomic) CGRect bounds;
        [Export("bounds", ArgumentSemantic.Assign)]
        CGRect Bounds { get; set; }

        // @property (nonatomic) SJUTVerticalAlignment alignment;
        [Export("alignment", ArgumentSemantic.Assign)]
        SJUTVerticalAlignment Alignment { get; set; }
    }

    // @interface SJUTReplace : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTReplace
    {
        // @property (nonatomic, strong) NSString * _Nullable fromString;
        [NullAllowed, Export("fromString", ArgumentSemantic.Strong)]
        string FromString { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUIKitTextMakerProtocol> _Nonnull) block;
        [NullAllowed, Export("block", ArgumentSemantic.Copy)]
        SJUIKitTextMakerProtocolArgumentAction Block { get; set; }
    }

    // @interface SJUTRecorder : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTRecorder
    {
        // -(void)setValue:(id _Nullable)value forAttributeKey:(NSString * _Nonnull)key;
        [Export("setValue:forAttributeKey:")]
        void SetValue(NSObject value, string key);

        // -(void)setValuesForAttributeKeysWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)keyedValues;
        [Export("setValuesForAttributeKeysWithDictionary:")]
        void SetValuesForAttributeKeysWithDictionary(NSDictionary<NSString, NSObject> keyedValues);

        // -(NSDictionary<NSAttributedStringKey,id> * _Nonnull)textAttributes;
        [Export("textAttributes")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, NSObject> TextAttributes();

        // -(NSParagraphStyle * _Nonnull)paragraphAttributesForStyle:(NSParagraphStyle * _Nullable)style;
        [Export("paragraphAttributesForStyle:")]
        NSParagraphStyle ParagraphAttributesForStyle(NSParagraphStyle style);

        // -(NSDictionary<NSAttributedStringKey,id> * _Nonnull)customAttributes;
        [Export("customAttributes")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, NSObject> CustomAttributes();

        // -(void)setValuesForCommonRecorder:(SJUTRecorder * _Nonnull)common;
        [Export("setValuesForCommonRecorder:")]
        void SetValuesForCommonRecorder(SJUTRecorder common);

        // -(void)setValuesForAttributedString:(NSAttributedString * _Nonnull)attributedString;
        [Export("setValuesForAttributedString:")]
        void SetValuesForAttributedString(NSAttributedString attributedString);
    }

    // @interface SJUTAttributes : NSObject <SJUTAttributesProtocol>
    [BaseType(typeof(NSObject))]
    interface SJUTAttributes : SJUTAttributesProtocol
    {
        // @property (readonly, nonatomic, strong) SJUTRecorder * _Nonnull recorder;
        [Export("recorder", ArgumentSemantic.Strong)]
        SJUTRecorder Recorder();
    }

    // @interface SJUIKitTextMaker : SJUTAttributes <SJUIKitTextMakerProtocol>
    [BaseType(typeof(SJUTAttributes))]
    interface SJUIKitTextMaker : SJUIKitTextMakerProtocol
    {
        // -(NSMutableAttributedString * _Nonnull)install;
        [Export("install")]
        //[Verify(MethodToProperty)]
        NSMutableAttributedString Install();
    }

    // @interface SJUTRangeHandler : NSObject <SJUTRangeHandlerProtocol>
    [BaseType(typeof(NSObject))]
    interface SJUTRangeHandler : SJUTRangeHandlerProtocol
    {
        // -(instancetype _Nonnull)initWithRange:(NSRange)range;
        [Export("initWithRange:")]
        NativeHandle Constructor(NSRange range);

        // @property (readonly, nonatomic, strong) SJUTRangeRecorder * _Nonnull recorder;
        [Export("recorder", ArgumentSemantic.Strong)]
        SJUTRangeRecorder Recorder();
    }

    // @interface SJUTRangeRecorder : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTRangeRecorder
    {
        // @property (nonatomic) NSRange range;
        [Export("range", ArgumentSemantic.Assign)]
        NSRange Range { get; set; }

        // @property (nonatomic, strong) id<SJUTAttributesProtocol> _Nullable utOfReplaceWithString;
        [NullAllowed, Export("utOfReplaceWithString", ArgumentSemantic.Strong)]
        SJUTAttributesProtocol UtOfReplaceWithString { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUIKitTextMakerProtocol> _Nonnull) replaceWithText;
        [NullAllowed, Export("replaceWithText", ArgumentSemantic.Copy)]
        SJUIKitTextMakerProtocolArgumentAction ReplaceWithText { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUTAttributesProtocol> _Nonnull) update;
        [NullAllowed, Export("update", ArgumentSemantic.Copy)]
        Action<SJUTAttributesProtocol> Update { get; set; }
    }

    // @interface SJUTRegexHandler : NSObject <SJUTRegexHandlerProtocol>
    [BaseType(typeof(NSObject))]
    interface SJUTRegexHandler : SJUTRegexHandlerProtocol
    {
        // -(instancetype _Nonnull)initWithRegex:(NSString * _Nonnull)regex;
        [Export("initWithRegex:")]
        NativeHandle Constructor(string regex);

        // @property (readonly, nonatomic, strong) SJUTRegexRecorder * _Nonnull recorder;
        [Export("recorder", ArgumentSemantic.Strong)]
        SJUTRegexRecorder Recorder();
    }

    // @interface SJUTRegexRecorder : NSObject
    [BaseType(typeof(NSObject))]
    interface SJUTRegexRecorder
    {
        // @property (nonatomic) NSRegularExpressionOptions regularExpressionOptions;
        [Export("regularExpressionOptions", ArgumentSemantic.Assign)]
        NSRegularExpressionOptions RegularExpressionOptions { get; set; }

        // @property (nonatomic) NSMatchingOptions matchingOptions;
        [Export("matchingOptions", ArgumentSemantic.Assign)]
        NSMatchingOptions MatchingOptions { get; set; }

        // @property (nonatomic, strong) id<SJUTAttributesProtocol> _Nullable utOfReplaceWithString;
        [NullAllowed, Export("utOfReplaceWithString", ArgumentSemantic.Strong)]
        SJUTAttributesProtocol UtOfReplaceWithString { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable regex;
        [NullAllowed, Export("regex")]
        string Regex { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUIKitTextMakerProtocol> _Nonnull) replaceWithText;
        [NullAllowed, Export("replaceWithText", ArgumentSemantic.Copy)]
        SJUIKitTextMakerProtocolArgumentAction ReplaceWithText { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(id<SJUTAttributesProtocol> _Nonnull) update;
        [NullAllowed, Export("update", ArgumentSemantic.Copy)]
        Action<SJUTAttributesProtocol> Update { get; set; }

        // @property (copy, nonatomic) void (^ _Nullable)(NSMutableAttributedString * _Nonnull, NSTextCheckingResult * _Nonnull) handler;
        [NullAllowed, Export("handler", ArgumentSemantic.Copy)]
        Action<NSMutableAttributedString, NSTextCheckingResult> Handler { get; set; }
    }

    // typedef void (^SJDeallockCallbackTask)(id _Nonnull);
    delegate void SJDeallockCallbackTask(NSObject arg0);

    // typedef void (^SJKVOObservedChangeHandler)(id _Nonnull, NSDictionary<NSKeyValueChangeKey,id> * _Nullable);
    delegate void SJKVOObservedChangeHandler(NSObject arg0, NSDictionary<NSString, NSObject> arg1);

    // @interface SJKVOHelper (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_SJKVOHelper
    {
        // -(void)sj_addObserver:(NSObject * _Nonnull)observer forKeyPath:(NSString * _Nonnull)keyPath;
        [Export("sj_addObserver:forKeyPath:")]
        void Sj_addObserver(NSObject observer, string keyPath);

        // -(void)sj_addObserver:(NSObject * _Nonnull)observer forKeyPath:(NSString * _Nonnull)keyPath context:(void * _Nullable)context;
        [Export("sj_addObserver:forKeyPath:context:")]
        unsafe void Sj_addObserver(NSObject observer, string keyPath, NSObject context);

        // -(void)sj_addObserver:(NSObject * _Nonnull)observer forKeyPath:(NSString * _Nonnull)keyPath options:(NSKeyValueObservingOptions)options context:(void * _Nullable)context;
        [Export("sj_addObserver:forKeyPath:options:context:")]
        unsafe void Sj_addObserver(NSObject observer, string keyPath, NSKeyValueObservingOptions options, NSObject context);
    }

    // @interface SJNotificationHelper (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_SJNotificationHelper
    {
        // -(void)sj_observeWithNotification:(NSNotificationName _Nonnull)notification target:(id _Nullable)sender usingBlock:(void (^ _Nonnull)(id _Nonnull, NSNotification * _Nonnull))block;
        [Export("sj_observeWithNotification:target:usingBlock:")]
        void Sj_observeWithNotification(string notification, NSObject sender, Action<NSObject, NSNotification> block);

        // -(void)sj_observeWithNotification:(NSNotificationName _Nonnull)notification target:(id _Nullable)sender queue:(NSOperationQueue * _Nullable)queue usingBlock:(void (^ _Nonnull)(id _Nonnull, NSNotification * _Nonnull))block;
        [Export("sj_observeWithNotification:target:queue:usingBlock:")]
        void Sj_observeWithNotification(string notification, NSObject sender, NSOperationQueue queue, Action<NSObject, NSNotification> block);
    }

    // @interface SJDeallocCallback (NSObject)
    [Category]
    [BaseType(typeof(NSObject))]
    interface NSObject_SJDeallocCallback
    {
        // -(void)sj_addDeallocCallbackTask:(SJDeallockCallbackTask _Nonnull)callback;
        [Export("sj_addDeallocCallbackTask:")]
        void Sj_addDeallocCallbackTask(SJDeallockCallbackTask callback);
    }

    // @interface SJPresentationQueue : NSObject
    [BaseType(typeof(NSObject))]
    interface SJPresentationQueue
    {
        // +(void)enqueueToPresent:(UIView<SJPresentViewProtocol> * _Nonnull)presentView sourceView:(UIView * _Nonnull)sourceView;
        [Static]
        [Export("enqueueToPresent:sourceView:")]
        void EnqueueToPresent(SJPresentViewProtocol presentView, UIView sourceView);
    }

    // @protocol SJPresentViewProtocol <NSObject>
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
    interface SJPresentViewProtocol
    {
        // @required @property (readonly, nonatomic) SJPresentationPriority priority;
        [Abstract]
        [Export("priority")]
        SJPresentationPriority Priority();

        // @required -(void)showInSourceView:(UIView * _Nonnull)source dismissedCallback:(void (^ _Nonnull)(void))callback;
        [Abstract]
        [Export("showInSourceView:dismissedCallback:")]
        void DismissedCallback(UIView source, Action callback);
    }

    // audit-objc-generics: @interface SJQueue<__covariant ObjectType> : NSObject
    [BaseType(typeof(NSObject))]
    interface SJQueue
    {
        // +(instancetype _Nonnull)queue;
        [Static]
        [Export("queue")]
        SJQueue Queue();

        // @property (readonly, nonatomic) NSInteger size;
        [Export("size")]
        nint Size();

        // @property (readonly, nonatomic, strong) ObjectType _Nullable firstObject;
        [NullAllowed, Export("firstObject", ArgumentSemantic.Strong)]
        NSObject FirstObject();

        // @property (readonly, nonatomic, strong) ObjectType _Nullable lastObject;
        [NullAllowed, Export("lastObject", ArgumentSemantic.Strong)]
        NSObject LastObject();

        // -(void)enqueue:(ObjectType _Nonnull)obj;
        [Export("enqueue:")]
        void Enqueue(NSObject obj);

        // -(ObjectType _Nullable)dequeue;
        [NullAllowed, Export("dequeue")]
        //[Verify(MethodToProperty)]
        NSObject Dequeue();

        // -(void)empty;
        [Export("empty")]
        void Empty();
    }

    // audit-objc-generics: @interface SJSafeQueue<__covariant ObjectType> : SJQueue
    [BaseType(typeof(SJQueue))]
    interface SJSafeQueue
    {
    }

    // typedef void (^SJRunLoopTaskHandler)();
    delegate void SJRunLoopTaskHandler();

    // @interface SJRunLoopTaskQueue : NSObject
    [BaseType(typeof(NSObject))]
    interface SJRunLoopTaskQueue
    {
        // @property (readonly, copy, nonatomic, class) SJRunLoopTaskQueue * _Nonnull (^ _Nonnull)(NSString * _Nonnull) queue;
        [Static]
        [Export("queue", ArgumentSemantic.Copy)]
        Func<NSString, SJRunLoopTaskQueue> Queue();

        // @property (readonly, copy, nonatomic, class) SJRunLoopTaskQueue * _Nonnull main;
        [Static]
        [Export("main", ArgumentSemantic.Copy)]
        SJRunLoopTaskQueue Main();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(NSString * _Nonnull) destroy;
        [Static]
        [Export("destroy", ArgumentSemantic.Copy)]
        Action<NSString> Destroy();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(NSUInteger) delay;
        [Export("delay", ArgumentSemantic.Copy)]
        Func<nuint, SJRunLoopTaskQueue> Delay();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(CFRunLoopRef _Nonnull, CFRunLoopMode _Nonnull) update;
        [Export("update", ArgumentSemantic.Copy)]
        unsafe Func<CFRunLoop, NSString, SJRunLoopTaskQueue> Update();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(SJRunLoopTaskHandler _Nonnull) enqueue;
        [Export("enqueue", ArgumentSemantic.Copy)]
        Func<SJRunLoopTaskHandler, SJRunLoopTaskQueue> Enqueue();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(void) dequeue;
        [Export("dequeue", ArgumentSemantic.Copy)]
        Func<SJRunLoopTaskQueue> Dequeue();

        // @property (readonly, copy, nonatomic) SJRunLoopTaskQueue * _Nullable (^ _Nonnull)(void) empty;
        [Export("empty", ArgumentSemantic.Copy)]
        Func<SJRunLoopTaskQueue> Empty();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(void) destroy;
        //[Export("destroy", ArgumentSemantic.Copy)]
        //Action Destroy();

        // @property (readonly, nonatomic, strong) NSString * _Nonnull name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name();

        // @property (readonly, nonatomic) NSInteger count;
        [Export("count")]
        nint Count();
    }

    // typedef void (^SJTaskHandler)();
    delegate void SJTaskHandler();

    // @interface SJTaskQueue : NSObject
    [BaseType(typeof(NSObject))]
    interface SJTaskQueue
    {
        // @property (readonly, copy, nonatomic, class) SJTaskQueue * _Nonnull (^ _Nonnull)(NSString * _Nonnull) queue;
        [Static]
        [Export("queue", ArgumentSemantic.Copy)]
        Func<NSString, SJTaskQueue> Queue();

        // @property (readonly, copy, nonatomic, class) SJTaskQueue * _Nonnull main;
        [Static]
        [Export("main", ArgumentSemantic.Copy)]
        SJTaskQueue Main();

        // @property (readonly, copy, nonatomic, class) void (^ _Nonnull)(NSString * _Nonnull) destroy;
        [Static]
        [Export("destroy", ArgumentSemantic.Copy)]
        Action<NSString> Destroy();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(NSTimeInterval) delay;
        [Export("delay", ArgumentSemantic.Copy)]
        Func<double, SJTaskQueue> Delay();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(SJTaskHandler _Nonnull) enqueue;
        [Export("enqueue", ArgumentSemantic.Copy)]
        Func<SJTaskHandler, SJTaskQueue> Enqueue();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(void) dequeue;
        [Export("dequeue", ArgumentSemantic.Copy)]
        Func<SJTaskQueue> Dequeue();

        // @property (readonly, copy, nonatomic) SJTaskQueue * _Nullable (^ _Nonnull)(void) empty;
        [Export("empty", ArgumentSemantic.Copy)]
        Func<SJTaskQueue> Empty();

        // @property (readonly, copy, nonatomic) void (^ _Nonnull)(void) destroy;
        //[Export("destroy", ArgumentSemantic.Copy)]
        //Action Destroy();

        // @property (readonly, nonatomic, strong) NSString * _Nonnull name;
        [Export("name", ArgumentSemantic.Strong)]
        string Name();

        // @property (readonly, nonatomic) NSInteger count;
        [Export("count")]
        nint Count();
    }

    // @interface SJSQLiteColumnInfo : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface SJSQLiteColumnInfo : INSCopying
    {
        // @property (copy, nonatomic) NSString * _Nullable name;
        [NullAllowed, Export("name")]
        string Name { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable type;
        [NullAllowed, Export("type")]
        string Type { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable constraints;
        [NullAllowed, Export("constraints")]
        string Constraints { get; set; }

        // @property (copy, nonatomic) NSString * _Nullable property;
        [NullAllowed, Export("property")]
        string Property { get; set; }

        // @property (nonatomic) BOOL isModelArray;
        [Export("isModelArray")]
        bool IsModelArray { get; set; }

        // @property (nonatomic) BOOL isJsonString;
        [Export("isJsonString")]
        bool IsJsonString { get; set; }

        // @property (nonatomic) BOOL isPrimaryKey;
        [Export("isPrimaryKey")]
        bool IsPrimaryKey { get; set; }

        // @property (nonatomic) BOOL isAutoincrement;
        [Export("isAutoincrement")]
        bool IsAutoincrement { get; set; }
    }

    // @interface SJSQLiteTableInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLiteTableInfo : ObjCRuntime.INativeObject
    {
        // +(instancetype _Nullable)tableInfoWithClass:(Class<SJSQLiteTableModelProtocol> _Nonnull)cls;
        [Static]
        [Export("tableInfoWithClass:")]
        //[return: NullAllowed]
        SJSQLiteTableInfo TableInfoWithClass(SJSQLiteTableModelProtocol cls);

        // @property (readonly, nonatomic) Class _Nonnull cls;
        [Export("cls")]
        Class Cls();

        // @property (readonly, copy, nonatomic) NSString * _Nonnull name;
        [Export("name")]
        string Name();

        // @property (readonly, copy, nonatomic) NSString * _Nonnull primaryKey;
        [Export("primaryKey")]
        string PrimaryKey();

        // @property (readonly, copy, nonatomic) NSArray<SJSQLiteColumnInfo *> * _Nullable columns;
        [NullAllowed, Export("columns", ArgumentSemantic.Copy)]
        SJSQLiteColumnInfo[] Columns();

        // @property (readonly, copy, nonatomic) NSDictionary<SJSQLiteColumnInfo *,SJSQLiteTableInfo *> * _Nullable columnAssociatedTableInfos;
        [NullAllowed, Export("columnAssociatedTableInfos", ArgumentSemantic.Copy)]
        NSDictionary<SJSQLiteColumnInfo, SJSQLiteTableInfo> ColumnAssociatedTableInfos();

        // @property (readonly, copy, nonatomic) NSSet<Class> * _Nonnull allClasses;
        [Export("allClasses", ArgumentSemantic.Copy)]
        NSSet<Class> AllClasses();

        // -(SJSQLiteColumnInfo * _Nullable)columnInfoForProperty:(NSString * _Nonnull)key;
        [Export("columnInfoForProperty:")]
        //[return: NullAllowed]
        SJSQLiteColumnInfo ColumnInfoForProperty(string key);

        // -(SJSQLiteColumnInfo * _Nullable)columnInfoForColumnName:(NSString * _Nonnull)key;
        [Export("columnInfoForColumnName:")]
        //[return: NullAllowed]
        SJSQLiteColumnInfo ColumnInfoForColumnName(string key);
    }

    // @interface SJSQLiteTableInfoExtended (SJSQLiteColumnInfo)
    [Category]
    [BaseType(typeof(SJSQLiteColumnInfo))]
    interface SJSQLiteColumnInfo_SJSQLiteTableInfoExtended
    {
        // @property (readonly, nonatomic, strong) SJSQLiteTableInfo * _Nullable associatedTableInfo;
        [NullAllowed, Export("associatedTableInfo", ArgumentSemantic.Strong)]
        SJSQLiteTableInfo AssociatedTableInfo();
    }

    // @interface SJSQLiteObjectInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLiteObjectInfo
    {
        // +(instancetype _Nullable)objectInfoWithObject:(id _Nonnull)obj tableInfo:(SJSQLiteTableInfo * _Nonnull)tableInfo;
        [Static]
        [Export("objectInfoWithObject:tableInfo:")]
        //[return: NullAllowed]
        SJSQLiteObjectInfo ObjectInfoWithObject(NSObject obj, SJSQLiteTableInfo tableInfo);

        // @property (readonly, nonatomic, strong) id _Nonnull obj;
        [Export("obj", ArgumentSemantic.Strong)]
        NSObject Obj();

        // @property (readonly, nonatomic, strong) SJSQLiteTableInfo * _Nonnull table;
        [Export("table", ArgumentSemantic.Strong)]
        SJSQLiteTableInfo Table();

        // @property (readonly, nonatomic, strong) SJSQLiteColumnInfo * _Nonnull primaryKeyColumnInfo;
        [Export("primaryKeyColumnInfo", ArgumentSemantic.Strong)]
        SJSQLiteColumnInfo PrimaryKeyColumnInfo();

        // @property (readonly, copy, nonatomic) NSArray<SJSQLiteColumnInfo *> * _Nullable autoincrementColumns;
        [NullAllowed, Export("autoincrementColumns", ArgumentSemantic.Copy)]
        SJSQLiteColumnInfo[] AutoincrementColumns();
    }

    // @interface SJSQLiteObjectInfoExtended (SJSQLiteColumnInfo)
    [Category]
    [BaseType(typeof(SJSQLiteColumnInfo))]
    interface SJSQLiteColumnInfo_SJSQLiteObjectInfoExtended
    {
        // @property (readonly, nonatomic, strong) NSArray<SJSQLiteObjectInfo *> * _Nullable associatedObjectInfos;
        [NullAllowed, Export("associatedObjectInfos", ArgumentSemantic.Strong)]
        SJSQLiteObjectInfo[] AssociatedObjectInfos();
    }

    // @interface SJSQLite3CoreExtended (NSMutableString)
    [Category]
    [BaseType(typeof(NSMutableString))]
    interface NSMutableString_SJSQLite3CoreExtended
    {
        // -(void)sjsql_deleteSuffix:(NSString * _Nonnull)str;
        [Export("sjsql_deleteSuffix:")]
        void Sjsql_deleteSuffix(string str);
    }

    // @protocol SJSQLiteTableModelProtocol <NSObject>
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
    interface SJSQLiteTableModelProtocol : ObjCRuntime.INativeObject
    {
        // @required +(NSString * _Nullable)sql_primaryKey;
        [Static, Abstract]
        [NullAllowed, Export("sql_primaryKey")]
        //[Verify(MethodToProperty)]
        string Sql_primaryKey();

        // @optional +(NSArray<NSString *> * _Nullable)sql_autoincrementlist;
        [Static]
        [NullAllowed, Export("sql_autoincrementlist")]
        //[Verify(MethodToProperty)]
        string[] Sql_autoincrementlist();

        // @optional +(NSDictionary<NSString *,Class> * _Nullable)sql_arrayPropertyGenericClass;
        [Static]
        [NullAllowed, Export("sql_arrayPropertyGenericClass")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, Class> Sql_arrayPropertyGenericClass();

        // @optional +(NSDictionary<NSString *,NSString *> * _Nullable)sql_customKeyMapper;
        [Static]
        [NullAllowed, Export("sql_customKeyMapper")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, NSString> Sql_customKeyMapper();

        // @optional +(NSArray<NSString *> * _Nullable)sql_uniquelist;
        [Static]
        [NullAllowed, Export("sql_uniquelist")]
        //[Verify(MethodToProperty)]
        string[] Sql_uniquelist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_whitelist;
        [Static]
        [NullAllowed, Export("sql_whitelist")]
        //[Verify(MethodToProperty)]
        string[] Sql_whitelist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_blacklist;
        [Static]
        [NullAllowed, Export("sql_blacklist")]
        //[Verify(MethodToProperty)]
        string[] Sql_blacklist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_notnulllist;
        [Static]
        [NullAllowed, Export("sql_notnulllist")]
        //[Verify(MethodToProperty)]
        string[] Sql_notnulllist();

        // @optional +(NSString * _Nullable)sql_tableName;
        [Static]
        [NullAllowed, Export("sql_tableName")]
        //[Verify(MethodToProperty)]
        string Sql_tableName();
    }

    // @interface SJSQLite3 : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLite3
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJSQLite3 Shared();

        // -(instancetype _Nullable)initWithDatabasePath:(NSString * _Nonnull)dbPath __attribute__((objc_designated_initializer));
        [Export("initWithDatabasePath:")]
        [DesignatedInitializer]
        NativeHandle Constructor(string dbPath);

        // -(BOOL)save:(id _Nonnull)object error:(NSError * _Nullable * _Nullable)error;
        [Export("save:error:")]
        bool Save(NSObject @object, out NSError error);

        // -(BOOL)saveObjects:(NSArray * _Nonnull)objectArray error:(NSError * _Nullable * _Nullable)error;
        [Export("saveObjects:error:")]
        //[Verify(StronglyTypedNSArray)]
        bool SaveObjects(NSObject[] objectArray, out NSError error);

        // -(BOOL)update:(id _Nonnull)object forKeys:(NSArray<NSString *> * _Nonnull)properties error:(NSError * _Nullable * _Nullable)error;
        [Export("update:forKeys:error:")]
        bool Update(NSObject @object, string[] properties, out NSError error);

        // -(BOOL)update:(id _Nonnull)object forKey:(NSString * _Nonnull)property error:(NSError * _Nullable * _Nullable)error;
        [Export("update:forKey:error:")]
        bool Update(NSObject @object, string property, out NSError error);

        // -(BOOL)updateObjects:(NSArray * _Nonnull)objectArray forKeys:(NSArray<NSString *> * _Nonnull)properties error:(NSError * _Nullable * _Nullable)error;
        [Export("updateObjects:forKeys:error:")]
        //[Verify(StronglyTypedNSArray)]
        bool UpdateObjects(NSObject[] objectArray, string[] properties, out NSError error);

        // -(id _Nullable)objectForClass:(Class _Nonnull)cls primaryKeyValue:(id _Nonnull)value error:(NSError * _Nullable * _Nullable)error;
        [Export("objectForClass:primaryKeyValue:error:")]
        //[return: NullAllowed]
        NSObject ObjectForClass(Class cls, NSObject value, out NSError error);

        // -(BOOL)removeAllObjectsForClass:(Class _Nonnull)cls error:(NSError * _Nullable * _Nullable)error;
        [Export("removeAllObjectsForClass:error:")]
        bool RemoveAllObjectsForClass(Class cls, out NSError error);

        // -(BOOL)removeObjectsForClass:(Class _Nonnull)cls primaryKeyValues:(NSArray<id> * _Nonnull)values error:(NSError * _Nullable * _Nullable)error;
        [Export("removeObjectsForClass:primaryKeyValues:error:")]
        bool RemoveObjectsForClass(Class cls, NSObject[] values, out NSError error);

        // -(BOOL)removeObjectForClass:(Class _Nonnull)cls primaryKeyValue:(id _Nonnull)value error:(NSError * _Nullable * _Nullable)error;
        [Export("removeObjectForClass:primaryKeyValue:error:")]
        bool RemoveObjectForClass(Class cls, NSObject value, out NSError error);
    }

    // @interface FoundationExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_FoundationExtended
    {
        // -(BOOL)save:(id _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("save:forKey:error:")]
        bool Save(NSObject value, string key, out NSError error);

        // -(BOOL)setValue:(id _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setValue:forKey:error:")]
        bool SetValue(NSObject value, string key, out NSError error);

        // -(BOOL)setDictionary:(NSDictionary * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setDictionary:forKey:error:")]
        bool SetDictionary(NSDictionary value, string key, out NSError error);

        // -(BOOL)setArray:(NSArray * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setArray:forKey:error:")]
        //[Verify(StronglyTypedNSArray)]
        bool SetArray(NSObject[] value, string key, out NSError error);

        // -(BOOL)setString:(NSString * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setString:forKey:error:")]
        bool SetString(string value, string key, out NSError error);

        // -(BOOL)setURL:(NSURL * _Nullable)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setURL:forKey:error:")]
        bool SetURL(NSUrl value, string key, out NSError error);

        // -(BOOL)setInteger:(NSInteger)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setInteger:forKey:error:")]
        bool SetInteger(nint value, string key, out NSError error);

        // -(BOOL)setDouble:(double)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setDouble:forKey:error:")]
        bool SetDouble(double value, string key, out NSError error);

        // -(BOOL)setFloat:(float)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setFloat:forKey:error:")]
        bool SetFloat(float value, string key, out NSError error);

        // -(BOOL)setBool:(BOOL)value forKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("setBool:forKey:error:")]
        bool SetBool(bool value, string key, out NSError error);

        // -(BOOL)removeValueForKey:(NSString * _Nonnull)key error:(NSError * _Nullable * _Nullable)error;
        [Export("removeValueForKey:error:")]
        bool RemoveValueForKey(string key, out NSError error);

        // -(id _Nullable)objectForKey:(NSString * _Nonnull)key objectClass:(Class _Nonnull)cls;
        [Export("objectForKey:objectClass:")]
        //[return: NullAllowed]
        NSObject ObjectForKey(string key, Class cls);

        // -(NSString * _Nullable)jsonStringForKey:(NSString * _Nonnull)key;
        [Export("jsonStringForKey:")]
        //[return: NullAllowed]
        string JsonStringForKey(string key);

        // -(NSDictionary * _Nullable)dictionaryForKey:(NSString * _Nonnull)key;
        [Export("dictionaryForKey:")]
        //[return: NullAllowed]
        NSDictionary DictionaryForKey(string key);

        // -(NSArray * _Nullable)arrayForKey:(NSString * _Nonnull)key;
        [Export("arrayForKey:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ArrayForKey(string key);

        // -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key;
        [Export("stringForKey:")]
        //[return: NullAllowed]
        string StringForKey(string key);

        // -(NSURL * _Nullable)URLForKey:(NSString * _Nonnull)key;
        [Export("URLForKey:")]
        //[return: NullAllowed]
        NSUrl URLForKey(string key);

        // -(NSInteger)integerForKey:(NSString * _Nonnull)key;
        [Export("integerForKey:")]
        nint IntegerForKey(string key);

        // -(double)doubleForKey:(NSString * _Nonnull)key;
        [Export("doubleForKey:")]
        double DoubleForKey(string key);

        // -(float)floatForKey:(NSString * _Nonnull)key;
        [Export("floatForKey:")]
        float FloatForKey(string key);

        // -(BOOL)boolForKey:(NSString * _Nonnull)key;
        [Export("boolForKey:")]
        bool BoolForKey(string key);
    }

    // @interface SJSQLite3TableClassCache : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLite3TableClassCache
    {
        // -(BOOL)containsClass:(Class _Nonnull)cls;
        [Export("containsClass:")]
        bool ContainsClass(Class cls);

        // -(void)addClass:(Class _Nonnull)cls;
        [Export("addClass:")]
        void AddClass(Class cls);

        // -(void)addClasses:(NSSet<Class> * _Nonnull)set;
        [Export("addClasses:")]
        void AddClasses(NSSet<Class> set);

        // -(void)removeClass:(Class _Nonnull)cls;
        [Export("removeClass:")]
        void RemoveClass(Class cls);

        // -(void)removeClasses:(NSSet<Class> * _Nonnull)set;
        [Export("removeClasses:")]
        void RemoveClasses(NSSet<Class> set);
    }

    // @interface Core (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_Core
    {
        // -(NSArray<SJSQLite3RowData *> * _Nullable)exec:(NSString * _Nonnull)sql error:(NSError * _Nullable * _Nullable)error;
        [Export("exec:error:")]
        //[return: NullAllowed]
        NSDictionary[] Exec(string sql, out NSError error);

        // -(NSArray<SJSQLite3RowData *> * _Nullable)execInTransaction:(NSString * _Nonnull)sql error:(NSError * _Nullable * _Nullable)error;
        [Export("execInTransaction:error:")]
        //[return: NullAllowed]
        NSDictionary[] ExecInTransaction(string sql, out NSError error);

        // -(void)execInTransaction:(BOOL (^ _Nonnull)(SJSQLite3 * _Nonnull))block;
        [Export("execInTransaction:")]
        void ExecInTransaction(Func<SJSQLite3, bool> block);

        // -(NSArray * _Nullable)objectsForClass:(Class _Nonnull)cls rowDatas:(NSArray<SJSQLite3RowData *> * _Nonnull)rowDatas error:(NSError * _Nullable * _Nullable)error;
        [Export("objectsForClass:rowDatas:error:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ObjectsForClass(Class cls, NSDictionary[] rowDatas, out NSError error);

        // -(SJSQLiteTableInfo * _Nullable)tableInfoForClass:(Class _Nonnull)cls error:(NSError * _Nullable * _Nullable)error;
        [Export("tableInfoForClass:error:")]
        //[return: NullAllowed]
        SJSQLiteTableInfo TableInfoForClass(Class cls, out NSError error);

        // -(SJSQLiteObjectInfo * _Nullable)objectInfoWithObject:(id _Nonnull)object error:(NSError * _Nullable * _Nullable)error;
        [Export("objectInfoWithObject:error:")]
        //[return: NullAllowed]
        SJSQLiteObjectInfo ObjectInfoWithObject(NSObject @object, out NSError error);

        // -(BOOL)containsTableForClass:(Class _Nonnull)cls;
        [Export("containsTableForClass:")]
        bool ContainsTableForClass(Class cls);
    }

    // @interface SJSQLite3Condition : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLite3Condition
    {
        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column relatedBy:(SJSQLite3Relation)relation value:(id _Nonnull)value;
        [Static]
        [Export("conditionWithColumn:relatedBy:value:")]
        SJSQLite3Condition ConditionWithColumn(string column, SJSQLite3Relation relation, NSObject value);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column value:(id _Nonnull)value;
        [Static]
        [Export("conditionWithColumn:value:")]
        SJSQLite3Condition ConditionWithColumn(string column, NSObject value);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column in:(NSArray * _Nonnull)values;
        [Static]
        [Export("conditionWithColumn:in:")]
        //[Verify(StronglyTypedNSArray)]
        SJSQLite3Condition ConditionWithColumn(string column, NSObject[] values);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column notIn:(NSArray * _Nonnull)values;
        [Static]
        [Export("conditionWithColumn:notIn:")]
        //[Verify(StronglyTypedNSArray)]
        SJSQLite3Condition ConditionWithColumnNotIn(string column, NSObject[] values);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column between:(id _Nonnull)start and:(id _Nonnull)end;
        [Static]
        [Export("conditionWithColumn:between:and:")]
        SJSQLite3Condition ConditionWithColumnBetween(string column, NSObject start, NSObject end);

        // +(instancetype _Nonnull)conditionWithColumn:(NSString * _Nonnull)column like:(NSString * _Nonnull)like;
        [Static]
        [Export("conditionWithColumn:like:")]
        SJSQLite3Condition ConditionWithColumnLike(string column, string like);

        // +(instancetype _Nonnull)conditionWithIsNullColumn:(NSString * _Nonnull)column;
        [Static]
        [Export("conditionWithIsNullColumn:")]
        SJSQLite3Condition ConditionWithIsNullColumn(string column);

        // -(instancetype _Nonnull)initWithCondition:(NSString * _Nonnull)condition;
        [Export("initWithCondition:")]
        NativeHandle Constructor(string condition);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull condition;
        [Export("condition")]
        string Condition();
    }

    // @interface SJSQLite3ColumnOrder : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLite3ColumnOrder
    {
        // +(instancetype _Nonnull)orderWithColumn:(NSString * _Nonnull)column ascending:(BOOL)ascending;
        [Static]
        [Export("orderWithColumn:ascending:")]
        SJSQLite3ColumnOrder OrderWithColumn(string column, bool ascending);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull order;
        [Export("order")]
        string Order();
    }

    // @interface QueryObjectsExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_QueryObjectsExtended
    {
        // -(NSArray * _Nullable)objectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders error:(NSError * _Nullable * _Nullable)error;
        [Export("objectsForClass:conditions:orderBy:error:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ObjectsForClass(Class cls, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, out NSError error);

        // -(NSArray * _Nullable)objectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders range:(NSRange)range error:(NSError * _Nullable * _Nullable)error;
        [Export("objectsForClass:conditions:orderBy:range:error:")]
        //[Verify(StronglyTypedNSArray)]
        //[return: NullAllowed]
        NSObject[] ObjectsForClass(Class cls, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, NSRange range, out NSError error);

        // -(NSUInteger)countOfObjectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions error:(NSError * _Nullable * _Nullable)error;
        [Export("countOfObjectsForClass:conditions:error:")]
        nuint CountOfObjectsForClass(Class cls, SJSQLite3Condition[] conditions, out NSError error);
    }

    // @interface QueryDataExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_QueryDataExtended
    {
        // -(NSArray<NSDictionary *> * _Nullable)queryDataForClass:(Class _Nonnull)cls resultColumns:(NSArray<NSString *> * _Nullable)columns conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders error:(NSError * _Nullable * _Nullable)error;
        [Export("queryDataForClass:resultColumns:conditions:orderBy:error:")]
        //[return: NullAllowed]
        NSDictionary[] QueryDataForClass(Class cls, string[] columns, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, out NSError error);

        // -(NSArray<NSDictionary *> * _Nullable)queryDataForClass:(Class _Nonnull)cls resultColumns:(NSArray<NSString *> * _Nullable)columns conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions orderBy:(NSArray<SJSQLite3ColumnOrder *> * _Nullable)orders range:(NSRange)range error:(NSError * _Nullable * _Nullable)error;
        [Export("queryDataForClass:resultColumns:conditions:orderBy:range:error:")]
        //[return: NullAllowed]
        NSDictionary[] QueryDataForClass(Class cls, string[] columns, SJSQLite3Condition[] conditions, SJSQLite3ColumnOrder[] orders, NSRange range, out NSError error);
    }

    // @interface RemoveExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_RemoveExtended
    {
        // -(BOOL)removeAllObjectsForClass:(Class _Nonnull)cls conditions:(NSArray<SJSQLite3Condition *> * _Nullable)conditions error:(NSError * _Nullable * _Nullable)error;
        [Export("removeAllObjectsForClass:conditions:error:")]
        bool RemoveAllObjectsForClass(Class cls, SJSQLite3Condition[] conditions, out NSError error);
    }

    // @interface TableExtended (SJSQLite3)
    [Category]
    [BaseType(typeof(SJSQLite3))]
    interface SJSQLite3_TableExtended
    {
        // -(BOOL)containsColumn:(NSString * _Nonnull)column inTableForClass:(Class _Nonnull)cls;
        [Export("containsColumn:inTableForClass:")]
        bool ContainsColumn(string column, Class cls);
    }

    // @interface SJSQLite3Logger : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLite3Logger
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJSQLite3Logger Shared();

        // @property (getter = isEnabledConsoleLog, nonatomic) BOOL enabledConsoleLog;
        [Export("enabledConsoleLog")]
        bool EnabledConsoleLog { [Bind("isEnabledConsoleLog")] get; set; }

        // -(void)addLog:(NSString * _Nonnull)format, ... __attribute__((format(NSString, 1, 2)));
        [Internal]
        [Export("addLog:", IsVariadic = true)]
        void AddLog(string format, IntPtr varArgs);
    }

    // @interface SJSQLite3TableInfoCache : NSObject
    [BaseType(typeof(NSObject))]
    interface SJSQLite3TableInfoCache
    {
        // +(instancetype _Nonnull)shared;
        [Static]
        [Export("shared")]
        SJSQLite3TableInfoCache Shared();

        // -(SJSQLiteTableInfo * _Nullable)getTableInfoForClass:(Class _Nonnull)cls;
        [Export("getTableInfoForClass:")]
        //[return: NullAllowed]
        SJSQLiteTableInfo GetTableInfoForClass(Class cls);
    }

    // @interface SJSQLiteTableModelConstraints : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface SJSQLiteTableModelConstraints
    {
        // -(instancetype _Nonnull)initWithClass:(Class<SJSQLiteTableModelProtocol> _Nonnull)cls __attribute__((objc_designated_initializer));
        [Export("initWithClass:")]
        [DesignatedInitializer]
        NativeHandle Constructor(SJSQLiteTableModelProtocol cls);

        // @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nonnull objc_sysProperties;
        [Export("objc_sysProperties", ArgumentSemantic.Strong)]
        string[] Objc_sysProperties();

        // @property (nonatomic, strong) NSString * _Nullable sql_primaryKey;
        [NullAllowed, Export("sql_primaryKey", ArgumentSemantic.Strong)]
        string Sql_primaryKey { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_autoincrementlist;
        [NullAllowed, Export("sql_autoincrementlist", ArgumentSemantic.Strong)]
        string[] Sql_autoincrementlist { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,Class<SJSQLiteTableModelProtocol>> * _Nullable sql_arrayPropertyGenericClass;
        [NullAllowed, Export("sql_arrayPropertyGenericClass", ArgumentSemantic.Strong)]
        NSDictionary<NSString, SJSQLiteTableModelProtocol> Sql_arrayPropertyGenericClass { get; set; }

        // @property (nonatomic, strong) NSDictionary<NSString *,NSString *> * _Nullable sql_customKeyMapper;
        [NullAllowed, Export("sql_customKeyMapper", ArgumentSemantic.Strong)]
        NSDictionary<NSString, NSString> Sql_customKeyMapper { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_uniquelist;
        [NullAllowed, Export("sql_uniquelist", ArgumentSemantic.Strong)]
        string[] Sql_uniquelist { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_whitelist;
        [NullAllowed, Export("sql_whitelist", ArgumentSemantic.Strong)]
        string[] Sql_whitelist { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_blacklist;
        [NullAllowed, Export("sql_blacklist", ArgumentSemantic.Strong)]
        string[] Sql_blacklist { get; set; }

        // @property (nonatomic, strong) NSArray<NSString *> * _Nullable sql_notnulllist;
        [NullAllowed, Export("sql_notnulllist", ArgumentSemantic.Strong)]
        string[] Sql_notnulllist { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable sql_tableName;
        [NullAllowed, Export("sql_tableName", ArgumentSemantic.Strong)]
        string Sql_tableName { get; set; }
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern double SJUIKitVersionNumber;
        [Field("SJUIKitVersionNumber", "__Internal")]
        double SJUIKitVersionNumber { get; }

        // extern const unsigned char[] SJUIKitVersionString;
        [Field("SJUIKitVersionString", "__Internal")]
        NSString SJUIKitVersionString { get; }
    }

#endregion

#region SJBaseVideoPlayerApis

    // common argument actions
    delegate void NSTimerArgumentAction(NSTimer arg0);
    delegate void SJBaseVideoPlayerArgumentAction(SJBaseVideoPlayer arg0);
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
        //[Abstract]
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
        //[Abstract]
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

        // -(instancetype _Nullable)initWithOtherAsset:(SJVideoPlayerURLAsset * _Nonnull)otherAsset playModel:(__kindof SJPlayModel * _Nullable)playModel;
        [Export("initWithOtherAsset:playModel:")]
        NativeHandle Constructor(SJVideoPlayerURLAsset otherAsset, SJPlayModel playModel);



        // -(instancetype _Nullable)initWithTitle:(NSString * _Nonnull)title URL:(NSURL * _Nonnull)URL playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithTitle:URL:playModel:")]
        NativeHandle Constructor(string title, NSUrl URL, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithTitle:(NSString * _Nonnull)title URL:(NSURL * _Nonnull)URL startPosition:(NSTimeInterval)startPosition playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithTitle:URL:startPosition:playModel:")]
        NativeHandle Constructor(string title, NSUrl URL, double startPosition, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithAttributedTitle:(NSAttributedString * _Nonnull)title URL:(NSURL * _Nonnull)URL playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAttributedTitle:URL:playModel:")]
        NativeHandle Constructor(NSAttributedString title, NSUrl URL, SJPlayModel playModel);

        // -(instancetype _Nullable)initWithAttributedTitle:(NSAttributedString * _Nonnull)title URL:(NSURL * _Nonnull)URL startPosition:(NSTimeInterval)startPosition playModel:(__kindof SJPlayModel * _Nonnull)playModel;
        [Export("initWithAttributedTitle:URL:startPosition:playModel:")]
        NativeHandle Constructor(NSAttributedString title, NSUrl URL, double startPosition, SJPlayModel playModel);



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
        // @property (nonatomic, strong) __kindof AVAsset * _Nullable avAsset;
        [Export("avAsset")]
        AVAsset? GetAvAsset();
        
        [Export("setavAsset:")]
        void SetAvAsset(AVAsset? asset);

        // @property (nonatomic, strong) AVPlayerItem * _Nullable avPlayerItem;
        [Export("avPlayerItem")]
        AVPlayerItem? GetAvPlayerItem();
        
        [Export("setavPlayerItem:")]
        void SetAvPlayerItem(AVPlayerItem? playerItem);
        
        // @property (nonatomic, strong) AVPlayer * _Nullable avPlayer;
        [Export("avPlayer")]
        AVPlayer? GetAvPlayer();
        
        [Export("setavPlayer:")]
        void SetAvPlayer(AVPlayer? avPlayer);

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
        //[Abstract]
        [Export("initWithContent:range:")]
        NativeHandle Constructor(NSAttributedString content, SJTimeRange range);

        // @required -(instancetype _Nonnull)initWithContent:(NSAttributedString * _Nonnull)content start:(NSTimeInterval)start end:(NSTimeInterval)end;
        //[Abstract]
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
        //[Abstract]
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
        //[Abstract]
        [Export("initWithContent:")]
        NativeHandle Constructor(NSAttributedString content);

        // @required -(instancetype _Nonnull)initWithCustomView:(__kindof UIView * _Nonnull)customView;
        //[Abstract]
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
        void LayoutWatermarkInRect(CGRect rect, CGSize vSize, string videoGravity);
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
        bool GetAudioSessionControlEnabled();

        [Export("setaudioSessionControlEnabled:")]
        void SetAudioSessionControlEnabled(bool audioSessionControlEnabled);

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
        bool GetAutomaticallyHidesPlaceholderImageView();
        
        [Export("setautomaticallyHidesPlaceholderImageView:")]
        void SetAutomaticallyHidesPlaceholderImageView(bool automaticallyHidesPlaceholderImageView);

        // @property (nonatomic) NSTimeInterval delayInSecondsForHiddenPlaceholderImageView;
        [Export("delayInSecondsForHiddenPlaceholderImageView")]
        double GetDelayInSecondsForHiddenPlaceholderImageView();
        
        [Export("setdelayInSecondsForHiddenPlaceholderImageView:")]
        void SetDelayInSecondsForHiddenPlaceholderImageView(double delayInSecondsForHiddenPlaceholderImageView);
    }

    // @interface VideoFlipTransition (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_VideoFlipTransition
    {
        // @property (nonatomic, strong, null_resettable) id<SJFlipTransitionManager> _Null_unspecified flipTransitionManager;
        [Export("flipTransitionManager")]
        SJFlipTransitionManager? GetFlipTransitionManager();

        [Export("setflipTransitionManager:")]
        void SetFlipTransitionManager(SJFlipTransitionManager? flipTransitionManager);

        // @property (readonly, nonatomic, strong) id<SJFlipTransitionManagerObserver> _Nonnull flipTransitionObserver;
        [Export("flipTransitionObserver", ArgumentSemantic.Strong)]
        SJFlipTransitionManagerObserver FlipTransitionObserver();
    }

    // @interface Playback (SJBaseVideoPlayer) <SJVideoPlayerPlaybackControllerDelegate>
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Playback //: SJVideoPlayerPlaybackControllerDelegate
    {
        //SJVideoPlayerPlaybackControllerDelegate
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
        //SJVideoPlayerPlaybackControllerDelegate


        // @property (nonatomic, strong, null_resettable) __kindof id<SJVideoPlayerPlaybackController> _Null_unspecified playbackController;
        [Export("playbackController")]
        SJVideoPlayerPlaybackController? GetPlaybackController();

        [Export("setplaybackController:")]
        void SetPlaybackController(SJVideoPlayerPlaybackController? playbackController);

        // @property (readonly, nonatomic, strong) SJPlaybackObservation * _Nonnull playbackObserver;
        [Export("playbackObserver", ArgumentSemantic.Strong)]
        SJPlaybackObservation PlaybackObserver();

        // @property (nonatomic, strong) SJVideoPlayerURLAsset * _Nullable URLAsset;
        [Export("URLAsset")]
        SJVideoPlayerURLAsset? GetURLAsset();
        
        [Export("setURLAsset:")]
        void SetURLAsset(SJVideoPlayerURLAsset? urlAsset);

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
        bool GetMuted();
        
        [Export("setmuted:")]
        void SetMuted(bool muted);

        // @property (nonatomic) float playerVolume;
        [Export("playerVolume")]
        float GetPlayerVolume();
        
        [Export("setplayerVolume:")]
        void SetPlayerVolume(float playerVolume);

        // @property (nonatomic) float rate;
        [Export("rate")]
        float GetRate();
        
        [Export("setrate:")]
        void SetRate(float rate);

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
        bool GetPausedInBackground();
        
        [Export("setpausedInBackground:")]
        void SetPausedInBackground(bool pausedInBackground);

        // @property (nonatomic) BOOL autoplayWhenSetNewAsset;
        [Export("autoplayWhenSetNewAsset")]
        bool GetAutoplayWhenSetNewAsset();
        
        [Export("setautoplayWhenSetNewAsset:")]
        void SetAutoplayWhenSetNewAsset(bool autoplayWhenSetNewAsset);

        // @property (nonatomic) BOOL resumePlaybackWhenAppDidEnterForeground;
        [Export("resumePlaybackWhenAppDidEnterForeground")]
        bool GetResumePlaybackWhenAppDidEnterForeground();
        
        [Export("setresumePlaybackWhenAppDidEnterForeground:")]
        void SetResumePlaybackWhenAppDidEnterForeground(bool resumePlaybackWhenAppDidEnterForeground);

        // @property (nonatomic) BOOL resumePlaybackWhenPlayerHasFinishedSeeking;
        [Export("resumePlaybackWhenPlayerHasFinishedSeeking")]
        bool GetResumePlaybackWhenPlayerHasFinishedSeeking();
        
        [Export("setresumePlaybackWhenPlayerHasFinishedSeeking:")]
        void SetResumePlaybackWhenPlayerHasFinishedSeeking(bool resumePlaybackWhenPlayerHasFinishedSeeking);

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) canPlayAnAsset;
        [Export("canPlayAnAsset")]
        Func<SJBaseVideoPlayer, bool>? GetCanPlayAnAsset();
        
        [Export("setcanPlayAnAsset:")]
        void SetCanPlayAnAsset(Func<SJBaseVideoPlayer, bool>? canPlayAnAsset);

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) canSeekToTime;
        [Export("canSeekToTime")]
        Func<SJBaseVideoPlayer, bool>? GetCanSeekToTime();
        
        [Export("setcanSeekToTime:")]
        void SetCanSeekToTime(Func<SJBaseVideoPlayer, bool>? canSeekToTime);

        // @property (nonatomic) BOOL accurateSeeking;
        [Export("accurateSeeking")]
        bool GetAccurateSeeking();
        
        [Export("setaccurateSeeking:")]
        void SetAccurateSeeking(bool accurateSeeking);

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
        [Export("deviceVolumeAndBrightnessController")]
        SJDeviceVolumeAndBrightnessController? GetDeviceVolumeAndBrightnessController();

        [Export("setdeviceVolumeAndBrightnessController:")]
        void SetDeviceVolumeAndBrightnessController(SJDeviceVolumeAndBrightnessController? brightnessController);

        // @property (readonly, nonatomic, strong) id<SJDeviceVolumeAndBrightnessControllerObserver> _Nonnull deviceVolumeAndBrightnessObserver;
        [Export("deviceVolumeAndBrightnessObserver", ArgumentSemantic.Strong)]
        SJDeviceVolumeAndBrightnessControllerObserver DeviceVolumeAndBrightnessObserver();

        // @property (nonatomic) BOOL disableBrightnessSetting;
        [Export("disableBrightnessSetting")]
        bool GetDisableBrightnessSetting();
        
        // @property (nonatomic) BOOL disableBrightnessSetting;
        [Export("setdisableBrightnessSetting:")]
        void SetDisableBrightnessSetting(bool disableBrightnessSetting);

        // @property (nonatomic) BOOL disableVolumeSetting;
        [Export("disableVolumeSetting")]
        bool GetDisableVolumeSetting();
        
        [Export("setdisableVolumeSetting:")]
        void SetDisableVolumeSetting(bool disableVolumeSetting);
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
        bool GetVc_isDisappeared();
        
        [Export("setvc_isDisappeared:")]
        void SetVc_isDisappeared(bool isDisappeared);

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
        [Export("reachability")]
        SJReachability? GetReachability();
        
        [Export("setreachability:")]
        void SetReachability(SJReachability? reachability);

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
        [Export("textPopupController")]
        SJTextPopupController? GetTextPopupController();
        
        [Export("settextPopupController:")]
        void SetTextPopupController(SJTextPopupController? popupController);

        // @property (nonatomic, strong, null_resettable) id<SJPromptingPopupController> _Null_unspecified promptingPopupController;
        [Export("promptingPopupController")]
        SJPromptingPopupController? GetPromptingPopupController();
        
        [Export("setpromptingPopupController:")]
        void SetPromptingPopupController(SJPromptingPopupController? popupController);
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
        [Export("gestureRecognizerShouldTrigger")]
        Func<SJBaseVideoPlayer, SJPlayerGestureType, CGPoint, bool>? GetGestureRecognizerShouldTrigger();
        
        [Export("setgestureRecognizerShouldTrigger:")]
        void SetGestureRecognizerShouldTrigger(Func<SJBaseVideoPlayer, SJPlayerGestureType, CGPoint, bool>? func);

        // @property (nonatomic) BOOL allowHorizontalTriggeringOfPanGesturesInCells;
        [Export("allowHorizontalTriggeringOfPanGesturesInCells")]
        bool GetAllowHorizontalTriggeringOfPanGesturesInCells();
        
        [Export("setallowHorizontalTriggeringOfPanGesturesInCells:")]
        void SetAllowHorizontalTriggeringOfPanGesturesInCells(bool allowHorizontalTriggeringOfPanGesturesInCells);

        // @property (nonatomic) CGFloat rateWhenLongPressGestureTriggered;
        [Export("rateWhenLongPressGestureTriggered")]
        nfloat GetRateWhenLongPressGestureTriggered();
        
        [Export("setrateWhenLongPressGestureTriggered:")]
        void SetRateWhenLongPressGestureTriggered(nfloat rateWhenLongPressGestureTriggered);

        // @property (nonatomic) CGFloat offsetFactorForHorizontalPanGesture;
        [Export("offsetFactorForHorizontalPanGesture")]
        nfloat GetOffsetFactorForHorizontalPanGesture();
        
        [Export("setoffsetFactorForHorizontalPanGesture:")]
        void SetOffsetFactorForHorizontalPanGesture(nfloat offsetFactorForHorizontalPanGesture);
    }

    // @interface ControlLayer (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_ControlLayer
    {
        // @property (nonatomic, strong, null_resettable) id<SJControlLayerAppearManager> _Null_unspecified controlLayerAppearManager;
        [Export("controlLayerAppearManager")]
        SJControlLayerAppearManager? GetControlLayerAppearManager();
        
        [Export("setcontrolLayerAppearManager:")]
        void SetControlLayerAppearManager(SJControlLayerAppearManager? appearManager);

        // @property (readonly, nonatomic, strong) id<SJControlLayerAppearManagerObserver> _Nonnull controlLayerAppearObserver;
        [Export("controlLayerAppearObserver", ArgumentSemantic.Strong)]
        SJControlLayerAppearManagerObserver ControlLayerAppearObserver();

        // @property (getter = isControlLayerAppeared, nonatomic) BOOL controlLayerAppeared;
        [Export("controlLayerAppeared")]
        bool GetControlLayerAppeared();
        
        [Export("setcontrolLayerAppeared:")]
        void SetControlLayerAppeared(bool controlLayerAppeared);

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) canAutomaticallyDisappear;
        [Export("canAutomaticallyDisappear")]
        Func<SJBaseVideoPlayer, bool>? GetCanAutomaticallyDisappear();
        
        [Export("setcanAutomaticallyDisappear:")]
        void SetCanAutomaticallyDisappear(Func<SJBaseVideoPlayer, bool>? canAutomaticallyDisappear);

        // -(void)controlLayerNeedAppear;
        [Export("controlLayerNeedAppear")]
        void ControlLayerNeedAppear();

        // -(void)controlLayerNeedDisappear;
        [Export("controlLayerNeedDisappear")]
        void ControlLayerNeedDisappear();

        // @property (nonatomic) BOOL pausedToKeepAppearState;
        [Export("pausedToKeepAppearState")]
        bool GetPausedToKeepAppearState();
        
        [Export("setpausedToKeepAppearState:")]
        void SetPausedToKeepAppearState(bool pausedToKeepAppearState);
    }

    // @interface FitOnScreen (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_FitOnScreen
    {
        // @property (nonatomic, strong, null_resettable) id<SJFitOnScreenManager> _Null_unspecified fitOnScreenManager;
        [Export("fitOnScreenManager")]
        SJFitOnScreenManager? GetFitOnScreenManager();
        
        [Export("setfitOnScreenManager:")]
        void SetFitOnScreenManager(SJFitOnScreenManager? fitOnScreenManager);

        // @property (readonly, nonatomic, strong) id<SJFitOnScreenManagerObserver> _Nonnull fitOnScreenObserver;
        [Export("fitOnScreenObserver", ArgumentSemantic.Strong)]
        SJFitOnScreenManagerObserver FitOnScreenObserver();

        // @property (getter = isFitOnScreen, nonatomic) BOOL fitOnScreen;
        [Export("fitOnScreen")]
        bool GetFitOnScreen();
        
        [Export("setfitOnScreen:")]
        void SetFitOnScreen(bool fitOnScreen);

        // @property (nonatomic) BOOL onlyFitOnScreen;
        [Export("onlyFitOnScreen")]
        bool GetOnlyFitOnScreen();
        
        [Export("setonlyFitOnScreen:")]
        void SetOnlyFitOnScreen(bool onlyFitOnScreen);

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
        [Export("rotationManager")]
        SJRotationManager? GetRotationManager();
        
        [Export("setrotationManager:")]
        void SetRotationManager(SJRotationManager? rotationManager);

        // @property (readonly, nonatomic, strong) id<SJRotationManagerObserver> _Nonnull rotationObserver;
        [Export("rotationObserver", ArgumentSemantic.Strong)]
        SJRotationManagerObserver RotationObserver();

        // @property (copy, nonatomic) BOOL (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) shouldTriggerRotation;
        [Export("shouldTriggerRotation")]
        Func<SJBaseVideoPlayer, bool>? GetShouldTriggerRotation();

        [Export("setshouldTriggerRotation:")]
        void SetShouldTriggerRotation(Func<SJBaseVideoPlayer, bool>? func);

        // @property (nonatomic) BOOL allowsRotationInFitOnScreen;
        [Export("allowsRotationInFitOnScreen")]
        bool GetAllowsRotationInFitOnScreen();
        
        [Export("setallowsRotationInFitOnScreen:")]
        void SetAllowsRotationInFitOnScreen(bool allowsRotationInFitOnScreen);

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
        bool GetLockedScreen();
        
        [Export("setlockedScreen:")]
        void SetLockedScreen(bool lockedScreen);

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
        [Export("presentationSizeDidChangeExeBlock")]
        Action<SJBaseVideoPlayer>? GetPresentationSizeDidChangeExeBlock();
        
        [Export("setpresentationSizeDidChangeExeBlock:")]
        void SetPresentationSizeDidChangeExeBlock(Action<SJBaseVideoPlayer>? action);

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
        [Export("smallViewFloatingController")]
        SJSmallViewFloatingController? GetSmallViewFloatingController();
        
        [Export("setsmallViewFloatingController:")]
        void SetSmallViewFloatingController(SJSmallViewFloatingController? floatingController);

        // @property (getter = isHiddenFloatSmallViewWhenPlaybackFinished, nonatomic) BOOL hiddenFloatSmallViewWhenPlaybackFinished;
        [Export("hiddenFloatSmallViewWhenPlaybackFinished")]
        bool GetHiddenFloatSmallViewWhenPlaybackFinished();
        
        [Export("sethiddenFloatSmallViewWhenPlaybackFinished:")]
        void SetHiddenFloatSmallViewWhenPlaybackFinished(bool hiddenFloatSmallViewWhenPlaybackFinished);

        // @property (nonatomic) BOOL pausedWhenScrollDisappeared;
        [Export("pausedWhenScrollDisappeared")]
        bool GetPausedWhenScrollDisappeared();
        
        [Export("setpausedWhenScrollDisappeared:")]
        void SetPausedWhenScrollDisappeared(bool pausedWhenScrollDisappeared);

        // @property (nonatomic) BOOL resumePlaybackWhenScrollAppeared;
        [Export("resumePlaybackWhenScrollAppeared")]
        bool GetResumePlaybackWhenScrollAppeared();
        
        [Export("setresumePlaybackWhenScrollAppeared:")]
        void SetResumePlaybackWhenScrollAppeared(bool resumePlaybackWhenScrollAppeared);

        // @property (nonatomic) BOOL hiddenViewWhenScrollDisappeared;
        [Export("hiddenViewWhenScrollDisappeared")]
        bool GetHiddenViewWhenScrollDisappeared();
        
        [Export("sethiddenViewWhenScrollDisappeared:")]
        void SetHiddenViewWhenScrollDisappeared(bool hiddenViewWhenScrollDisappeared);

        // @property (readonly, nonatomic) BOOL isPlayOnScrollView;
        [Export("isPlayOnScrollView")]
        bool IsPlayOnScrollView();

        // @property (readonly, nonatomic) BOOL isScrollAppeared;
        [Export("isScrollAppeared")]
        bool IsScrollAppeared();

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playerViewWillAppearExeBlock;
        [Export("playerViewWillAppearExeBlock")]
        Action<SJBaseVideoPlayer>? GetPlayerViewWillAppearExeBlock();
        
        [Export("setplayerViewWillAppearExeBlock:")]
        void SetPlayerViewWillAppearExeBlock(SJBaseVideoPlayerArgumentAction? action);

        // @property (copy, nonatomic) void (^ _Nullable)(__kindof SJBaseVideoPlayer * _Nonnull) playerViewWillDisappearExeBlock;
        [Export("playerViewWillDisappearExeBlock")]
        Action<SJBaseVideoPlayer>? GetPlayerViewWillDisappearExeBlock();
        
        [Export("setplayerViewWillDisappearExeBlock:")]
        void SetPlayerViewWillDisappearExeBlock(SJBaseVideoPlayerArgumentAction? action);
    }

    // @interface Subtitle (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Subtitle
    {
        // @property (nonatomic, strong, null_resettable) id<SJSubtitlePopupController> _Null_unspecified subtitlePopupController;
        [Export("subtitlePopupController")]
        SJSubtitlePopupController? GetSubtitlePopupController();
        
        [Export("setsubtitlePopupController:")]
        void SetSubtitlePopupController(SJSubtitlePopupController? popupController);

        // @property (nonatomic) CGFloat subtitleBottomMargin;
        [Export("subtitleBottomMargin")]
        nfloat GetSubtitleBottomMargin();
        
        [Export("subtitleBottomMargin:")]
        void SetSubtitleBottomMargin(nfloat bottomMargin);

        // @property (nonatomic) CGFloat subtitleHorizontalMinMargin;
        [Export("subtitleHorizontalMinMargin")]
        nfloat GetSubtitleHorizontalMinMargin();
        
        [Export("setsubtitleHorizontalMinMargin:")]
        void SetSubtitleHorizontalMinMargin(nfloat horizontalMinMargin);
    }

    // @interface Danmaku (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Danmaku
    {
        // @property (nonatomic, strong, null_resettable) id<SJDanmakuPopupController> _Null_unspecified danmakuPopupController;
        [Export("danmakuPopupController")]
        SJDanmakuPopupController? GetDanmakuPopupController();
        
        [Export("setdanmakuPopupController:")]
        void SetDanmakuPopupController(SJDanmakuPopupController? popupController);
    }

    // @interface Watermark (SJBaseVideoPlayer)
    [Category]
    [BaseType(typeof(SJBaseVideoPlayer))]
    interface SJBaseVideoPlayer_Watermark
    {
        // @property (nonatomic, strong) UIView<SJWatermarkView> * _Nullable watermarkView;
        [Export("watermarkView")]
        SJWatermarkView? GetWatermarkView();

        [Export("setwatermarkView:")]
        void SetWatermarkView(SJWatermarkView? watermarkView);

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
        [Export("assetURL")]
        NSUrl? GetAssetURL();
        
        [Export("setassetURL:")]
        void SetAssetURL(NSUrl? url);

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
        //[Export("mediaId")]
        //nint MediaId { get; set; }

        // @property (nonatomic) NSInteger userId;
        //[Export("userId")]
        //nint UserId { get; set; }

        // @property (nonatomic) NSTimeInterval position;
        //[Export("position")]
        //double Position { get; set; }

        // @property (nonatomic) SJMediaType _Nonnull mediaType;
        //[Export("mediaType")]
        //string MediaType { get; set; }
    }

    // @interface SJPrivate (SJPlaybackRecord)
    [Category]
    [BaseType(typeof(SJPlaybackRecord))]
    interface SJPlaybackRecord_SJPrivate
    {
        // @property (nonatomic) NSInteger id;
        [Export("id")]
        nint GetId();
        
        [Export("setid:")]
        void SetId(nint id);

        // @property (nonatomic) NSTimeInterval createdTime;
        [Export("createdTime")]
        double GetCreatedTime();
        
        [Export("setcreatedTime:")]
        void SetCreatedTime(double createdTime);

        // @property (nonatomic) NSTimeInterval updatedTime;
        [Export("updatedTime")]
        double GetUpdatedTime();
        
        [Export("setupdatedTime:")]
        void SetUpdatedTime(double updatedTime);
    }

    // @interface SJSQLite3Extended (SJPlaybackRecord) <SJSQLiteTableModelProtocol>
    [Category]
    [BaseType(typeof(SJPlaybackRecord))]
    interface SJPlaybackRecord_SJSQLite3Extended //: SJSQLiteTableModelProtocol
    {
        //SJSQLiteTableModelProtocol
        // @required +(NSString * _Nullable)sql_primaryKey;
        [Static, Abstract]
        [NullAllowed, Export("sql_primaryKey")]
        //[Verify(MethodToProperty)]
        string Sql_primaryKey();

        // @optional +(NSArray<NSString *> * _Nullable)sql_autoincrementlist;
        [Static]
        [NullAllowed, Export("sql_autoincrementlist")]
        //[Verify(MethodToProperty)]
        string[] Sql_autoincrementlist();

        // @optional +(NSDictionary<NSString *,Class> * _Nullable)sql_arrayPropertyGenericClass;
        [Static]
        [NullAllowed, Export("sql_arrayPropertyGenericClass")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, Class> Sql_arrayPropertyGenericClass();

        // @optional +(NSDictionary<NSString *,NSString *> * _Nullable)sql_customKeyMapper;
        [Static]
        [NullAllowed, Export("sql_customKeyMapper")]
        //[Verify(MethodToProperty)]
        NSDictionary<NSString, NSString> Sql_customKeyMapper();

        // @optional +(NSArray<NSString *> * _Nullable)sql_uniquelist;
        [Static]
        [NullAllowed, Export("sql_uniquelist")]
        //[Verify(MethodToProperty)]
        string[] Sql_uniquelist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_whitelist;
        [Static]
        [NullAllowed, Export("sql_whitelist")]
        //[Verify(MethodToProperty)]
        string[] Sql_whitelist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_blacklist;
        [Static]
        [NullAllowed, Export("sql_blacklist")]
        //[Verify(MethodToProperty)]
        string[] Sql_blacklist();

        // @optional +(NSArray<NSString *> * _Nullable)sql_notnulllist;
        [Static]
        [NullAllowed, Export("sql_notnulllist")]
        //[Verify(MethodToProperty)]
        string[] Sql_notnulllist();

        // @optional +(NSString * _Nullable)sql_tableName;
        [Static]
        [NullAllowed, Export("sql_tableName")]
        //[Verify(MethodToProperty)]
        string Sql_tableName();
        //SJSQLiteTableModelProtocol
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
        [Export("record")]
        SJPlaybackRecord? GetRecord();
        
        [Export("setrecord:")]
        void SetRecord(SJPlaybackRecord? record);
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
        // @required @property (nonatomic, strong) id<SJMediaModelProtocol> _Nullable media;
        [NullAllowed, Export("media", ArgumentSemantic.Strong)]
        SJMediaModelProtocol Media { get; set; }

        // @property (nonatomic, strong) SJVideoPlayerURLAsset * _Nullable media;
        [NullAllowed, Export("media", ArgumentSemantic.Strong)]
        SJVideoPlayerURLAsset MediaAsset { get; set; }

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
        NSString SJMediaPlayerPlaybackTypeDidChangeNotification { get; }
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
    interface SJAVMediaPlaybackController_SJAVMediaPlaybackAdd //: ISJMediaPlaybackExportController, ISJMediaPlaybackScreenshotController
    {
        // @required -(void)exportWithBeginTime:(NSTimeInterval)beginTime duration:(NSTimeInterval)duration presetName:(NSString * _Nullable)presetName progress:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, float))progress completion:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, NSURL * _Nullable, UIImage * _Nullable))completion failure:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, NSError * _Nullable))failure;
        [Export("exportWithBeginTime:duration:presetName:progress:completion:failure:")]
        void ExportWithBeginTime(double beginTime, double duration, string presetName, Action<SJVideoPlayerPlaybackController, float> progress, Action<SJVideoPlayerPlaybackController, NSUrl, UIImage> completion, Action<SJVideoPlayerPlaybackController, NSError> failure);

        // @required -(void)generateGIFWithBeginTime:(NSTimeInterval)beginTime duration:(NSTimeInterval)duration maximumSize:(CGSize)maximumSize interval:(float)interval gifSavePath:(NSURL * _Nonnull)gifSavePath progress:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, float))progressBlock completion:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, UIImage * _Nonnull, UIImage * _Nonnull))completion failure:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, NSError * _Nonnull))failure;
        [Export("generateGIFWithBeginTime:duration:maximumSize:interval:gifSavePath:progress:completion:failure:")]
        void GenerateGIFWithBeginTime(double beginTime, double duration, CGSize maximumSize, float interval, NSUrl gifSavePath, Action<SJVideoPlayerPlaybackController, float> progressBlock, Action<SJVideoPlayerPlaybackController, UIImage, UIImage> completion, Action<SJVideoPlayerPlaybackController, NSError> failure);

        // @required -(void)cancelExportOperation;
        [Export("cancelExportOperation")]
        void CancelExportOperation();

        // @required -(void)cancelGenerateGIFOperation;
        [Export("cancelGenerateGIFOperation")]
        void CancelGenerateGIFOperation();

        // @required -(void)screenshotWithTime:(NSTimeInterval)time size:(CGSize)size completion:(void (^ _Nonnull)(id<SJVideoPlayerPlaybackController> _Nonnull, UIImage * _Nullable, NSError * _Nullable))block;
        [Export("screenshotWithTime:size:completion:")]
        void Size(double time, CGSize size, Action<SJVideoPlayerPlaybackController, UIImage, NSError> block);
    }

    //[Static]
    //[Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSInteger SJPlayerViewTag;
        [Field("SJPlayerViewTag", "__Internal")]
        nint SJPlayerViewTag { get; }

        // extern const NSInteger SJPresentViewTag;
        [Field("SJPresentViewTag", "__Internal")]
        nint SJPresentViewTag { get; }
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
        NSString SJVideoPlayerAssetStatusDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerDefinitionSwitchStatusDidChangeNotification;
        [Field("SJVideoPlayerDefinitionSwitchStatusDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerDefinitionSwitchStatusDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerURLAssetWillChangeNotification;
        [Field("SJVideoPlayerURLAssetWillChangeNotification", "__Internal")]
        NSString SJVideoPlayerURLAssetWillChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerURLAssetDidChangeNotification;
        [Field("SJVideoPlayerURLAssetDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerURLAssetDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerApplicationDidEnterBackgroundNotification;
        [Field("SJVideoPlayerApplicationDidEnterBackgroundNotification", "__Internal")]
        NSString SJVideoPlayerApplicationDidEnterBackgroundNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerApplicationWillEnterForegroundNotification;
        [Field("SJVideoPlayerApplicationWillEnterForegroundNotification", "__Internal")]
        NSString SJVideoPlayerApplicationWillEnterForegroundNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerApplicationWillTerminateNotification;
        [Field("SJVideoPlayerApplicationWillTerminateNotification", "__Internal")]
        NSString SJVideoPlayerApplicationWillTerminateNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackControllerWillDeallocateNotification;
        [Field("SJVideoPlayerPlaybackControllerWillDeallocateNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackControllerWillDeallocateNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackTimeControlStatusDidChangeNotification;
        [Field("SJVideoPlayerPlaybackTimeControlStatusDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackTimeControlStatusDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPictureInPictureStatusDidChangeNotification;
        [Field("SJVideoPlayerPictureInPictureStatusDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPictureInPictureStatusDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidFinishNotification;
        [Field("SJVideoPlayerPlaybackDidFinishNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidFinishNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidReplayNotification;
        [Field("SJVideoPlayerPlaybackDidReplayNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidReplayNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackWillStopNotification;
        [Field("SJVideoPlayerPlaybackWillStopNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackWillStopNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidStopNotification;
        [Field("SJVideoPlayerPlaybackDidStopNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidStopNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackWillRefreshNotification;
        [Field("SJVideoPlayerPlaybackWillRefreshNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackWillRefreshNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidRefreshNotification;
        [Field("SJVideoPlayerPlaybackDidRefreshNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidRefreshNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackWillSeekNotification;
        [Field("SJVideoPlayerPlaybackWillSeekNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackWillSeekNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackDidSeekNotification;
        [Field("SJVideoPlayerPlaybackDidSeekNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackDidSeekNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerCurrentTimeDidChangeNotification;
        [Field("SJVideoPlayerCurrentTimeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerCurrentTimeDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerDurationDidChangeNotification;
        [Field("SJVideoPlayerDurationDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerDurationDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlayableDurationDidChangeNotification;
        [Field("SJVideoPlayerPlayableDurationDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPlayableDurationDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPresentationSizeDidChangeNotification;
        [Field("SJVideoPlayerPresentationSizeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPresentationSizeDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerPlaybackTypeDidChangeNotification;
        [Field("SJVideoPlayerPlaybackTypeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerPlaybackTypeDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerRateDidChangeNotification;
        [Field("SJVideoPlayerRateDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerRateDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerMutedDidChangeNotification;
        [Field("SJVideoPlayerMutedDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerMutedDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerVolumeDidChangeNotification;
        [Field("SJVideoPlayerVolumeDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerVolumeDidChangeNotification { get; }

        // extern const NSNotificationName _Nonnull SJVideoPlayerScreenLockStateDidChangeNotification;
        [Field("SJVideoPlayerScreenLockStateDidChangeNotification", "__Internal")]
        NSString SJVideoPlayerScreenLockStateDidChangeNotification { get; }

        // extern NSString *const _Nonnull SJVideoPlayerNotificationUserInfoKeySeekTime;
        [Field("SJVideoPlayerNotificationUserInfoKeySeekTime", "__Internal")]
        NSString SJVideoPlayerNotificationUserInfoKeySeekTime { get; }
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
        [Export("sj_usingBlock")]
        Action<NSTimer>? GetSj_usingBlock();
        
        [Export("setsj_usingBlock:")]
        void SetSj_usingBlock(NSTimerArgumentAction? usingBlock);

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
        //[Export("isFullscreen")]
        //bool IsFullscreen { get; set; }

        // @property (nonatomic) BOOL isFitOnScreen;
        //[Export("isFitOnScreen")]
        //bool IsFitOnScreen { get; set; }

        // @property (nonatomic) BOOL isPlayOnScrollView;
        //[Export("isPlayOnScrollView")]
        //bool IsPlayOnScrollView { get; set; }

        // @property (nonatomic) BOOL isScrollAppeared;
        //[Export("isScrollAppeared")]
        //bool IsScrollAppeared { get; set; }

        // @property (nonatomic) BOOL isFloatingMode;
        //[Export("isFloatingMode")]
        //bool IsFloatingMode { get; set; }

        // @property (nonatomic) BOOL isPictureInPictureMode;
        //[Export("isPictureInPictureMode")]
        //bool IsPictureInPictureMode { get; set; }
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
        [Export("presentView")]
        UIView? GetPresentView();

        [Export("setpresentView:")]
        void SetPresentView(UIView? view);
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
        NSString SJRotationManagerRotationNotification { get; }

        // extern const NSNotificationName _Nonnull SJRotationManagerTransitionNotification;
        [Field("SJRotationManagerTransitionNotification", "__Internal")]
        NSString SJRotationManagerTransitionNotification { get; }
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
        [Export("disabledAdjustSafeAreaInsetsMask")]
        SJSafeAreaInsetsMask GetDisabledAdjustSafeAreaInsetsMask();
        
        [Export("setdisabledAdjustSafeAreaInsetsMask:")]
        void SetDisabledAdjustSafeAreaInsetsMask(SJSafeAreaInsetsMask disabledAdjustSafeAreaInsetsMask);
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
    interface SJRotationManager_Internal //: SJRotationFullscreenViewControllerDelegate
    {
        // @required -(UIStatusBarStyle)preferredStatusBarStyleForRotationFullscreenViewController:(SJRotationFullscreenViewController * _Nonnull)viewController;
        [Export("preferredStatusBarStyleForRotationFullscreenViewController:")]
        UIStatusBarStyle PreferredStatusBarStyleForRotationFullscreenViewController(SJRotationFullscreenViewController viewController);

        // @required -(BOOL)prefersStatusBarHiddenForRotationFullscreenViewController:(SJRotationFullscreenViewController * _Nonnull)viewController;
        [Export("prefersStatusBarHiddenForRotationFullscreenViewController:")]
        bool PrefersStatusBarHiddenForRotationFullscreenViewController(SJRotationFullscreenViewController viewController);

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
        bool GetForcedRotation();
        
        [Export("setforcedRotation:")]
        void SetForcedRotation(bool forcedRotation);

        // @property (readonly, nonatomic) SJOrientation deviceOrientation;
        [Export("deviceOrientation")]
        SJOrientation DeviceOrientation();

        // @property (nonatomic) SJOrientation currentOrientation;
        [Export("currentOrientation")]
        SJOrientation GetCurrentOrientation();
        
        [Export("setcurrentOrientation:")]
        void SetCurrentOrientation(SJOrientation orientation);

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
        [Export("currentPlayingAsset")]
        SJVideoPlayerURLAsset? GetCurrentPlayingAsset();
        
        [Export("setcurrentPlayingAsset:")]
        void SetCurrentPlayingAsset(SJVideoPlayerURLAsset? playerUrlAsset);

        // @property (nonatomic, weak) SJVideoPlayerURLAsset * _Nullable switchingAsset;
        [Export("switchingAsset")]
        SJVideoPlayerURLAsset? GetSwitchingAsset();
        
        [Export("setswitchingAsset:")]
        void SetSwitchingAsset(SJVideoPlayerURLAsset? playerUrlAsset);

        // @property (nonatomic) SJDefinitionSwitchStatus status;
        [Export("status")]
        SJDefinitionSwitchStatus GetStatus();
        
        [Export("setstatus:")]
        void SetStatus(SJDefinitionSwitchStatus status);
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
        [Export("subtitles")]
        SJSubtitleItem[]? GetSubtitles();
        
        [Export("setsubtitles:")]
        void SetSubtitles(SJSubtitleItem[]? subtitleItems);
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

        // @required -(void)pushViewController:(UIViewController * _Nonnull)viewController animated:(BOOL)animated;
        [Export("pushViewController:animated:")]
        void PushViewController(UIViewController viewController, bool animated);
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
        nfloat GetSj_x();
        
        [Export("setsj_x:")]
        void SetSj_x(nfloat sjx);

        // @property (nonatomic) CGFloat sj_y;
        [Export("sj_y")]
        nfloat GetSj_y();
        
        [Export("setsj_y:")]
        void SetSj_y(nfloat sjy);

        // @property (nonatomic) CGFloat sj_w;
        [Export("sj_w")]
        nfloat GetSj_w();
        
        [Export("setsj_w:")]
        void SetSj_w(nfloat sjw);

        // @property (nonatomic) CGFloat sj_h;
        [Export("sj_h")]
        nfloat GetSj_h();
        
        [Export("setsj_h:")]
        void SetSj_h(nfloat sjh);

        // @property (nonatomic) CGSize sj_size;
        [Export("sj_size")]
        CGSize GetSj_size();
        
        [Export("setsj_size:")]
        void SetSj_size(CGSize sjsize);
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
        NSString SJIJKMediaPlayerErrorDomain { get; }
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
        double SJBaseVideoPlayerVersionNumber { get; }

        // extern const unsigned char[] SJBaseVideoPlayerVersionString;
        [Field("SJBaseVideoPlayerVersionString", "__Internal")]
        NSString SJBaseVideoPlayerVersionString { get; }
    }

#endregion

#region SJVideoPlayerApis

    // common argument actions
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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
*/
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

#endregion