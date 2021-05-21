using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UTIL
{
    public static int levelIndex = 2;
    public static int current_virus_count = 0;
    public static string PREFS_LVL_CLEARED = "lvl_cleared";
    public static string PREFS_SKIP_STORY = "story_cleared";

    public static string PREFS_IS_UNIQUE_ID = "unique_id";
    public static int MAX_LEVEL = 16;
    public static int lvlOffset = 1;

    public static bool canShowRewardAd = false;

    public static string adRemoved = "AppPurchased";
    public static int appPurchased  = 0;
}
