using System;

namespace Plugin.IISControl
{
	internal static class Constant
	{
		public static class Adsi
		{
			/// <summary>Получить корень IIS'а</summary>
			public const String ServerArgs1 = "IIS://{0}/w3svc";
			/// <summary>Получить информацию о хосте</summary>
			public const String SiteArgs2 = "IIS://{0}/w3svc/{1}";
			/// <summary>Получить информацию о корне хоста</summary>
			public const String SiteRootArgs2 = "IIS://{0}/w3svc/{1}/ROOT";
			/// <summary>Получить информацию о виртуальной папке хоста</summary>
			public const String SiteVirtualDirArgs3 = "IIS://{0}/w3svc/{1}/ROOT/{2}";
		}
	}
}