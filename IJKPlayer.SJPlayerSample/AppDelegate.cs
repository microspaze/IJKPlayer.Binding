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
		vc.View!.AddSubview (new UILabel (Window!.Frame) {
			BackgroundColor = UIColor.SystemBackground,
			TextAlignment = UITextAlignment.Center,
			Text = "Hello, iOS!",
			AutoresizingMask = UIViewAutoresizing.All,
		});

		IJKFFOptions options = IJKFFOptions.OptionsByDefault;
		options.SetPlayerOptionIntValue(-1, "probesize");
		options.SetPlayerOptionIntValue(0, "packet-buffering");
		options.SetPlayerOptionIntValue(0, "enable-accurate-seek");
		//options.SetPlayerOptionIntValue(10 * 1024 * 1024, "max-buffer-size");
		SJVideoPlayer player = new SJVideoPlayer();
		SJVideoPlayerURLAsset urlAsset = new SJVideoPlayerURLAsset(
			"Video Title",
			new NSUrl("https://gastaticqn.gatime.cn/big_buck_bunny.mp4"),
			SJPlayModel_SJDeprecated.UIViewPlayModel);
		SJIJKMediaPlaybackController controller = new SJIJKMediaPlaybackController();
		controller.Options = options;
		player.IJKPlaybackController = controller;
		player.URLAsset = urlAsset;
		player.PresentView.PlaceholderImageView.Image = UIImage.FromFile("big_buck_bunny.jpg");
		player.Pause();
		UIView playerView = player.View;
		playerView.BackgroundColor = UIColor.Black;
		playerView.Frame = new CGRect(0, 50, UIScreen.MainScreen.Bounds.Width, 220);
		vc.View!.AddSubview(playerView);
		
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

