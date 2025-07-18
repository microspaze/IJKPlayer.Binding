using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xyz.Doikki.Videoplayer.Player
{
    public partial class BaseVideoView : global::Xyz.Doikki.Videoplayer.Controller.IMediaPlayerControl
    {
        public void SetRotation(float rotation)
        {
            MRenderView?.SetVideoRotation((int)rotation);
        }
    }
}
