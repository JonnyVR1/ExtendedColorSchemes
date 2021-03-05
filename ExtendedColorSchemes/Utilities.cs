﻿using System.Diagnostics;
using UnityEngine;

namespace ExtendedColorSchemes
{
    internal class Utilities
    {
        // Wrapper class so that BSIPA can save the color schemes
        internal class ExtendedColorScheme
        {
            public string _colorSchemeId = "Default";
            internal string _colorSchemeName = "Default";
            internal bool _isEditable = true;
            internal Color _saberAColor = Color.white;
            internal Color _saberBColor = Color.white;
            internal Color _environmentColor0 = Color.white;
            internal Color _environmentColor1 = Color.white;
            internal bool _supportsEnvironmentColorBoost = false;
            internal Color _environmentColor0Boost = Color.white;
            internal Color _environmentColor1Boost = Color.white;
            internal Color _obstaclesColor = Color.white;

            public ExtendedColorScheme() { }

            public ColorScheme ToColorScheme()
            {
                return new ColorScheme(
                    _colorSchemeId,
                    _colorSchemeName,
                    _isEditable,
                    _saberAColor,
                    _saberBColor,
                    _environmentColor0,
                    _environmentColor1,
                    _supportsEnvironmentColorBoost,
                    _environmentColor0Boost,
                    _environmentColor1Boost,
                    _obstaclesColor
                );
            }
        }

        public static ExtendedColorScheme ToExtendedColorScheme(ColorScheme colorScheme)
        {
            var extendedColorScheme = new ExtendedColorScheme
            {
                _colorSchemeId = colorScheme.colorSchemeId,
                _colorSchemeName = colorScheme.colorSchemeName,
                _isEditable = colorScheme.isEditable,
                _saberAColor = colorScheme.saberAColor,
                _saberBColor = colorScheme.saberBColor,
                _environmentColor0 = colorScheme.environmentColor0,
                _environmentColor1 = colorScheme.environmentColor1,
                _supportsEnvironmentColorBoost = colorScheme.supportsEnvironmentColorBoost,
                _environmentColor0Boost = colorScheme.environmentColor0Boost,
                _environmentColor1Boost = colorScheme.environmentColor1Boost,
                _obstaclesColor = colorScheme.obstaclesColor
            };

            return extendedColorScheme;
        }

        public static bool IsCallByMethod(string methodName, bool debug = false)
        {
            var stackTrace = new StackTrace();

            for (int i = 1; i < stackTrace.FrameCount; i++)
            {
                string callMethod = stackTrace.GetFrame(i).GetMethod().Name;

                if (debug)
                    Plugin.Log.Notice($"callMethod={callMethod}");

                if (callMethod == methodName)
                    return true;
            }

            return false;
        }
    }
}
