namespace Ludotek.Repositories.Models
{
    using System.Collections.Generic;

    public class WheelResponse
    {
        public Data Data { get; set; }
    }

    public class Data
    {
        public List<Wheel> Wheels { get; set; }
        public bool MoreWheelsAvailable { get; set; }
    }

    public class Wheel
    {
        public WheelConfig Config { get; set; }
        public long? Created { get; set; }
        public long? LastRead { get; set; }
        public long? LastWrite { get; set; }
        public string Path { get; set; }
        public int ReadCount { get; set; }
        public string ShareMode { get; set; }
    }

    public class WheelConfig
    {
        public bool DisplayWinnerDialog { get; set; }
        public bool SlowSpin { get; set; }
        public string PageBackgroundColor { get; set; }
        public string Description { get; set; }
        public bool AnimateWinner { get; set; }
        public string WinnerMessage { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public bool AutoRemoveWinner { get; set; }
        public string Path { get; set; }
        public string CustomPictureName { get; set; }
        public string CustomCoverImageDataUri { get; set; }
        public bool PlayClickWhenWinnerRemoved { get; set; }
        public string DuringSpinSound { get; set; }
        public int MaxNames { get; set; }
        public string CenterText { get; set; }
        public int AfterSpinSoundVolume { get; set; }
        public int SpinTime { get; set; }
        public string HubSize { get; set; }
        public string CoverImageName { get; set; }
        public List<Entry> Entries { get; set; }
        public bool IsAdvanced { get; set; }
        public string GalleryPicture { get; set; }
        public string CustomPictureDataUri { get; set; }
        public bool ShowTitle { get; set; }
        public bool DisplayHideButton { get; set; }
        public string AfterSpinSound { get; set; }
        public List<ColorSetting> ColorSettings { get; set; }
        public int DuringSpinSoundVolume { get; set; }
        public bool DisplayRemoveButton { get; set; }
        public string PictureType { get; set; }
        public bool AllowDuplicates { get; set; }
        public string CoverImageType { get; set; }
        public bool DrawOutlines { get; set; }
        public bool LaunchConfetti { get; set; }
        public bool DrawShadow { get; set; }
    }

    public class Entry
    {
        public string Text { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public string Id { get; set; }
        public bool Enabled { get; set; }
        public string Sound { get; set; }
        public string Message { get; set; }
    }

    public class ColorSetting
    {
        public string Color { get; set; }
        public bool Enabled { get; set; }
    }
}
