using System.ComponentModel;
using W2ColormapGen.Managers;

namespace W2ColormapGen.UI
{
    internal class FrontendCheckBox : CheckBox
    {
        private FrontendSounds sound = FrontendSounds.Impact;

        [Category("Frontend")]
        [Description("Which sound effect to play OnMouseDown")]
        [Browsable(true)]
        public FrontendSounds Sound { get { return sound; } set { sound = value; } }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            SoundManager.PlaySound(Sound);
            base.OnMouseDown(mevent);
        }

        public void SetValueWithoutNotify(bool value)
        {
            FrontendSounds cache = sound;
            sound = FrontendSounds.None;

            Checked = value;

            sound = cache;
        }
    }
}
