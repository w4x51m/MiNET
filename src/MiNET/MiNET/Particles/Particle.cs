﻿#region LICENSE

// The contents of this file are subject to the Common Public Attribution
// License Version 1.0. (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
// https://github.com/NiclasOlofsson/MiNET/blob/master/LICENSE. 
// The License is based on the Mozilla Public License Version 1.1, but Sections 14 
// and 15 have been added to cover use of software over a computer network and 
// provide for limited attribution for the Original Developer. In addition, Exhibit A has 
// been modified to be consistent with Exhibit B.
// 
// Software distributed under the License is distributed on an "AS IS" basis,
// WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License for
// the specific language governing rights and limitations under the License.
// 
// The Original Code is MiNET.
// 
// The Original Developer is the Initial Developer.  The Initial Developer of
// the Original Code is Niclas Olofsson.
// 
// All portions of the code written by Niclas Olofsson are Copyright (c) 2014-2018 Niclas Olofsson. 
// All Rights Reserved.

#endregion

using System.Numerics;
using MiNET.Net;
using MiNET.Worlds;

namespace MiNET.Particles
{
	public enum ParticleType
	{
		Bubble = 1,
		Critical,
		BlockForceField,
		Smoke,
		Explode,
		WhiteSmoke,
		Flame,
		Lava,
		LargeSmoke,
		Redstone,
		RisingRedDust,
		ItemBreak,
		SnowballPoof,
		LargeExplode,
		HugeExplode,
		MobFlame,
		Heart,
		Terrain,
		TownAura,
		Portal,
		WaterSplash,
		WaterWake,
		DripWater,
		DripLava,
		Dust,
		MobSpell,
		MobSpellAmbient,
		MobSpellInstantaneous,
		Ink,
		Slime,
		RainSplash,
		VillagerAngry,
		VillagerHappy,
		EnchantmentTable,
		TrackingEmitter,
		Note,
		WitchSpell,
		Carrot,
		Unknown39,
		EndRod,
		DragonsBreath
	}

	public class Particle
	{
		public int Id { get; private set; }
		protected Level Level { get; set; }
		public Vector3 Position { get; set; }
		protected int Data { get; set; }

		protected Particle(ParticleType particleType, Level level) : this((int) particleType, level)
		{
		}

		public Particle(int id, Level level)
		{
			Id = id;
			Level = level;
		}

		public virtual void Spawn()
		{
			McpeLevelEvent particleEvent = McpeLevelEvent.CreateObject();
			particleEvent.eventId = (short) (0x4000 | Id);
			particleEvent.position = Position;
			particleEvent.data = Data;
			Level.RelayBroadcast(particleEvent);
		}

		public virtual void Spawn(Player[] players)
		{
			McpeLevelEvent particleEvent = McpeLevelEvent.CreateObject();
			particleEvent.eventId = (short) (0x4000 | Id);
			particleEvent.position = Position;
			particleEvent.data = Data;
			Level.RelayBroadcast(players, particleEvent);
		}
	}
}