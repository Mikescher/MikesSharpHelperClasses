﻿using System;
using System.Diagnostics;
using System.Reflection;

namespace MSHC
{
	public static class LanguageUtils
	{
		private static Version _versionCache = null; 
		public static Version VERSION => _versionCache ?? (_versionCache=GetInformationalVersion());

		private static Version GetInformationalVersion()
		{
			try
			{
				var assembly = Assembly.GetExecutingAssembly();
				if (assembly==null || !assembly.FullName.StartsWith("LanguageUtils")) assembly = Assembly.GetCallingAssembly();
				if (assembly==null || !assembly.FullName.StartsWith("LanguageUtils")) assembly = Assembly.GetEntryAssembly();
				if (assembly==null || !assembly.FullName.StartsWith("LanguageUtils")) assembly = Assembly.GetAssembly(typeof(LanguageUtils));
				if (assembly==null || !assembly.FullName.StartsWith("LanguageUtils")) throw new Exception("Assembly not found");

				var loc = assembly.Location;
				var vi = FileVersionInfo.GetVersionInfo(loc);
				return new Version(vi.FileMajorPart, vi.FileMinorPart, vi.FileBuildPart, vi.FilePrivatePart);
			}
			catch (Exception)
			{
				return new Version(0, 0, 0, 0);
			}
		}
	}
}
