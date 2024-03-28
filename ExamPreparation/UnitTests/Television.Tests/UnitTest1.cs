namespace Television.Tests
{
    using System;
    using NUnit.Framework;
    public class Tests
    {
        private TelevisionDevice tvDevice;
        private const string Brand = "LG";
        private const double Price = 1999.99;
        private const int ScreenWidth = 60;
        private const int ScreenHeight = 20;

        [SetUp]
        public void Setup()
        {
            tvDevice = new TelevisionDevice(Brand, Price, ScreenWidth, ScreenHeight);
        }

        [Test]
        public void Ctor_InitializesObject_PropertiesAreCorrect()
        {
            Assert.That(tvDevice, Is.Not.Null);
            Assert.That(tvDevice.Brand, Is.EqualTo(Brand));
            Assert.That(tvDevice.Price, Is.EqualTo(Price));
            Assert.That(tvDevice.ScreenWidth, Is.EqualTo(ScreenWidth));
            Assert.That(tvDevice.ScreenHeigth, Is.EqualTo(ScreenHeight));
            Assert.That(tvDevice.CurrentChannel, Is.EqualTo(0));
            Assert.That(tvDevice.Volume, Is.EqualTo(13));
            Assert.That(tvDevice.IsMuted, Is.EqualTo(false));
        }

        [Test]
        public void ToString_Returns_CorrectString()
        {
            string expected = $"TV Device: {Brand}, Screen Resolution: {ScreenWidth}x{ScreenHeight}, Price {Price}$";
            string actual = tvDevice.ToString();
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void SwitchOn_SwitchesTheTvOn()
        {
            string expected = $"Cahnnel 0 - Volume 13 - Sound On";
            string actual = tvDevice.SwitchOn();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ChangeChannel_SetsTheRightChannel()
        {
            int expectedChannel = 7;
            var actual = tvDevice.ChangeChannel(expectedChannel);
            Assert.That(expectedChannel, Is.EqualTo(actual));
        }


        [Test]
        public void ChangeChannel_WhenChannelIsLessThan0_ThrowsException()
        {
            int channel = -7;
            Exception ex = Assert.Throws<ArgumentException>(() => 
                tvDevice.ChangeChannel(channel));
        }

        [Test]
        public void Mute_Toggles_TheMute()
        {
            tvDevice.MuteDevice();
            Assert.That(tvDevice.IsMuted, Is.EqualTo(true));

            tvDevice.MuteDevice();
            Assert.That(tvDevice.IsMuted, Is.EqualTo(false));
        }

        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeUp_Sets_CorrectVolume(int volumeChange)
        {
            string expected = "Volume: 20";
            string actual = tvDevice.VolumeChange("UP", volumeChange);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void VolumeUp_WhenVolumeIsMoreThan100_SetsVolumeTo100()
        {
            string expected = "Volume: 100";
            string actual = tvDevice.VolumeChange("UP", 100);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(7)]
        [TestCase(-7)]
        public void VolumeDown_Sets_CorrectVolume(int volumeChange)
        {
            string expected = "Volume: 6";
            string actual = tvDevice.VolumeChange("DOWN", volumeChange);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void VolumeDown_WhenVolumeIsLessThan0_SetsVolumeTo0()
        {
            string expected = "Volume: 0";
            string actual = tvDevice.VolumeChange("DOWN", -100);
            Assert.That(expected, Is.EqualTo(actual));
        }
    }

}