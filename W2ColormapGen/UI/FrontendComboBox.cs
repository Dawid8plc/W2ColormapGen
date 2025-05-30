using System.ComponentModel;
using W2ColormapGen.Managers;

namespace W2ColormapGen.UI
{
    internal class FrontendComboBox : ComboBox
    {
        private FrontendSounds sound = FrontendSounds.Impact;

        [Category("Frontend")]
        [Description("Which sound effect to play OnMouseDown")]
        [Browsable(true)]
        public FrontendSounds Sound { get { return sound; } set { sound = value; } }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            SoundManager.PlaySound(sound);
            base.OnSelectedIndexChanged(e);
        }

        public void SetValueWithoutNotify(int value)
        {
            FrontendSounds cache = sound;
            sound = FrontendSounds.None;

            SelectedIndex = value;

            sound = cache;
        }

        public void SetValueWithoutNotify(string value)
        {
            FrontendSounds cache = sound;
            sound = FrontendSounds.None;

            Text = value;

            sound = cache;
        }
    }

}
