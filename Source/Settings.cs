﻿/*
 * User: Phomor
 * Date: 22.06.2018
 * Time: 18:18
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Reflection;
using Harmony;
using UnityEngine;
using Verse;
using RimWorld;

namespace CraftingQualityRebalanced
{
	public class Settings : Verse.ModSettings
	{
		public int minSkillPoor = 9;
		public int minSkillNormal = 13;
		public int minSkillGood = 17;
		public int minSkillExcellent = 21;
		public int minSkillMasterwork = 22;
		public int minSkillLegendary = 19;
		public int legendaryChance = 5;
		public bool supressMasterworkMessages = false;
		public bool supressLegendaryMessages = false;
		
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref minSkillPoor, "minskillpoor", 9);
			Scribe_Values.Look(ref minSkillNormal, "minskillnormal", 13);
			Scribe_Values.Look(ref minSkillGood, "minskillgood", 17);
			Scribe_Values.Look(ref minSkillExcellent, "minskillexcellent", 21);
			Scribe_Values.Look(ref minSkillMasterwork, "minskillmasterwork", 22);
			Scribe_Values.Look(ref minSkillLegendary, "minskilllegendary", 19);
			Scribe_Values.Look(ref legendaryChance, "legendarychance", 5);
			Scribe_Values.Look(ref supressMasterworkMessages, "supressmasterworkmessages", false);
			Scribe_Values.Look(ref supressLegendaryMessages, "supresslegendarymessages", false);
		}	
		
		public void DoWindowContents(Rect inRect)
		{
			{
				var list = new Listing_Standard();
				Color defaultColor = GUI.color;
				list.Begin(inRect);
				
				list.Label("CraftingQualityRebalanced.SliderWarning".Translate());
				
				list.Label("CraftingQualityRebalanced.MinimumSkillPoor".Translate() + minSkillPoor);
				minSkillPoor = (int) list.Slider(minSkillPoor, 0, minSkillNormal - 1);
			
				list.Label("CraftingQualityRebalanced.MinimumSkillNormal".Translate() + minSkillNormal);
				minSkillNormal = (int) list.Slider(minSkillNormal, minSkillPoor + 1, minSkillGood - 1);
			
				list.Label("CraftingQualityRebalanced.MinimumSkillGood".Translate() + minSkillGood);
				minSkillGood = (int) list.Slider(minSkillGood, minSkillNormal + 1, minSkillExcellent - 1);
				
				list.Label("CraftingQualityRebalanced.MinimumSkillExcellent".Translate() + minSkillExcellent);
				minSkillExcellent = (int) list.Slider(minSkillExcellent, minSkillGood + 1, minSkillMasterwork - 1);
				
				list.Label("CraftingQualityRebalanced.MinimumSkillMasterwork".Translate() + minSkillMasterwork);
				minSkillMasterwork = (int) list.Slider(minSkillMasterwork, 7, 22);
				
				list.Label("CraftingQualityRebalanced.MinimumSkillLegendary".Translate() + minSkillLegendary);
				minSkillLegendary = (int) list.Slider(minSkillLegendary, 0, 21);
				
				list.Label("CraftingQualityRebalanced.LegendaryChance".Translate() + legendaryChance + "%");
				legendaryChance = (int) list.Slider(legendaryChance, 0, 100);
				
				list.Label("CraftingQualityRebalanced.LegendaryChanceExplanation".Translate());
				
				list.CheckboxLabeledSelectable("CraftingQualityRebalanced.SupressMasterworkMessages".Translate(), ref supressMasterworkMessages, ref supressMasterworkMessages);
				
				list.CheckboxLabeledSelectable("CraftingQualityRebalanced.SupressLegendaryMessages".Translate(), ref supressLegendaryMessages, ref supressLegendaryMessages);
				
				if(minSkillExcellent >= minSkillMasterwork)
				{
					minSkillExcellent = minSkillMasterwork - 1;
				}
				if(minSkillGood >= minSkillExcellent)
				{
					minSkillGood = minSkillExcellent - 1;
				}
				if(minSkillNormal >= minSkillGood)
				{
					minSkillNormal = minSkillGood - 1;
				}
				if(minSkillPoor >= minSkillNormal)
				{
					minSkillPoor = minSkillNormal - 1;
				}
				
				list.End();
			}
		}
	}
}
