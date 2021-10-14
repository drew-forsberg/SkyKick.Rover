﻿using System.Linq;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace SkyKick.Rover.UnitTests.Support
{
    /// <summary>
    /// Support class that enables easier mocking of data in a test method
    /// </summary>
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(() =>
        {
            var fixture = new Fixture().Customize(
                new CompositeCustomization(
                    new AutoMoqCustomization(),
                new SupportMutableValueTypesCustomization()));

            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture;
        })
        {
        }
    }
}
