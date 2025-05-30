using System.ComponentModel;
using W2ColormapGen.Managers;

namespace W2ColormapGen.UI
{
    internal class FrontendButton : Button
    {
        private FrontendSounds sound = FrontendSounds.Click;

        [Category("Frontend")]
        [Description("Which sound effect to play OnMouseDown")]
        [Browsable(true)]
        public FrontendSounds Sound { get { return sound; } set { sound = value; } }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            PlayClickSound();
            base.OnMouseDown(mevent);
        }

        private void PlayClickSound()
        {
            SoundManager.PlaySound(sound);
        }
    }
}
