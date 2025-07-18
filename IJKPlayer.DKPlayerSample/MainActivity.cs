using Android.Util;
using Android.Views;
using Bumptech.Glide;
using Xyz.Doikki.Videocontroller;
using Xyz.Doikki.Videocontroller.Component;
using Xyz.Doikki.Videoplayer.Ijk;
using Xyz.Doikki.Videoplayer.Player;
using VideoView = Xyz.Doikki.Videoplayer.Player.VideoView;

namespace IJKPlayer.DKPlayerSample
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private VideoView? playerView = null;
        private StandardVideoController? playerController = null;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create a vertical LinearLayout to hold the VideoViews
            var layout = new LinearLayout(this)
            {
                Orientation = Orientation.Vertical
            };

            // 关键修改2：创建全屏容器
            var playerContainer = new FrameLayout(this);
            var layoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent,
                (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 200, Resources.DisplayMetrics)
            );
            playerContainer.LayoutParameters = layoutParams;

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
            playerView.SetLooping(true);

            var playerLayoutParams = new LinearLayout.LayoutParams(
                ViewGroup.LayoutParams.MatchParent,
                ViewGroup.LayoutParams.MatchParent
            );
            playerView.LayoutParameters = playerLayoutParams;

            // Add VideoViews to layout
            playerContainer.AddView(playerView);
            layout.AddView(playerContainer);

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