using System;
using UnityEngine;

public class Config
{
    public static readonly string app_Version = Application.version;


    // ProjectSetting -> Player -> OtherSetting -> Scripting Define Symbols에서 설정
    // 설정한 값대로 값이 변경됨
#if DEV
    public const ENVIRONMENT_TYPE environment_Type = ENVIRONMENT_TYPE.Dev;
#elif STAGE
    public const ENVIRONMENT_TYPE environment_Type = ENVIRONMENT_TYPE.Stage;
#elif LIVE
    public const ENVIRONMENT_TYPE environment_Type = ENVIRONMENT_TYPE.Live;
#else
    public const ENVIRONMENT_TYPE environment_Type = ENVIRONMENT_TYPE.Dev;
#endif

#if DEV
    public const string SERVER_API_URL = "https://localhost:7278/";
#elif STAGE
    public const string SERVER_API_URL = "https://localhost:7278/";
#elif LIVE
    public const string SERVER_API_URL = "https://localhost:7278/";
#else
    public const string SERVER_API_URL = "https://localhost:7278/";
#endif

#if UNITY_ANDRID
    public const OS_TYPE os_Type = OS_TYPE.Andriod;
#elif UNITY_IOS
    public const OS_TYPE os_Type = OS_TYPE.IOS;
#else
    public const OS_TYPE os_Type = OS_TYPE.Andriod;
#endif

}
