using NUnit.Framework;
using ricky_capg_sample_challenge_2;
using System;
using static ricky_capg_sample_challenge_2.Sampler;
using System.IO;


namespace TestLibrary
{

    public class SamplerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RelativeToCommonBaseTest()
        {
            string result = Sampler.RelativeToCommonBase("/home/daniel/memes", "/home/daniel/work");
            Assert.That("/home/daniel", Is.EqualTo(result));
        }

        [Test]
        public void ClosestWordTest()
        {
            string result = Sampler.ClosestWord("ricky", new string[] { "raiki", "rambo", "riki", "ricki", "Rhandy" });
            Assert.That("ricki", Is.EqualTo(result));
        }

        [Test]
        public void SpeedAtTimeTest()
        {
            // simple example
            // 2 points only
            // in 10 second travel time on a distance of 5
            Sampler.PointInTime start = new Sampler.PointInTime(1, 1, 1729502700);
            Sampler.PointInTime end = new Sampler.PointInTime(4, 5, 1729502710);
            Sampler.PointInTime[] path = new PointInTime[2] { start, end };
            var result = Sampler.SpeedAtTime(1729502702, path);
            Assert.That(0.5, Is.EqualTo(result));
        }
    }
}
