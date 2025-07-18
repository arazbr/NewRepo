﻿using System;
using System.Collections.Generic;
using SCICT.NLP.TextProofing.SpellChecker;
using SCICT.Utility.Keyboard;

namespace VirastyarWordAddin.Configurations
{
    #region Delegates

    //public delegate void ShortcutChangedEventHandler(ShortcutChangedEventArgs e);
    public delegate void RefineAllSettingsChangedEventHandler(RefineAllSettingsChangedEventArgs e);
    public delegate void SpellCheckSettingsChangedEventHandler(SpellCheckSettingsChangedEventArgs e);
    public delegate void PreprocessSpellSettingsChangedEventHandler();

    #endregion

    #region EventArgs

    public class RefineAllSettingsChangedEventArgs : EventArgs
    {
        public AllCharactersRefinerSettings Settings { get; set; }
    }

    public class ShortcutChangedEventArgs : EventArgs
    {
        public string ShortcutName { get; set; }
        public Hotkey NewHotkey { get; set; }
        public Hotkey OldHotkey { get; set; }
        public bool Cancel { get; set; }
    }

    public class SpellCheckSettingsChangedEventArgs : EventArgs
    {
        public SpellCheckSettingsChangedEventArgs()
        {
            ErroneousUserDictionaries = new List<string>();
        }

        public SpellCheckerConfig Settings { get; set; }

        public string[] CustomDictionaries { get; set; }

        public bool CancelLoadingUserDictionary { get; set; }
        public List<string> ErroneousUserDictionaries  { get; set; }

        public bool PrespellCorrectPrefixes { get; set; }
        public bool PrespellCorrectSuffixes { get; set; }
        public bool PrespellCorrectBe { get; set; }

        public bool ReloadSpellCheckerEngine { get; set; }
    }

    #endregion
}
