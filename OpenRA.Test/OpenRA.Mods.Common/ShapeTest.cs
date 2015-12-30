#region Copyright & License Information
/*
 * Copyright 2007-2015 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation. For more information,
 * see COPYING.
 */
#endregion

using NUnit.Framework;
using OpenRA.Mods.Common.HitShapes;

namespace OpenRA.Test
{
	[TestFixture]
	public class ShapeTest
	{
		IHitShape shape;

		[TestCase(TestName = "CircleShape reports accurate distance")]
		public void Circle()
		{
			shape = new CircleShape(new WDist(1234));
			shape.Initialize();

			Assert.That(shape.DistanceFromEdge(new WVec(100, 100, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(1000, 0, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(2000, 2000, 0)).Length,
				Is.EqualTo(1594));

			Assert.That(new CircleShape(new WDist(73))
				.DistanceFromEdge(new WVec(150, -100, 0)).Length,
				Is.EqualTo(107));

			Assert.That(new CircleShape(new WDist(55))
				.DistanceFromEdge(new WVec(30, -45, 0)).Length,
				Is.EqualTo(0));
		}

		[TestCase(TestName = "CapsuleShape report accurate distance")]
		public void Capsule()
		{
			shape = new CapsuleShape(new int2(-50, 0), new int2(500, 235), new WDist(50));
			shape.Initialize();

			Assert.That(shape.DistanceFromEdge(new WVec(300, 100, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(-50, 0, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(518, 451, 0)).Length,
				Is.EqualTo(166));

			Assert.That(shape.DistanceFromEdge(new WVec(-50, -50, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(-41, 97, 0)).Length,
				Is.EqualTo(35));

			Assert.That(shape.DistanceFromEdge(new WVec(339, 41, 0)).Length,
				Is.EqualTo(64));
		}

		[TestCase(TestName = "RectangleShape report accurate distance")]
		public void Rectangle()
		{
			shape = new RectangleShape(new int2(-123, -456), new int2(100, 100));
			shape.Initialize();

			Assert.That(shape.DistanceFromEdge(new WVec(10, 10, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(-100, 50, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(0, 200, 0)).Length,
				Is.EqualTo(100));

			Assert.That(shape.DistanceFromEdge(new WVec(123, 0, 0)).Length,
				Is.EqualTo(24));

			Assert.That(shape.DistanceFromEdge(new WVec(-100, -400, 0)).Length,
				Is.EqualTo(0));

			Assert.That(shape.DistanceFromEdge(new WVec(-1000, -400, 0)).Length,
				Is.EqualTo(877));
		}
	}
}