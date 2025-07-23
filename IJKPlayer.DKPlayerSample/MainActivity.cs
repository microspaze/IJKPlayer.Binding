using Android.Util;
using Android.Views;
using AndroidX.AppCompat.App;
using AndroidX.ConstraintLayout.Widget;
using Bumptech.Glide;
using Xyz.Doikki.Videocontroller;
using Xyz.Doikki.Videocontroller.Component;
using Xyz.Doikki.Videoplayer.Ijk;
using Xyz.Doikki.Videoplayer.Player;
using VideoView = Xyz.Doikki.Videoplayer.Player.VideoView;

namespace IJKPlayer.DKPlayerSample
{
    [Activity(
        Theme = "@style/Maui.MainTheme",
        Label = "@string/app_name",
        MainLauncher = true,
        ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class MainActivity : AppCompatActivity
    {
        private VideoView? playerView = null;
        private StandardVideoController? playerController = null;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create a vertical LinearLayout to hold the VideoViews
            var layout = new ConstraintLayout(this)
            {
                LayoutParameters = new ViewGroup.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent)
            };
            layout.SetFitsSystemWindows(true);

            var isLive = false;

            // Create IJKPlayer Controller
            playerController = new StandardVideoController(this);
            //ijkController.SetBackgroundColor(Android.Graphics.Color.Black);
            var prepareView = new PrepareView(this);
            prepareView.SetClickStart();
            var thumbView = prepareView.FindViewById(Resource.Id.thumb) as ImageView;
            Glide.With(this).Load("https://gastaticqn.gatime.cn/big_buck_bunny.jpg").Into(thumbView!);
            playerController.AddControlComponent(prepareView);
            playerController.AddControlComponent(new CompleteView(this));
            playerController.AddControlComponent(new ErrorView(this));
            //playerController.AddDefaultControlComponent("Big Buck Bunny Trailer (IJKPlayer)", isLive);
            var titleView = new TitleView(this);
            titleView.SetTitle("Big Buck Bunny Trailer (IJKPlayer)");
            playerController.AddControlComponent(titleView);
            if (isLive)
            {
                playerController.AddControlComponent(new LiveControlView(this));
            }
            else
            {
                var vodControlView = new VodControlView(this);
                vodControlView.ShowBottomProgress(false);
                playerController.AddControlComponent(vodControlView);
            }

            var gestureView = new GestureView(this);
            playerController.AddControlComponent(gestureView);
            playerController.SetCanChangePosition(!isLive);//根据是否为直播决定是否需要滑动调节进度
            playerController.SetEnableInNormal(true);//竖屏也开启手势操作，默认关闭
            playerController.SetEnableOrientation(false);//根据屏幕方向自动进入/退出全屏
            playerController.SetGestureEnabled(true);//滑动调节亮度，音量，进度，默认开启
            playerController.SetAdaptCutout(true);//适配刘海屏，默认开启
            playerController.SetDoubleTapTogglePlayEnabled(true);//双击播放暂停，默认开启

            // Create IJKPlayer VideoView
            playerView = new VideoView(this);
            playerView.SetPlayerFactory(IjkPlayerFactory.Create());
            //playerView.SetPlayerFactory(AndroidMediaPlayerFactory.Create());
            playerView.SetUrl("https://gastaticqn.gatime.cn/big_buck_bunny.mp4");
            playerView.SetVideoController(playerController);
            playerView.SetScreenScaleType(BaseVideoView.ScreenScaleMatchParent);
            playerView.SetLooping(true);

            var layoutParams = new ConstraintLayout.LayoutParams(
                ConstraintLayout.LayoutParams.MatchParent,
                0 // 高度设为0
            );
            layoutParams.TopToTop = ConstraintLayout.LayoutParams.ParentId;
            layoutParams.LeftToLeft = ConstraintLayout.LayoutParams.ParentId;
            layoutParams.RightToRight = ConstraintLayout.LayoutParams.ParentId;
            layoutParams.DimensionRatio = "16:9";

            playerView.LayoutParameters = layoutParams;

            // Add VideoViews to layout
            layout.AddView(playerView);

            // Set the layout as the content view
            SetContentView(layout);
        }

        protected override void OnPause()
        {
            base.OnPause();
            playerView?.Pause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            playerView?.Resume();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            playerView?.Release();
        }

        public override void OnBackPressed()
        {
            if (playerView == null || !playerView.OnBackPressed())
            {
                base.OnBackPressed();
            }
        }
    }
}