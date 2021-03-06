﻿using System.Diagnostics.Eventing.Reader;
using Harmony;
using UnityEngine;
using Verse;

namespace ExtendedStorage
{
    [HarmonyPatch(typeof(Thing), nameof(Thing.DrawAt))]
    internal class Thing_DrawAt
    {
        public static bool Prefix(Thing __instance, Vector3 drawLoc, bool flip)
        {
            return __instance.def.IsApparel ||
                   !(StorageUtility.GetStoringBuilding(__instance)?.OutputSlot == __instance.Position);
        }
    }

    [HarmonyPatch(typeof(Thing), nameof(Thing.Print))]
    internal class Thing_Print
    {
        public static bool Prefix(Thing __instance)
        {
            // no apparel check for now - print & section layers not used for those
            return !(StorageUtility.GetStoringBuilding(__instance)?.OutputSlot == __instance.Position);
        }
    }
}