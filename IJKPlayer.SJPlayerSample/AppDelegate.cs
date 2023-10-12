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
		var player = new SJVideoPlayer();
        var useIJK = false;
		if (useIJK)
		{
			SJIJKMediaPlaybackController controller = new SJIJKMediaPlaybackController();
			IJKFFOptions options = IJKFFOptions.OptionsByDefault;
			options.SetPlayerOptionIntValue(-1, "probesize");
			options.SetPlayerOptionIntValue(0, "packet-buffering");
			options.SetPlayerOptionIntValue(0, "enable-accurate-seek");
			//options.SetPlayerOptionIntValue(10 * 1024 * 1024, "max-buffer-size");
			controller.Options = options;
			player.PlaybackController = controller;
		}
		else
		{
            //Use AVMedia for default
            #region 1. No need set PlaybackController
            //The following code will cause NSInternalInconsistencyException: You must override playerWithMedia:completionHandler: in a subclass.
            //SJAVMediaPlaybackController playbackController = new SJAVMediaPlaybackController();
            //player.PlaybackController = playbackController;
            #endregion

            #region 2. iOS 14.0 support PictureInPicture
			//Don't forget add Audio AirPlay and Picture in Picture in Info.plist's Application Background Modes
            //You can use IsPictureInPictureSupported() to check if PIP is supported
            Console.WriteLine(player.PlaybackController.IsPictureInPictureSupported());
            #endregion
        }

        #region 3. Small View Floating 
        var smallViewController = new SJSmallViewFloatingController();
        smallViewController.LayoutPosition = SJSmallViewLayoutPosition.BottomRight;
        smallViewController.LayoutInsets = new UIEdgeInsets(20, 12, 20, 12);
        smallViewController.LayoutSize = new CGSize(260, 260 * 9 / 16.0);
        smallViewController.FloatingViewShouldAppear = (controller) => { return true; };
        smallViewController.OnSingleTapped = (controller) =>
        {
            if (player.IsPaused)
            {
                player.Play();
            }
            else
            {
                player.Pause();
            }
        };
        smallViewController.OnDoubleTapped = (controller) =>
        {
            controller.Dismiss();
        };
        var smallViewObserver = smallViewController.Observer();
        smallViewObserver.OnAppearChanged = (controller) =>
        {
            Console.WriteLine($"Small view isAppeared: {controller.IsAppeared}");
        };
        player.SmallViewFloatingController = smallViewController;
        player.SmallViewFloatingController.Enabled = true;
        player.DefaultSmallViewControlLayer.TopContainerView.CleanColors();

        var smallViewLabel = new UILabel(Window!.Frame)
        {
            BackgroundColor = UIColor.SystemBackground,
            TextAlignment = UITextAlignment.Center,
            Text = $"Small View",
            AutoresizingMask = UIViewAutoresizing.All,
        };
        var tapGestureRecognizer = new UITapGestureRecognizer();
        tapGestureRecognizer.AddTarget(() =>
        {
            //player.Pause();
            player.SmallViewFloatingController.Show();
        });
        smallViewLabel.UserInteractionEnabled = true;
        smallViewLabel.AddGestureRecognizer(tapGestureRecognizer);
        vc.View!.AddSubview(smallViewLabel);

        #endregion

        var urlAsset = new SJVideoPlayerURLAsset(
            title: "Video Title",
            URL: new NSUrl("https://gastaticqn.gatime.cn/big_buck_bunny.mp4"),
            playModel: new SJPlayModel());
        player.URLAsset = urlAsset;
        player.PresentView.PlaceholderImageView.Image = UIImage.FromFile("big_buck_bunny.jpg");
        player.View.BackgroundColor = UIColor.Black;
        player.View.Frame = new CGRect(0, 50, UIScreen.MainScreen.Bounds.Width, 220);
        player.Pause();

        vc.View!.AddSubview(player.View);

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

