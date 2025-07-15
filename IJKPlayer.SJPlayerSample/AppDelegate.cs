using IJKPlayer.SJPlayer;
using ObjCRuntime;

namespace IJKPlayer.SJPlayerSample;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// create a UIViewController with a single UILabel
		var vc = new UIViewController();
		var avPlayer = new SJVideoPlayer();
		var ijkPlayer = new SJVideoPlayer();
        var urlAsset = new SJVideoPlayerURLAsset(
            title: "Big Buck Bunny Trailer",
            URL: new NSUrl("https://gastaticqn.gatime.cn/big_buck_bunny.mp4"),
            playModel: new SJPlayModel());

        //Use AVMedia for default
        #region 1. No need set PlaybackController
        //The following code will cause NSInternalInconsistencyException: You must override playerWithMedia:completionHandler: in a subclass.
        //SJAVMediaPlaybackController playbackController = new SJAVMediaPlaybackController();
        //player.PlaybackController = playbackController;
        #endregion
        
        //Set ijkplayer
        #region 2. Set IJKFFOptions & JKKMediaPlaybackController
        SJIJKMediaPlaybackController controller = new SJIJKMediaPlaybackController();
        IJKFFOptions options = IJKFFOptions.OptionsByDefault;
        //options.SetPlayerOptionIntValue(-1, "probesize");
        //options.SetPlayerOptionIntValue(0, "packet-buffering");
        //options.SetPlayerOptionIntValue(0, "enable-accurate-seek");
        //options.SetPlayerOptionIntValue(10 * 1024 * 1024, "max-buffer-size");
        controller.Options = options;
        ijkPlayer.PlaybackController = controller;
        #endregion
        
        #region 3. iOS 14.0 support PictureInPicture
        //Don't forget add Audio AirPlay and Picture in Picture in Info.plist's Application Background Modes
        //You can use IsPictureInPictureSupported() to check if PIP is supported
        Console.WriteLine($"AVPlayer PIP supported: {avPlayer.PlaybackController.IsPictureInPictureSupported()}");
        Console.WriteLine($"IJKPlayer PIP supported: {ijkPlayer.PlaybackController.IsPictureInPictureSupported()}");
        #endregion

        #region 4. Small View Floating 
        var avSmallViewController = new SJSmallViewFloatingController();
        avSmallViewController.LayoutPosition = SJSmallViewLayoutPosition.BottomRight;
        avSmallViewController.LayoutInsets = new UIEdgeInsets(20, 12, 20, 12);
        avSmallViewController.LayoutSize = new CGSize(260, 260 * 9 / 16.0);
        avSmallViewController.FloatingViewShouldAppear = (controller) => { return true; };
        avSmallViewController.OnSingleTapped = (controller) =>
        {
            if (avPlayer.IsPaused)
            {
                avPlayer.Play();
            }
            else
            {
                avPlayer.Pause();
            }
        };
        avSmallViewController.OnDoubleTapped = (controller) =>
        {
            controller.Dismiss();
        };
        var avSmallViewObserver = avSmallViewController.Observer();
        avSmallViewObserver.OnAppearChanged = (controller) =>
        {
            Console.WriteLine($"AVPlayer Small view isAppeared: {controller.IsAppeared}");
        };
        avPlayer.SmallViewFloatingController = avSmallViewController;
        avPlayer.SmallViewFloatingController.Enabled = true;
        avPlayer.DefaultSmallViewControlLayer.TopContainerView.CleanColors();
        
        var ijkSmallViewController = new SJSmallViewFloatingController();
        ijkSmallViewController.LayoutPosition = SJSmallViewLayoutPosition.BottomRight;
        ijkSmallViewController.LayoutInsets = new UIEdgeInsets(20, 12, 20, 12);
        ijkSmallViewController.LayoutSize = new CGSize(260, 260 * 9 / 16.0);
        ijkSmallViewController.FloatingViewShouldAppear = (controller) => { return true; };
        ijkSmallViewController.OnSingleTapped = (controller) =>
        {
            if (avPlayer.IsPaused)
            {
                avPlayer.Play();
            }
            else
            {
                avPlayer.Pause();
            }
        };
        ijkSmallViewController.OnDoubleTapped = (controller) =>
        {
            controller.Dismiss();
        };
        var ijkSmallViewObserver = ijkSmallViewController.Observer();
        ijkSmallViewObserver.OnAppearChanged = (controller) =>
        {
            Console.WriteLine($"IJKPlayer Small view isAppeared: {controller.IsAppeared}");
        };
        ijkPlayer.SmallViewFloatingController = ijkSmallViewController;
        ijkPlayer.SmallViewFloatingController.Enabled = true;
        ijkPlayer.DefaultSmallViewControlLayer.TopContainerView.CleanColors();

        var avSmallViewLabel = new UILabel(Window!.Frame)
        {
            BackgroundColor = UIColor.SystemBackground,
            TextAlignment = UITextAlignment.Center,
            Text = $"AVPlayer Small View",
            AutoresizingMask = UIViewAutoresizing.All,
        };
        avSmallViewLabel.Frame = new CGRect(0, 290, UIScreen.MainScreen.Bounds.Width, 30);
        var avTapGestureRecognizer = new UITapGestureRecognizer();
        avTapGestureRecognizer.AddTarget(() =>
        {
            //player.Pause();
            avPlayer.SmallViewFloatingController.Show();
        });
        avSmallViewLabel.UserInteractionEnabled = true;
        avSmallViewLabel.AddGestureRecognizer(avTapGestureRecognizer);
        vc.View!.AddSubview(avSmallViewLabel);
        
        var ijkSmallViewLabel = new UILabel(Window!.Frame)
        {
            BackgroundColor = UIColor.SystemBackground,
            TextAlignment = UITextAlignment.Center,
            Text = $"IJKPlayer Small View",
            AutoresizingMask = UIViewAutoresizing.All,
        };
        ijkSmallViewLabel.Frame = new CGRect(0, 630, UIScreen.MainScreen.Bounds.Width, 30);
        var ijkTapGestureRecognizer = new UITapGestureRecognizer();
        ijkTapGestureRecognizer.AddTarget(() =>
        {
            //player.Pause();
            ijkPlayer.SmallViewFloatingController.Show();
        });
        ijkSmallViewLabel.UserInteractionEnabled = true;
        ijkSmallViewLabel.AddGestureRecognizer(ijkTapGestureRecognizer);
        vc.View!.AddSubview(ijkSmallViewLabel);

        #endregion

        #region 5. Autoplay Config

        avPlayer.AutoplayWhenSetNewAsset = false;
        ijkPlayer.AutoplayWhenSetNewAsset = false;

        #endregion

        #region 6. Subtitle Config

        var subtitleDict = new Dictionary<string, int>()
        {
            { "Subtitle 1 duration 2s", 2 },
            { "Subtitle 2 duration 4s", 4 },
            { "Subtitle 3 duration 6s", 6 },
            { "Subtitle 4 duration 8s", 8 },
            { "Subtitle 5 duration 10s", 10 }
        };
        var subtitles = new List<SJSubtitleItem>();
        var start = 1;    // Subtitle show start time
        var duration = 0; // Subtitle duration seconds
        foreach (var subtitle in subtitleDict.Keys)
        {
            var content = new NSAttributedString();
            // content object must be reasigned again in C# code (otherwise text maker will not be effected)
            content = content.Sj_UIKitText((textMaker) =>
            {
                // Inorder to fix SJUIKitTextMakerProtocol not found errors in binding project, you may add [BaseType(typeof(NSObject))] to SJUIKitTextMakerProtocol
                // But it will cause new InvalidCastException because of SJUIKitTextMakerProtocol is a pure protocol can not be used as a NSObject.
                // The right solution is to replace all SJUIKitTextMakerProtocol to SJUIKitTextMaker expect SJUIKitTextMakerProtocol's self definition.
                textMaker.Font.Invoke(UIFont.BoldSystemFontOfSize(17));
                textMaker.Append.Invoke(new NSString(subtitle));
                textMaker.TextColor.Invoke(UIColor.White);
                textMaker.Stroke.Invoke((stroke) =>
                {
                    stroke.Width = -1;
                    stroke.Color = UIColor.Black;
                });
            });
            duration = subtitleDict[subtitle];
            subtitles.Add(new SJSubtitleItem(content, new SJTimeRange() { start = start, duration = duration }));
            start += duration + 1;
        }

        urlAsset.Subtitles = subtitles.ToArray();

        //Subtitle view config
        //player.SubtitlePopupController.View.BackgroundColor = UIColor.FromWhiteAlpha(0, 0.6f);
        //player.SubtitlePopupController.View.Layer.CornerRadius = 15;
        //player.SubtitlePopupController.ContentInsets = new UIEdgeInsets(6, 11, 6, 11);

        #endregion

        avPlayer.URLAsset = urlAsset;
        avPlayer.PresentView.PlaceholderImageView.Image = UIImage.FromFile("big_buck_bunny.jpg");
        avPlayer.View.BackgroundColor = UIColor.Black;
        avPlayer.View.Frame = new CGRect(0, 60, UIScreen.MainScreen.Bounds.Width, 220);
        
        ijkPlayer.URLAsset = urlAsset;
        ijkPlayer.PresentView.PlaceholderImageView.Image = UIImage.FromFile("big_buck_bunny.jpg");
        ijkPlayer.View.BackgroundColor = UIColor.Black;
        ijkPlayer.View.Frame = new CGRect(0, 400, UIScreen.MainScreen.Bounds.Width, 220);
        
        //Use Autoplay config instead
        //player.Pause();

        vc.View!.AddSubview(avPlayer.View);
        vc.View!.AddSubview(ijkPlayer.View);

        Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		return true;
	}

	public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, [Transient] UIWindow forWindow)
	{
		//return base.GetSupportedInterfaceOrientations(application, forWindow);
		return SJRotationManager.SupportedInterfaceOrientationsForWindow(forWindow);
	}
}

