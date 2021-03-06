﻿using System.Windows;
using ReverseKinematicsPathFinding.Model;
using Xunit;

namespace ReverseKinematicsPathFindingTests.Model
{
	public class RobotTests
	{
		private readonly Robot _unitUnderTest = new Robot(10, 10);

		[Fact]
		public void Constructor_ScreenDimensions_PositionSetToCenter()
		{
			var unitUnderTest = new Robot(2, 10);
			
			Assert.Equal(1, unitUnderTest.Position.X);
			Assert.Equal(5, unitUnderTest.Position.Y);
		}

		[Fact]
		public void Reset_Always_RobotReset()
		{
			var position = new Point(2, 10);
			var endPosition = new Point(2, 10);
			_unitUnderTest.Arm.SetArmPosition(position);
			_unitUnderTest.Arm.SetArmPosition(endPosition);

			_unitUnderTest.Reset();

			Assert.NotEqual(position, _unitUnderTest.Arm.Joint);
			Assert.NotEqual(endPosition, _unitUnderTest.Arm.End);
			Assert.Equal(_unitUnderTest.Position, _unitUnderTest.Destination);
		}
	}
}