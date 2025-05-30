using IrrKlang;

namespace W2ColormapGen.Managers
{
    internal class SoundManager
    {
        static Dictionary<FrontendSounds, ISoundSource> Sounds = new Dictionary<FrontendSounds, ISoundSource>();

        static ISoundEngine engine;

        public static void Initialize()
        {
            engine = new ISoundEngine();

            LoadSound(FrontendSounds.Click, @"Effects\MineImpact.wav");
            LoadSound(FrontendSounds.Impact, @"Effects\CrossImpact.wav");
            LoadSound(FrontendSounds.SnotPlop, @"Effects\SnotPlop.wav");
            LoadSound(FrontendSounds.CowMoo, @"Effects\CowMoo.wav");
            LoadSound(FrontendSounds.YesSir, @"Speech\yessir.wav");
        }

        public static ISoundSource LoadSound(FrontendSounds sound, string path)
        {
            string fullPath = Path.Combine(Program.GamePath, @"Data\Wav", path);

            if (!File.Exists(fullPath))
                return null;

            ISoundSource source = engine.AddSoundSourceFromFile(fullPath, StreamMode.NoStreaming, true);

            if (sound != FrontendSounds.None)
                Sounds.Add(sound, source);

            return source;
        }

        public static void RemoveSound(ISoundSource source)
        {
            engine.RemoveSoundSource(source.Name);
        }

        public static void Deinitialize()
        {
            engine.RemoveAllSoundSources();

            foreach (var item in Sounds)
            {
                item.Value.Dispose();
            }

            Sounds.Clear();

            engine.Dispose();
        }

        internal static ISound Play(ISoundSource source, bool loop)
        {
            if (source == null) return null;

            return engine.Play2D(source, loop, false, false);
        }

        internal static ISound PlaySound(FrontendSounds sound) => PlaySound(sound, false);

        internal static ISound PlaySound(FrontendSounds sound, bool loop)
        {
            if (sound == FrontendSounds.None)
                return null;

            if (Sounds.TryGetValue(sound, out ISoundSource soundInstance))
            {
                return engine.Play2D(soundInstance, loop, false, false);
            }

            return null;
        }
    }

    internal enum FrontendSounds
    {
        None,
        Click,
        Impact,
        SnotPlop,
        CowMoo,
        YesSir
    }
}
